using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alisveris.Sistemi.MVC.AuthenticationClasses
{
    //Belirtilen yetkiye sahip olmayan ziyaretçilerin belli işlemleri yapmasını istemediğimiz durumlar için Authentication işlemi yapıyoruz
    public class MemberAuthentication : AuthorizeAttribute //Attribute olabilmesi için bu class'tan miras aldık
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext) //Attribute olarak verildiğinde, bu ezdiğimiz metoda düşer
        {
            if (httpContext.Session["member"] != null)
            {
                return true; //Belirtilen koşul sağlandıysa true döndürerek girişe izin verir
            }

            httpContext.Response.Redirect("/Home/Login"); //Koşula uygun değilse belirttiğimiz action'a yönlendirdik
            return false; //False çevirerek girişe izin vermedik
        }
    }
}