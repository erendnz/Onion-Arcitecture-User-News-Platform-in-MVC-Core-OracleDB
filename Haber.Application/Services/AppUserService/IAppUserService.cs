using Haber.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Application.Services.AppUserService
{
    public interface IAppUserService
    {
        Task<LoginReturnDTO> LoginAsync(LoginDTO login);
        Task LogoutAsync();
        Task<bool> RegisterAsync(UyeKayitDTO uye);
        Task UyeGuncelleAsync(UyeGuncelleDTO uye);

        int GetUserID(ClaimsPrincipal claims);
 
    }
}
