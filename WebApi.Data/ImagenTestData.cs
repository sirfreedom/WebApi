using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public void Delete(int Id)
        {
            IRepository<ImagenTest> Serv = new ContextSQL<ImagenTest>(_ConnectionString);
            Serv.Delete(Id);
        }

        public ImagenTest Insert(ImagenTest entity)
        {
            IRepository<ImagenTest> Serv = new ContextSQL<ImagenTest>(_ConnectionString);
            ImagenTest oImagenTest;
            DataTable dt;
            try
            {
                dt = Serv.Fill("Insert", entity.ToDictionary());
                oImagenTest = ImagenTest.ToList<ImagenTest>(dt).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }  
            return oImagenTest;
        }

        public List<ImagenTest> List()
        {
            IRepository<ImagenTest> Serv = new ContextSQL<ImagenTest>(_ConnectionString);
            return Serv.List();
        }
    }

}
