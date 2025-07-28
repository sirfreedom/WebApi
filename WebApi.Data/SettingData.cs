using System;
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



        public List<dynamic> Find(Dictionary<string, string> lParam)
        {
            IRepository<Setting> SettingRepository = new ContextSQL<Setting>(_ConnectionString);
            List<dynamic> ldynamic;
            try
            {
                ldynamic = SettingRepository.Find(lParam);
            }
            catch (Exception)
            {
                throw;
            }
            return ldynamic;
        }


        public Setting GetByDependency(int IdDependency)
        {
            DataTable dt = new DataTable();
            Setting oSetting = new Setting();
            Dictionary<string, string> lParam = new Dictionary<string, string>();
            lParam.Add("IdDependency", IdDependency.ToString());
            IRepository<Setting> Serv = new ContextSQL<Setting>(_ConnectionString);
            dt = Serv.Fill("GetByDependency", lParam);
            oSetting = Setting.ToList<Setting>(dt).SingleOrDefault();
            return oSetting;
        }


        public Setting Get(int Id)
        {
            IRepository<Setting> SettingRepository = new ContextSQL<Setting>(_ConnectionString);
            Setting oSetting;
            try
            {
                oSetting = SettingRepository.Get(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return oSetting;
        }


        public void Update(Setting setting)
        {
            IRepository<Setting> SettingRepository = new ContextSQL<Setting>(_ConnectionString);
            try
            {
                SettingRepository.Update(setting);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void Insert(Setting setting)
        {
            IRepository<Setting> SettingRepository = new ContextSQL<Setting>(_ConnectionString);
            try
            {
                SettingRepository.Insert(setting);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void Delete(int Id)
        {
            IRepository<Setting> SettingRepository = new ContextSQL<Setting>(_ConnectionString);
            try
            {
                SettingRepository.Delete(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }












    }
}
