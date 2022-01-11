using Google.Apis.Auth;
using JvA.Library.Api.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JvA.Library.Api.Controllers
{
    public class GoogleAuthController : Controller
    {
        public class AuthenticateRequest
        {
            [Required]
            public string IdToken { get; set; }
        }

        private readonly JwtGenerator _jwtGenerator;
        private readonly string _audience;
        public GoogleAuthController(IConfiguration configuration)
        {
            _jwtGenerator = new JwtGenerator(configuration["JwtSettings:Key"]);
            _audience = configuration["JwtSettings:Audience"];
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest data)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings();
            settings.Audience = new List<string>() { _audience };
            var payload = GoogleJsonWebSignature.ValidateAsync(data.IdToken, settings).Result;
            return Ok(new { AuthToken = _jwtGenerator.GenerateToken(payload.Email) });
        }
    }
}
