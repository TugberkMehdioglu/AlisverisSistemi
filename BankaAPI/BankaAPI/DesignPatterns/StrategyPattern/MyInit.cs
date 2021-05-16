using BankaAPI.Models.Context;
using BankaAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankaAPI.DesignPatterns.StrategyPattern
{
    public class MyInit : CreateDatabaseIfNotExists<MyContext> //Bu Database önceden kurulmadıysa kur komutu vermek için bu class'tan miras aldırttık. Bu generic sınıfımıza MyContext tipinde işlem yaptırttık
    {
        protected override void Seed(MyContext context) //Ezdiğimiz bu metod Database'in ilk kurulumunda bu verileride birlikte oluşturmamızı sağlayan komutu içerir
        {
            CardInfo ci = new CardInfo(); //Object İnitializer yöntemiyle değişkenimizin property'lerine veri ekledik
            ci.CardUserName = "Tuğberk Mehdioğlu";
            ci.CardNumber = "1111 1111 1111 1111";
            ci.CardExpiryYear = 2025;
            ci.CardExpiryMonth = 12;
            ci.Limit = 40000;
            ci.Balance = 40000;
            ci.SecurityNumber = "333";

            context.Cards.Add(ci); //ci verisini Cards tablosuna ekle
            context.SaveChanges(); //DB'de yapılmak istenen değişiklikleri DB'de kaydet
        }
    }
}