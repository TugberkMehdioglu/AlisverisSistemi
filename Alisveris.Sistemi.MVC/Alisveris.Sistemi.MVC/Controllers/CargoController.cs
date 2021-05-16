using Alisveris.Sistemi.MVC.DesingPatterns.SingletonPattern;
using Alisveris.Sistemi.MVC.DTOClasses;
using Alisveris.Sistemi.MVC.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Alisveris.Sistemi.MVC.Controllers
{
    public class CargoController : Controller
    {
        MyContext _db;
        public CargoController()
        {
            _db = DBTool.DBInstance; //Singleton Pattern
        }

        [HttpGet]
        public ActionResult GetCargo()
        {
            return View(); //Action'a istek olduğu gibi View'unu döndürdük
        }


    }
}