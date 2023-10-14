using EnvanterTakipSt.EFModels;

namespace EnvanterTakipSt.Services
{
	public interface IDepartmanService
	{
        public bool DepartmanEkle(Departman departman);
        public bool DepartmanSil(int id);
        public bool DepartmanDuzenle(Departman departman);
        public Departman GetDepartman(int id);
        public List<Departman> GetDepartmanList();
    }
}
