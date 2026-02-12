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

        public async Task<Setting> GetByDependency(int IdDependency) 
        {
            SettingData Serv = new (_ConnectionString);
            Setting oSetting;
            try
            {
               oSetting = await Serv.GetByDependency(IdDependency);
            }
            catch (Exception)
            {
                throw;
            }
            return oSetting;
        }

        public async Task<List<dynamic>> Find(Dictionary<string, string> lParam)
        {
            SettingData oSettingData = new (_ConnectionString);
            List<dynamic> ldynamic;
            try
            {
                ldynamic = await oSettingData.Find(lParam);
            }
            catch (Exception)
            {
                throw;
            }
            return ldynamic;
        }


        public async Task<Setting> Get(int Id)
        {
            SettingData oSettingData = new (_ConnectionString);
            Setting oSetting;
            try
            {
                oSetting = await oSettingData.Get(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return oSetting;
        }


        public async Task Update(Setting setting)
        {
            SettingData oSettingData = new (_ConnectionString);
            try
            {
                await oSettingData.Update(setting);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<Setting> Insert(Setting setting)
        {
            SettingData oSettingData = new (_ConnectionString);
            Setting oSetting;
            try
            {
                oSetting = await oSettingData.Insert(setting);
            }
            catch (Exception)
            {
                throw;
            }
            return oSetting;
        }


        public async Task Delete(int Id)
        {
            SettingData oSettingData = new (_ConnectionString);
            try
            {
                await oSettingData.Delete(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Disabled(int Id,bool Disabled)
        {
            SettingData oSettingData = new (_ConnectionString);
            try
            {
                await oSettingData.Disabled(Id,Disabled);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
