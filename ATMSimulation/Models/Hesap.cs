using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATMSimulation.Models
{
    public class Hesap
    {
        public int Id { get; set; }

        public  int MusteriId{ get; set; }
        public String HesapAdi { get; set; }
        public String IBAN { get; set; }
    }
}
