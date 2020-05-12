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
    public class GirisController : Controller
    {

      

        public IActionResult Index()
        {
          
            return View();
        }

        public IActionResult Giris(String kullaniciadi,String sifre)
        {
            try
            {
                var musteriId = MusteriIslemleri.girisYap(kullaniciadi, sifre);
                HttpContext.Session.SetInt32("musteriid", musteriId);
                return RedirectToAction("Index", "MusteriBilgileri");
            }
            catch (Exception ex)
            {

                return RedirectToAction("GirisHata");
            }
            
        }
        public IActionResult Cikis()
        {

            HttpContext.Session.Remove("musteriid");
            return RedirectToAction("index", "giris");
        }
        public IActionResult GirisHata()
        {
            return View("GirisHata","Kullanıcı Bilgileri Hatalı");

        }


    }
}
