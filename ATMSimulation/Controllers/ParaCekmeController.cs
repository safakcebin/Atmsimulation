using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ATMSimulation.Models;
using ATMSimulation.Database;
using ATMSimulation.VeriKatmani;
using Microsoft.AspNetCore.Http;

namespace ATMSimulation.Controllers
{
    public class ParaCekmeController : Controller
    {

       
        public IActionResult Index(int hesapid)
        {
            
            return View(hesapid);
        }

        public IActionResult ParaCek(int hesapid,int miktar)
        {



            var hesapIslemleri = new HesapIslemleri(hesapid);

            hesapIslemleri.ParaCek(miktar);
            return RedirectToAction("Tamam");
        }


        public IActionResult Tamam()
        {

            return View();
        }


    }
}
