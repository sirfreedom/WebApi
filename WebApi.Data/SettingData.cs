using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebApi.Entity;

namespace WebApi.Data
{
    public class SettingData 
    {

        private readonly string _ConnectionString = string.Empty;

        public SettingData(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public Setting GetByDependency(int IdDependency)
        {
            DataSet ds = new DataSet();
            Setting oSetting = new Setting();
            Dictionary<string, string> lParam = new Dictionary<string, string>();
            lParam.Add("IdDependency", IdDependency.ToString());
            IRepository<Setting> Serv = new ContextSQL<Setting>(_ConnectionString);
            ds = Serv.Fill("GetByDependency", lParam);
            oSetting = Setting.ToList<Setting>(ds.Tables[0]).SingleOrDefault();
            return oSetting;
        }





    }
}
