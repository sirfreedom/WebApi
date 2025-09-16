using System.Collections.Generic;
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
            IRepositoryAsync<ImagenTest> Serv = new ContextSQLAsync<ImagenTest>(_ConnectionString);
            Serv.Delete(Id);
        }

        public Task<ImagenTest> Insert(ImagenTest entity)
        {
            IRepositoryAsync<ImagenTest> Serv = new ContextSQLAsync<ImagenTest>(_ConnectionString);
            Task<ImagenTest> oImagenTest;
            oImagenTest = Serv.Insert(entity);
            return oImagenTest;
        }

        public Task<List<ImagenTest>> List()
        {
            IRepositoryAsync<ImagenTest> Serv = new ContextSQLAsync<ImagenTest>(_ConnectionString);
            Task<List<ImagenTest>> lImagenTest;
            lImagenTest = Serv.List();
            return lImagenTest;
        }

        public List<ImagenTest> Test1()
        {
            IRepositoryAsync<ImagenTest> Serv = new ContextSQLAsync<ImagenTest>(_ConnectionString);
            List<ImagenTest> lImagenTest = new List<ImagenTest>();

            var tareas = new List<Task>();

            for (int i = 0; i < 3; i++)
            {
                tareas.Add(Serv.Fill("Test3"));
                tareas.Add(Serv.ExecuteNonQuery("Test3"));
            }
            
            Task.WhenAll(tareas);
            //Task.WaitAll(tareas);
            
            return lImagenTest;
        }

     




    }

}
