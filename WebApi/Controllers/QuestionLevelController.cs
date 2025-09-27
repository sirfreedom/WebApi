using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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
    public class QuestionLevelController : Controller
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _ConnectionString;

        public QuestionLevelController(ILogger<ValuesController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _ConnectionString = _configuration.GetConnectionString("DefaultConnection");
        }


        /// <summary>
        /// Lista los niveles de las preguntas
        /// </summary>
        /// <param name="IdDependency">
        /// La dependencia es un valor definido para saber el agrupamiento de las preguntas
        /// </param>
        /// <returns>
        /// devuelve la lista completa de niveles con su codigo descripcion y propiedad de class
        /// </returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> List(int IdDependency)
        {
            List<QuestionLevel> lq;
            QuestionLevelBiz questionLevelBiz = new QuestionLevelBiz(_ConnectionString);
            try
            {
                lq = await Task.Run(() => questionLevelBiz.List(IdDependency));
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "List", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "List", 500, ex.Message);
            }
            return Ok(new { questionlevels = lq }); //OK 200
        }


        /// <summary>
        /// Devuelve un QuestionLevel
        /// </summary>
        /// <param name="Id">
        /// El Id es la clave unica PK de la entidad QuestionLevel.
        /// </param>
        /// <returns>
        /// devuelve un objeto unico del tipo QuestionLevel .
        /// </returns>
        [HttpGet("Get")]
        [AllowAnonymous]
        public async Task<ActionResult> Get(int Id)
        {
            QuestionLevelBiz oQuestionLevelBiz = new QuestionLevelBiz(_ConnectionString);
            QuestionLevel oQuestionLevel = new QuestionLevel();
            try
            {
                oQuestionLevel = await Task.Run(() => oQuestionLevelBiz.Get(Id));
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
            return Ok(new { questionlevel = oQuestionLevel }); //OK 200);
        }


        /// <summary>
        /// Actualiza QuestionLevel
        /// </summary>
        /// <param name="questionlevel">
        /// Esta entidad permite actualizar todos los valores de la tabla QuestionLevel.
        /// </param>
        /// <returns>
        /// devuelve Status: 200 en caso de haber actualizado correctamente 
        /// </returns>
        [HttpPut("Update")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Update([FromBody] QuestionLevel questionlevel)
        {
            QuestionLevelBiz oQuestionLevelBiz = new QuestionLevelBiz(_ConnectionString);
            try
            {
                await Task.Run(() => oQuestionLevelBiz.Update(questionlevel));
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
            return Ok(); //OK 200
        }


        /// <summary>
        /// Inserta QuestionLevel
        /// </summary>
        /// <param name="questionlevelModel">
        /// Inserta todos los campos de la entidad QuestionLevel.
        /// </param>
        /// <returns>
        /// devuelve un status: 201/204 si inserto correctamente 
        /// </returns>
        [HttpPost("Insert")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Insert([FromBody] QuestionLevelModel questionlevelModel)
        {
            QuestionLevelBiz oQuestionLevelBiz = new QuestionLevelBiz(_ConnectionString);
            QuestionLevel oQuestionLevel;
            try
            {
                oQuestionLevel = QuestionLevel.Merge<QuestionLevelModel, QuestionLevel>(questionlevelModel);
                oQuestionLevel = await Task.Run(() => oQuestionLevelBiz.Insert(oQuestionLevel));
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
            return Created("questionlevel",oQuestionLevel); //OK 201/204
        }


        /// <summary>
        /// Elimina un registro de  QuestionLevel
        /// </summary>
        /// <param name="Id">
        /// El Id es la clave unica PK de la entidad QuestionLevel.
        /// </param>
        /// <returns>
        /// devuelve Status: 200 en caso de haber eliminado correctamente 
        /// </returns>
        [HttpDelete("Delete")]
        [Authorize(Policy = "SuperAdmin")]
        public async Task<ActionResult> Delete(int Id)
        {
            QuestionLevelBiz oQuestionLevelBiz = new QuestionLevelBiz(_ConnectionString);
            try
            {
                await Task.Run(() => oQuestionLevelBiz.Delete(Id));
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
        /// Disabled : deshabilita un Question level para que no sea visiable.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Disabled"></param>
        /// <returns>
        /// devuelve un 200 ok
        /// </returns>
        [HttpPatch("Disabled")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Disabled(int Id, bool Disabled)
        {
            QuestionLevelBiz oQuestionLevelBiz = new QuestionLevelBiz(_ConnectionString);
            try
            {
                await Task.Run(() => oQuestionLevelBiz.Disabled(Id,Disabled));
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
