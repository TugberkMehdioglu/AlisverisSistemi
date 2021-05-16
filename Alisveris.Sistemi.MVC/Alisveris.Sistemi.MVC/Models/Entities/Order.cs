using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alisveris.Sistemi.MVC.Models.Entities
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public int? AppUserID { get; set; } //Bire-Çok ilişkimizde, bu tablomuzda ilişkili olduğu tablonun ID'sini gösterdik


        public Order()
        {
            OrderDate = DateTime.Now; //Bu class'tan instance alındığında OrderDate'e veri girişi sağladık
        }

        //Relational Properties
        public virtual AppUser AppUser { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }


    }
}