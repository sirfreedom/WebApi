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
            List<dynamic> ldynamic;
            try
            {
                ldynamic = SettingRepository.Find(lParam);
            }
            catch (Exception)
            {
                throw;
            }
            return Task.FromResult(ldynamic);
        }


        public Task<Setting> GetByDependency(int IdDependency)
        {
            DataTable dt;
            Setting oSetting;
            Dictionary<string, string> lParam = new Dictionary<string, string>();
            try
            {
                lParam.Add("IdDependency", IdDependency.ToString());
                IRepository<Setting> Serv = new ContextSQL<Setting>(_ConnectionString);
                dt = Serv.Fill("GetByDependency", lParam);
                oSetting = Setting.ToList<Setting>(dt).SingleOrDefault();
            }
            catch (Exception) 
            {
                throw;
            }
            return Task.FromResult(oSetting);
        }


        public Task<Setting> Get(int Id)
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
            return Task.FromResult(oSetting);
        }


        public Task Update(Setting setting)
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
            return Task.CompletedTask;
        }


        public Task<Setting> Insert(Setting setting)
        {
            IRepository<Setting> SettingRepository = new ContextSQL<Setting>(_ConnectionString);
            Setting oSetting;
            try
            {
                oSetting = SettingRepository.Insert(setting);
            }
            catch (Exception)
            {
                throw;
            }
            return Task.FromResult(oSetting);
        }


        public Task Delete(int Id)
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
            return Task.CompletedTask;
        }

        public Task Disabled(int Id, bool Disabled) 
        {
            IRepository<Setting> SettingRepository = new ContextSQL<Setting>(_ConnectionString);
            Dictionary<string, string> lParam = new Dictionary<string, string>();
            try
            {
                lParam.Add("Id", Id.ToString());
                lParam.Add("Disabled",Disabled.ToString());
                SettingRepository.ExecuteNonQuery("Disabled", lParam);
            }
            catch (Exception)
            {
                throw;
            }
            return Task.CompletedTask;
        }











    }
}
