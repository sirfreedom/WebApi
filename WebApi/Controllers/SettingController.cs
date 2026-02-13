using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
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
        /// Busca un Setting
        /// </summary>
        /// <returns>
        /// devuelve una lista dinamica de los valores obtenidos en la base de datos, puede alterar los valores sin problemas
        /// Esta lista dinamica, es convertible tranquilamente a un Model
        /// </returns>
        [HttpGet("Find")]
        [AllowAnonymous]
        public async Task<ActionResult> Find()
        {
            SettingBiz oSettingBiz = new (_ConnectionString);
            List<dynamic> ldynamic;
            try
            {
                ldynamic = await Task.Run(() => oSettingBiz.Find(new Dictionary<string, string>()));
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Find", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Find", 500, ex.Message);
            }
            return Ok(new { listsetting = ldynamic }); //OK 200);
        }


        /// <summary>
        /// GetByDependency :  La configuracion va directamente por la depencia, eso determina el titulo del cuestionario, la cantidad de preguntas por hoja, valor de aprobacion del cuestionario, si tiene algun archivo para descargar informacion, etc.
        /// </summary>
        /// <param name="Id">
        /// la dependencia es el identificador y agrupamiento de las preguntas, y sirve para todo lo que tenga que ver con ellas.
        /// </param>
        /// <returns>
        /// siempre retornara un solo registro en formato entidad para configurar la aplicacion.
        /// </returns>
        [HttpGet("Get")]
        [AllowAnonymous]
        public async Task<ActionResult> Get(int Id)
        {
            Setting oSetting;
            SettingBiz settingBiz = new (_ConnectionString);
            try
            {
                oSetting = await Task.Run(() => settingBiz.Get(Id));
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



        /// <summary>
        /// GetByDependency :  La configuracion va directamente por la depencia, eso determina el titulo del cuestionario, la cantidad de preguntas por hoja, valor de aprobacion del cuestionario, si tiene algun archivo para descargar informacion, etc.
        /// </summary>
        /// <param name="IdDependency">
        /// la dependencia es el identificador y agrupamiento de las preguntas, y sirve para todo lo que tenga que ver con ellas.
        /// </param>
        /// <returns>
        /// siempre retornara un solo registro en formato entidad para configurar la aplicacion.
        /// </returns>
        [HttpGet("GetByDependency")]
        [AllowAnonymous]
        public async Task<ActionResult> GetByDependency(int IdDependency)
        {
            Setting oSetting;
            SettingBiz settingBiz = new (_ConnectionString);
            try
            {
                oSetting = await Task.Run(() => settingBiz.GetByDependency(IdDependency));
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "GetByDependency", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "GetByDependency", 500, ex.Message);
            }
            return Ok(new { setting = oSetting }); //OK 200
        }


        /// <summary>
        /// Update : Actualizacion de setting 
        /// </summary>
        /// <returns>
        /// retorna ok
        /// </returns>
        [HttpPut("Update")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Update([FromBody] Setting setting)
        {
            SettingBiz settingBiz = new (_ConnectionString);
            try
            {
                await Task.Run(() => settingBiz.Update(setting));
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Update", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Update", 500, ex.Message);
            }
            return Ok(setting); //OK 200
        }



        /// <summary>
        /// Insert : Inserta un setting
        /// </summary>
        /// <param name="setting"></param>
        /// <returns>
        /// ok 201/204 
        /// </returns>
        [HttpPost("Insert")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Insert([FromBody] SettingModel setting)
        {
            SettingBiz settingBiz = new (_ConnectionString);
            Setting oSetting;
            try
            {
                if (setting.iddependency == 0 || setting.correctanswers == 0 || setting.questionperpage == 0 || setting.title.Length == 0 || setting.subtitle.Length == 0)
                {
                    return ValidationProblem("Validacion", "verifique los parametros", 400, "Validacion");
                }

                oSetting = Setting.Merge<SettingModel,Setting>(setting);
                oSetting = await Task.Run(() => settingBiz.Insert(oSetting));
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Insert", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Insert", 500, ex.Message);
            }
            return Created("setting",oSetting); //OK 201 / 204
        }


        /// <summary>
        /// Delete : Elimina un setting y todas las referencias disponibles
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>
        /// ok 200
        /// </returns>
        [HttpDelete("Delete")]
        [Authorize(Policy = "SuperAdmin")]
        public async Task<ActionResult> Delete(int Id)
        {
            SettingBiz settingBiz = new (_ConnectionString);
            try
            {
                await Task.Run(() => settingBiz.Delete(Id));
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Delete", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Delete", 500, ex.Message);
            }
            return Ok(); //OK 200
        }


        /// <summary>
        /// Disabled : deshabilita un setting para que no sea visible
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Disabled"></param>
        /// <returns>
        /// Devuelve un 200
        /// </returns>
        [HttpPatch("Disabled")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Disabled(int Id, bool Disabled)
        {
            SettingBiz settingBiz = new (_ConnectionString);
            try
            {
                await Task.Run(() => settingBiz.Disabled(Id,Disabled));
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Disabled", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Disabled", 500, ex.Message);
            }
            return Ok(); //OK 200
        }



    }
}
