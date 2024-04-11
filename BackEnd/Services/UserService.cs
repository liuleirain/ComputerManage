using ComputerManage.Interfaces;
using ComputerManage.Models;
using ComputerManage.Models.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NuGet.Packaging;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ComputerManage.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<IdentityUser> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }

        public async Task<UserManagerResponse> ChangePasswordAsync(ChangePasswordModel model)
        {
            if (model == null)
                throw new NullReferenceException("Change model is null");

            var user = await _userManager.FindByNameAsync(model.Username);

            await _userManager.RemovePasswordAsync(user);

            var result = await _userManager.AddPasswordAsync(user, model.newPassword);

            if (result.Succeeded)
            {
                return new UserManagerResponse
                {
                    Message = "User change password successfully",
                    IsSuccess = true,
                };
            }

            return new UserManagerResponse
            {
                Message = "User password did not change",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        public async Task<UserManagerResponse> LoginUserAsync(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                return new UserManagerResponse
                {
                    Message = "There is no user with that username",
                    IsSuccess = false,
                };
            }

            var result = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!result)
                return new UserManagerResponse
                {
                    Message = "Invalid password",
                    IsSuccess = false,
                };

            var claims = new List<Claim>
            {
                new Claim("UserName", model.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach(var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserManagerResponse
            {
                Message = tokenAsString,
                IsSuccess = true,
                ExpireDate = token.ValidTo,
            };
        }

        public async Task<UserManagerResponse> RegisterUserAsync(RegisterModel model, String role = "Administrator")
        {
            if (model == null)
                throw new NullReferenceException("Reigster model is null");
            if (model.Password != model.ConfirmPassword)
                return new UserManagerResponse
                {
                    Message = "Confirm password doesn't match the password",
                    IsSuccess = false,
                };

            var identityUser = new IdentityUser
            {
                UserName = model.Username,
            };

            var result = await _userManager.CreateAsync(identityUser, model.Password);

            if (await _roleManager.RoleExistsAsync(role))
            {
                await _userManager.AddToRoleAsync(identityUser, role);
            }
            else
            {
                return new UserManagerResponse
                {
                    Message = "This role Does not exist",
                    IsSuccess = false
                };
            }

            if (result.Succeeded)
            {
                return new UserManagerResponse
                {
                    Message = "User Created successfully",
                    IsSuccess = true,
                };
            }
           

            return new UserManagerResponse
            {
                Message = "User did not Create",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }
    }
}
