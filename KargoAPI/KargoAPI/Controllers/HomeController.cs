using KargoAPI.DesingPattern.SingletonPattern;
using KargoAPI.DTOClasses;
using KargoAPI.Models.Context;
using KargoAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KargoAPI.Controllers
{
    public class HomeController : ApiController
    {
        MyContext _db;
        public HomeController()
        {
            _db = DBTool.DBInstance; //Paternimizi bu controller'dan her instance alındığında kullandırtmış olduk
        }


        //Bu action'ımız IHttpActionResult döndürüyor çünkü; istediğimiz koşullar sağlanmazsa BadRequest döndürmek istiyoruz
        //Action'ımız Post tipinde çünkü; gelen her request DB'mize bilgi kaydetmek istiyor.
        [HttpPost]
        public IHttpActionResult CargoOrder(CargoDTO item) //Bu Action'ımıza gelen request'lerden CargoDTO tipinde veri istemiş olduk
        {
            if (item.Address != null && item.City != null && item.Country != null && item.FirstName != null && item.LastName != null && item.Phone != null)
            {
                Shipper s = new Shipper
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Country = item.Country,
                    City = item.City,
                    Address = item.Address,
                    Phone = item.Phone,
                    Email = item.Email
                };
                _db.Shippers.Add(s);
                _db.SaveChanges();
                return Ok(); //Gelen veri istediğimiz koşuldaysa CargoDTO tipindeki veriyi Shipper tipine çevirip, DB'ye kaydedip başarılı durum kodu yolluyoruz request'e
            }
            else return BadRequest("Mandatory fields cannot be null");
        }


        //Bu action'ımız CargoDTO tipinde ve protokolüde Get tipinde çünkü gelen request'teki veride bulunan id'ye sahip olan veriyi görüntülemek istiyor
        [HttpGet]
        public CargoDTO GetCargo(int id)
        {
            if (id > 0)
            {
                return _db.Shippers.Where(x => x.ID == id).Select(x => new CargoDTO //DB'deki Shippers tablomuzdaki veriyi CargoDTO tipine çeviriyoruz
                {
                    ID = x.ID,
                    ShippedDate = x.ShippedDate,
                    Status = x.Status,
                    DeliveryDate = x.DeliveryDate
                }).FirstOrDefault(); //Istenen veri varsa direk veriyi yolluyoruz yoksa default değer yolluyoruz
            }
            else
            {
                return null;
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateStatus(CargoDTO item)
        {
            if (item.ID > 0 && item.Status != null)
            {
                Shipper s = _db.Shippers.Where(x => x.ID == item.ID).FirstOrDefault();

                if (s != null)
                {
                    s.Status = item.Status;

                    if (item.Status == "Teslim edildi")
                    {
                        s.DeliveryDate = DateTime.Now;
                    }

                    _db.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("CargoNo can not found");
                }
            }
            else
            {
                return BadRequest("Mandatory fields cannot be null");
            }
        }
    }
}
