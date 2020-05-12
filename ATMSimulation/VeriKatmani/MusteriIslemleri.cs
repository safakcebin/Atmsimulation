using ATMSimulation.Database;
using ATMSimulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATMSimulation.VeriKatmani
{
    public class MusteriIslemleri:BankaDatabase
    {
        int __musteriId = 0;
      
        public MusteriIslemleri(int _musteriId)
        {
            __musteriId = _musteriId;
        }
        public void Olustur(String _kullaniciAdi,String _sifre,String _ad,String _soyad)
        {
            musteriOlustur(_kullaniciAdi, _sifre, _ad, _soyad);
        }
        public Musteri Sorgula()
        {
            return musteriSorgula(__musteriId);
        }
        public static int girisYap(String _kullaniciAdi, String _sifre)
        {
            var veritabani = new BankaDatabase();

            var musteriId = veritabani.musteriIdSorgula(_kullaniciAdi, _sifre);
            if (musteriId == null)
            {
                throw new Exception("Kullanıcı Bilgileri Yanlış");
            }
            return musteriId.Value;
        }
        public void HesapAc(String _hesapAdi,String _iban)
        {
            hesapOlustur(__musteriId, _hesapAdi,_iban);
        }

        public Decimal BakiyeHesapla()
        {
            var musteriHesaplari=HesapIslemleri.Sorgula_musteriId(__musteriId);
            decimal toplamBakiye = 0;
            foreach(var hesap in musteriHesaplari)
            {
                var hesapIslemleri =new  HesapIslemleri(hesap.Id);
                toplamBakiye+= hesapIslemleri.BakiyeHesapla();
            }
            return toplamBakiye;
        }
        
    }
}
