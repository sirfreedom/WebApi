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
		/// Lista HeadSlide, por IdAppConfig
		/// </summary>
		/// <returns>
		/// devuelve la lista de HeadSlide. generalmente usado para combos y lugares donde no necesitarias un filtro
		/// </returns>
		[HttpGet("Find")]
		[AllowAnonymous]
		public async Task<ActionResult> Find(int IdAppConfig)
		{
			HeadSlideBiz oHeadSlideBiz = new (_ConectionString);
			List<HeadSlide> lHeadSlide;
			try
			{
				lHeadSlide = await Task.Run(() => oHeadSlideBiz.Find(IdAppConfig));
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


	}

}