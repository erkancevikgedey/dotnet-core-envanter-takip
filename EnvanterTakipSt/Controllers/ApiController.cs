using EnvanterTakipSt.EFModels;
using EnvanterTakipSt.Models;
using EnvanterTakipSt.Models.DTO;
using EnvanterTakipSt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EnvanterTakipSt.Controllers
{
    [Authorize]
    public partial class ApiController : Controller
    {
        private readonly IMalzemeService _malzemeService;
        private readonly ISKullaniciService _sKullaniciService;
        private readonly IPersonelService _personelService;
        private readonly IDepartmanService _departmanService;
        private readonly IZimmetService _zimmetService;
        private readonly IGecmisService _gecmisService;

        public ApiController(IMalzemeService malzemeService, ISKullaniciService sKullaniciService, IPersonelService personelService, IDepartmanService departmanService, IZimmetService zimmetService, IGecmisService gecmisService)
		{
			_malzemeService = malzemeService;
			_sKullaniciService = sKullaniciService;
			_personelService = personelService;
            _departmanService = departmanService;
            _zimmetService = zimmetService;
            _gecmisService = gecmisService;
        }
		public IActionResult GetMalzemeler()
        {
            var malzemeListesi = _malzemeService.GetMalzemeList().Where(x => x.Durum == true);
            //var liste = JsonConvert.SerializeObject(malzemeListesi);
            return Json(malzemeListesi);
        }

        public IActionResult GetMalzeme(int id)
        {
            var malzeme = _malzemeService.GetMalzemeList().Where(x => x.MalzemeId == id).SingleOrDefault();
            return Json(malzeme); // null dönse de sorun değil
        }

        public IActionResult AddMalzeme(Malzeme malzeme)
        {
            malzeme.Durum = true;
            var durum = _malzemeService.MalzemeEkle(malzeme);
            return Json(new { islem = durum });
        }

        public IActionResult EditMalzeme(Malzeme malzeme)
        {
            var durum = _malzemeService.MalzemeDuzenle(malzeme); // kullanıcının durum etiketi gönderip burada ihlal yapması mümkün fakat bir şey değiştirmeyeceği için dikkate alınmadı
            return Json(new { islem = durum });
        }
        public IActionResult DeleteMalzeme(int id)
        {
            var durum = _malzemeService.MalzemeSil(id);
            return Json(new { islem = durum });
        }
        public IActionResult GetSistemKullanicilari()
        {
            var kullaniciListesi = _sKullaniciService.GetUsers();
            var kullanicilarDTOIle = kullaniciListesi.Select(p => new ApplicationUserDTO
            {
                Id = p.Id,
                Ad = p.Ad,
                Soyad = p.Soyad,
                Email = p.Email
            }).ToList();
            return Json(kullanicilarDTOIle);
        }
        public async Task<IActionResult>AddKullanici(InputModel kullanici)
        {
            var durum = await _sKullaniciService.AddUser(kullanici);
            return durum ? Json(new { islem = true }) : Json(new { islem = false });
        }

        public IActionResult DeleteKullanici(string id)
        {
            var durum = _sKullaniciService.RemoveUser(id);
            return durum ? Json(new { islem = true }) : Json(new { islem = false });
        }

        public IActionResult GetPersoneller()
        {
            var personeller = _personelService.GetPersonelList();
            return Json(personeller);
        }

        public IActionResult EditPersonel(EditPersonelInput input)
		{
            var personel = _personelService.GetPersonel(input.Id);
            if(personel != null)
			{
                personel.Ad = input.Ad;
                personel.Soyad = input.Soyad;
                personel.TelefonNo = input.Telefon;
                personel.DepartmanId = input.DepartmanId;
                personel.Departmani = _departmanService.GetDepartman(input.DepartmanId);
                personel.Durumu = input.Durum;
                var durum = _personelService.PersonelDuzenle(personel);
                return durum ? Json(new { islem = true }) : Json(new { islem = false });
			}
			else
			{
                return Json(new { islem = false });
			}
        }

        public IActionResult AddPersonel(Personel personel)
		{
            var durum = _personelService.PersonelEkle(personel);
            return durum ? Json(new { islem = true }) : Json(new { islem = false });
        }
        public IActionResult DeletePersonel(int id)
        {
            var durum = _personelService.PersonelSil(id);
            return durum ? Json(new { islem = true}) : Json(new {islem = false});
        }
        public IActionResult GetDepartmanlar()
		{
            var departmanlar = _departmanService.GetDepartmanList();
            return Json(departmanlar);
        }
        public IActionResult GetDepartman(int id)
        {
            var departmanlar = _departmanService.GetDepartman(id);
            return Json(departmanlar);
        }
        public IActionResult AddDepartman(string departmanAdi)
		{
            var departman = new Departman() { DepartmanAdi = departmanAdi };
            var durum = _departmanService.DepartmanEkle(departman);
            return durum ? Json(new { islem = true }) : Json(new { islem = false });
        }
        public IActionResult EditDepartman(Departman departman)
		{
            var durum = _departmanService.DepartmanDuzenle(departman);
            return durum ? Json(new { islem = true }) : Json(new { islem = false });
        }
        public IActionResult DeleteDepartman(int id)
        {
            var durum = _departmanService.DepartmanSil(id);
            return Json(new { islem = durum });
        }

        public IActionResult GetZimmetler(int id)
        {
            var zimmetler = _zimmetService.GetZimmetList().Where(x=>x.PersonelId == id);
            return Json(zimmetler);
        }
        public IActionResult AddZimmet(AddZimmetModel zimmet)
        {
            var zaman = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(Math.Round(Int64.Parse(zimmet.Timestamp) / 1000d)).ToLocalTime();
            var _zimmet = new Zimmet() { MalzemeId = zimmet.MalzemeId, PersonelId = zimmet.PersonelId, ZimmetTarihi = zaman };
            var durum = _zimmetService.ZimmetVer(_zimmet);
            return durum ? Json(new { islem = true }) : Json(new { islem = false });
        }
        public IActionResult UpdateZimmetTime(int zimmetId)
        {
            var zimmet = _zimmetService.GetZimmet(zimmetId);
            var durum = false;
            if (zimmet != null)
            {
                durum = _zimmetService.ZimmetYenile(zimmetId);
            }
            return durum ? Json(new { islem = true }) : Json(new { islem = false });
        }

        public IActionResult DeleteZimmet(int zimmetId)
        {
            var durum = _zimmetService.ZimmetGeriAl(zimmetId);
            return durum ? Json(new { islem = true }) : Json(new { islem = false });
        }
        
        public IActionResult GetGecmisler(int id)
        {
            var gecmisler = _gecmisService.GecmisleriGetir(id);
            return Json(gecmisler);
        }

        public IActionResult GetRapor(int id)
        {
            var rapor = new Rapor()
            {
                Personel = _personelService.GetPersonel(id),
                Gecmis = _gecmisService.GecmisleriGetir(id),
                Zimmetler = _zimmetService.GetZimmetList().Where(x => x.PersonelId == id).ToList(),
            };
            return Json(rapor);
        }
    }
}
