﻿using ComputerManage.Models;
using ComputerManage.Models.Authentication;
using Microsoft.AspNetCore.Identity;

namespace ComputerManage.Interfaces
{
    public interface IUserService
    {
        public Task<UserManagerResponse> RegisterUserAsync(RegisterModel model, string role = "Administrator");
        public Task<UserManagerResponse> ChangePasswordAsync(ChangePasswordModel model);
        public Task<UserManagerResponse> LoginUserAsync(LoginModel model);
    }
}
