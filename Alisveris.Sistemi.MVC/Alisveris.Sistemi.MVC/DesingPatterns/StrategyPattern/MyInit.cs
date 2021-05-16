using Alisveris.Sistemi.MVC.Models.Context;
using Alisveris.Sistemi.MVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Alisveris.Sistemi.MVC.DesingPatterns.StrategyPattern
{
    public class MyInit : CreateDatabaseIfNotExists<MyContext> //Bu Database önceden kurulmadıysa kur komutu vermek için bu class'tan miras aldırttık. Bu generic sınıfımıza MyContext tipinde işlem yaptırttık
    {
        protected override void Seed(MyContext context) //Ezdiğimiz bu metod Database'in ilk kurulumunda bu verileride birlikte oluşturmamızı sağlayan komutu içerir
        {
            Product p1 = new Product //Object İnitializer yöntemiyle değişkenimizin property'lerine veri ekledik
            {
                Name = "Bardak",
                Amount = 365,
                UnitPrice = 12
            };

            Product p2 = new Product //Object İnitializer yöntemiyle değişkenimizin property'lerine veri ekledik
            {
                Name = "Kalem",
                Amount = 781,
                UnitPrice = 8
            };

            Product p3 = new Product //Object İnitializer yöntemiyle değişkenimizin property'lerine veri ekledik
            {
                Name = "Silgi",
                Amount = 624,
                UnitPrice = 4
            };

            Product p4 = new Product //Object İnitializer yöntemiyle değişkenimizin property'lerine veri ekledik
            {
                Name = "Cüzdan",
                Amount = 64,
                UnitPrice = 564
            };

            Product p5 = new Product //Object İnitializer yöntemiyle değişkenimizin property'lerine veri ekledik
            {
                Name = "El kremi",
                Amount = 34,
                UnitPrice = 36
            };

            context.Products.Add(p1); //p1 verisini Products tablosuna ekle
            context.Products.Add(p2); //p2 verisini Products tablosuna ekle
            context.Products.Add(p3); //p3 verisini Products tablosuna ekle
            context.Products.Add(p4); //p4 verisini Products tablosuna ekle
            context.Products.Add(p5); //p5 verisini Products tablosuna ekle
            context.SaveChanges(); //DB'de yapılmak istenen değişiklikleri DB'de kaydet
        }
    }
}