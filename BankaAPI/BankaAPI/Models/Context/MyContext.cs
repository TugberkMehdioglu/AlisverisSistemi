using BankaAPI.DesignPatterns.StrategyPattern;
using BankaAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankaAPI.Models.Context
{
    //Database ile haberleşmeyi sağlayan class'ımız
    public class MyContext : DbContext //Database ile haberleşmemizi sağliyacak olan yapıları barındıran class'ımızdan miras aldık
    {
        public MyContext() : base("MyConnection") //WebConfig'deki MyConnection isimli connectionStrings xml tag'imizi bulmasını sağladık
        {
            Database.SetInitializer(new MyInit()); //MyInit class'ımızda yaptığımız ayarlamaları DB oluşturuluken tetikleyebilmek için burada instance'ını aldık
        }

        public DbSet<CardInfo> Cards { get; set; } //Database'de Cards isimli tablo açılmasını sağladık

    }
}