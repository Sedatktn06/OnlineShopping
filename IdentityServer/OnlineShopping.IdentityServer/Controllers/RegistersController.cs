using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.IdentityServer.Dtos.UserRegister;
using OnlineShopping.IdentityServer.Models;
using System.Threading.Tasks;

namespace OnlineShopping.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
        {
            var result = await _userManager.CreateAsync(userRegisterDto.ToEntity(), userRegisterDto.Password);
            if (result.Succeeded)
            {
                return Ok("Kullanıcı başarıyla eklendi");
            }
            else
            {
                return BadRequest("Kullanıcı ekleme işlemi başarısız olmuştur!");
            }
        }
    }
}
