using ASRental.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASRental.Services.Interfaces
{
    public interface IAuthentificationService
    {
        public ApplicationUser CreateUser(string email);
        public Task<IdentityResult> Register(ApplicationUser user, string password);
        public Task<SignInResult> Login(string email, string password, bool rememberMe);
        public Task<ApplicationUser> FindLoggedInUser(ClaimsPrincipal principal);
        public Task<ApplicationUser> FindUserById(string userId);
        public Task Logout();
    }
}