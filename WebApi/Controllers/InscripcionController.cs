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
	public class InscripcionController : Controller 
	{
		private readonly ILogger<InscripcionController> _logger;
		private readonly IConfiguration _configuration;
		private readonly string _ConectionString;


		public InscripcionController(ILogger<InscripcionController> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
			_ConectionString = _configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Lista Inscripcion
		/// </summary>
		/// <returns>
		/// devuelve la lista de Inscripcion. generalmente usado para combos y lugares donde no necesitarias un filtro
		/// </returns>
		[HttpGet("List")]
		[AllowAnonymous]
		public async Task<ActionResult> List()
		{
			InscripcionBiz oIncripcionBiz = new InscripcionBiz(_ConectionString);
			List<Inscripcion> lIncripcion;
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
        /// Find 
        /// </summary>
        /// <param name="inscripcionFindModel">
        /// Filtros
        /// </param>
        /// <returns>
        /// Retorna las filas de Inscripcion segun los filtros enviados
        /// </returns>
        [HttpGet("Find")]
        [AllowAnonymous]
        public async Task<ActionResult> Find(InscripcionFindModel inscripcionFindModel)
        {
            InscripcionBiz oIncripcionBiz = new InscripcionBiz(_ConectionString);
            List<dynamic> lIncripcion;
			Dictionary<string, string> lParam = new Dictionary<string, string>();
            try
            {
				lParam = Inscripcion.ToDictionary<InscripcionFindModel>(inscripcionFindModel);
                lIncripcion = await Task.Run(() => oIncripcionBiz.Find(lParam));
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
        /// Inserta Inscripcion
        /// </summary>
        /// <param name="inscripcionModel">
        /// Inserta todos los campos de la entidad Incripcion.
        /// </param>
        /// <returns>
        /// devuelve un status: 201/204 si inserto correctamente 
        /// </returns>
        [HttpPost("Insert")]
		[AllowAnonymous]
        public async Task<ActionResult> Insert([FromBody] List<InscripcionInsertModel> inscripcionModel)
        {
			InscripcionBiz oIncripcionBiz = new InscripcionBiz(_ConectionString);
			string sXml = string.Empty;
            try
			{
                sXml = Inscripcion.ToXml(inscripcionModel);
                await Task.Run(() => oIncripcionBiz.Insert(sXml));
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
		/// Elimina un registro de  Inscripcion
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
		InscripcionBiz oIncripcionBiz = new InscripcionBiz(_ConectionString); 
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
