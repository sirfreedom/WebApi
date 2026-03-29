using System.Collections.Generic;
using System;
using WebApi.Entity;
using System.Threading.Tasks;

namespace WebApi.Data
{
    public class CategoryData
    {

        private readonly string _ConnectionString = string.Empty;

        public CategoryData(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public async Task<List<Category>> Find(int IdAppConfig)
        {
            IRead<Category> CategoryRepository = new ContextSQL<Category>(_ConnectionString);
            List<Category> lCategory;
            Dictionary<string, string> lParam = new();
            List<dynamic> lResult;
            try
            {
                lParam.Add("IdAppConfig", IdAppConfig.ToString());
                lResult = await CategoryRepository.Find(lParam);
                lCategory = Category.ToList<Category>(lResult);
            }
            catch (Exception)
            {
                throw;
            }
            return lCategory;
        }





    }
}
