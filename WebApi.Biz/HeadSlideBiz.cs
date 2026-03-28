using System.Collections.Generic;
using System;
using WebApi.Entity;
using WebApi.Data;
using System.Threading.Tasks;

namespace WebApi.Biz
{

	public class HeadSlideBiz
	{

		private readonly string _ConnectionString = string.Empty;

		public HeadSlideBiz (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public async Task<List<HeadSlide>> Find(int IdAppConfig)
		{
			HeadSlideData oHeadSlideData = new (_ConnectionString);
			List<HeadSlide> lHeadSlide;
			try
			{
				lHeadSlide = await oHeadSlideData.Find(IdAppConfig);
			}
			catch (Exception)
			{
				throw;
			}
			return lHeadSlide;
		}


		public async Task<HeadSlide> Insert(HeadSlide headslide)
		{
			HeadSlideData oHeadSlideData = new (_ConnectionString);
			HeadSlide oHeadSlide;
			try
			{
				oHeadSlide = await oHeadSlideData.Insert(headslide);
			}
			catch (Exception)
			{
				throw;
			}
			return oHeadSlide;
		}


		public async Task Delete(int Id)
		{
			HeadSlideData oHeadSlideData = new (_ConnectionString);
			try
			{
				await oHeadSlideData.Delete(Id);
			}
			catch (Exception)
			{
				throw;
			}
		}

	}

}