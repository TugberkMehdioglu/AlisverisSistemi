using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankaAPI.Models.Entities
{
    //Bankada müşteriyle ilgili sahip olmak istediğimiz bilgileri property olarak atadık
    public class CardInfo
    {
        public int ID { get; set; }
        public string CardUserName { get; set; }
        public string SecurityNumber { get; set; }
        public string CardNumber { get; set; }
        public int CardExpiryMonth { get; set; }
        public int CardExpiryYear { get; set; }
        public decimal Limit { get; set; }
        public decimal Balance { get; set; }
    }
}