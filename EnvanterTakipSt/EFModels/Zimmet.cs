using System.ComponentModel.DataAnnotations;

namespace EnvanterTakipSt.EFModels
{
    public class Zimmet
    {
        [Key]
        public int ZimmetId { get; set; }
        public int MalzemeId { get; set; }
        public Malzeme Malzeme { get; set; }
        public int PersonelId { get; set; }
        public Personel Personel { get; set; }
        public DateTime ZimmetTarihi { get; set; }
    }
}
