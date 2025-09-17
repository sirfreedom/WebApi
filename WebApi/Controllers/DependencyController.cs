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
using System.Threading.Tasks;


namespace WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class DependencyController : Controller 
	{
		private readonly ILogger<DependencyController> _logger;
		private readonly IConfiguration _configuration;
		private readonly string _ConnectionString;


		public DependencyController(ILogger<DependencyController> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
			_ConnectionString = _configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Lista Dependency
		/// </summary>
		/// <returns>
		/// devuelve la lista de Dependency. generalmente usado para combos y lugares donde no necesitarias un filtro
		/// </returns>
		[HttpGet("List")]
		[AllowAnonymous]
		public ActionResult List()
		{
		DependencyBiz oDependencyBiz = new DependencyBiz(_ConnectionString); 
		List<Dependency> lDependency;
		try 
		{
			lDependency = oDependencyBiz.List().Result;
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
		return Ok(new {  dependencies = lDependency }); //OK 200);
		}


		/// <summary>
		/// Devuelve un Dependency
		/// </summary>
		/// <param name="Id">
		/// El Id es la clave unica PK de la entidad Dependency.
		/// </param>
		/// <returns>
		/// devuelve un objeto unico del tipo Dependency .
		/// </returns>
		[HttpGet("Get")]
		[AllowAnonymous]
		public async Task<ActionResult> Get(int Id) 
		{
		DependencyBiz oDependencyBiz = new DependencyBiz(_ConnectionString); 
		Dependency oDependency = new Dependency();
		try
		{
			oDependency = await oDependencyBiz.Get(Id);
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
		return Ok(new {  dependency = oDependency}); //OK 200);
		}


		/// <summary>
		/// Actualiza Dependency
		/// </summary>
		/// <param name="dependency">
		/// Esta entidad permite actualizar todos los valores de la tabla Dependency.
		/// </param>
		/// <returns>
		/// devuelve Status: 200 en caso de haber actualizado correctamente 
		/// </returns>
		[HttpPut("Update")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Update([FromBody] Dependency dependency)
		{
		DependencyBiz oDependencyBiz = new DependencyBiz(_ConnectionString); 
		try
		{
			await oDependencyBiz.Update(dependency); 
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
		/// Inserta Dependency
		/// </summary>
		/// <param name="dependencyModel">
		/// Inserta todos los campos de la entidad Dependency.
		/// </param>
		/// <returns>
		/// devuelve un status: 201/204 si inserto correctamente 
		/// </returns>
		[HttpPost("Insert")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Insert([FromBody] DependencyModel dependencyModel)
		{
		DependencyBiz oDependencyBiz = new DependencyBiz(_ConnectionString);
			Dependency oDependency;
		try
		{
			oDependency = Dependency.Merge<DependencyModel, Dependency>(dependencyModel);
			oDependency = await oDependencyBiz.Insert(oDependency);
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
		return Created("dependency",oDependency); //OK 201/204
		}


		/// <summary>
		/// Elimina un registro de  Dependency
		/// </summary>
		/// <param name="Id">
		/// El Id es la clave unica PK de la entidad Dependency.
		/// </param>
		/// <returns>
		/// devuelve Status: 200 en caso de haber eliminado correctamente 
		/// </returns>
		[HttpDelete("Delete")]
        [Authorize(Policy = "SuperAdmin")]
        public async Task<ActionResult> Delete(int Id)
		{
		DependencyBiz oDependencyBiz = new DependencyBiz(_ConnectionString); 
		try
		{
			await oDependencyBiz.Delete(Id);
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
		/// Disabled : deshabilita un Dependency para que no sea visible
		/// </summary>
		/// <param name="Id"></param>
		/// <param name="Disabled"></param>
		/// <returns></returns>
        [HttpPatch("Disabled")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Disabled(int Id, bool Disabled)
        {
            DependencyBiz oDependencyBiz = new DependencyBiz(_ConnectionString);
            try
            {
                await oDependencyBiz.Disabled(Id, Disabled);
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