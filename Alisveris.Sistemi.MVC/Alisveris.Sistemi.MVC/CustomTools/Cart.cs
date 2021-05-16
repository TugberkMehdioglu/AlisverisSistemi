using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alisveris.Sistemi.MVC.CustomTools
{
    //Sepet algoritmamız
    public class Cart
    {
        Dictionary<int, CartItem> _sepetUrunlerim; //Dictionary yapmamızın nedeni key'i verilince kendi içinde ekstradan aramada yapmadan direk value'sunu getirmesi
        public Cart()
        {
            _sepetUrunlerim = new Dictionary<int, CartItem>(); 
        }

        public List<CartItem> Sepetim 
        { 
            get //ReadOnly
            {
                return _sepetUrunlerim.Values.ToList(); //_sepetUrunlerim'in içindeki tüm Value'ları List'e çevirdik
            } 
        }

        public void SepeteEkle(CartItem item)
        {
            if (_sepetUrunlerim.ContainsKey(item.ID))
            {
                _sepetUrunlerim[item.ID].Amount += 1; //Ürün önceden sepete atılmışsa sadece Amount'u yükselsin
                return;
            }
            _sepetUrunlerim.Add(item.ID, item); //Ürün ilk defa sepete atılıyorsa ekleme yapılsın
        }

        public void SepettenSil(int id)
        {
            if (_sepetUrunlerim[id].Amount > 1)
            {
                _sepetUrunlerim[id].Amount -= 1; //Ürün sepetteyse sadece Amount'u eksilsin
                return;
            }
            _sepetUrunlerim.Remove(id); //Ürün sepette 1 adet ise ürün silinsin
        }

        public decimal TotalPrice 
        {
            get//ReadOnly
            {
                return _sepetUrunlerim.Values.Sum(x => x.SubTotal); //Bütün Value'lardaki SubTotal property'si toplansın
            }  
        }
    }
}