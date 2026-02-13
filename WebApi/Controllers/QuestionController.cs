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
    public class QuestionController : Controller
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _ConnectionString;

        public QuestionController(ILogger<ValuesController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _ConnectionString = _configuration.GetConnectionString("DefaultConnection");
        }


        /// <summary>
        /// Devueve todas las preguntas y respuestas de una dependencia
        /// </summary>
        /// <param name="IdDependency">
        /// agrupamiento de preguntas
        /// </param>
        /// <param name="CodLevel">
        /// El nivel, es el nivel guardado de las preguntas puede haber varios niveles de preguntas dependiendo de la dependencia solicitada.
        /// </param>
        /// <returns>
        /// La estructura de la pregunta es, la pregunta, un codigo, y posibles respuestas.
        /// </returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> List(int IdDependency, int CodLevel=0)
        {
            List<Question> lq = new ();
            QuestionBiz questionBiz = new (_ConnectionString);
            try
            {
                lq = await Task.Run(() => questionBiz.List(IdDependency,CodLevel));
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
            return Ok(new { questions = lq }); //OK 200
        }


        /// <summary>
        /// Devuelve un Question
        /// </summary>
        /// <param name="Id">
        /// El Id es la clave unica PK de la entidad Question.
        /// </param>
        /// <returns>
        /// devuelve un objeto unico del tipo Question .
        /// </returns>
        [HttpGet("Get")]
        [AllowAnonymous]
        public async Task<ActionResult> Get(int Id)
        {
            QuestionBiz oQuestionBiz = new (_ConnectionString);
            Question oQuestion;
            try
            {
                oQuestion = await Task.Run(() => oQuestionBiz.Get(Id));
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
            return Ok(new { question = oQuestion }); //OK 200);
        }


        /// <summary>
        /// Actualiza Question
        /// </summary>
        /// <param name="question">
        /// Esta entidad permite actualizar todos los valores de la tabla Question.
        /// </param>
        /// <returns>
        /// devuelve Status: 200 en caso de haber actualizado correctamente 
        /// </returns>
        [HttpPut("Update")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Update([FromBody] Question question)
        {
            QuestionBiz oQuestionBiz = new QuestionBiz(_ConnectionString);
            try
            {
                await Task.Run(() => oQuestionBiz.Update(question));
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
        /// Inserta Question
        /// </summary>
        /// <param name="questionModel">
        /// Inserta todos los campos de la entidad Question.
        /// </param>
        /// <returns>
        /// devuelve un status: 201/204 si inserto correctamente 
        /// </returns>
        [HttpPost("Insert")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Insert([FromBody] QuestionModel questionModel)
        {
            QuestionBiz oQuestionBiz = new QuestionBiz(_ConnectionString);
            Question oQuestion;
            try
            {
                oQuestion = Question.Merge<QuestionModel, Question>(questionModel);
                oQuestion = await Task.Run(() => oQuestionBiz.Insert(oQuestion));
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
            return Created("question",oQuestion); //OK 201/204
        }


        /// <summary>
        /// Elimina un registro de  Question
        /// </summary>
        /// <param name="Id">
        /// El Id es la clave unica PK de la entidad Question.
        /// </param>
        /// <returns>
        /// devuelve Status: 200 en caso de haber eliminado correctamente 
        /// </returns>
        [HttpDelete("Delete")]
        [Authorize(Policy = "SuperAdmin")]
        public async Task<ActionResult> Delete(int Id)
        {
            QuestionBiz oQuestionBiz = new QuestionBiz(_ConnectionString);
            try
            {
                await Task.Run(() => oQuestionBiz.Delete(Id));
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
        /// Disabled : deshabilita un Question para que no sea visiable
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
            QuestionLevelBiz oQuestionLevelBiz = new (_ConnectionString);
            try
            {
                await Task.Run(() => oQuestionLevelBiz.Disabled(Id, Disabled));
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
