using System.Collections.Generic;
using System;
using WebApi.Entity;
using WebApi.Data;
using System.Threading.Tasks;

namespace WebApi.Biz
{

	public class ProductStoreBiz
	{

		private readonly string _ConnectionString = string.Empty;

		public ProductStoreBiz (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public async Task<List<dynamic>> Find(Dictionary<string, string> lParam)
		{
			ProductStoreData oProductStoreData = new(_ConnectionString);
			List<dynamic> ldynamic;
			try
			{
				ldynamic = await oProductStoreData.Find(lParam);
			}
			catch (Exception)
			{
				throw;
			}
			return ldynamic;
		}

		public async Task<ProductStore> Get(int Id)
		{
			ProductStoreData oProductStoreData = new(_ConnectionString);
			ProductStore oProductStore;
			try
			{
				oProductStore = await oProductStoreData.Get(Id);
			}
			catch (Exception)
			{
				throw;
			}
			return oProductStore;
		}

		public async Task Update(ProductStore oProductStore)
		{
			ProductStoreData oProductStoreData = new(_ConnectionString);
			try
			{
				await oProductStoreData.Update(oProductStore);
			}
			catch (Exception)
			{
				throw;
			}
		}


		public async Task Insert(ProductStore oProductStore)
		{
			ProductStoreData oProductStoreData = new(_ConnectionString);
			try
			{
				await oProductStoreData.Insert(oProductStore);
			}
			catch (Exception)
			{
				throw;
			}
		}



	}

}