using Alisveris.Sistemi.MVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alisveris.Sistemi.MVC.Models.Entities
{

    //Bu class'ımız diğer class'lara miras vereceği için, bütün class'lardaki ortak property'leri içeriyor
    public abstract class BaseEntity //Abstract yapmamızın nedeni bu class'ın instance vermesini değil sadece miras vermesini istediğimizden
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }
        public BaseEntity()
        {
            CreatedDate = DateTime.Now; //Miras alınan class'tan instance alındığı gibi bu property'e bu verinin girilmesini istedik
            Status = DataStatus.Inserted; //Miras alınan class'tan instance alındığı gibi bu property'e bu verinin girilmesini istedik
        }

    }
}