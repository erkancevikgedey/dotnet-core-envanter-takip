using EnvanterTakipSt.Data;
using EnvanterTakipSt.EFModels;

namespace EnvanterTakipSt.Services
{
    public class MalzemeService : IMalzemeService
    {
        private readonly ApplicationDbContext _context;

        public MalzemeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Malzeme GetMalzeme(int id)
        {
            throw new NotImplementedException();
        }

        public List<Malzeme> GetMalzemeList()
        {
            var malzemeler = _context.Malzeme.ToList();
            return malzemeler;
        }

        public bool MalzemeDuzenle(Malzeme malzeme)
        {
            try
            {
                _context.Malzeme.Update(malzeme);
                return _context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool MalzemeEkle(Malzeme malzeme)
        {
            try
            {
                _context.Malzeme.Add(malzeme);
                return _context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool MalzemeSil(int id)
        {
            var malzeme = _context.Malzeme.Where(x => x.MalzemeId == id).SingleOrDefault();
            if(malzeme != null)
            {
                var kullanilanMiktar = _context.Zimmet.Where(x => x.MalzemeId == id).Count();
                if(kullanilanMiktar > 0)
                {
                    try
                    {
                        malzeme.Durum = false;
                        _context.Malzeme.Update(malzeme);
                        return _context.SaveChanges() > 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                {
                    try
                    {
                        _context.Remove(malzeme);
                        return _context.SaveChanges() > 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
                
            }
            else
            {
                return false;
            }
            
        }
    }
}
