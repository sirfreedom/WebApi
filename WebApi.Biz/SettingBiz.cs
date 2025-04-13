using WebApi.Data;
using WebApi.Entity;

namespace WebApi.Biz
{
    public class SettingBiz
    {

        private string _ConnectionString = string.Empty;

        public SettingBiz(string ConecctionString) 
        { 
            _ConnectionString = ConecctionString;
        }

        public Setting Get(int IdDependency) 
        {
            IGetRepository<Setting> Serv = new SettingData(new ContextSQL<Setting>(_ConnectionString));
            Setting setting;
            setting = Serv.Get(IdDependency);
            return setting;
        }



    }
}
