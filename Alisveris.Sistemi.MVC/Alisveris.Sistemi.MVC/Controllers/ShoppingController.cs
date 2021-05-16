using Alisveris.Sistemi.MVC.CustomTools;
using Alisveris.Sistemi.MVC.DesingPatterns.SingletonPattern;
using Alisveris.Sistemi.MVC.DTOClasses;
using Alisveris.Sistemi.MVC.Models.Context;
using Alisveris.Sistemi.MVC.Models.Entities;
using Alisveris.Sistemi.MVC.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Alisveris.Sistemi.MVC.Controllers
{
    public class ShoppingController : Controller
    {
        MyContext _db;
        public ShoppingController()
        {
            _db = DBTool.DBInstance; //Singleton Pattern
        }
        public ActionResult ProductList()
        {
            ProductVM pvm = new ProductVM
            {
                Products = _db.Products.ToList() //Object initializer ile Products property'sine DB'deki Products'ları atadık
            };

            return View(pvm); //View'a model yolladık
        }

        public ActionResult SepeteEkle(int id)
        {
            Cart c = Session["scart"] == null ? new Cart() : Session["scart"] as Cart; //Önceden kart oluştuysa ondan devam et yoksa yeni yarat

            Product eklenecekUrun = _db.Products.Find(id); //Sepetteki ürünü DB'den bul

            CartItem ci = new CartItem() //Object initializer ile atamaları yap
            {
                ID = eklenecekUrun.ID,
                Name = eklenecekUrun.Name,
                Price = eklenecekUrun.UnitPrice
            };

            c.SepeteEkle(ci); 
            Session["scart"] = c;

            return RedirectToAction("ProductList"); //View'a yönlendir
        }

        public ActionResult SepetSayfasi()
        {
            if (Session["scart"] != null)
            {
                Cart c = Session["scart"] as Cart;
                return View(c); //sepette ürün varsa sepeti göster
            }
            ViewBag.Message = "Sepetinizde ürün bulunmamaktadır";
            return View(); //Uyarı verip kendi View'una yönlendir
        }

        public ActionResult SepettenCikar(int id)
        {
            if (Session["scart"] != null)
            {
                Cart c = Session["scart"] as Cart;
                c.SepettenSil(id); //Sepet boş değilse ürünü sepetten çıkar

                if ((Session["scart"] as Cart).Sepetim.Count == 0)
                {
                    Session.Remove("scart");
                    TempData["silindi"] = "Sepetiniz boşaltılmıştır";
                    return RedirectToAction("ProductList"); //sepette ürün kalmadıysa komple sepeti silip mesajla birlikte belirtilen view'a yönlendir
                }

                return RedirectToAction("SepetSayfasi");
            }
            return RedirectToAction("SepetSayfasi");
        }

        public ActionResult SiparisiOnayla()
        {
            if (Session["scart"] == null) return RedirectToAction("ProductList");

            if (Session["member"] != null) return View(); //Kullanıcı üye ise onaylama sayfasına girebilir

            else
            {
                TempData["hata"] = "Satın almak için üye olmalısınız";
                return RedirectToAction("Register", "Home"); //Kullanıcı üye değilse belirtilen controller'daki view'a mesaj ile yönlendir
            }
        }


        [HttpPost]
        public ActionResult SiparisiOnayla(PaymentDTO paymentDTO)
        {
            Cart sepet = Session["scart"] as Cart; //Unboxing yapıp atama gerçekleştirdik

            AppUser au = Session["member"] as AppUser; //Unboxing yapıp atama gerçekleştirdik

            paymentDTO.ShoppingPrice = sepet.TotalPrice;



            using (HttpClient client = new HttpClient()) //BackEnd tarafında API ile haberleşmek için client oluşturduk
            {
                client.BaseAddress = new Uri("https://localhost:44309/api/"); //API adresi tanımlaması
                Task<HttpResponseMessage> postTask = client.PostAsJsonAsync("Payment/ReceivePayment", paymentDTO); //Post yöntemiyle Json tipinde veri yolladık
                

                HttpResponseMessage sonuc;

                try
                {
                    sonuc = postTask.Result; //API'dan dönen mesajları yakaladık
                }
                catch (Exception)
                {

                    TempData["hata"] = "Banka bağlantıyı reddetti";
                    return RedirectToAction("ProductList"); //API'dan kaynaklı sorun olduğunda mesajla birlikte belirtilen view'a yönlendirdik
                }

                bool result;

                if (sonuc.IsSuccessStatusCode) result = true;
                else result = false;

                if (result) //Başarılı status kodu dönerse
                {

                    Order o = new Order()
                    {
                        AppUserID = au.ID
                    };

                    _db.Orders.Add(o);
                    _db.SaveChanges(); //Çoka-Çok tabloya ekleme yapmadan önce Order'ı DB'ye kaydetmeliyizki kendi ID'si oluşsun ve Çoka-Çok tabloya ekleme yapabilsin

                    foreach (CartItem item in sepet.Sepetim)
                    {
                        OrderDetail od = new OrderDetail()
                        {
                            OrderID = o.ID,
                            ProductID = item.ID,
                            Amount = item.Amount,
                            UnitPrice = item.Price
                        };

                        Product p = _db.Products.Find(item.ID);
                        p.Amount -= item.Amount; //Sipariş edilen ürünün Amount'ı sipariş edildiği miktarda düşsün

                        _db.OrderDetails.Add(od);
                        _db.SaveChanges();
                    }

                    CargoDTO cDTO = new CargoDTO //Object initializer ile yollicağımız kargo bilgilerini kullanıcı profilinden çektik
                    {
                        FirstName = au.Profile.FirstName,
                        LastName = au.Profile.LastName,
                        Country = au.Profile.Country,
                        City = au.Profile.City,
                        Address = au.Profile.Address,
                        Email = au.Profile.Email,
                        Phone = au.Profile.Phone
                    };

                    using (HttpClient clientCargo=new HttpClient()) //BackEnd tarafında API ile haberleşmek için client oluşturduk
                    {
                        clientCargo.BaseAddress = new Uri("https://localhost:44351/api/"); //API adresi tanımlaması

                        Task<HttpResponseMessage> postTaskCargo = clientCargo.PostAsJsonAsync("Home/CargoOrder", cDTO); //Post yöntemiyle Json tipinde veri yolladık

                        HttpResponseMessage sonucKargo;

                        try
                        {
                            sonucKargo = postTaskCargo.Result; //API'dan dönen mesajları yakaladık
                        }
                        catch (Exception)
                        {

                            TempData["hata"] = "Kargo şirketi bağlantıyı reddetti";
                            return RedirectToAction("ProductList"); //API'dan kaynaklı sorun olduğunda mesajla birlikte belirtilen view'a yönlendirdik
                        }

                    }

                    TempData["basarili"] = "Siparişiniz bize ulaşmıştır";
                    return RedirectToAction("ProductList");
                }
                else
                {
                    TempData["hata"] = "Ödemeniz ile ilgili bir sorun oluştu, lütfen bankanızla iletişime geçiniz";
                    return RedirectToAction("ProductList");
                }
            }
        }
    }
}