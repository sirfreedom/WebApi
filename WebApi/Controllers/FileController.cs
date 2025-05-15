using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;
using System;
using WebApi.Model;
using WebApi.Entity;
using System.Collections.Generic;
using WebApi.Biz;
using Microsoft.Extensions.Logging;



namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : Controller
    {

        private readonly ILogger<FileController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _ConectionString;

        public FileController(ILogger<FileController> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _ConectionString = _configuration.GetConnectionString("DefaultConnection");
            _logger = logger;
        }


        /// <summary>
        /// Lista todas las imagenes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult List()
        {
            ImagenBiz Serv = new ImagenBiz(_ConectionString);
            List<ImagenTest> lImageTest;
            try
            {
                lImageTest = lImageTest = Serv.List();
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
            return Ok(new { ImageList = lImageTest }); //OK 200
        }



        /// <summary>
        /// Prueba de imagen
        /// </summary>
        /// <param name="imagentext"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Post([FromBody] FileModel imagentext)
        {
            ImagenBiz Serv = new ImagenBiz(_ConectionString);
            ImagenTest oImagen = new ImagenTest();
            try
            {
                oImagen = ImagenTest.Merge<FileModel, ImagenTest>(imagentext);
                Serv.Insert(oImagen);
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
        /// Elimina una imagen
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        [AllowAnonymous]
        public ActionResult Delete(int Id)
        {
            ImagenBiz Serv = new ImagenBiz(_ConectionString);
            ImagenTest oImagen = new ImagenTest();
            try
            {
                Serv.Delete(Id);
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
