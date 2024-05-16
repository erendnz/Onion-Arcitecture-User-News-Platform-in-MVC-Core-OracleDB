using Haber.Application.Models.DTOs;
using Haber.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Application.Services.AppUserService
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        
        private readonly SignInManager<AppUser> _signInManager;

        public AppUserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public int GetUserID(ClaimsPrincipal claims)
        {
             return int.Parse(_userManager.GetUserId(claims));
        }

        public async Task<LoginReturnDTO> LoginAsync(LoginDTO login)
        {
            LoginReturnDTO returnDTO = new LoginReturnDTO() { IsUser = false,IsAdmin=false };
           
            var user = await _userManager.FindByNameAsync(login.UserName);
            if (user == null) 
                return returnDTO;
            var passwordIsCorrect = await  _userManager.CheckPasswordAsync(user, login.Password);

            if (!passwordIsCorrect) 
                return returnDTO;
            await _signInManager.SignInAsync(user, true);
            returnDTO.IsUser = true;
            returnDTO.IsAdmin = await _userManager.IsInRoleAsync(user,"Admin");
            return returnDTO;
            
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> RegisterAsync(UyeKayitDTO uye)
        {
            AppUser user = new AppUser();
            user.UserName = uye.UserName;
            user.Ad = uye.Ad;
            user.Email = uye.Email;
            user.Soyad=uye.Soyad;
            
            PasswordHasher<AppUser> hasher = new PasswordHasher<AppUser>();

            user.PasswordHash = hasher.HashPassword(user, uye.Password);
            var result = await _userManager.CreateAsync(user);

            //Uye rol iliskisi...
            await _userManager.AddToRoleAsync(user, "Uye");
            return result.Succeeded;
        }

        public Task UyeGuncelleAsync(UyeGuncelleDTO uye)
        {
            throw new NotImplementedException();
        }
    }
}
