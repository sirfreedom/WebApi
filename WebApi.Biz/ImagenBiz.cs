using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Entity;

namespace WebApi.Biz
{
    public class ImagenBiz
    {
        private readonly string _ConnectionString = string.Empty;
        
        public ImagenBiz(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public async Task<List<ImagenTest>> List() 
        {
            ImagenTestData Serv = new (_ConnectionString);
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

        public async Task<ImagenTest> Insert(ImagenTest imagenTest) 
        {
            ImagenTestData Serv = new (_ConnectionString);
            ImagenTest oImagenTest;
            try
            {
                oImagenTest = await Serv.Insert(imagenTest);
            }
            catch (Exception)
            {
                throw;
            }
            return oImagenTest;
        }

        public async Task Delete(int Id) 
        {
            ImagenTestData Serv = new (_ConnectionString);
            try
            {
                await Serv.Delete(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

   


    }
}
