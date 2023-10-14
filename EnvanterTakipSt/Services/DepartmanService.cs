using EnvanterTakipSt.Data;
using EnvanterTakipSt.EFModels;

namespace EnvanterTakipSt.Services
{
	public class DepartmanService : IDepartmanService
	{
		private readonly ApplicationDbContext _context;
		public DepartmanService(ApplicationDbContext context)
		{
			_context = context;
		}
		public bool DepartmanDuzenle(Departman departman)
		{
			try
			{
				_context.Departman.Update(departman);
				return _context.SaveChanges() > 0;
			}
			catch
			{
				return false;
			}
		}

		public bool DepartmanEkle(Departman departman)
		{
			try
			{
				_context.Departman.Add(departman);
				return _context.SaveChanges() > 0;
			}
			catch
			{
				return false;
			}
		}

		public bool DepartmanSil(int id)
		{
			var departman = _context.Departman.Where(x => x.DepartmanId == id).SingleOrDefault();
			if (departman != null)
			{
				var kullanilanMiktar = _context.Personel.Where(x => x.DepartmanId == id).Count();
				if (kullanilanMiktar > 0)
				{
					return false; // silinme yasak
				}
				else
				{
					try
					{
						_context.Remove(departman);
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

		public Departman GetDepartman(int id)
		{
			var departman = _context.Departman.Where(x => x.DepartmanId == id).FirstOrDefault();
			return departman;
		}

		public List<Departman> GetDepartmanList()
		{
			var departmanlar = _context.Departman.ToList();
			return departmanlar;
		}
	}
}
