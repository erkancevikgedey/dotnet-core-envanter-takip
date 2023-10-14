using EnvanterTakipSt.EFModels;

namespace EnvanterTakipSt.Models
{
	public class PersonelInputModel
	{
		public string Ad { get; set; }
		public string Soyad { get; set; }
		public string TelefonNo { get; set; }
		public Departman Departman { get; set; }
		public int DepartmanId { get; set; }
	}
}
