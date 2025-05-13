using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;
using System;
using Microsoft.Extensions.Logging;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using WebApi.Model;
using System.IO;


namespace WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PdfReaderTest2Controller : Controller
    {

        private readonly ILogger<FileController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _ConectionString;

        public PdfReaderTest2Controller(ILogger<FileController> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _ConectionString = _configuration.GetConnectionString("DefaultConnection");
            _logger = logger;
        }



        /// <summary>
        /// Prueba de pdf
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Post([FromBody] PdfByteArrayRequestModel request)
        {
            StringBuilder textoExtraido = new StringBuilder();
            try
            {
                if (request?.PdfBytes == null || request.PdfBytes.Length == 0)
                    return BadRequest("No se recibió el PDF como arreglo de bytes.");
            
                using (var stream = new MemoryStream(request.PdfBytes))
                using (var reader = new PdfReader(stream))
                {
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        string texto = PdfTextExtractor.GetTextFromPage(reader, i);
                        textoExtraido.AppendLine(texto);
                    }
                }

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
            return Ok(new { texto = textoExtraido.ToString() });
        }







    }
}
