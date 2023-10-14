using EnvanterTakipSt.Data;
using EnvanterTakipSt.EFModels;
using Microsoft.EntityFrameworkCore;

namespace EnvanterTakipSt.Services
{
	public class PersonelService : IPersonelService
	{
		private readonly ApplicationDbContext _context;
		public PersonelService(ApplicationDbContext context)
		{
			_context = context;
		}
		public Personel GetPersonel(int id)
		{
			var personel = _context.Personel.Include(a=>a.Departmani).Where(x => x.PersonelId == id).FirstOrDefault();
			return personel;
		}

		public List<Personel> GetPersonelList()
		{
			var personeller = _context.Personel.Include(a => a.Departmani).ToList();
			return personeller;
		}

		public bool PersonelDuzenle(Personel personel)
		{
			try
			{
				_context.Personel.Update(personel);
				return _context.SaveChanges() > 0;
			}
			catch
			{
				return false;
			}
		}

		public bool PersonelEkle(Personel personel)
		{
			personel.Durumu = true;
			personel.Departmani = _context.Departman.Where(x => x.DepartmanId == personel.DepartmanId).FirstOrDefault();
			try
			{
				_context.Personel.Add(personel);
				return _context.SaveChanges() > 0;
			}
			catch
			{
				return false;
			}
		}

		public bool PersonelSil(int id)
		{
			var personel = _context.Personel.Where(x => x.PersonelId == id).SingleOrDefault();
			if (personel != null)
			{
				try
				{
					_context.Remove(personel);
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
