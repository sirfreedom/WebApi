using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using WebApi.Entity;
using WebApi.Biz;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class VaperProductController : Controller 
	{
		private readonly ILogger<VaperProductController> _logger;
		private readonly IConfiguration _configuration;
		private readonly string _ConectionString;

		public VaperProductController(ILogger<VaperProductController> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
			_ConectionString = _configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Lista VaperProduct
		/// </summary>
		/// <returns>
		/// devuelve la lista de Product. generalmente usado para combos y lugares donde no necesitarias un filtro
		/// </returns>
		[HttpGet("List")]
		[AllowAnonymous]
		public async Task<ActionResult> List()
		{
			VaperProductBiz oVaperProductBiz = new VaperProductBiz(_ConectionString);
			List<VaperProduct> lVaperProduct;
			try
			{
                lVaperProduct = await Task.Run(() => oVaperProductBiz.List());
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
			return Ok(new { listvaperproduct = lVaperProduct }); //OK 200
        }









	}

}