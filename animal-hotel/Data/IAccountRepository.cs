using animal_hotel.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using IdentityResult = Microsoft.AspNet.Identity.IdentityResult;

namespace animal_hotel.Data
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpModel userModel);
        Task<SignInResult> PasswordSignInAsync(SignInModel signInModel);
        
    }
}