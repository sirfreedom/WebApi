using System.Collections.Generic;
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
            oImagenTest = Serv.Insert(entity);

            return oImagenTest;
        }

        public List<ImagenTest> List()
        {
            IRepository<ImagenTest> Serv = new ContextSQL<ImagenTest>(_ConnectionString);
            return Serv.List();
        }
    }

}
