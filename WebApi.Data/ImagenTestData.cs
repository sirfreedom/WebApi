using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entity;

namespace WebApi.Data
{
    public class ImagenTestData
    {
        private readonly string _ConnectionString = string.Empty;

        public ImagenTestData(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public async Task Delete(int Id)
        {
            IRepository<ImagenTest> Serv = new ContextSQL<ImagenTest>(_ConnectionString);
            try
            {
                await Serv.Delete(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ImagenTest> Insert(ImagenTest entity)
        {
            IRepository<ImagenTest> Serv = new ContextSQL<ImagenTest>(_ConnectionString);
            ImagenTest oImagenTest;
            DataTable dt;
            try
            {
                dt = await Serv.Fill("Insert", entity.ToDictionary());
                oImagenTest = ImagenTest.ToList<ImagenTest>(dt).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }  
            return oImagenTest;
        }

        public async Task<List<ImagenTest>> List()
        {
            IRepository<ImagenTest> Serv = new ContextSQL<ImagenTest>(_ConnectionString);
            List<ImagenTest> lImagenTest;
            try
            {
                lImagenTest = await Serv.List();
            }
            catch (Exception)
            {
                throw;
            }
            return lImagenTest;
        }


    }

}
