using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alisveris.Sistemi.MVC.Models.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }

        //Relational Properties
        public virtual List<OrderDetail> OrderDetails { get; set; }


    }
}