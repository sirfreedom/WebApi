using WebApi.Entity;

namespace WebApi.Data
{
    public class SettingData : IGetRepository<Setting>
    {
        private readonly IRepository<Setting> _context;

        public SettingData(IRepository<Setting> context)
        {
            _context = context;
        }

        public string EntityName
        {
            get { return _context.EntityName; }
        }

        public Setting Get(int IdDependency)
        {
            return _context.Get(IdDependency);
        }

    }
}
