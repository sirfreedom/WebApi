using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using WebApi.Entity;
using WebApi.Biz;

using WebApi.Model;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AnswerController : Controller 
	{
		private readonly ILogger<AnswerController> _logger;
		private readonly IConfiguration _configuration;
		private readonly string _ConectionString;


		public AnswerController(ILogger<AnswerController> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
			_ConectionString = _configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Devuelve un Answer
		/// </summary>
		/// <param name="Id">
		/// El Id es la clave unica PK de la entidad Answer.
		/// </param>
		/// <returns>
		/// devuelve un objeto unico del tipo Answer .
		/// </returns>
		[HttpGet("Get")]
		[AllowAnonymous]
		public ActionResult Get(int Id) 
		{
		AnswerBiz oAnswerBiz = new AnswerBiz(_ConectionString); 
		Answer oAnswer = new Answer();
		try
		{
			oAnswer = oAnswerBiz.Get(Id).Result;
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
		return Ok(new {  answer = oAnswer}); //OK 200);
		}


		/// <summary>
		/// Actualiza Answer
		/// </summary>
		/// <param name="answer">
		/// Esta entidad permite actualizar todos los valores de la tabla Answer.
		/// </param>
		/// <returns>
		/// devuelve Status: 200 en caso de haber actualizado correctamente 
		/// </returns>
		[HttpPut("Update")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Update([FromBody] Answer answer)
		{
		AnswerBiz oAnswerBiz = new AnswerBiz(_ConectionString); 
		try
		{
			await oAnswerBiz.Update(answer); 
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
		/// Inserta Answer
		/// </summary>
		/// <param name="answerModel">
		/// Inserta todos los campos de la entidad Answer.
		/// </param>
		/// <returns>
		/// devuelve un status: 201/204 si inserto correctamente 
		/// </returns>
		[HttpPost("Insert")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Insert([FromBody] AnswerModel answerModel)
		{
			AnswerBiz oAnswerBiz = new AnswerBiz(_ConectionString);
			Answer oAnswer;
			try
			{
				oAnswer = Answer.Merge<AnswerModel, Answer>(answerModel);
				oAnswer = await oAnswerBiz.Insert(oAnswer);
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
			return Created("answer", oAnswer); //OK 201/204
		}


		/// <summary>
		/// Elimina un registro de  Answer
		/// </summary>
		/// <param name="Id">
		/// El Id es la clave unica PK de la entidad Answer.
		/// </param>
		/// <returns>
		/// devuelve Status: 200 en caso de haber eliminado correctamente 
		/// </returns>
		[HttpDelete("Delete")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Delete(int Id)
		{
		AnswerBiz oAnswerBiz = new AnswerBiz(_ConectionString); 
		try
		{
			await oAnswerBiz.Delete(Id);
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
		/// Disabled : deshabilita un Answer para que no pueda ser visible
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
            AnswerBiz oAnswerBiz = new AnswerBiz(_ConectionString);
            try
            {
                await oAnswerBiz.Disabled(Id, Disabled);
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