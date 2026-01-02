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
        /// Find 
        /// </summary>
        /// <param name="IdTipoContacto"></param>
        /// <param name="Carrera"></param>
        /// <param name="MM">
        /// month inicio
        /// </param>
        /// <param name="YY">
        /// year inicio
        /// </param>
        /// <returns></returns>
        [HttpGet("Find")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Find(int IdTipoContacto, string Carrera = "", int MM= 0,int YY=0)
        {
            InscripcionBiz oIncripcionBiz = new (_ConectionString);
            List<dynamic> lIncripcion;
			List<InscripcionFindModel> lIncripcionFindModel = new List<InscripcionFindModel>();
            Dictionary<string, string> lParam = new Dictionary<string, string>();
            try
            {
				lParam.Add("IdTipoContacto", IdTipoContacto.ToString());
                lParam.Add("Carrera", Carrera);
                lParam.Add("MM",MM.ToString());
                lParam.Add("YY",YY.ToString());

                lIncripcion = await Task.Run(() => oIncripcionBiz.Find(lParam));
				lIncripcionFindModel = Inscripcion.ToList<InscripcionFindModel>(lIncripcion);
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
            return Ok(new { inscripciones = lIncripcionFindModel }); //OK 200);
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
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Insert([FromBody] List<InscripcionInsertModel> inscripcionModel)
        {
			InscripcionBiz oIncripcionBiz = new (_ConectionString);
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
        /// Chequea que un registro fue contactado
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="IsContacted"></param>
        /// <returns></returns>
        [HttpPatch("Contacted")]
        [AllowAnonymous]
        public ActionResult Contacted(int Id, bool IsContacted)
        {
            InscripcionBiz oIncripcionBiz = new(_ConectionString);
            try
            {
                oIncripcionBiz.Conected(Id, IsContacted);
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
        /// Actualiza el estado de error de una inscripcion
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="IsError"></param>
        /// <returns></returns>
        [HttpPatch("Error")]
        [AllowAnonymous]
        public ActionResult Error(int Id, bool IsError)
        {
            InscripcionBiz oIncripcionBiz = new(_ConectionString);
            try
            {
                oIncripcionBiz.Error(Id, IsError);
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
