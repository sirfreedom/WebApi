using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;
using System;
using WebApi.Biz;
using WebApi.Entity;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SettingController : Controller
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _ConectionString;

        public SettingController(ILogger<ValuesController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _ConectionString = _configuration.GetConnectionString("DefaultConnection");
        }


        /// <summary>
        /// La configuracion va directamente por la depencia, eso determina el titulo del cuestionario, la cantidad de preguntas por hoja, valor de aprobacion del cuestionario, si tiene algun archivo para descargar informacion, etc.
        /// </summary>
        /// <param name="IdDependency">
        /// la dependencia es el identificador y agrupamiento de las preguntas, y sirve para todo lo que tenga que ver con ellas.
        /// </param>
        /// <returns>
        /// siempre retornara un solo registro en formato entidad para configurar la aplicacion.
        /// </returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Get(int IdDependency)
        {
            Setting oSetting = new Setting();
            SettingBiz settingBiz = new SettingBiz(_ConectionString);
            try
            {
                oSetting = settingBiz.Get(IdDependency);
            }
            catch (WebException ex)
            {
                return ValidationProblem("Error", "Get", 500, ex.Message);
            }
            catch (Exception ex)
            {
                return ValidationProblem("Error", "Get", 500, ex.Message);
            }
            return Ok(new { setting = oSetting }); //OK 200
        }



    }
}
