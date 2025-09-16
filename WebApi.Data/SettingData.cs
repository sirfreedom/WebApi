using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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

        public Task<List<dynamic>> Find(Dictionary<string, string> lParam)
        {
            IRepository<Setting> SettingRepository = new ContextSQL<Setting>(_ConnectionString);
            Task<List<dynamic>> ldynamic;
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


        public Task<Setting> GetByDependency(int IdDependency)
        {
            Task<DataTable> dt;
            Task<Setting> oSetting;
            Dictionary<string, string> lParam = new Dictionary<string, string>();
            IRepository<Setting> Serv = new ContextSQL<Setting>(_ConnectionString);
            try
            {
                lParam.Add("IdDependency", IdDependency.ToString());
                dt = Serv.Fill("GetByDependency", lParam);
                oSetting = Task.FromResult(Setting.ToList<Setting>(dt.Result).SingleOrDefault());
            }
            catch (Exception) 
            {
                throw;
            }
            return oSetting;
        }


        public Task<Setting> Get(int Id)
        {
            IRepository<Setting> SettingRepository = new ContextSQL<Setting>(_ConnectionString);
            Task<Setting> oSetting;
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


        public Task Update(Setting setting)
        {
            IRepository<Setting> SettingRepository = new ContextSQL<Setting>(_ConnectionString);
            Task task;
            try
            {
                 task = SettingRepository.Update(setting);
            }
            catch (Exception)
            {
                throw;
            }
            return task;
        }


        public Task<Setting> Insert(Setting setting)
        {
            IRepository<Setting> SettingRepository = new ContextSQL<Setting>(_ConnectionString);
            Task<Setting> oSetting;
            try
            {
                oSetting = SettingRepository.Insert(setting);
            }
            catch (Exception)
            {
                throw;
            }
            return oSetting;
        }


        public Task Delete(int Id)
        {
            IRepository<Setting> SettingRepository = new ContextSQL<Setting>(_ConnectionString);
            Task task;
            try
            {
                task = SettingRepository.Delete(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return task;
        }

        public Task Disabled(int Id, bool Disabled) 
        {
            IRepository<Setting> SettingRepository = new ContextSQL<Setting>(_ConnectionString);
            Dictionary<string, string> lParam = new Dictionary<string, string>();
            Task task;
            try
            {
                lParam.Add("Id", Id.ToString());
                lParam.Add("Disabled",Disabled.ToString());
                task = SettingRepository.ExecuteNonQuery("Disabled", lParam);
            }
            catch (Exception)
            {
                throw;
            }
            return task;
        }











    }
}
