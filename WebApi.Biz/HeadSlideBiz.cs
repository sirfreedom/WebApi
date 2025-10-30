using System.Collections.Generic;
using System;
using WebApi.Entity;
using WebApi.Data;

namespace WebApi.Biz
{

	public class HeadSlideBiz
	{

		private readonly string _ConnectionString = string.Empty;

		public HeadSlideBiz (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public List<HeadSlide> List()
		{
			HeadSlideData oHeadSlideData = new HeadSlideData(_ConnectionString);
			List<HeadSlide> lHeadSlide;
			try
			{
				lHeadSlide = oHeadSlideData.List();
			}
			catch (Exception)
			{
				throw;
			}
			return lHeadSlide;
		}


		public HeadSlide Insert(HeadSlide headslide)
		{
			HeadSlideData oHeadSlideData = new HeadSlideData(_ConnectionString);
			HeadSlide oHeadSlide;
			try
			{
				oHeadSlide = oHeadSlideData.Insert(headslide);
			}
			catch (Exception)
			{
				throw;
			}
			return oHeadSlide;
		}


		public void Delete(int Id)
		{
			HeadSlideData oHeadSlideData = new HeadSlideData(_ConnectionString);
			try
			{
				oHeadSlideData.Delete(Id);
			}
			catch (Exception)
			{
				throw;
			}
		}

	}

}