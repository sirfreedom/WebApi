using System.Collections.Generic;
using System;
using WebApi.Entity;
using WebApi.Data;

namespace WebApi.Biz
{

	public class CardPictureBiz
	{

		private readonly string _ConnectionString = string.Empty;

		public CardPictureBiz (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public List<CardPicture> List()
		{
			CardPictureData oCardPictureData = new CardPictureData(_ConnectionString);
			List<CardPicture> lCardPicture;
			try
			{
				lCardPicture = oCardPictureData.List();
			}
			catch (Exception)
			{
				throw;
			}
			return lCardPicture;
		}


		public CardPicture Insert(CardPicture oCardPicture)
		{
			CardPictureData oCardPictureData = new CardPictureData(_ConnectionString);
			try
			{
				oCardPicture = oCardPictureData.Insert(oCardPicture);
			}
			catch (Exception)
			{
				throw;
			}
			return oCardPicture;
		}


		public void Delete(int Id)
		{
			CardPictureData oCardPictureData = new CardPictureData(_ConnectionString);
			try
			{
				oCardPictureData.Delete(Id);
			}
			catch (Exception)
			{
				throw;
			}
		}

	}

}