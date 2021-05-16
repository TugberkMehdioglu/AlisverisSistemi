using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KargoAPI.Models.Entities
{

    //Bir kargo siparişinde bilinmesini istediğimiz bütün bilgileri class'ımıza entegre ettik

    public class Shipper
    {
        public int ID { get; set; }
        public DateTime ShippedDate { get; set; }
        public DateTime? DeliveryDate { get; set; } //Bu bilgiyi kargocu kendi sisteminden veri yollaması için Nullable yaptık
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }

        public Shipper()
        {
            ShippedDate = DateTime.Now; //Instance alındığı gibi bu bilginin girilmesini sağladık
            Status = "Teslim Alındı"; //Ürün KargoAPI projesine düştüğünde, şubemiz ürünü teslim almış olduğu için bu bilgiyi instance alındığında girilmesini sağladık
        }

    }
}