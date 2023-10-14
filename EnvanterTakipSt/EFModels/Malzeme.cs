using System.ComponentModel.DataAnnotations;

namespace EnvanterTakipSt.EFModels
{
    public class Malzeme
    {
        [Key]
        public int MalzemeId { get; set; }
        public string MalzemeAdi { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
    }
}
