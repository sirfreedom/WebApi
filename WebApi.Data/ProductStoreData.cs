using System.Collections.Generic;
using System;
using WebApi.Entity;
using System.Threading.Tasks;

namespace WebApi.Data
{

    public class ProductStoreData
    {
        private readonly string _ConnectionString = string.Empty;

        public ProductStoreData(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public async Task<List<dynamic>> Find(Dictionary<string, string> lParam)
        {
            IRead<ProductStore> oProductStoreRepository = new ContextSQL<ProductStore>(_ConnectionString);
            List<dynamic> ldynamic;
            try
            {
                ldynamic = await oProductStoreRepository.Find(lParam);
            }
            catch (Exception)
            {
                throw;
            }
            return ldynamic;
        }

        public async Task<ProductStore> Get(int Id)
        {
            IRead<ProductStore> oProductStoreRepository = new ContextSQL<ProductStore>(_ConnectionString);
            ProductStore oProductStore;
            try
            {
                oProductStore = await oProductStoreRepository.Get(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return oProductStore;
        }

        public async Task Update(ProductStore oProductStore)
        {
            IWrite<ProductStore> ProductStoreRepository = new ContextSQL<ProductStore>(_ConnectionString);
            try
            {
                await ProductStoreRepository.Update(oProductStore);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Insert(ProductStore oProductStore)
        {
            IWrite<ProductStore> oProductStoreRepository = new ContextSQL<ProductStore>(_ConnectionString);
            try
            {
                await oProductStoreRepository.Insert(oProductStore);
            }
            catch (Exception)
            {
                throw;
            }
        }



    }

}