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
		BestProductData oBestProductData = new BestProductData(_ConnectionString); 
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


		public List<dynamic> Find (Dictionary<string, string> lParam)
		{
		BestProductData oBestProductData = new BestProductData(_ConnectionString); 
		List<dynamic> ldynamic;
		try
		{
			ldynamic = oBestProductData.Find(lParam);
		}
		catch (Exception) 
		{
			throw;
		}
		return ldynamic;
		}


		public BestProduct Get(int Id)
		{
			BestProductData oBestProductData = new BestProductData(_ConnectionString);
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
			BestProductData oBestProductData = new BestProductData(_ConnectionString);
			try
			{
				oBestProductData.Update(product);
			}
			catch (Exception)
			{
				throw;
			}
		}


		public void Insert(BestProduct product)
		{
			BestProductData oBestProductData = new BestProductData(_ConnectionString);
			try
			{
				oBestProductData.Insert(product);
			}
			catch (Exception)
			{
				throw;
			}
		}


		public void Delete(int Id)
		{
			BestProductData oProductData = new BestProductData(_ConnectionString);
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