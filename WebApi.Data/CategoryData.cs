using System.Collections.Generic;
using System;
using WebApi.Entity;
using System.Threading.Tasks;
using System.Data;

namespace WebApi.Data
{
    public class CategoryData
    {

        private readonly string _ConnectionString = string.Empty;

        public CategoryData(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public async Task<List<Category>> Marquee(int IdAppConfig)
        {
            IRead<Category> CategoryRepository = new ContextSQL<Category>(_ConnectionString);
            List<Category> lCategory;
            Dictionary<string, string> lParam = new();
            DataTable dt;
            try
            {
                lParam.Add("IdAppConfig", IdAppConfig.ToString());
                dt = await CategoryRepository.Fill("Marquee",lParam);
                lCategory = Category.ToList<Category>(dt);
            }
            catch (Exception)
            {
                throw;
            }
            return lCategory;
        }

        public async Task<List<Category>> List(int IdAppConfig)
        {
            IRead<Category> CategoryRepository = new ContextSQL<Category>(_ConnectionString);
            List<Category> lCategory;
            Dictionary<string, string> lParam = new();
            DataTable dt;
            try
            {
                lParam.Add("IdAppConfig", IdAppConfig.ToString());
                dt = await CategoryRepository.Fill("List", lParam);
                lCategory = Category.ToList<Category>(dt);
            }
            catch (Exception)
            {
                throw;
            }
            return lCategory;
        }

    }
}
