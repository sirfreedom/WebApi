using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Infrastructure.BasicAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using WebApi.Model;
using WebApi.Entity;
using System.Linq.Expressions;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _ConectionString = string.Empty;
        private readonly string _Setting1;

        public ValuesController(ILogger<ValuesController> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _ConectionString = _configuration.GetConnectionString("DefaultConnection");
            _Setting1 = _configuration.GetValue(typeof(string), "AppConfig:Setting1", string.Empty).ToString();
            _logger = logger;
            _configuration = configuration;
        }

        /// <summary>
        /// Metodo de prueba sin autenticacion
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<int> GetTest1()
        {
            var rng = new Random();
            return Enumerable.Range(1, 3).Select(x => rng.Next(0, 100));
        }


        /// <summary>
        /// PostTest1
        /// </summary>
        /// <param name="testmodel"></param>
        /// <returns> devuelve lo mismo que le envias </returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult PostTest1([FromBody] TestModel testmodel)
        {
            TestPropiedades1 t = new TestPropiedades1();
            TestPropiedadesHija h = new TestPropiedadesHija();
            Dictionary<string, string> lParam = new Dictionary<string, string>();
            t.Id = 1;
            t.Nombre = "pepe";
            t.Apellido = "Gomez";
            h.Telefono = "1111111";
            h.Direccion = "Aguero2219";
            t.testPropiedadesHija = h;

            lParam = t.ToDictionary(true, true);
            t.testPropiedadesHija.ToDictionary(true, true);


            return Ok(new { test = lParam }); //OK 200
        }

        
        /// <summary>
        /// PutTest1
        /// </summary>
        /// <param name="testmodel"></param>
        /// <returns> devuelve lo mismo que le envias </returns>
        [HttpPut]
        [AllowAnonymous]
        public ActionResult PutTest1([FromBody] TestModel testmodel)
        {
            return Ok(new { test = testmodel }); //OK 200
        }


        /// <summary>
        /// DeleteTest
        /// </summary>
        /// <param name="Id"></param>
        /// <returns> devuelve lo mismo que le envias </returns>
        [HttpDelete]
        [AllowAnonymous]
        public ActionResult DeleteTest1(int Id)
        {
            return Ok(new { test = Id.ToString() }); //OK 200
        }


        /// <summary>
        /// PatchTest
        /// </summary>
        /// <param name="testmodel"></param>
        /// <returns></returns>
        [HttpPatch]
        [AllowAnonymous]
        public ActionResult PatchTest1([FromBody] TestModel testmodel)
        {
            return Ok(new { test = testmodel }); //OK 200
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





        /// <summary>
        /// Solo pruebas pequenas
        /// </summary>
        /// <returns>
        /// 200
        /// </returns>
        //[HttpPost]
        //[AllowAnonymous]
        //public ActionResult Test() 
        //{
        //    TestPropiedades1 t = new TestPropiedades1();
        //    TestPropiedadesHija h = new TestPropiedadesHija();
        //    Dictionary<string, string> lParam = new Dictionary<string, string>();
        //    t.Id = 1;
        //    t.Nombre = "pepe";
        //    t.Apellido = "Gomez";
        //    h.Telefono = "1111111";
        //    h.Direccion = "Aguero2219";
        //    t.testPropiedadesHija = h;

        //    lParam = t.ToDictionary(true, true);

        //    return Ok(new { test = lParam }); //OK 200
        //}





    }
}
