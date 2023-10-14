using Microsoft.AspNetCore.Identity;

namespace EnvanterTakipSt.EFModels
{
    public class ApplicationUser : IdentityUser
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
    }
}
