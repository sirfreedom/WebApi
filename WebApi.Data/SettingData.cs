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



        public async Task<List<dynamic>> Find(Dictionary<string, string> lParam)
        {
            IRepository<Setting> SettingRepository = new ContextSQL<Setting>(_ConnectionString);
            List<dynamic> ldynamic;
            try
            {
                ldynamic = await SettingRepository.Find(lParam);
            }
            catch (Exception)
            {
                throw;
            }
            return ldynamic;
        }


        public async Task<Setting> GetByDependency(int IdDependency)
        {
            DataTable dt = new ();
            Setting oSetting = new ();
            Dictionary<string, string> lParam = new();
            try
            {
                lParam.Add("IdDependency", IdDependency.ToString());
                IRepository<Setting> Serv = new ContextSQL<Setting>(_ConnectionString);
                dt = await Serv.Fill("GetByDependency", lParam);
                oSetting = Setting.ToList<Setting>(dt).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return oSetting;
        }


        public async Task<Setting> Get(int Id)
        {
            IRepository<Setting> SettingRepository = new ContextSQL<Setting>(_ConnectionString);
            Setting oSetting;
            try
            {
                oSetting = await SettingRepository.Get(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return oSetting;
        }


        public async Task Update(Setting setting)
        {
            IRepository<Setting> SettingRepository = new ContextSQL<Setting>(_ConnectionString);
            try
            {
               await SettingRepository.Update(setting);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<Setting> Insert(Setting setting)
        {
            IRepository<Setting> SettingRepository = new ContextSQL<Setting>(_ConnectionString);
            Setting oSetting;
            DataTable dt;
            try
            {
                dt = await SettingRepository.Fill("Insert", setting.ToDictionary());
                oSetting = Setting.ToList<Setting>(dt).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return oSetting;
        }


        public async Task Delete(int Id)
        {
            IRepository<Setting> SettingRepository = new ContextSQL<Setting>(_ConnectionString);
            try
            {
               await SettingRepository.Delete(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Disabled(int Id, bool Disabled) 
        {
            IRepository<Setting> SettingRepository = new ContextSQL<Setting>(_ConnectionString);
            Dictionary<string, string> lParam = new Dictionary<string, string>();
            try
            {
                lParam.Add("Id", Id.ToString());
                lParam.Add("Disabled",Disabled.ToString());
                await SettingRepository.ExecuteNonQuery("Disabled", lParam);
            }
            catch (Exception)
            {
                throw;
            }
        }











    }
}
