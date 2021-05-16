using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alisveris.Sistemi.MVC.Models.Entities
{

    //Çoka-Çok tablomuz

    public class OrderDetail : BaseEntity
    {
        public int OrderID { get; set; } //İlişkili olduğu class'ların ID'sini gösterttik
        public int ProductID { get; set; } //İlişkili olduğu class'ların ID'sini gösterttik
        public decimal UnitPrice { get; set; }
        public int Amount { get; set; }

        //Relational Properties
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

    }
}