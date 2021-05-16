using BankaAPI.DesignPatterns.SingletonPattern;
using BankaAPI.DTOClasses;
using BankaAPI.Models.Context;
using BankaAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BankaAPI.Controllers
{
    public class PaymentController : ApiController
    {
        MyContext _db;
        public PaymentController()
        {
            _db = DBTool.DBInstance; //Singleton Pattern
        }

        [HttpPost]
        public IHttpActionResult ReceivePayment(PaymentDTO item)
        {
            CardInfo ci = _db.Cards.FirstOrDefault(x => x.CardNumber == item.CardNumber && x.SecurityNumber == item.SecurityNumber && x.CardUserName == item.CardUserName && x.CardExpiryYear == item.CardExpiryYear && x.CardExpiryMonth == item.CardExpiryMonth);

            if (ci != null) //Request ile gelen veri istediğimiz koşuldaysa if'e girer
            {
                if (ci.CardExpiryYear < DateTime.Now.Year)
                {
                    return BadRequest("Expired Card"); //Kart son kullanma tarihini doldurmuş
                }
                else if (ci.CardExpiryYear == DateTime.Now.Year)
                {
                    if (ci.CardExpiryMonth < DateTime.Now.Month)
                    {
                        return BadRequest("Expired Card"); //Kart son kullanma tarihini doldurmuş
                    }

                    if (ci.Balance >= item.ShoppingPrice)
                    {
                        SetBalance(item, ci); //Müşterinin kartından yapılan harcama kadar tutar düşüldü
                        return Ok(); //Olumlu status kodu yolladık request'e
                    }
                    else
                    {
                        return BadRequest("Balance Exceeded"); //Balance aşıldı
                    }
                }

                if (ci.Balance >= item.ShoppingPrice)
                {
                    SetBalance(item, ci); //Müşterinin kartından yapılan harcama kadar tutar düşüldü
                    return Ok(); //Olumlu status kodu yolladık request'e
                }
                else return BadRequest("Balance Exceeded"); //Balance aşıldı

            }
            else
            {
                return BadRequest("Card Not Found"); //Kart bulunamadı
            }
        }

        private void SetBalance(PaymentDTO item, CardInfo ci) //Karttan tutar düşme işlemini metoda aldık
        {
            ci.Balance -= item.ShoppingPrice;
            _db.SaveChanges();
        }
    }
}
