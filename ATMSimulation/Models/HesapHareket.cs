using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATMSimulation.Models
{
    public class HesapHareket
    {
        public int Id { get; set; }
        public enum HareketTipiEnum { ParaYatirma = 0, ParaCekme=1,ParaGonderme=2,ParaAlma=3}
        public HareketTipiEnum HareketTipi { get; set; }
        public Decimal Miktar { get; set; }
        public int? IliskiliHesap { get; set; }
        public String Aciklama { get; set; }
        public DateTime Zaman { get; set; }
    }
}
