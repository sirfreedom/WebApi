using System.Collections.Generic;
using System;
using WebApi.Entity;
using System.Data;
using System.Linq;

namespace WebApi.Data
{

	public class HeadSlideData
	{

		private readonly string _ConnectionString = string.Empty;


		public HeadSlideData (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public List<HeadSlide> List()
		{
			IRepository<HeadSlide> HeadSlideRepository = new ContextSQL<HeadSlide>(_ConnectionString);
			List<HeadSlide> lHeadSlide;
			try
			{
				lHeadSlide = HeadSlideRepository.List();
			}
			catch (Exception)
			{
				throw;
			}
			return lHeadSlide;
		}


		public HeadSlide Insert(HeadSlide headslide)
		{
			IRepository<HeadSlide> HeadSlideRepository = new ContextSQL<HeadSlide>(_ConnectionString);
			HeadSlide oHeadSlide;
			DataTable dt;
			try
			{
				dt = HeadSlideRepository.Fill("Insert", headslide.ToDictionary());
				oHeadSlide = HeadSlide.ToList<HeadSlide>(dt).SingleOrDefault();
			}
			catch (Exception)
			{
				throw;
			}
			return oHeadSlide;
		}


		public void Delete(int Id)
		{
			IRepository<HeadSlide> HeadSlideRepository = new ContextSQL<HeadSlide>(_ConnectionString);
			try
			{
				HeadSlideRepository.Delete(Id);
			}
			catch (Exception)
			{
				throw;
			}
		}

	}

}