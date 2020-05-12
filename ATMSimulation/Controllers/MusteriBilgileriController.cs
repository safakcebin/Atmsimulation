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
    public class MusteriBilgileriController : Controller
    {

        

        public IActionResult Index()
        {

            var musteriId=HttpContext.Session.GetInt32("musteriid");
            if (musteriId == null)
            {
                return RedirectToAction("index","giris");
            }

            var musteriIslemleri = new MusteriIslemleri(musteriId.Value);
            var musteriModel = musteriIslemleri.Sorgula();
            var musteriBakiye = musteriIslemleri.BakiyeHesapla();
            ViewBag.Bakiye = musteriBakiye;
            Dictionary<Hesap, Decimal> hesapBakiye = new Dictionary<Hesap, Decimal>();
            var hesapList= HesapIslemleri.Sorgula_musteriId(musteriId.Value);
            foreach(var item in hesapList)
            {
                var islem=new HesapIslemleri(item.Id);

                hesapBakiye.Add(item, islem.BakiyeHesapla());
            }
            
            ViewBag.HesapListesi = hesapBakiye;

            return View(musteriModel); 
           
            
        }

       
        public IActionResult Hata()
        {
            return View();

        }


    }
}
