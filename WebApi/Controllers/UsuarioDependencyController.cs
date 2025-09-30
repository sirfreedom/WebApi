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
	public class UsuarioDependencyController : Controller 
	{
		private readonly ILogger<UsuarioDependencyController> _logger;
		private readonly IConfiguration _configuration;
		private readonly string _ConectionString;


		public UsuarioDependencyController(ILogger<UsuarioDependencyController> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
			_ConectionString = _configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Lista UsuarioDependency
		/// </summary>
		/// <returns>
		/// devuelve la lista de UsuarioDependency. generalmente usado para combos y lugares donde no necesitarias un filtro
		/// </returns>
		[HttpGet("List")]
		[AllowAnonymous]
		public ActionResult List()
		{
		UsuarioDependencyBiz oUsuarioDependencyBiz = new UsuarioDependencyBiz(_ConectionString); 
		List<UsuarioDependency> lUsuarioDependency;
		try 
		{
			lUsuarioDependency = oUsuarioDependencyBiz.List();
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
		return Ok(new {  listusuariodependency = lUsuarioDependency }); //OK 200);
		}



		/// <summary>
		/// Inserta UsuarioDependency
		/// </summary>
		/// <param name="usuariodependencyModel">
		/// Inserta todos los campos de la entidad UsuarioDependency.
		/// </param>
		/// <returns>
		/// devuelve un status: 201/204 si inserto correctamente 
		/// </returns>
		[HttpPost("Insert")]
		[AllowAnonymous]
		public ActionResult Insert([FromBody] UsuarioDependencyModel usuariodependencyModel)
		{
		UsuarioDependencyBiz oUsuarioDependencyBiz = new UsuarioDependencyBiz(_ConectionString); 
		UsuarioDependency usuariodependency = new UsuarioDependency();
		try
		{
			usuariodependency = UsuarioDependency.Merge<UsuarioDependencyModel, UsuarioDependency>(usuariodependencyModel);
			oUsuarioDependencyBiz.Insert(usuariodependency);
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