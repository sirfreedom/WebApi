using System.Collections.Generic;
using System;
using WebApi.Entity;
using WebApi.Data;
using System.Threading.Tasks;

namespace WebApi.Biz
{
	public class BestProductBiz
	{

		private readonly string _ConnectionString = string.Empty;

		public BestProductBiz (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public async Task<List<BestProduct>> List()
		{
			BestProductData oBestProductData = new(_ConnectionString);
			List<BestProduct> lProduct;
			try
			{
				lProduct = await oBestProductData.List();
			}
			catch (Exception)
			{
				throw;
			}
			return lProduct;
		}


		public async Task<BestProduct> Get(int Id)
		{
			BestProductData oBestProductData = new (_ConnectionString);
			BestProduct oBestProduct;
			try
			{
				oBestProduct = await oBestProductData.Get(Id);
			}
			catch (Exception)
			{
				throw;
			}
			return oBestProduct;
		}


		public async Task Update(BestProduct product)
		{
			BestProductData oBestProductData = new (_ConnectionString);
			try
			{
				await oBestProductData.Update(product);
			}
			catch (Exception)
			{
				throw;
			}
		}


		public async Task<BestProduct> Insert(BestProduct bestproduct)
		{
			BestProductData oBestProductData = new (_ConnectionString);
            try
			{
				bestproduct = await oBestProductData.Insert(bestproduct);
			}
			catch (Exception)
			{
				throw;
			}
			return bestproduct;
		}


		public async Task Delete(int Id)
		{
			BestProductData oProductData = new (_ConnectionString);
			try
			{
				await oProductData.Delete(Id);
			}
			catch (Exception)
			{
				throw;
			}
		}


	}

}