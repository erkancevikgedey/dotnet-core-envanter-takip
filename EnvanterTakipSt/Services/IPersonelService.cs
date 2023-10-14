using EnvanterTakipSt.EFModels;

namespace EnvanterTakipSt.Services
{
    public interface IPersonelService
    {
        public bool PersonelEkle(Personel personel);
        public bool PersonelSil(int id);
        public bool PersonelDuzenle(Personel personel);
        public Personel GetPersonel(int id);
        public List<Personel> GetPersonelList();
    }
}
