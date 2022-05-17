using Examino.Domain.Contracts;
using Examino.Domain.Entities;
using Examino.Domain.TokenClasses;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Infrastructure.Services
{
    public class LoginService : ILoginService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPasswordHasher<Patient> _patientPasswordHasher;
        private readonly IPasswordHasher<Doctor> _doctorPasswordHasher;
        private readonly IPasswordHasher<ApplicationUser> _adminPasswordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public LoginService(UserManager<ApplicationUser> userManager,
            IPasswordHasher<Patient> patientPasswordHasher, IPasswordHasher<Doctor> doctorPasswordHasher, IPasswordHasher<ApplicationUser> adminPasswordHasher,
            AuthenticationSettings authenticationSettings)
        {

            _userManager = userManager;
            _patientPasswordHasher = patientPasswordHasher;
            _doctorPasswordHasher = doctorPasswordHasher;
            _adminPasswordHasher = adminPasswordHasher;
            _authenticationSettings = authenticationSettings;
        }
        public string GenerateJwt(string email, string password)
        {
            PasswordVerificationResult result;
            var user = _userManager.FindByEmailAsync(email).Result;
            if (user is null)
            {
                return null;
            }
            if (user.GetType() == typeof(Patient))
            {
                result = _patientPasswordHasher.VerifyHashedPassword((Patient)user, user.PasswordHash, password);
            }
            else if (user.GetType() == typeof(Doctor))
            {
                result = _doctorPasswordHasher.VerifyHashedPassword((Doctor)user, user.PasswordHash, password);
            }
            else
            {
                result = _adminPasswordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            }

            if (result == PasswordVerificationResult.Failed)
            {
                return null;
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Email,user.Email.ToString()),
                new Claim(ClaimTypes.Name,$"{user.Name} {user.Surname}"),
                new Claim(ClaimTypes.Role,_userManager.GetRolesAsync(user).Result.First())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires:expires,
                signingCredentials:cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

    }
}
