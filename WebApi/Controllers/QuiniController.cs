using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApi.Biz;
using WebApi.Entity;

namespace WebApi.Controllers
{

    //[EnableCors("MyPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class QuiniController : Controller
    {

        /// <summary>
        /// funcion que permite obtener todos los numeros ganadores de la fecha o periodo solicitado
        /// </summary>
        /// <param name="dd"></param>
        /// <param name="mm"></param>
        /// <param name="yyyy"></param>
        /// <returns>
        /// devuelve n1 n2 n3 n4 n5 n6 en secuencia de los numeros ganadores de la fecha o periodo solicitado
        /// </returns>
        [HttpGet("Get")]
        [AllowAnonymous]
        //[DisableCors]
        public ActionResult Get(Byte dd, Byte mm, int yyyy)
        {
            Quini oQuini;
            List<Quini> lQuini = new List<Quini>();
            QuiniBiz oQuiniBiz = new QuiniBiz();
            try
            {

                if (dd == 0 & mm == 0 && yyyy != 0)
                {
                    lQuini = oQuiniBiz.Get(yyyy);
                }

                if (dd == 0 && mm != 0 && yyyy != 0)
                {
                    lQuini = oQuiniBiz.Get(mm, yyyy);
                }

                if (dd != 0 && mm != 0 && yyyy != 0 && oQuiniBiz.ValidarFecha(dd, mm, yyyy) != string.Empty)
                {
                    oQuini = oQuiniBiz.Get(dd, mm, yyyy);
                    lQuini.Add(oQuini);
                }

                if (lQuini.Count == 0)
                {
                    throw new WebException("El metodo Get recibe 3 parametros, dos de ellos opcionales. dd = dia (opcional), mm = mes (opcional), yyyy = año");
                }

            }
            catch (WebException ex)
            {
                return ValidationProblem("Error", "Get", 500, ex.Message);
            }
            catch (Exception ex)
            {
                return ValidationProblem("Error", "Get", 500, ex.Message);
            }
            return Ok(new { Quini = lQuini }); //OK 200
        }



    }
}
