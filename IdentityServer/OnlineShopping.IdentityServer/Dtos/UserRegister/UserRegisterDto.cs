﻿namespace OnlineShopping.IdentityServer.Dtos.UserRegister
{
    public class UserRegisterDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
