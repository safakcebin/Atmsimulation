using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using ATMSimulation.Models;
using Microsoft.Extensions.Configuration;

namespace ATMSimulation.Database
{
    public class BankaDatabase
    {
        const string bankaveritabanistring = "Server=(localdb)\\MSSQLLocalDB;Database=banka;Trusted_Connection=True;MultipleActiveResultSets=true";
        protected SqlConnection baglantiOlustur()
        {

            return new SqlConnection(bankaveritabanistring);
        }

        public int? musteriIdSorgula(String _kullaniciAdi, String _sifre)
        {
            using (var conn = baglantiOlustur())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM musteri WHERE kullanici_adi = @kadi", conn);
                cmd.Parameters.Add(new SqlParameter("@kadi", _kullaniciAdi));
                System.Data.DataTable dt = new DataTable();
                System.Data.SqlClient.SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    var kullaniciVeri = dt.Rows[0];
                    var sifre = kullaniciVeri["sifre"].ToString();
                    if (sifre == _sifre)
                    {
                        return Convert.ToInt32(kullaniciVeri["Id"]);
                    }

                }
                return null;
            }


        }
        public void musteriOlustur(String _kullaniciAdi, String _sifre, String _adi, String _soyadi)
        {
            using (var conn = baglantiOlustur())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO musteri(kullanici_adi,sifre,adi,soyadi) VALUES(@kadi,@sifre,@adi,@soyadi", conn);
                cmd.Parameters.Add(new SqlParameter("@kadi", _kullaniciAdi));
                cmd.Parameters.Add(new SqlParameter("@sifre", _sifre));
                cmd.Parameters.Add(new SqlParameter("@adi", _adi));
                cmd.Parameters.Add(new SqlParameter("@soyadi", _soyadi));
                cmd.ExecuteNonQuery();
            }


        }
        public void hesapOlustur(int _musteriId, String _hesapAdi, String _iban)
        {
            using (var conn = baglantiOlustur())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO hesap(musteri_id,hesap_adi,iban) WHERE VALUES(@musteri_id,@hesap_adi,@iban)", conn);
                cmd.Parameters.Add(new SqlParameter("@musteri_id", _musteriId));
                cmd.Parameters.Add(new SqlParameter("@hesap_adi", _hesapAdi));
                cmd.Parameters.Add(new SqlParameter("@iban", _iban));

                cmd.ExecuteNonQuery();
            }


        }
        public void hesapHareketOlustur(int _hesapId, HesapHareket.HareketTipiEnum _hareketTipi, decimal _Miktar, int? _iliskiliHesapId, String Aciklama)
        {
            using (var conn = baglantiOlustur())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO hesap_hareket(hesap_id,hareket_tipi,miktar,iliskili_hesap_id,aciklama,zaman)  VALUES(@hesap_id,@hareket_tipi,@miktar,@iliskili_hesap_id,@aciklama,@zaman)", conn);
                cmd.Parameters.Add(new SqlParameter("@hesap_id", _hesapId));
                cmd.Parameters.Add(new SqlParameter("@hareket_tipi", _hareketTipi));
                cmd.Parameters.Add(new SqlParameter("@miktar", _Miktar));
                cmd.Parameters.Add(new SqlParameter("@iliskili_hesap_id", _iliskiliHesapId??0));
                cmd.Parameters.Add(new SqlParameter("@aciklama", Aciklama));
                cmd.Parameters.Add(new SqlParameter("@zaman", DateTime.Now));

                cmd.ExecuteNonQuery();

            }


        }
        public Musteri musteriSorgula(int _musteriId)
        {
            Musteri musteri = null;

            using (var conn = baglantiOlustur())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM musteri WHERE id = @id", conn);
                cmd.Parameters.Add(new SqlParameter("@id", _musteriId));
                System.Data.DataTable dt = new DataTable();
                System.Data.SqlClient.SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    musteri = new Musteri();
                    var musteriVeri = dt.Rows[0];
                    musteri.Adi = musteriVeri["adi"].ToString();
                    musteri.Soyadi = musteriVeri["soyadi"].ToString();
                    musteri.KullaniciAdi = musteriVeri["kullanici_adi"].ToString();

                }
            }
            return musteri;


        }
        public List<HesapHareket> hesapHareketSorgula_HesapId(int _hesapId)
        {

            List<HesapHareket> hesapHareketList = new List<HesapHareket>();


            using (var conn = baglantiOlustur())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM hesap_hareket WHERE hesap_id = @hesapid order by zaman desc", conn);
                cmd.Parameters.Add(new SqlParameter("@hesapid", _hesapId));
                System.Data.DataTable dt = new DataTable();
                System.Data.SqlClient.SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    var hesapHareket = new HesapHareket();
                    hesapHareket.Id = Convert.ToInt32(item["Id"]);
                    hesapHareket.Miktar = Convert.ToDecimal(item["miktar"]);
                    if (item["iliskili_hesap_id"] != null)
                    {
                        hesapHareket.IliskiliHesap = Convert.ToInt32(item["iliskili_hesap_id"]);

                    }
                    hesapHareket.Aciklama = item["aciklama"].ToString();
                    hesapHareket.HareketTipi = (HesapHareket.HareketTipiEnum)Convert.ToInt32(item["hareket_tipi"]);
                    hesapHareket.Zaman = Convert.ToDateTime(item["zaman"]);
                    hesapHareketList.Add(hesapHareket);
                }

            }
            return hesapHareketList;

        }
        public List<Hesap> hesapSorgula_MusteriId(int _musteriId)
        {

            List<Hesap> hesapList = new List<Hesap>();

            using (var conn = baglantiOlustur())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM hesap WHERE musteri_id = @musteriid", conn);
                cmd.Parameters.Add(new SqlParameter("@musteriid", _musteriId));
                System.Data.DataTable dt = new DataTable();
                System.Data.SqlClient.SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    Hesap hesap = new Hesap();
                    hesap.Id = Convert.ToInt32(item["Id"]);
                    hesap.HesapAdi = item["hesap_adi"].ToString();
                    hesap.IBAN = item["iban"].ToString();
                    hesapList.Add(hesap);

                }
            }
            return hesapList;


        }

        public Hesap hesapSorgula_Iban(String _iban)
        {

            Hesap hesap = null;

            using (var conn = baglantiOlustur())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM hesap WHERE iban = @iban", conn);
                cmd.Parameters.Add(new SqlParameter("@iban", _iban));
                System.Data.DataTable dt = new DataTable();
                System.Data.SqlClient.SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    hesap = new Hesap();
                    var hesapVeri = dt.Rows[0];
                    hesap.Id =Convert.ToInt32(hesapVeri["Id"]);
                    hesap.HesapAdi = hesapVeri["hesap_adi"].ToString();
                    hesap.IBAN = hesapVeri["iban"].ToString();



                }
            }
            return hesap;


        }
        public Hesap hesapSorgula_Id(int _id)
        {

            Hesap hesap = null;

            using (var conn = baglantiOlustur())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM hesap WHERE id = @id", conn);
                cmd.Parameters.Add(new SqlParameter("@id", _id));
                System.Data.DataTable dt = new DataTable();
                System.Data.SqlClient.SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    hesap = new Hesap();
                    var hesapVeri = dt.Rows[0];
                    hesap.Id = Convert.ToInt32(hesapVeri["Id"]);
                    hesap.HesapAdi = hesapVeri["hesap_adi"].ToString();
                    hesap.IBAN = hesapVeri["iban"].ToString();



                }
            }
            return hesap;


        }

    }
}
