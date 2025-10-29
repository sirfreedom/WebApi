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
using WebApi.Model;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BestProductController : Controller 
	{
		private readonly ILogger<BestProductController> _logger;
		private readonly IConfiguration _configuration;
		private readonly string _ConectionString;


		public BestProductController(ILogger<BestProductController> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
			_ConectionString = _configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Lista Product
		/// </summary>
		/// <returns>
		/// devuelve la lista de Product. generalmente usado para combos y lugares donde no necesitarias un filtro
		/// </returns>
		[HttpGet("List")]
		[AllowAnonymous]
		public async Task<ActionResult> List()
		{
			BestProductBiz oBestProductBiz = new BestProductBiz(_ConectionString);
			List<BestProduct> lBestProduct;
			try
			{
                lBestProduct = await Task.Run(() => oBestProductBiz.List());
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
			return Ok(new { listbestproduct = lBestProduct }); //OK 200
        }


		/// <summary>
		/// Devuelve un BestProduct
		/// </summary>
		/// <param name="Id">
		/// El Id es la clave unica PK de la entidad BestProduct.
		/// </param>
		/// <returns>
		/// devuelve un objeto unico del tipo BestProduct .
		/// </returns>
		[HttpGet("Get")]
		[AllowAnonymous]
		public async Task<ActionResult> Get(int Id)
		{
			BestProductBiz oProductBiz = new BestProductBiz(_ConectionString);
			BestProduct oBestProduct;
			try
			{
				oBestProduct = await Task.Run(() => oProductBiz.Get(Id));
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
			return Ok(new { BestProduct = oBestProduct }); //OK 200
        }


		/// <summary>
		/// Actualiza Product
		/// </summary>
		/// <param name="bestproduct">
		/// Esta entidad permite actualizar todos los valores de la tabla Product.
		/// </param>
		/// <returns>
		/// devuelve Status: 200 en caso de haber actualizado correctamente 
		/// </returns>
		[HttpPut("Update")]
		[AllowAnonymous]
		public async Task<ActionResult> Update([FromBody] BestProduct bestproduct)
		{
			BestProductBiz oBestProductBiz = new BestProductBiz(_ConectionString);
			try
			{
                await Task.Run(() => oBestProductBiz.Update(bestproduct));
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
			return Ok(bestproduct); 
		}


        /// <summary>
        /// Inserta BestProduct
        /// </summary>
        /// <param name="bestproductModel">
        /// Inserta todos los campos de la entidad Product.
        /// </param>
        /// <returns>
        /// devuelve un objeto unico del tipo BestProduct y un 201
        /// </returns>
        [HttpPost("Insert")]
		[AllowAnonymous]
		public async Task<ActionResult> Insert([FromBody] BestProductModel bestproductModel)
		{
			BestProductBiz oBestProductBiz = new BestProductBiz(_ConectionString);
			BestProduct bestproduct = new BestProduct();
			try
			{
				bestproduct = BestProduct.Merge<BestProductModel, BestProduct>(bestproductModel);
                bestproduct = await Task.Run(() => oBestProductBiz.Insert(bestproduct));
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
            return Ok(new { bestproduct = bestproduct }); //OK 200
        }


		/// <summary>
		/// Elimina un registro de BestProduct
		/// </summary>
		/// <param name="Id">
		/// El Id es la clave unica PK de la entidad BestProduct.
		/// </param>
		/// <returns>
		/// devuelve Status: 200 en caso de haber eliminado correctamente 
		/// </returns>
		[HttpDelete("Delete")]
		[AllowAnonymous]
		public async Task<ActionResult> Delete(int Id)
		{
			BestProductBiz oProductBiz = new BestProductBiz(_ConectionString);
			try
			{
				await Task.Run(() => oProductBiz.Delete(Id));
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
			return Ok();
		}


	}

}