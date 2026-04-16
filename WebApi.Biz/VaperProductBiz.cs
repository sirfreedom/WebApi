using System.Collections.Generic;
using System;
using WebApi.Entity;
using WebApi.Data;
using System.Threading.Tasks;

namespace WebApi.Biz
{
	public class VaperProductBiz
	{

		private readonly string _ConnectionString = string.Empty;

		public VaperProductBiz (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public async Task<List<VaperProduct>> List()
		{
			VaperProductData oVaperProductData = new(_ConnectionString);
			List<VaperProduct> lVaperProduct;
			try
			{
				lVaperProduct = await oVaperProductData.List();
			}
			catch (Exception)
			{
				throw;
			}
			return lVaperProduct;
		}

	}

}