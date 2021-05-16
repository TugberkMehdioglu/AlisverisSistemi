using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KargoAPI.DTOClasses
{

    //API ile haberleşmek isteyen sitelere ham veriyi değil DTO class'ında belirttiğimiz bilgileri göstermek ve bu tipte veri almak için CargoDTO Class'ını kullanıyoruz.

    public class CargoDTO
    {
        public int ID { get; set; }
        public string FirstName { get; set; } //Alisveris.Sistemi.MVC projesinden bu bilgiyi istemek için kullanıyoruz
        public string LastName { get; set; } //Alisveris.Sistemi.MVC projesinden bu bilgiyi istemek için kullanıyoruz
        public string Country { get; set; } //Alisveris.Sistemi.MVC projesinden bu bilgiyi istemek için kullanıyoruz
        public string City { get; set; } //Alisveris.Sistemi.MVC projesinden bu bilgiyi istemek için kullanıyoruz
        public string Address { get; set; } //Alisveris.Sistemi.MVC projesinden bu bilgiyi istemek için kullanıyoruz
        public string Phone { get; set; } //Alisveris.Sistemi.MVC projesinden bu bilgiyi istemek için kullanıyoruz
        public string Email { get; set; } //Alisveris.Sistemi.MVC projesinden bu bilgiyi istemek için kullanıyoruz
        public DateTime? ShippedDate { get; set; } //KargoAPI projesinde bu bilgiyi göstermek için kullanıyoruz.
        public string Status { get; set; } //KargoAPI projesinde bu bilgiyi göstermek için kullanıyoruz.
        public DateTime? DeliveryDate { get; set; } //KargoAPI projesinde bu bilgiyi göstermek için kullanıyoruz.


    }
}