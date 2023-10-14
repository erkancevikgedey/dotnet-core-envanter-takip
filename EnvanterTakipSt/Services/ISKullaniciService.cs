using EnvanterTakipSt.EFModels;
using static EnvanterTakipSt.Controllers.ApiController;

namespace EnvanterTakipSt.Services
{
    public interface ISKullaniciService
    {
        public Task<bool> AddUser(InputModel kullanici);
        public bool RemoveUser(string id);
        public bool EditUser(string id, InputModel kullanici);
        public List<ApplicationUser> GetUsers();

    }
}
