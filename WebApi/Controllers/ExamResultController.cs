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
	public class ExamResultController : Controller 
	{
		private readonly ILogger<ExamResultController> _logger;
		private readonly IConfiguration _configuration;
		private readonly string _ConectionString;


		public ExamResultController(ILogger<ExamResultController> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
			_ConectionString = _configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Busca un ExamResult
		/// </summary>
		/// <param name="examresultFindModel">
		/// Esta entidad permite filtrar de manera sensilla por todos los campos que contiene
		/// Los valores que son filtrables son de tipo string. 
		/// ESTE METODO NO SE PUEDE PROBAR CON SWAGGER, intente probarlo con Postman u otro programa
		/// </param>
		/// <returns>
		/// devuelve una lista dinamica de los valores obtenidos en la base de datos, puede alterar los valores sin problemas
		/// Esta lista dinamica, es convertible tranquilamente a un Model
		/// </returns>
		[HttpGet("Find")]
		[AllowAnonymous]
		public async Task<ActionResult> Find ([FromBody] ExamResultFindModel examresultFindModel)
		{
		ExamResultBiz oExamResultBiz = new ExamResultBiz(_ConectionString); 
		List<dynamic> ldynamic;
		try
		{
                ldynamic = await Task.Run(() => oExamResultBiz.Find(ExamResult.ToDictionary<ExamResultFindModel>(examresultFindModel)));
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
		return Ok(new {  listexamresult = ldynamic}); //OK 200);
		}


		/// <summary>
		/// Inserta ExamResult
		/// </summary>
		/// <param name="examresultModel">
		/// Inserta todos los campos de la entidad ExamResult.
		/// </param>
		/// <returns>
		/// devuelve un status: 201/204 si inserto correctamente 
		/// </returns>
		[HttpPost("Insert")]
		[AllowAnonymous]
		public async Task<ActionResult> Insert([FromBody] ExamResultModel examresultModel)
		{
		ExamResultBiz oExamResultBiz = new ExamResultBiz(_ConectionString); 
		ExamResult examresult = new ExamResult();
		try
		{
			examresult = ExamResult.Merge<ExamResultModel, ExamResult>(examresultModel);
            await Task.Run(() =>  oExamResultBiz.Insert(examresult));
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


	}

}