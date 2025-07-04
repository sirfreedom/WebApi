using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Infrastructure.BasicAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

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
        public IEnumerable<int> JwtAuth()
        {
            var username = User.Identity.Name;
            _logger.LogInformation($"User [{username}] is visiting jwt auth with token {1}");
            var rng = new Random();
            return Enumerable.Range(1, 10).Select(x => rng.Next(0, 100));
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
            _logger.LogInformation("basic auth");
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
            _logger.LogInformation("basic auth logout");
            HttpContext.Response.Headers["WWW-Authenticate"] = "Basic realm=\"My Realm\"";
            return new UnauthorizedResult();
        }






    }
}
