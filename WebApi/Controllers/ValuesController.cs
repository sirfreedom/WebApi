using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebApi.Infrastructure.BasicAuth;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _ConnectionString = string.Empty;
        private readonly string _Setting1;

        public ValuesController(ILogger<ValuesController> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            _Setting1 = _configuration.GetValue(typeof(string), "AppConfig:Setting1", string.Empty).ToString();
            _logger = logger;
            _configuration = configuration;
        }


        /// <summary>
        /// JwtAuth Metodo de autenticacion por JWT
        /// </summary>
        /// <returns></returns>
        [HttpGet("jwt")]
        [Authorize]
        public ActionResult JwtAuth()
        {
            var username = User.Identity.Name;
            var rng = new Random();
            return Ok(new { user = User.Identity.Name, randome = Enumerable.Range(1, 10).Select(x => rng.Next(0, 100)) });
        }

        /// <summary>
        /// BasicAuth Metodo de prueba para basic autentication
        /// </summary>
        /// <returns>
        /// Devuelve una lista de numeros random si fue ok 200
        /// </returns>
        [HttpGet("basic")]
        [BasicAuth] // You can optionally provide a specific realm --> [BasicAuth("my-realm")]
        public IEnumerable<int> BasicAuth()
        {
            var rng = new Random();
            return Enumerable.Range(1, 10).Select(x => rng.Next(0, 100));
        }


        /// <summary>
        /// Metodo de prueba de logout
        /// </summary>
        /// <returns></returns>
        [HttpGet("basic-logout")]
        [BasicAuth]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult BasicAuthLogout()
        {
            HttpContext.Response.Headers["WWW-Authenticate"] = "Basic realm=\"My Realm\"";
            return new UnauthorizedResult();
        }






    }
}
