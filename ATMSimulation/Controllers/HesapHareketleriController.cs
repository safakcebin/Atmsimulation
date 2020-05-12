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
    public class HesapHareketleriController : Controller
    {

     

        public IActionResult Index(int hesapid)
        {
            var hesapIslemleri = new HesapIslemleri(hesapid);

            var hareketler = hesapIslemleri.HesapHareketleriSorgula();

            return View(hareketler);
        }

       
    


    }
}
