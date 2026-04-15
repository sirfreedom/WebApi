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


		

	}

}