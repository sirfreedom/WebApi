using System.Collections.Generic;
using System;
using WebApi.Entity;

namespace WebApi.Data
{

	public class CardPictureData
	{

		private readonly string _ConnectionString = string.Empty;

		public CardPictureData (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}


		public List<CardPicture> List()
		{
            IRepository<CardPicture> CardPictureRepository = new ContextSQL<CardPicture>(_ConnectionString);
            List<CardPicture> lCardPicture;
			try
			{
				lCardPicture = CardPictureRepository.List();
			}
			catch (Exception)
			{
				throw;
			}
			return lCardPicture;
		}



		public CardPicture Insert(CardPicture oCardPicture)
		{
			IRepository<CardPicture> CardPictureRepository = new ContextSQL<CardPicture>(_ConnectionString);
			try
			{
				oCardPicture = CardPictureRepository.Insert(oCardPicture);
			}
			catch (Exception)
			{
				throw;
			}
			return oCardPicture;
		}

		public void Delete(int Id)
		{
			IRepository<CardPicture> CardPictureRepository = new ContextSQL<CardPicture>(_ConnectionString);
			try
			{
				CardPictureRepository.Delete(Id);
			}
			catch (Exception)
			{
				throw;
			}
		}

	}

}