using System.Collections.Generic;
using System;
using WebApi.Entity;
using WebApi.Data;

namespace WebApi.Biz
{
	public class BestProductBiz
	{

		private readonly string _ConnectionString = string.Empty;

		public BestProductBiz (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public List<BestProduct> List() 
		{
		BestProductData oBestProductData = new (_ConnectionString); 
		List<BestProduct> lProduct;
		try 
		{
			lProduct = oBestProductData.List();
		}
		catch (Exception) 
		{
			throw;
		}
		return lProduct;
		}


		public BestProduct Get(int Id)
		{
			BestProductData oBestProductData = new (_ConnectionString);
			BestProduct oBestProduct;
			try
			{
				oBestProduct = oBestProductData.Get(Id);
			}
			catch (Exception)
			{
				throw;
			}
			return oBestProduct;
		}


		public void Update(BestProduct product)
		{
			BestProductData oBestProductData = new (_ConnectionString);
			try
			{
				oBestProductData.Update(product);
			}
			catch (Exception)
			{
				throw;
			}
		}


		public BestProduct Insert(BestProduct bestproduct)
		{
			BestProductData oBestProductData = new (_ConnectionString);
            try
			{
				bestproduct = oBestProductData.Insert(bestproduct);
			}
			catch (Exception)
			{
				throw;
			}
			return bestproduct;
		}


		public void Delete(int Id)
		{
			BestProductData oProductData = new (_ConnectionString);
			try
			{
				oProductData.Delete(Id);
			}
			catch (Exception)
			{
				throw;
			}
		}


	}

}