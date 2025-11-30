using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using WebApi.Entity;
using WebApi.Biz;
using WebApi.Model;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class IncripcionController : Controller 
	{
		private readonly ILogger<IncripcionController> _logger;
		private readonly IConfiguration _configuration;
		private readonly string _ConectionString;


		public IncripcionController(ILogger<IncripcionController> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
			_ConectionString = _configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Lista Incripcion
		/// </summary>
		/// <returns>
		/// devuelve la lista de Incripcion. generalmente usado para combos y lugares donde no necesitarias un filtro
		/// </returns>
		[HttpGet("List")]
		[AllowAnonymous]
		public async Task<ActionResult> List()
		{
			IncripcionBiz oIncripcionBiz = new IncripcionBiz(_ConectionString);
			List<Incripcion> lIncripcion;
			try
			{
				lIncripcion = await Task.Run(() => oIncripcionBiz.List());
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
			return Ok(new { incripcion = lIncripcion }); //OK 200);
		}



		/// <summary>
		/// Inserta Incripcion
		/// </summary>
		/// <param name="incripcionModel">
		/// Inserta todos los campos de la entidad Incripcion.
		/// </param>
		/// <returns>
		/// devuelve un status: 201/204 si inserto correctamente 
		/// </returns>
		[HttpPost("Insert")]
		[AllowAnonymous]
		public async Task<ActionResult> Insert([FromBody] IncripcionModel incripcionModel)
		{
		IncripcionBiz oIncripcionBiz = new IncripcionBiz(_ConectionString); 
		Incripcion incripcion;
		try
		{
			incripcion = Incripcion.Merge<IncripcionModel, Incripcion>(incripcionModel);
 			await Task.Run(() => oIncripcionBiz.Insert(incripcion));
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
			return Created(); //OK 201);
		}



		/// <summary>
		/// Elimina un registro de  Incripcion
		/// </summary>
		/// <param name="Id">
		/// El Id es la clave unica PK de la entidad Incripcion.
		/// </param>
		/// <returns>
		/// devuelve Status: 200 en caso de haber eliminado correctamente 
		/// </returns>
		[HttpDelete("Delete")]
		[AllowAnonymous]
		public ActionResult Delete(int Id)
		{
		IncripcionBiz oIncripcionBiz = new IncripcionBiz(_ConectionString); 
		try
		{
			oIncripcionBiz.Delete(Id);
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