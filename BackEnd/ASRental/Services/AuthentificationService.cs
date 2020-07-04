using ASRental.Models;
using ASRental.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASRental.Services
{
    public class AuthentificationService : IAuthentificationService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthentificationService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public ApplicationUser CreateUser(string email)
        {
            return new ApplicationUser { UserName = email, Email = email };
        }

        public async Task<IdentityResult> Register(ApplicationUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<SignInResult> Login(string email, string password, bool rememberMe)
        {
            return await _signInManager.PasswordSignInAsync(email, password, rememberMe, lockoutOnFailure: false);
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<ApplicationUser> FindLoggedInUser(ClaimsPrincipal principal)
        {
            return await _userManager.GetUserAsync(principal);
        }

        public async Task<ApplicationUser> FindUserById(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }
    }
}
