using System.Collections.Generic;
using WebApi.Entity;

namespace WebApi.Data
{
    public class ImagenTestData
    {
        private readonly string _ConectionString = string.Empty;

        public ImagenTestData(string ConnectionString)
        {
            _ConectionString = ConnectionString;
        }

        public void Delete(int Id)
        {
            IDeleteRespository Serv = new ContextSQL<ImagenTest>(_ConectionString);
            Serv.Delete(Id);
        }

        public void Insert(ImagenTest entity)
        {
            ICreateRepository<ImagenTest> Serv = new ContextSQL<ImagenTest>(_ConectionString);
            Serv.Insert(entity);
        }

        public List<ImagenTest> List()
        {
            IListRepository<ImagenTest> Serv = new ContextSQL<ImagenTest>(_ConectionString);
            return Serv.List();
        }
    }

}
