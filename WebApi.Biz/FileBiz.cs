using System.Collections.Generic;
using WebApi.Data;
using WebApi.Data.Interfaces;
using WebApi.Entity;

namespace WebApi.Biz
{
    public class FileBiz
    {

        private readonly string _ConectionString = string.Empty;
        

        public FileBiz(string ConnectionString)
        {
            _ConectionString = ConnectionString;
        }

        public List<ImagenTest> List() 
        {
            IListRepository<ImagenTest> Serv = new ImagenTestData(new ContextSQL<ImagenTest>(_ConectionString));
            return Serv.List();
        }

        public void Insert(ImagenTest imagenTest) 
        {
            ICreateRepository<ImagenTest> Serv = new ImagenTestData(new ContextSQL<ImagenTest>(_ConectionString));
            Serv.Insert(imagenTest);
        }


        public void Delete(int Id) 
        { 
            IDeleteRespository Serv = new ImagenTestData(new ContextSQL<ImagenTest>(_ConectionString));
            Serv.Delete(Id);
        } 



    }
}
