using System.Collections.Generic;
using System;
using WebApi.Entity;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data
{

	public class BestProductData
	{

		private readonly string _ConnectionString = string.Empty;


		public BestProductData (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public async Task<List<BestProduct>> List()
		{
			IRepository<BestProduct> ProductRepository = new ContextSQL<BestProduct>(_ConnectionString);
			List<BestProduct> lBestProduct;
			try
			{
				lBestProduct = await ProductRepository.List();
			}
			catch (Exception)
			{
				throw;
			}
			return lBestProduct;
		}


		public async Task<BestProduct> Get(int Id)
		{
			IRepository<BestProduct> ProductRepository = new ContextSQL<BestProduct>(_ConnectionString);
			BestProduct oProduct;
			try
			{
				oProduct = await ProductRepository.Get(Id);
			}
			catch (Exception)
			{
				throw;
			}
			return oProduct;
		}


		public async Task Update(BestProduct bestproduct)
		{
			IRepository<BestProduct> BestProductRepository = new ContextSQL<BestProduct>(_ConnectionString);
			try
			{
				await BestProductRepository.Update(bestproduct);
			}
			catch (Exception)
			{
				throw;
			}
		}


		public async Task<BestProduct> Insert(BestProduct bestproduct)
		{
			IRepository<BestProduct> BestProductRepository = new ContextSQL<BestProduct>(_ConnectionString);
			DataTable dt;
			try
			{
				dt = await BestProductRepository.Fill("Insert", bestproduct.ToDictionary());
				bestproduct = BestProduct.ToList<BestProduct>(dt).SingleOrDefault();
			}
			catch (Exception)
			{
				throw;
			}
			return bestproduct;
		}


		public async Task Delete(int Id)
		{
			IRepository<BestProduct> BestProductRepository = new ContextSQL<BestProduct>(_ConnectionString);
			try
			{
				await BestProductRepository.Delete(Id);
			}
			catch (Exception)
			{
				throw;
			}
		}


	}

}