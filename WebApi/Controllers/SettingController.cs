using Microsoft.AspNetCore.Authorization;
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
        private readonly string _ConnectionString;

        public SettingController(ILogger<ValuesController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _ConnectionString = _configuration.GetConnectionString("DefaultConnection");
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
        [HttpGet("Get")]
        [AllowAnonymous]
        public ActionResult Get(int IdDependency)
        {
            Setting oSetting;
            SettingModel oSettingModel;
            SettingBiz settingBiz = new SettingBiz(_ConnectionString);
            try
            {
                oSetting = settingBiz.GetByDependency(IdDependency);
                oSettingModel = Setting.Merge<Setting,SettingModel>(oSetting);
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
            return Ok(new { setting = oSettingModel }); //OK 200
        }



        /// <summary>
        /// Update : Actualizacion de setting 
        /// </summary>
        /// <param name="settting"></param>
        /// <returns>
        /// retorna ok
        /// </returns>
        [HttpPut("Update")]
        [Authorize]
        public ActionResult Update([FromBody] Setting settting)
        {
            SettingBiz settingBiz = new SettingBiz(_ConnectionString);
            try
            {
                settingBiz.Update(settting);
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
            return Ok(new { setting = settting }); //OK 200
        }



        /// <summary>
        /// Insert : Inserta un setting
        /// </summary>
        /// <param name="settting"></param>
        /// <returns>
        /// ok 201/204 
        /// </returns>
        [HttpPost("Insert")]
        [Authorize]
        public ActionResult Insert([FromBody] SettingModel settting)
        {
            SettingBiz settingBiz = new SettingBiz(_ConnectionString);
            Setting oSetting;
            try
            {
                oSetting = Setting.Merge<SettingModel,Setting>(settting);
                settingBiz.Insert(oSetting);
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
            return Created(); //OK 201 / 204
        }


        /// <summary>
        /// Delete : Elimina un setting y todas las referencias disponibles
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>
        /// ok 200
        /// </returns>
        [HttpDelete("Delete")]
        [Authorize]
        public ActionResult Delete(int Id)
        {
            SettingBiz settingBiz = new SettingBiz(_ConnectionString);
            try
            {
                settingBiz.Delete(Id);
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
            return Ok(); //OK 200
        }




    }
}
