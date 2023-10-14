using EnvanterTakipSt.Controllers;
using EnvanterTakipSt.Data;
using EnvanterTakipSt.EFModels;
using Microsoft.AspNetCore.Identity;

namespace EnvanterTakipSt.Services
{
    public class SKullaniciService : ISKullaniciService
    {
        private readonly ApplicationDbContext _context;

        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly UserManager<ApplicationUser> _userManager;

        public SKullaniciService(ApplicationDbContext context, UserManager<ApplicationUser> userManager,IUserStore<ApplicationUser> userStore)
        {
            _context = context;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = (IUserEmailStore<ApplicationUser>)_userStore;
        }
        public async Task<bool> AddUser(ApiController.InputModel kullanici)
        {
            var user = CreateUser();
            user.Ad = kullanici.Ad;
            user.Soyad = kullanici.Soyad;
            await _userStore.SetUserNameAsync(user, kullanici.Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, kullanici.Email, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, kullanici.Password);
            return result.Succeeded;
        }

        public bool EditUser(string id, ApiController.InputModel kullanici)
        {
            throw new NotImplementedException();
        }

        public List<ApplicationUser> GetUsers()
        {
            return _context.ApplicationUsers.ToList();
        }

        public bool RemoveUser(string id)
        {
            var kullanici = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            if(kullanici != null)
            {
                _context.Users.Remove(kullanici);
                return _context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException("hata");
            }
        }
    }
}
