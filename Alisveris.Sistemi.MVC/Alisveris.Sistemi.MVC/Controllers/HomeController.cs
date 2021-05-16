using Alisveris.Sistemi.MVC.DesingPatterns.SingletonPattern;
using Alisveris.Sistemi.MVC.Models.Context;
using Alisveris.Sistemi.MVC.Models.Entities;
using Alisveris.Sistemi.MVC.Models.Enums;
using Alisveris.Sistemi.MVC.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alisveris.Sistemi.MVC.Controllers
{
    public class HomeController : Controller
    {
        MyContext _db;
        public HomeController()
        {
            _db = DBTool.DBInstance; //Singleton Pattern
        }

        //MVC'de protoköl belirtilmezse otomatik Get algılanır
        public ActionResult Register()
        {
            List<string> countries = new List<string>
            {
                "Amerika", "Lübnan", "Türkiye", "Azerbeycan", "Hollanda", "Rusya", "Ukrayna"
            };

            TempData["ulkeler"] = countries; //View'a model yolladık

            return View();
        }

        [HttpPost]
        public ActionResult Register(AppUser appUser) //View'daki modelin içindeki AppUser property'sini aldık
        {
            if (!ModelState.IsValid) return View();//Validation hatası varsa geri View'a yolla
            _db.AppUsers.Add(appUser);
            _db.SaveChanges(); //Girilen veriyi DB'ye kaydet
            TempData["giris"] = "Üyelik işleminiz başarıyla gerçekleşmiştir, lütfen giriş yapınız"; 
            return RedirectToAction("Login"); //Belirlenen action'a yönlendir
        }

        public ActionResult Login()
        {
            return View(); //Action'a istek olduğu gibi View'unu döndürdük
        }

        [HttpPost]
        public ActionResult Login(AppUser appUser) //View'daki modelin içindeki AppUser property'sini aldık
        {
            AppUser ap = _db.AppUsers.FirstOrDefault(x => x.UserName == appUser.UserName && x.Password == appUser.Password);

            if (ap != null)
            {
                Session["member"] = ap; //Kullanıcıyı session'a ata
                TempData["giris"] = $"Hoşgeldin {ap.Profile.FullName}"; //Hoşgeldin mesajı
                return RedirectToAction("ProductList", "Shopping"); //İstenilen koşullar gerçekleştiğinde belirtilen controller'daki action'a yönlendir 
            }
            else
            {
                //İstenilen koşullar sağlanmazsa View'a mesaj vererek yönlendir
                ViewBag.Message = "Kullanıcı adı veya şifre hatalı";
                return View();
            }           
        }

       
        public ActionResult Exit()
        {
            //Action'a istek olduğunda session silinip, belirtilen view'a yönlendirilir
                Session.Remove("member");
                return RedirectToAction("ProductList", "Shopping");
        }
    }
}