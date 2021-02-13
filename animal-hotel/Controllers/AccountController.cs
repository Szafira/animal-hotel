﻿using animal_hotel.Models;
using animal_hotel.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace animal_hotel.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }


        [Route("SignUp")]
        public IActionResult SignUp()
        {
            return View();

        }


        [Route("SignUp")]
        [HttpPost]
        public IActionResult SignUp(SignUpModel userModel)
        {
            if (ModelState.IsValid)
            {
                
                ModelState.Clear();
            }
                return View();

        }
        [Route("Login")]
        public IActionResult Login()
        {

            return View();

        }
        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(SignInModel signInModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.PasswordSignInAsync(signInModel);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Niepoprawny email lub hasło");
            }
            return View(signInModel);

        }

    }


}

