using System.Collections.Generic;
using System;
using WebApi.Entity;

namespace WebApi.Data
{

	public class BestProductData
	{

		private readonly string _ConnectionString = string.Empty;


		public BestProductData (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public List<BestProduct> List()
		{
			IRepository<BestProduct> ProductRepository = new ContextSQL<BestProduct>(_ConnectionString);
			List<BestProduct> lBestProduct;
			try
			{
				lBestProduct = ProductRepository.List();
			}
			catch (Exception)
			{
				throw;
			}
			return lBestProduct;
		}


		public BestProduct Get(int Id)
		{
			IRepository<BestProduct> ProductRepository = new ContextSQL<BestProduct>(_ConnectionString);
			BestProduct oProduct;
			try
			{
				oProduct = ProductRepository.Get(Id);
			}
			catch (Exception)
			{
				throw;
			}
			return oProduct;
		}


		public void Update(BestProduct bestproduct)
		{
			IRepository<BestProduct> BestProductRepository = new ContextSQL<BestProduct>(_ConnectionString);
			try
			{
				BestProductRepository.Update(bestproduct);
			}
			catch (Exception)
			{
				throw;
			}
		}


		public BestProduct Insert(BestProduct bestproduct)
		{
			IRepository<BestProduct> BestProductRepository = new ContextSQL<BestProduct>(_ConnectionString);
			try
			{
				bestproduct = BestProductRepository.Insert(bestproduct);
			}
			catch (Exception)
			{
				throw;
			}
			return bestproduct;
		}


		public void Delete(int Id)
		{
			IRepository<BestProduct> BestProductRepository = new ContextSQL<BestProduct>(_ConnectionString);
			try
			{
				BestProductRepository.Delete(Id);
			}
			catch (Exception)
			{
				throw;
			}
		}


	}

}