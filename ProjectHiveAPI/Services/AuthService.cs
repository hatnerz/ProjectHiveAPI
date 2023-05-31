﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectHiveAPI.DataBase;
using ProjectHiveAPI.DI;
using ProjectHiveAPI.Models;
using Task = System.Threading.Tasks.Task;

namespace ProjectHiveAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly ProjectHiveContext context;
        private readonly IUserService userService;

        public AuthService(ProjectHiveContext context, IUserService userService)
        {
            this.context = context;
            this.userService = userService;
        }


        public async Task<User> Login(AuthModel login)
        {
            var user = await context.User.FirstOrDefaultAsync(u => u.Email == login.Email);

            if (user != null && VerifyPassword(login.Password, user.Password))
            {
                return user;
            }

            return null; // Пароль не соответствует или пользователь не найден
        }

        public Task Register(User user)
        {
            this.userService.AddUser(user);

            return Task.CompletedTask;
        }

        private bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
        }
    }
}
