using EnvanterTakipSt.EFModels;

namespace EnvanterTakipSt.Services
{
    public interface IMalzemeService
    {
        public bool MalzemeEkle(Malzeme malzeme);
        public bool MalzemeSil(int id);
        public bool MalzemeDuzenle(Malzeme malzeme);
        public Malzeme GetMalzeme(int id);
        public List<Malzeme> GetMalzemeList();

    }
}
