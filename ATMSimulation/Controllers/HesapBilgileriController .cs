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
    public class HesapBilgileriController : Controller
    {

        public IActionResult Index(int id)
        {

            var musteriId = HttpContext.Session.GetInt32("musteriid");
            if (musteriId == null)
            {
                return RedirectToAction("index","giris");
            }


            var hesap = HesapIslemleri.Sorgula_hesapId(id);
            var hesapIslemleri = new HesapIslemleri(id);

            var hesapBakiye = hesapIslemleri.BakiyeHesapla();
            ViewBag.Bakiye = hesapBakiye;
            return View(hesap);
        }

     
        public IActionResult Hata()
        {
            return View();

        }


    }
}
