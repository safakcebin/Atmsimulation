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
    public class ParaGondermeController : Controller
    {


        public IActionResult Index(int hesapid)
        {

            return View(hesapid);
        }

        public IActionResult ParaGonder(int hesapid, int miktar,String iban,String aciklama)
        {



            try
            {
                var hesapIslemleri = new HesapIslemleri(hesapid);
                hesapIslemleri.HesabaParaGonder(iban, miktar, aciklama);
                return RedirectToAction("Tamam");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Hata",new { Hata = ex.Message});


            }
        }
        public IActionResult Tamam(String hata)
        {

            return View("Tamam");
        }

        public IActionResult Hata(String hata)
        {

            return View("Hata",hata);
        }



    }
}
