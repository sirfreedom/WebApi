using System.Collections.Generic;
using System;
using WebApi.Entity;
using System.Threading.Tasks;

namespace WebApi.Data
{

	public class VaperProductData
	{
		private readonly string _ConnectionString = string.Empty;

		public VaperProductData (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public async Task<List<VaperProduct>> List()
		{
			IRead<VaperProduct> ProductRepository = new ContextSQL<VaperProduct>(_ConnectionString);
			List<VaperProduct> lVaperProduct;
			try
			{
				lVaperProduct = await ProductRepository.List();
			}
			catch (Exception)
			{
				throw;
			}
			return lVaperProduct;
		}




	}

}