using System.Collections.Generic;
using System;
using WebApi.Entity;
using WebApi.Data;
using System.Threading.Tasks;

namespace WebApi.Biz
{
    public class CategoryBiz
    {
        private readonly string _ConnectionString = string.Empty;

        public CategoryBiz(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public async Task<List<Category>> Marquee(int IdAppConfig)
        {
            CategoryData oCategoryData = new(_ConnectionString);
            List<Category> lCategory;
            try
            {
                lCategory = await oCategoryData.Marquee(IdAppConfig);
            }
            catch (Exception)
            {
                throw;
            }
            return lCategory;
        }


    }
}
