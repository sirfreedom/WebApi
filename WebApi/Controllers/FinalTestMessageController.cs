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
    public class FinalTestMessageController : Controller
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _ConnectionString;

        public FinalTestMessageController(ILogger<ValuesController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _ConnectionString = _configuration.GetConnectionString("DefaultConnection");
        }


        /// <summary>
        /// Devuelve la lista de mensajes que se utilizan cuando uno completa el examen
        /// por ej, para los niveles 1 y 2, y para preguntas contestadas entre 1 y 10, el mensaje puede ser estuviste bien, pero deberias esforzarte mas.
        /// para los niveles 3 y 4, y para las preguntas contestadas entre 11 y 20, el mensaje puede ser estuviste genial.
        /// </summary>
        /// <param name="IdDependency">
        /// la dependencia es la agrupacion de un grupo de preguntas
        /// </param>
        /// <returns>
        /// devuelve la lista de mensajes asociados a niveles y valores de contestacion de preguntas.
        /// </returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> List(int IdDependency)
        {
            List<FinalTestMessage> lFinalTestMessage;
            FinalTestMessageBiz finalTestMessageBiz = new (_ConnectionString);
            try
            {
                lFinalTestMessage = await Task.Run(() => finalTestMessageBiz.List(IdDependency));
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "List", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "List", 500, ex.Message);
            }
            return Ok(new { finaltestmessage = lFinalTestMessage }); //OK 200
        }


        /// <summary>
        /// Devuelve un FinalTestMessage
        /// </summary>
        /// <param name="Id">
        /// El Id es la clave unica PK de la entidad FinalTestMessage.
        /// </param>
        /// <returns>
        /// devuelve un objeto unico del tipo FinalTestMessage .
        /// </returns>
        [HttpGet("Get")]
        [AllowAnonymous]
        public async Task<ActionResult> Get(int Id)
        {
            FinalTestMessageBiz oFinalTestMessageBiz = new (_ConnectionString);
            FinalTestMessage oFinalTestMessage;
            try
            {
                oFinalTestMessage = await Task.Run(() => oFinalTestMessageBiz.Get(Id));
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Get", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Get", 500, ex.Message);
            }
            return Ok(new { finaltestmessage = oFinalTestMessage }); //OK 200);
        }


        /// <summary>
        /// Actualiza FinalTestMessage
        /// </summary>
        /// <param name="finaltestmessage">
        /// Esta entidad permite actualizar todos los valores de la tabla FinalTestMessage.
        /// </param>
        /// <returns>
        /// devuelve Status: 200 en caso de haber actualizado correctamente 
        /// </returns>
        [HttpPut("Update")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Update([FromBody] FinalTestMessage finaltestmessage)
        {
            FinalTestMessageBiz oFinalTestMessageBiz = new FinalTestMessageBiz(_ConnectionString);
            try
            {
                await Task.Run(() => oFinalTestMessageBiz.Update(finaltestmessage));
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


        /// <summary>
        /// Inserta FinalTestMessage
        /// </summary>
        /// <param name="finaltestmessageModel">
        /// Inserta todos los campos de la entidad FinalTestMessage.
        /// </param>
        /// <returns>
        /// devuelve un status: 201/204 si inserto correctamente 
        /// </returns>
        [HttpPost("Insert")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Insert([FromBody] FinalTestMessageModel finaltestmessageModel)
        {
            FinalTestMessageBiz oFinalTestMessageBiz = new FinalTestMessageBiz(_ConnectionString);
            FinalTestMessage oFinalTestMessage;
            try
            {
                oFinalTestMessage = FinalTestMessage.Merge<FinalTestMessageModel, FinalTestMessage>(finaltestmessageModel);
                oFinalTestMessage = await Task.Run(() => oFinalTestMessageBiz.Insert(oFinalTestMessage));
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Insert", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Insert", 500, ex.Message);
            }
            return Created("finaltestmessage",oFinalTestMessage); //OK 201/204
        }


        /// <summary>
        /// Elimina un registro de  FinalTestMessage
        /// </summary>
        /// <param name="Id">
        /// El Id es la clave unica PK de la entidad FinalTestMessage.
        /// </param>
        /// <returns>
        /// devuelve Status: 200 en caso de haber eliminado correctamente 
        /// </returns>
        [HttpDelete("Delete")]
        [Authorize(Policy = "SuperAdmin")]
        public async Task<ActionResult> Delete(int Id)
        {
            FinalTestMessageBiz oFinalTestMessageBiz = new FinalTestMessageBiz(_ConnectionString);
            try
            {
                await Task.Run(() => oFinalTestMessageBiz.Delete(Id));
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Delete", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Delete", 500, ex.Message);
            }
            return Ok(); //OK 200
        }


        /// <summary>
        /// Disabled : deshabilita un FinalTestMessage para que no sea visible
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Disabled"></param>
        /// <returns>
        /// retorna un 200 ok.
        /// </returns>
        [HttpPatch("Disabled")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Disabled(int Id, bool Disabled)
        {
            FinalTestMessageBiz oFinalTestMessageBiz = new FinalTestMessageBiz(_ConnectionString);
            try
            {
                await Task.Run(() => oFinalTestMessageBiz.Disabled(Id,Disabled));
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Disabled", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Disabled", 500, ex.Message);
            }
            return Ok(); //OK 200
        }
    }
}
