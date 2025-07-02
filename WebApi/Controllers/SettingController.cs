using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using WebApi.Biz;
using WebApi.Entity;
using WebApi.Model;

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
            Setting oSetting;
            SettingBiz settingBiz = new SettingBiz(_ConectionString);
            try
            {
                oSetting = settingBiz.GetByDependency(IdDependency);
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Get", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Get", 500, ex.Message);
            }
            return Ok(new { setting = oSetting }); //OK 200
        }


        [HttpPut]
        [Authorize]
        public ActionResult Update([FromBody] SettingModel setttingmodel)
        {
            //SettingBiz settingBiz = new SettingBiz(_ConectionString);
            try
            {
                //oSetting = settingBiz.GetByDependency(IdDependency);
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Get", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Get", 500, ex.Message);
            }
            return Ok(new { setting = setttingmodel }); //OK 200
        }



        [HttpPost]
        [Authorize]
        public ActionResult Insert([FromBody] SettingModel setttingmodel)
        {
            //SettingBiz settingBiz = new SettingBiz(_ConectionString);
            try
            {
                //oSetting = settingBiz.GetByDependency(IdDependency);
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Get", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Get", 500, ex.Message);
            }
            return Ok(new { setting = setttingmodel }); //OK 200
        }



        [HttpDelete]
        [Authorize]
        public ActionResult Delete(int Id)
        {
            //SettingBiz settingBiz = new SettingBiz(_ConectionString);
            try
            {
                //oSetting = settingBiz.GetByDependency(IdDependency);
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Get", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Get", 500, ex.Message);
            }
            return Ok(new { Id = Id }); //OK 200
        }




    }
}
