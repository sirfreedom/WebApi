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
    public class FileController : Controller
    {

        private readonly ILogger<FileController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _ConnectionString;

        public FileController(ILogger<FileController> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            _logger = logger;
        }

        /// <summary>
        /// List 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> List()
        {
            ImagenBiz Serv = new (_ConnectionString);
            List<ImagenTest> lImageTest;
            Dictionary<string,string> lParam = new ();
            ActionResult result;
            try
            {
                lImageTest = await Task.Run(() => Serv.List());
                result = await Task.Run(() => Ok(new { ImageList = lImageTest })); //OK 200
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                result = ValidationProblem("Error", "List", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                result = ValidationProblem("Error", "List", 500, ex.Message);
            }
            return result;
        }



        /// <summary>
        /// Post
        /// </summary>
        /// <param name="imagentext"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody] FileModel imagentext)
        {
            ImagenBiz Serv = new (_ConnectionString);
            ImagenTest oImagen = new ();
            try
            {
                oImagen = ImagenTest.Merge<FileModel, ImagenTest>(imagentext);
                await Task.Run(() => Serv.Insert(oImagen));
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Post", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Post", 500, ex.Message);
            }
            return Created(); //OK 201
        }


        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        [AllowAnonymous]
        public async Task<ActionResult> Delete(int Id)
        {
            ImagenBiz Serv = new (_ConnectionString);
            ImagenTest oImagen = new ();
            try
            {
                await Task.Run(() => Serv.Delete(Id));
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Post", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Post", 500, ex.Message);
            }
            return Ok(); //OK 200
        }



        /// <summary>
        /// Update 
        /// </summary>
        /// <param name="imagentext">
        /// Base64test
        /// </param>
        /// <returns>
        /// Devuelve una prueba 
        /// </returns>
        [HttpPut]
        [AllowAnonymous]
        public ActionResult Update([FromBody] FileModel imagentext)
        {
            try
            {
                
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message,ex.InnerException,ex.StackTrace);
                return ValidationProblem("Error", "Post", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Post", 500, ex.Message);
            }
            return Ok(new { Image = imagentext }); //OK 200
        }



   









    }
}
