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

        public Setting GetByDependency(int IdDependency) 
        {
            SettingData Serv = new SettingData(_ConnectionString);
            return Serv.GetByDependency(IdDependency);
        }




    }
}
