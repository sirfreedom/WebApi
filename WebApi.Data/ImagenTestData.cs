using System.Collections.Generic;
using WebApi.Data.Interfaces;
using WebApi.Entity;

namespace WebApi.Data
{
    public class ImagenTestData : ICreateRepository<ImagenTest>, IListRepository<ImagenTest>, IDeleteRespository
    {

        private readonly IRepository<ImagenTest> _context;

        public ImagenTestData(IRepository<ImagenTest> context)
        {
            _context = context;
        }

        public string EntityName
        {
            get { return _context.EntityName; }
        }

        public void Delete(int Id)
        {
            _context.Delete(Id);
        }

        public void Insert(ImagenTest entity)
        {
            _context.Insert(entity.ToDictionary(false,false));
        }

        public List<ImagenTest> List()
        {
            return _context.List();
        }
    }

}
