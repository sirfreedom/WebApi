using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;



namespace WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PdfReaderTest1Controller : Controller
    {
        private readonly ILogger<FileController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _ConectionString;

        public PdfReaderTest1Controller(ILogger<FileController> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _ConectionString = _configuration.GetConnectionString("DefaultConnection");
            _logger = logger;
        }


        /// <summary>
        /// Prueba de pdf
        /// </summary>
        /// <param name="archivoPdf"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Post([FromBody] IFormFile archivoPdf)
        {
            StringBuilder textoExtraido = new StringBuilder();
            try
            {
                if (archivoPdf == null || archivoPdf.Length == 0)
                {
                    return BadRequest("No se envió ningún archivo PDF.");
                }

                using (var stream = archivoPdf.OpenReadStream())
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
