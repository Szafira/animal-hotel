﻿using animal_hotel.Models;
using animal_hotel.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace animal_hotel.Data
{
    public class AccountRepository

    {
        private readonly UserManager<IdentityUser> _userManager;



        public AccountRepository(UserManager<IdentityUser> userManager)
        {
            _userManager =  userManager;
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

    }
}
