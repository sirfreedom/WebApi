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

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoInscripcionController : Controller
    {

        private readonly ILogger<InscripcionController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _ConectionString;

        public TipoInscripcionController(ILogger<InscripcionController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _ConectionString = _configuration.GetConnectionString("DefaultConnection");
        }


        /// <summary>
        /// Lista los tipos de inscripcion
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> List()
        {
            TipoInscripcionBiz oInscripcionBiz = new(_ConectionString);
            List<TipoInscripcion> lTipoInscripcion = new List<TipoInscripcion>();
            try
            {
                lTipoInscripcion = await Task.Run(() => oInscripcionBiz.List());
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
            return Ok(new { tipoinscripciones = lTipoInscripcion }); //OK 200);
        }

        /// <summary>
        /// Lista los tipos de inscripcion en el menu
        /// </summary>
        /// <returns>
        /// 200 ok - Devuelve la lista de tipos de inscripcion
        /// </returns>
        [HttpGet("ListMenu")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> ListMenu()
        {
            TipoInscripcionBiz oInscripcionBiz = new(_ConectionString);
            List<TipoInscripcion> lTipoInscripcion = new List<TipoInscripcion>();
            try
            {
                lTipoInscripcion = await Task.Run(() => oInscripcionBiz.ListMenu());
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
            return Ok(new { tipoinscripciones = lTipoInscripcion }); //OK 200);
        }


        /// <summary>
        /// Lista los tipos de inscripcion
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Get(int Id)
        {
            TipoInscripcionBiz oInscripcionBiz = new(_ConectionString);
            TipoInscripcion tipoInscripcion = new TipoInscripcion();
            try
            {
                tipoInscripcion = await Task.Run(() => oInscripcionBiz.Get(Id));
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
            return Ok(new { tiopinscripciones = tipoInscripcion }); //OK 200);
        }



        [HttpPut("Update")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Update([FromBody] TipoInscripcion tipoInscripcion)
        {
            TipoInscripcionBiz oInscripcionBiz = new(_ConectionString);
            try
            {
                await Task.Run(() => oInscripcionBiz.Update(tipoInscripcion));
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Update", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Update", 500, ex.Message);
            }
            return Ok(); //OK 200
        }





    }
}
