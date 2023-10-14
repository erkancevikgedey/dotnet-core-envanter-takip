using System.ComponentModel.DataAnnotations;

namespace EnvanterTakipSt.EFModels
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TelefonNo { get; set; }
        public int DepartmanId { get; set; }
        public Departman Departmani { get; set; }
        public bool Durumu { get; set; }
    }
}
