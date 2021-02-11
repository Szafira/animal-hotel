using animal_hotel.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace animal_hotel.Repository

{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpModel userModel);
    }
}