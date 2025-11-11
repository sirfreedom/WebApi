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
	public class CardPictureController : Controller 
	{
		private readonly ILogger<CardPictureController> _logger;
		private readonly IConfiguration _configuration;
		private readonly string _ConectionString;


		public CardPictureController(ILogger<CardPictureController> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
			_ConectionString = _configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Lista CardPicture
		/// </summary>
		/// <returns>
		/// devuelve la lista de CardPicture. generalmente usado para combos y lugares donde no necesitarias un filtro
		/// </returns>
		[HttpGet("List")]
		[AllowAnonymous]
		public async Task<ActionResult> List()
		{
			CardPictureBiz oCardPictureBiz = new CardPictureBiz(_ConectionString);
			List<CardPicture> lCardPicture;
			try
			{
				lCardPicture = await Task.Run(() => oCardPictureBiz.List());
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
			return Ok(new { cardpictures = lCardPicture }); //OK 200);
		}



		/// <summary>
		/// Inserta CardPicture
		/// </summary>
		/// <param name="CardPictureModel">
		/// Inserta todos los campos de la entidad CardPicture.
		/// </param>
		/// <returns>
		/// devuelve un status: 201/204 si inserto correctamente 
		/// </returns>
		[HttpPost("Insert")]
		[AllowAnonymous]
		public async Task<ActionResult> Insert([FromBody] CardPictureModel CardPictureModel)
		{
			CardPictureBiz oCardPictureBiz = new CardPictureBiz(_ConectionString);
			CardPicture CardPicture;
			try
			{
				CardPicture = CardPicture.Merge<CardPictureModel, CardPicture>(CardPictureModel);
				CardPicture = await Task.Run(() => oCardPictureBiz.Insert(CardPicture));
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
			return Ok(new { cardpictures = CardPicture }); //OK 200);
		}



		/// <summary>
		/// Elimina un registro de  CardPicture
		/// </summary>
		/// <param name="Id">
		/// El Id es la clave unica PK de la entidad CardPicture.
		/// </param>
		/// <returns>
		/// devuelve Status: 200 en caso de haber eliminado correctamente 
		/// </returns>
		[HttpDelete("Delete")]
		[AllowAnonymous]
		public ActionResult Delete(int Id)
		{
			CardPictureBiz oCardPictureBiz = new CardPictureBiz(_ConectionString);
			try
			{
				oCardPictureBiz.Delete(Id);
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



	}

}