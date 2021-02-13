using animal_hotel.Models;
using animal_hotel.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluent.Infrastructure.FluentModel;

namespace animal_hotel.Data
{
    public class AccountRepository : IAccountRepository

    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        


        public AccountRepository(UserManager<IdentityUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager =  userManager;
            _signInManager = signInManager;
            
        }



        public async Task<IdentityResult> CreateUserAsync(SignUpModel userModel)

        {
            var user = new IdentityUser()
            {
                Email = userModel.Email,
                UserName = userModel.Email,



            };
            var result = await _userManager.CreateAsync(user, userModel.Password);
            return result;
        }
        public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel)
        {
            return await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.RememberMe, false);
        }

        Task<Microsoft.AspNet.Identity.IdentityResult> IAccountRepository.CreateUserAsync(SignUpModel userModel)
        {
            throw new NotImplementedException();
        }
    }
}
