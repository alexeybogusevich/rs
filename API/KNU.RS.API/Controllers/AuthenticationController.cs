﻿using KNU.RS.Logic.Models.Account;
using KNU.RS.Logic.Services.AuthenticationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.RS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(IEnumerable<string>), 400)]
        [ProducesResponseType(typeof(string), 401)]
        public async Task<ActionResult<string>> LoginAsync([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.Select(v => v.Errors));
            }

            var token = await authenticationService.AuthenticateAsync(loginModel);

            if (token == null)
            {
                return Unauthorized("Помилка аутентифікації.");
            }

            return Ok(token);
        }
    }
}
