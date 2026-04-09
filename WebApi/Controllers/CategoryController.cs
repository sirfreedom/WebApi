using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using WebApi.Entity;
using WebApi.Biz;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _ConectionString;

        public CategoryController(ILogger<CategoryController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _ConectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Lista Categorias por IdAppConfig
        /// </summary>
        /// <returns>
        /// devuelve la lista de HeadSlide. generalmente usado para combos y lugares donde no necesitarias un filtro
        /// </returns>
        [HttpGet("Marquee")]
        [AllowAnonymous]
        public async Task<ActionResult> Marquee(int IdAppConfig)
        {
            CategoryBiz oCategoryBiz = new(_ConectionString);
            List<Category> lCategory;
            try
            {
                lCategory = await Task.Run(() => oCategoryBiz.Marquee(IdAppConfig));
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
            return Ok(new { listcategory = lCategory }); //OK 200);
        }


    }
}
