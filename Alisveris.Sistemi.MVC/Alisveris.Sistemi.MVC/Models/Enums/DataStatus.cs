using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alisveris.Sistemi.MVC.Models.Enums
{
    //Bu tipte olucak verilerin sadece belirtilen verileri alabilmesi için enum kullandık
    public enum DataStatus
    {
        Inserted = 1, Updated =2, Deleted =3
    }
}