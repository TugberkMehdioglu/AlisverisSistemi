using KargoAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KargoAPI.Models.Context
{
    //Database ile haberleşmeyi sağlayan class'ımız

    public class MyContext : DbContext //Database ile haberleşmemizi sağliyacak olan yapıları barındıran class'ımızdan miras aldık
    {
        public MyContext() : base("MyConnection") //WebConfig'deki MyConnection isimli connectionStrings xml tag'imizi bulmasını sağladık
        {

        }

        public DbSet<Shipper> Shippers { get; set; } //Database'de Shippers isimli tablo açılmasını sağladık

    }
}