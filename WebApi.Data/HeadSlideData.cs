using System.Collections.Generic;
using System;
using WebApi.Entity;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data
{
	public class HeadSlideData
	{
		private readonly string _ConnectionString = string.Empty;

		public HeadSlideData (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public async Task<List<HeadSlide>> List()
		{
			IRead<HeadSlide> HeadSlideRepository = new ContextSQL<HeadSlide>(_ConnectionString);
			List<HeadSlide> lHeadSlide;
			try
			{
				lHeadSlide = await HeadSlideRepository.List();
			}
			catch (Exception)
			{
				throw;
			}
			return lHeadSlide;
		}


		public async Task<HeadSlide> Insert(HeadSlide headslide)
		{
			IRead<HeadSlide> HeadSlideRepository = new ContextSQL<HeadSlide>(_ConnectionString);
			HeadSlide oHeadSlide;
			DataTable dt;
			try
			{
				dt = await HeadSlideRepository.Fill("Insert", headslide.ToDictionary());
				oHeadSlide = HeadSlide.ToList<HeadSlide>(dt).SingleOrDefault();
			}
			catch (Exception)
			{
				throw;
			}
			return oHeadSlide;
		}


		public async Task Delete(int Id)
		{
			IWrite<HeadSlide> HeadSlideRepository = new ContextSQL<HeadSlide>(_ConnectionString);
			try
			{
				 await HeadSlideRepository.Delete(Id);
			}
			catch (Exception)
			{
				throw;
			}
		}

	}

}