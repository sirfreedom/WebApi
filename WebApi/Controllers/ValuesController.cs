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

        public ValuesController(ILogger<ValuesController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        /// <summary>
        /// Metodo de prueba sin autenticacion
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<int> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 3).Select(x => rng.Next(0, 100));
        }

        /// <summary>
        /// Metodo de autenticacion por JWT
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
        /// Metodo de prueba para basic autentication
        /// </summary>
        /// <returns></returns>
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
