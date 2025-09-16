using System.Collections.Generic;
using WebApi.Data;
using WebApi.Entity;
using System.Threading.Tasks;

namespace WebApi.Biz
{
    public class ImagenBiz
    {
        private readonly string _ConnectionString = string.Empty;
        
        public ImagenBiz(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public Task<List<ImagenTest>> List() 
        {
            ImagenTestData Serv = new ImagenTestData(_ConnectionString);
            return Serv.List();
        }

        public Task<ImagenTest> Insert(ImagenTest imagenTest) 
        {
            ImagenTestData Serv = new ImagenTestData(_ConnectionString);
            Task<ImagenTest> oImagenTest;
            oImagenTest = Serv.Insert(imagenTest);
            return oImagenTest;
        }

        public void Delete(int Id) 
        {
            ImagenTestData Serv = new ImagenTestData(_ConnectionString);
            Serv.Delete(Id);
        }

        public List<ImagenTest> Test1() 
        {
            ImagenTestData Serv = new ImagenTestData(_ConnectionString);
            return Serv.Test1();
        }

    }
}
