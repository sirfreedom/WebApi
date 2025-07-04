using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using WebApi.Entity;
using WebApi.Biz;

using WebApi.Model;

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
			oAnswer = oAnswerBiz.Get(Id);
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
		[AllowAnonymous]
		public ActionResult Update([FromBody] Answer answer)
		{
		AnswerBiz oAnswerBiz = new AnswerBiz(_ConectionString); 
		try
		{
			oAnswerBiz.Update(answer); 
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
		[AllowAnonymous]
		public ActionResult Insert([FromBody] AnswerModel answerModel)
		{
		AnswerBiz oAnswerBiz = new AnswerBiz(_ConectionString); 
		Answer answer = new Answer();
		try
		{
			answer = Answer.Merge<AnswerModel, Answer>(answerModel);
			oAnswerBiz.Insert(answer);
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
		return Created(); //OK 201/204
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
		[AllowAnonymous]
		public ActionResult Delete(int Id)
		{
		AnswerBiz oAnswerBiz = new AnswerBiz(_ConectionString); 
		try
		{
			oAnswerBiz.Delete(Id);
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