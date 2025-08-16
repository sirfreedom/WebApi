using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
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
        public ActionResult List(int IdDependency, int CodLevel=0)
        {
            List<Question> lq = new List<Question>();
            QuestionBiz questionBiz = new QuestionBiz(_ConnectionString);
            try
            {
                lq = questionBiz.List(IdDependency,CodLevel);
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
        public ActionResult Get(int Id)
        {
            QuestionBiz oQuestionBiz = new QuestionBiz(_ConnectionString);
            Question oQuestion = new Question();
            try
            {
                oQuestion = oQuestionBiz.Get(Id);
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Get", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Get ", 500, ex.Message);
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
        public ActionResult Update([FromBody] Question question)
        {
            QuestionBiz oQuestionBiz = new QuestionBiz(_ConnectionString);
            try
            {
                oQuestionBiz.Update(question);
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Get", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Get ", 500, ex.Message);
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
        public ActionResult Insert([FromBody] QuestionModel questionModel)
        {
            QuestionBiz oQuestionBiz = new QuestionBiz(_ConnectionString);
            Question oQuestion;
            try
            {
                oQuestion = Question.Merge<QuestionModel, Question>(questionModel);
                oQuestion = oQuestionBiz.Insert(oQuestion);
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Get", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Get ", 500, ex.Message);
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
        public ActionResult Delete(int Id)
        {
            QuestionBiz oQuestionBiz = new QuestionBiz(_ConnectionString);
            try
            {
                oQuestionBiz.Delete(Id);
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Get", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Get ", 500, ex.Message);
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
        public ActionResult Disabled(int Id, bool Disabled)
        {
            QuestionLevelBiz oQuestionLevelBiz = new QuestionLevelBiz(_ConnectionString);
            try
            {
                oQuestionLevelBiz.Disabled(Id, Disabled);
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Get", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Get ", 500, ex.Message);
            }
            return Ok(); //OK 200
        }


    }
}
