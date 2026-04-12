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
    public class UserRateController : Controller
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _ConnectionString;

        public UserRateController(ILogger<ValuesController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _ConnectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// devuelve los rating de los usuarios de un vendedor
        /// </summary>
        /// <returns>
        /// devuelve una lista dinamica de los valores obtenidos en la base de datos, puede alterar los valores sin problemas
        /// Esta lista dinamica, es convertible tranquilamente a un Model
        /// </returns>
        [HttpGet("GetRating")]
        [AllowAnonymous]
        public async Task<ActionResult> GetRating(int IdUserDataSeller)
        {
            UserRateBiz oUserRateBiz = new(_ConnectionString);
            List<UserRate> lUserRate;
            Dictionary<string, string> lParam = new();
            try
            {
                lParam.Add("IdUserDataSeller", IdUserDataSeller.ToString());
                lUserRate = await Task.Run(() => oUserRateBiz.GetRating(IdUserDataSeller));
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Find", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Find", 500, ex.Message);
            }
            return Ok(new { listuserrate = lUserRate }); //OK 200);
        }

    }
}
