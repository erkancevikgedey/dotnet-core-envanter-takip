using EnvanterTakipSt.EFModels;

namespace EnvanterTakipSt.Services
{
    public interface IZimmetService
    {
        public bool ZimmetVer(Zimmet zimmet);
        public bool ZimmetGeriAl(int id);
        public bool ZimmetYenile(int id);
        public Zimmet GetZimmet(int id);
        public List<Zimmet> GetZimmetList();
    }
}
