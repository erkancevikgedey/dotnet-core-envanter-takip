using EnvanterTakipSt.EFModels;
using EnvanterTakipSt.Models;
using EnvanterTakipSt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EnvanterTakipSt.Controllers
{
    [Authorize]
    public class YonetimController : Controller
    {
        private readonly ISiteDetayService _siteDetayService;
        private readonly IPersonelService _personelService;
        private readonly IDepartmanService _departmanService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public YonetimController(ISiteDetayService siteDetayService, IPersonelService personelService, IDepartmanService departmanService, SignInManager<ApplicationUser> signInManager)
        {
            _siteDetayService = siteDetayService;
            _personelService = personelService;
            _departmanService = departmanService;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            ViewBag.PersonelSayisi = _siteDetayService.GetPersonelSayisi();
            ViewBag.SistemKullaniciSayisi = _siteDetayService.GetSistemKullaniciSayisi();
            ViewBag.MalzemeCesitSayisi = _siteDetayService.GetMalzemeCesitSayisi();

            return View();
        }

        public IActionResult Malzemeler()
        {
            return View();
        }
        public IActionResult SistemKullanicilari()
        {
            return View();
        }

        public IActionResult Personeller()
        {
            return View();
        }

        public IActionResult Departmanlar()
        {
            return View();
        }
        
        public IActionResult Detay(int id)
        {
            if(id != null || id != 0)
			{
                var personel = _personelService.GetPersonel(id);
                if(personel != null)
				{
                    var gonderilecekModel = new PersonelDetayInputModel()
                    {
                        Personel = personel,
                        Options = _departmanService.GetDepartmanList().Select(a => new SelectListItem
                        {
                            Text = a.DepartmanAdi,
                            Value = a.DepartmanId.ToString(),
                            Selected = personel.DepartmanId == a.DepartmanId ? true : false,
                        }
                        ).ToList(),
					};
                    return View(gonderilecekModel);
				}
				else
				{
                    return RedirectToAction("Personeller");
                }
			}
			else
			{
                return RedirectToAction("Personeller");
            }
        }

        public IActionResult Rapor(int id)
        {
            if (id != null || id != 0)
            {
                var personel = _personelService.GetPersonel(id);
                if (personel != null)
                {
                    return View(personel);
                }
                else
                {
                    return RedirectToAction("Personeller");
                }
            }
            else
            {
                return RedirectToAction("Personeller");
            }
        }
        public async Task<IActionResult> Cikis()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
