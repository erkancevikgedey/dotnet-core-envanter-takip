using EnvanterTakipSt.EFModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EnvanterTakipSt.Models
{
	public class PersonelDetayInputModel
	{
		public Personel Personel { get; set; }
		public List<SelectListItem> Options { get; set; }
	}
}
