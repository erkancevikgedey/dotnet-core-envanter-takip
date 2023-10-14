using EnvanterTakipSt.EFModels;

namespace EnvanterTakipSt.Models
{
    public class Rapor
    {
        public Personel Personel { get; set; }
        public List<Zimmet> Zimmetler { get; set; }
        public List<Gecmis> Gecmis { get; set; }
    }
}
