using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            // 2XX  200 OK, 201 Created
            // 3XX
            // 4XX  400 Bad Request, 401 Unauthorized, 403 Forbidden, 404
            // 5XX  500 => Internal server error

            if (!ModelState.IsValid)
            {
                // 400 Bad request
                return BadRequest();
            }
            var user = await _accountService.CreateUser(model);
            if (user == null) return BadRequest();
            return Ok(user);
        }
    }
}
