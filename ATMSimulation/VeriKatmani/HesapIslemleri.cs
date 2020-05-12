using ATMSimulation.Database;
using ATMSimulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATMSimulation.VeriKatmani
{
    public class HesapIslemleri:BankaDatabase
    {
        int __hesapId=0;
        public HesapIslemleri(int _hesapId)
        {
            __hesapId = _hesapId;
        }
        public static void Olustur(int _musteriId,String _hesapAdi,String _IBAN)
        {
            var veritabani = new BankaDatabase();

            veritabani.hesapOlustur(_musteriId, _hesapAdi, _IBAN);
        }
        public static List<Hesap> Sorgula_musteriId(int _musteriId)
        {
            var veritabani = new BankaDatabase();
            return veritabani.hesapSorgula_MusteriId(_musteriId);
        }
        public static Hesap Sorgula_hesapId(int _hesapId)
        {
            var veritabani = new BankaDatabase();
            return veritabani.hesapSorgula_Id(_hesapId);
        }
        public List<HesapHareket> HesapHareketleriSorgula()
        {
            return hesapHareketSorgula_HesapId(__hesapId);
        }
        public Decimal BakiyeHesapla()
        {
            var hesapHareketleri = HesapHareketleriSorgula();
            Decimal toplamBakiye = 0;
            foreach(var item in hesapHareketleri)
            {
                toplamBakiye += item.Miktar;

            }
            return toplamBakiye;
        }
        public void ParaYatir(int _miktar)
        {
            hesapHareketOlustur(__hesapId, HesapHareket.HareketTipiEnum.ParaYatirma, _miktar, 0, "");
        }
        public void ParaCek( int _miktar)
        {
            hesapHareketOlustur(__hesapId, HesapHareket.HareketTipiEnum.ParaCekme, -1 * _miktar, 0, "");
        }
        public void HesabaParaGonder( String hedefHesapIban, int _miktar, String _aciklama)
        {
            var hedefHesap = hesapSorgula_Iban(hedefHesapIban);
            if (hedefHesap == null)
            {
                throw new Exception("bu iban no ile ilişkili hesap bulunamadı");
            }
            hesapHareketOlustur(__hesapId, HesapHareket.HareketTipiEnum.ParaGonderme, -1 * _miktar, hedefHesap.Id, _aciklama);
            hesapHareketOlustur(hedefHesap.Id, HesapHareket.HareketTipiEnum.ParaAlma, _miktar, __hesapId, _aciklama);

        }

    }
}
