using EnvanterTakipSt.Data;
using EnvanterTakipSt.EFModels;
using Microsoft.EntityFrameworkCore;

namespace EnvanterTakipSt.Services
{
    public class GecmisService : IGecmisService
    {
        private readonly ApplicationDbContext _context;
        public GecmisService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool GecmisEkle(Gecmis gecmis)
        {
            try
            {
                _context.Gecmis.Add(gecmis);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Gecmis> GecmisleriGetir(int id)
        {
            var gecmisler = _context.Gecmis.Include(a=>a.Personel).Include(b=>b.Malzeme).Where(x => x.PersonelId == id).OrderByDescending(z=>z.GecmisZamani).ToList();
            return gecmisler;
        }

        public bool GecmisSil(int id)
        {
            var gecmis = _context.Gecmis.Where(x => x.GecmisId == id).FirstOrDefault();
            if (gecmis != null)
            {
                try
                {
                    _context.Gecmis.Remove(gecmis);
                    return _context.SaveChanges() > 0;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
