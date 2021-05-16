using Alisveris.Sistemi.MVC.DesingPatterns.StrategyPattern;
using Alisveris.Sistemi.MVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Alisveris.Sistemi.MVC.Models.Context
{
    //Database ile haberleşmeyi sağlayan class'ımız

    public class MyContext : DbContext //Database ile haberleşmemizi sağliyacak olan yapıları barındıran class'ımızdan miras aldık
    {
        public MyContext() : base("MyConnection") //WebConfig'deki MyConnection isimli connectionStrings xml tag'imizi bulmasını sağladık
        {
            Database.SetInitializer(new MyInit()); //MyInit class'ımızda yaptığımız ayarlamaları DB oluşturuluken tetikleyebilmek için burada instance'ını aldık
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) //Bu metodu ezerek, içine DB'de tablo olacak class'larımızın DB'ye giderken yapılmasını istediğimiz ayarlamaları yapmamızı sağlıyor
        {
            modelBuilder.Entity<AppUserProfile>().HasRequired(x => x.AppUser).WithOptional(x => x.Profile); //Çoka-Çok tablomuza veri girişinde sorun yaşamamız için AppUser'ı zorunlu, Profile'ı null geçilebilir yaptık


            modelBuilder.Entity<OrderDetail>().Ignore(x => x.ID); //OrderDetail'daki ID property'sini DB'ye yollamadık çünkü Çoka-Çok tablonun kendine has ID'si olmaz
            modelBuilder.Entity<OrderDetail>().HasKey(x => new //İçerdiği property'lerle Composite Key oluşturduk
            {
                x.OrderID,
                x.ProductID
            });

            modelBuilder.Entity<AppUserProfile>().Ignore(x => x.FullName); //DB'ye FullName property'sini yollamadık

            modelBuilder.Entity<Order>().Ignore(x => x.CreatedDate); //DB'ye CreatedDate property'sini yollamadık
        }

        public DbSet<AppUser> AppUsers { get; set; } //Database'de AppUsers isimli tablo açılmasını sağladık
        public DbSet<AppUserProfile> Profiles { get; set; } //Database'de Profiles isimli tablo açılmasını sağladık
        public DbSet<Order> Orders { get; set; } //Database'de Orders isimli tablo açılmasını sağladık
        public DbSet<OrderDetail> OrderDetails { get; set; } //Database'de OrderDetails isimli tablo açılmasını sağladık
        public DbSet<Product> Products { get; set; } //Database'de Products isimli tablo açılmasını sağladık

    }
}