using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alisveris.Sistemi.MVC.DTOClasses
{

    //BankaAPI projesi request için bizden bu tipte veri istediğinden bu class'ı oluşturduk
    public class PaymentDTO
    {
        public int ID { get; set; }
        public string CardUserName { get; set; }
        public string SecurityNumber { get; set; }
        public string CardNumber { get; set; }
        public int CardExpiryYear { get; set; }
        public int CardExpiryMonth { get; set; }
        public decimal ShoppingPrice { get; set; }

    }
}