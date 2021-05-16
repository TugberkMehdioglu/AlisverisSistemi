using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankaAPI.DesignPatterns.SingletonPattern
{
    using BankaAPI.Models.Context; //MyContext class'ımızı tanıyabilmesi için, namespace tanımlaması yaptık

    //Bu paternimizin amacı; eğer database'den instance alınmış ise tekrardan işlem yapılacağı zaman yeniden instance alınıp bütün database'i tetiklemektense önceden alınmış olunan instance'dan devam edilmesini sağlamaktır

    //Sadece class'ımız static değildir çünkü; static class'lar member instance barındıramaz, DBInstance property'mizde de koşul sağlanmışsa database'in instance'ını aldırtıyoruz
    public class DBTool
    {

        DBTool() { } //Ctor'ı private yaparak, bu class'tan instance alınmasını engelledik

        static MyContext _dbInstance;

        public static MyContext DBInstance
        {
            get
            {
                if (_dbInstance is null)
                {
                    _dbInstance = new MyContext();
                }

                return _dbInstance;

            }
        }


    }
}