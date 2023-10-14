using EnvanterTakipSt.Data;
using EnvanterTakipSt.EFModels;
using Microsoft.EntityFrameworkCore;

namespace EnvanterTakipSt.Services
{
    public class ZimmetService : IZimmetService
    {
        private readonly ApplicationDbContext _context;
        private readonly IGecmisService gecmisService;
        public ZimmetService(ApplicationDbContext context, IGecmisService gecmisService)
        {
            _context = context;
            this.gecmisService = gecmisService;
        }
        public Zimmet GetZimmet(int id)
        {
            var zimmet = _context.Zimmet.Include(a=>a.Malzeme).Include(b=>b.Personel).Where(x=>x.ZimmetId == id).FirstOrDefault();
            return zimmet;
        }

        public List<Zimmet> GetZimmetList()
        {
            var zimmetler = _context.Zimmet.Include(a => a.Malzeme).Include(b => b.Personel).ToList();
            return zimmetler;
        }

        public bool ZimmetGeriAl(int id)
        {
            var zimmet = GetZimmet(id);
            if(zimmet != null)
            {
                try
                {
                    _context.Zimmet.Remove(zimmet);
                    if (_context.SaveChanges() > 0)
                    {
                        var gecmis = new Gecmis()
                        {
                            GecmisZamani = DateTime.Now,
                            GuncelTarihi = default, // bu yenilemedeki yenilenmiş tarih
                            MalzemeId = zimmet.MalzemeId,
                            PersonelId = zimmet.PersonelId,
                            SistemKullaniciId = "2e9f028c-8c64-4b49-af7f-2ba901f77fcf",
                            Islem = Islem.ZimmetGeriAl,
                        };
                        gecmisService.GecmisEkle(gecmis);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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

        public bool ZimmetVer(Zimmet zimmet)
        {
            try {
                _context.Zimmet.Add(zimmet);
                if(_context.SaveChanges() > 0)
                {
                    var gecmis = new Gecmis()
                    {
                        GecmisZamani = DateTime.Now,
                        GuncelTarihi = DateTime.Now, // bu yenilemedeki yenilenmiş tarih
                        MalzemeId = zimmet.MalzemeId,
                        PersonelId = zimmet.PersonelId,
                        SistemKullaniciId = "2e9f028c-8c64-4b49-af7f-2ba901f77fcf",
                        Islem = Islem.ZimmetEt,
                    };
                    gecmisService.GecmisEkle(gecmis);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool ZimmetYenile(int id)
        {
            var zimmet = GetZimmet(id);
            if (zimmet != null)
            {
                try
                {
                    zimmet.ZimmetTarihi = DateTime.Now;
                    if (_context.SaveChanges() > 0)
                    {
                        var gecmis = new Gecmis()
                        {
                            GecmisZamani = DateTime.Now,
                            GuncelTarihi = DateTime.Now, // bu yenilemedeki yenilenmiş tarih
                            MalzemeId = zimmet.MalzemeId,
                            PersonelId = zimmet.PersonelId,
                            SistemKullaniciId = "2e9f028c-8c64-4b49-af7f-2ba901f77fcf",
                            Islem = Islem.Yenileme,
                        };
                        gecmisService.GecmisEkle(gecmis);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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
