﻿using Alisveris.Sistemi.MVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alisveris.Sistemi.MVC.VMClasses
{
    //View'a tek model yollicaz ama yollicağımız model'in içinde birden fazla model olması için ViewModel yöntemini kullanıyoruz
    public class AppUserVM
    {
        public AppUser AppUser { get; set; }
        public AppUserProfile Profile { get; set; }


    }
}