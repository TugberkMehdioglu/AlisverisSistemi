using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alisveris.Sistemi.MVC.CustomTools
{
    //Sepette sadece Ürün'ün istediğimiz özelliklerini göstermek istediğimizdan bu class'ı açtık
    public class CartItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public decimal SubTotal { get { return Amount * Price; } } //ReadOnly, Amount ve Price'ın çarpımlarını getiriyor
        public CartItem()
        {
            ++Amount; //Amount değer tipi olduğundan 0'dan başlar, Sepete ürün atılınca 1'den başlaması için instance alındığı gibi Amount'u 1 arttırdık
        }
    }
}