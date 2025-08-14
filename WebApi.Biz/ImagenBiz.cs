using System.Collections.Generic;
using WebApi.Data;
using WebApi.Entity;
using System.Net;
using System.Net.Mail;

namespace WebApi.Biz
{
    public class ImagenBiz
    {
        private readonly string _ConnectionString = string.Empty;
        
        public ImagenBiz(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public List<ImagenTest> List() 
        {
            ImagenTestData Serv = new ImagenTestData(_ConnectionString);
            return Serv.List();
        }

        public ImagenTest Insert(ImagenTest imagenTest) 
        {
            ImagenTestData Serv = new ImagenTestData(_ConnectionString);
            ImagenTest oImagenTest;

            oImagenTest = Serv.Insert(imagenTest);


            return oImagenTest;
        }

        public void Delete(int Id) 
        {
            ImagenTestData Serv = new ImagenTestData(_ConnectionString);
            Serv.Delete(Id);
        }

   


    }
}
