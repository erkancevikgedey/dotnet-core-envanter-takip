using System.ComponentModel.DataAnnotations;

namespace EnvanterTakipSt.EFModels
{
    public enum Islem { Yenileme, ZimmetEt, ZimmetGeriAl }
    public class Gecmis
    {
        [Key]
        public int GecmisId { get; set; }
        public int PersonelId { get; set; }
        public Personel Personel { get; set; }
        public int MalzemeId { get; set; }
        public Malzeme Malzeme { get; set; }
        public DateTime GuncelTarihi { get; set; }
        public DateTime GecmisZamani { get; set; }
        public string SistemKullaniciId { get; set; }
        public Islem Islem { get; set; }
    }
}
