using System.Collections.Generic;
using WebApi.Data;
using WebApi.Entity;

namespace WebApi.Biz
{
    public class ImagenBiz
    {

        private readonly string _ConectionString = string.Empty;
        

        public ImagenBiz(string ConnectionString)
        {
            _ConectionString = ConnectionString;
        }

        public List<ImagenTest> List() 
        {
            ImagenTestData Serv = new ImagenTestData(_ConectionString);
            return Serv.List();
        }

        public void Insert(ImagenTest imagenTest) 
        {
            ImagenTestData Serv = new ImagenTestData(_ConectionString);
            Serv.Insert(imagenTest);
        }

        public void Delete(int Id) 
        {
            ImagenTestData Serv = new ImagenTestData(_ConectionString);
            Serv.Delete(Id);
        } 


    }
}
