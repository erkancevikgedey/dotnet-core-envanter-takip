using EnvanterTakipSt.Data;

namespace EnvanterTakipSt.Services
{
    public class SiteDetayService : ISiteDetayService
    {
        private readonly ApplicationDbContext _context;

        public SiteDetayService(ApplicationDbContext context)
        {
            _context = context;
        }

        public int GetMalzemeCesitSayisi()
        {
            int mevcutSayi = _context.Malzeme.Count();
            return mevcutSayi;
        }

        public int GetPersonelSayisi()
        {
            int mevcutSayi = _context.Personel.Count();
            return mevcutSayi;
        }

        public int GetSistemKullaniciSayisi()
        {
            int mevcutSayi = _context.Users.Count();
            return mevcutSayi;
        }
    }
}
