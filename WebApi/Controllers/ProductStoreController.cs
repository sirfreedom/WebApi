using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using WebApi.Entity;
using WebApi.Biz;
using WebApi.Model;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductStoreController : Controller
	{
		private readonly ILogger<ProductStoreController> _logger;
		private readonly IConfiguration _configuration;
		private readonly string _ConectionString;

		public ProductStoreController(ILogger<ProductStoreController> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
			_ConectionString = _configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Busca un ProductStore
		/// </summary>
		/// <param name="ProductStoreFindModel">
		/// Esta entidad permite filtrar de manera sensilla por todos los campos que contiene
		/// Los valores que son filtrables son de tipo string. 
		/// ESTE METODO NO SE PUEDE PROBAR CON SWAGGER, intente probarlo con Postman u otro programa
		/// </param>
		/// <returns>
		/// devuelve una lista dinamica de los valores obtenidos en la base de datos, puede alterar los valores sin problemas
		/// Esta lista dinamica, es convertible tranquilamente a un Model
		/// </returns>
		[HttpGet("Find")]
		[AllowAnonymous]
		public async Task<ActionResult> Find([FromBody] ProductStoreFindModel ProductStoreFindModel)
		{
			ProductStoreBiz oProductStoreBiz = new(_ConectionString);
			List<dynamic> ldynamic;
			try
			{
				ldynamic = await Task.Run(() => oProductStoreBiz.Find(ProductStore.ToDictionary<ProductStoreFindModel>(ProductStoreFindModel)));
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
			return Ok(new { listproductstore = ldynamic }); //OK 200);
		}

		/// <summary>
		/// Devuelve un ProductStore
		/// </summary>
		/// <param name="Id">
		/// El Id es la clave unica PK de la entidad ProductStore.
		/// </param>
		/// <returns>
		/// devuelve un objeto unico del tipo ProductStore .
		/// </returns>
		[HttpGet("Get")]
		[AllowAnonymous]
		public async Task<ActionResult> Get(int Id)
		{
			ProductStoreBiz oProductStoreBiz = new(_ConectionString);
			ProductStore productstore;
			try
			{
				productstore = await Task.Run(() => oProductStoreBiz.Get(Id));
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
			return Ok(new { productstore = productstore }); //OK 200);
		}

		/// <summary>
		/// Actualiza ProductStore
		/// </summary>
		/// <param name="productstore">
		/// Esta entidad permite actualizar todos los valores de la tabla ProductStore.
		/// </param>
		/// <returns>
		/// devuelve Status: 200 en caso de haber actualizado correctamente 
		/// </returns>
		[HttpPut("Update")]
		[AllowAnonymous]
		public async Task<ActionResult> Update([FromBody] ProductStore productstore)
		{
			ProductStoreBiz oProductStoreBiz = new(_ConectionString);
			try
			{
				await Task.Run(() => oProductStoreBiz.Update(productstore));
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
			return Ok(); //OK 200
		}


		/// <summary>
		/// Inserta ProductStore
		/// </summary>
		/// <param name="productstoreModel">
		/// Inserta todos los campos de la entidad ProductStore.
		/// </param>
		/// <returns>
		/// devuelve un status: 201/204 si inserto correctamente 
		/// </returns>
		[HttpPost("Insert")]
		[AllowAnonymous]
		public async Task<ActionResult> Insert([FromBody] ProductStoreModel productstoreModel)
		{
			ProductStoreBiz oProductStoreBiz = new(_ConectionString);
			ProductStore productstore;
			try
			{
				productstore = ProductStore.Merge<ProductStoreModel, ProductStore>(productstoreModel);
				await Task.Run(() => oProductStoreBiz.Insert(productstore));
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
            return Created();
        }

	}

}