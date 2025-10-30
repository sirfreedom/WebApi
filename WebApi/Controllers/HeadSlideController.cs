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
	public class HeadSlideController : Controller 
	{
		private readonly ILogger<HeadSlideController> _logger;
		private readonly IConfiguration _configuration;
		private readonly string _ConectionString;


		public HeadSlideController(ILogger<HeadSlideController> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
			_ConectionString = _configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Lista HeadSlide
		/// </summary>
		/// <returns>
		/// devuelve la lista de HeadSlide. generalmente usado para combos y lugares donde no necesitarias un filtro
		/// </returns>
		[HttpGet("List")]
		[AllowAnonymous]
		public async Task<ActionResult> List()
		{
			HeadSlideBiz oHeadSlideBiz = new HeadSlideBiz(_ConectionString);
			List<HeadSlide> lHeadSlide;
			try
			{
				lHeadSlide = await Task.Run(() => oHeadSlideBiz.List());
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
			return Ok(new { listheadslide = lHeadSlide }); //OK 200);
		}


		/// <summary>
		/// Inserta HeadSlide
		/// </summary>
		/// <param name="HeadSlideModel">
		/// Inserta todos los campos de la entidad HeadSlide.
		/// </param>
		/// <returns>
		/// devuelve un status: 201/204 si inserto correctamente 
		/// </returns>
		[HttpPost("Insert")]
		[AllowAnonymous]
		public async Task<ActionResult> Insert([FromBody] HeadSlideModel HeadSlideModel)
		{
			HeadSlideBiz oHeadSlideBiz = new HeadSlideBiz(_ConectionString);
			HeadSlide oHeadSlide;
			try
			{
				oHeadSlide = HeadSlide.Merge<HeadSlideModel, HeadSlide>(HeadSlideModel);
				oHeadSlide = await Task.Run(() => oHeadSlideBiz.Insert(oHeadSlide));
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
			return Ok(new { headslide = oHeadSlide }); //OK 200);
		}

		/// <summary>
		/// Elimina un registro de  HeadSlide
		/// </summary>
		/// <param name="Id">
		/// El Id es la clave unica PK de la entidad HeadSlide.
		/// </param>
		/// <returns>
		/// devuelve Status: 200 en caso de haber eliminado correctamente 
		/// </returns>
		[HttpDelete("Delete")]
		[AllowAnonymous]
		public ActionResult Delete(int Id)
		{
			HeadSlideBiz oHeadSlideBiz = new HeadSlideBiz(_ConectionString);
			try
			{
				oHeadSlideBiz.Delete(Id);
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