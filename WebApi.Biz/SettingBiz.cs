using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public Task<Setting> GetByDependency(int IdDependency) 
        {
            SettingData Serv = new SettingData(_ConnectionString);
            Task<Setting> oSetting;
            try
            {
                oSetting = Serv.GetByDependency(IdDependency);
            }
            catch (Exception) 
            {
                throw;
            }
            return oSetting;
        }

        public Task<List<dynamic>> Find(Dictionary<string, string> lParam)
        {
            SettingData oSettingData = new SettingData(_ConnectionString);
            Task<List<dynamic>> ldynamic;
            try
            {
                ldynamic = oSettingData.Find(lParam);
            }
            catch (Exception)
            {
                throw;
            }
            return ldynamic;
        }


        public Task<Setting> Get(int Id)
        {
            SettingData oSettingData = new SettingData(_ConnectionString);
            Task<Setting> oSetting;
            try
            {
                oSetting = oSettingData.Get(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return oSetting;
        }


        public Task Update(Setting setting)
        {
            SettingData oSettingData = new SettingData(_ConnectionString);
            Task task;
            try
            {
                task = oSettingData.Update(setting);
            }
            catch (Exception)
            {
                throw;
            }
            return task;
        }


        public Task<Setting> Insert(Setting setting)
        {
            SettingData oSettingData = new SettingData(_ConnectionString);
            Task<Setting> oSetting;
            try
            {
                oSetting = oSettingData.Insert(setting);
            }
            catch (Exception)
            {
                throw;
            }
            return oSetting;
        }


        public Task Delete(int Id)
        {
            SettingData oSettingData = new SettingData(_ConnectionString);
            Task task;
            try
            {
                task = oSettingData.Delete(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return task;
        }

        public Task Disabled(int Id,bool Disabled)
        {
            SettingData oSettingData = new SettingData(_ConnectionString);
            try
            {
                oSettingData.Disabled(Id,Disabled);
            }
            catch (Exception)
            {
                throw;
            }
            return Task.CompletedTask;
        }


    }
}
