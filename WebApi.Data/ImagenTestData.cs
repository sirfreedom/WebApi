using System.Collections.Generic;
using System.Data;
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



        public List<ImagenTest> Test1()
        {
            IRepositoryAsync<ImagenTest> Serv = new ContextSQLAsync<ImagenTest>(_ConnectionString);
            List<ImagenTest> lImagenTest = new List<ImagenTest>();

            var tareas = new List<Task>();

            for (int i = 0; i < 3; i++)
            {
                tareas.Add(Serv.Fill("Test3"));
            }
            
            Task.WhenAll(tareas);
            //Task.WaitAll(tareas);

            
            return lImagenTest;
        }

     




    }

}
