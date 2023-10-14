using EnvanterTakipSt.EFModels;

namespace EnvanterTakipSt.Services
{
    public interface IGecmisService
    {
        public List<Gecmis> GecmisleriGetir(int id);
        public bool GecmisEkle(Gecmis gecmis);
        public bool GecmisSil(int id);
    }
}
