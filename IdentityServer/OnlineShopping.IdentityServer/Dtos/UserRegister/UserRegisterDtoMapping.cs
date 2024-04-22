using OnlineShopping.IdentityServer.Models;

namespace OnlineShopping.IdentityServer.Dtos.UserRegister
{
    public static class UserRegisterDtoMapping
    {
        public static UserRegisterDto ToDto(this ApplicationUser user)
        {
            return new UserRegisterDto
            {
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname,
                UserName= user.UserName
            };
        }

        public static ApplicationUser ToEntity(this UserRegisterDto dto)
        {
            return new ApplicationUser
            {
                UserName = dto.UserName,
                Surname = dto.Surname,
                Name = dto.Name,
                Email = dto.Email
            };
        }
    }
}
