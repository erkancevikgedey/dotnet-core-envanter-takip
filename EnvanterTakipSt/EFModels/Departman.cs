using System.ComponentModel.DataAnnotations;

namespace EnvanterTakipSt.EFModels
{
    public class Departman
    {
        [Key]
        public int DepartmanId { get; set; }
        public string DepartmanAdi { get; set; }
    }
}
