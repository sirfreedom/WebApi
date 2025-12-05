using System;
using System.Collections.Generic;
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
            SettingData Serv = new (_ConnectionString);
            return Serv.GetByDependency(IdDependency);
        }

        public List<dynamic> Find(Dictionary<string, string> lParam)
        {
            SettingData oSettingData = new (_ConnectionString);
            List<dynamic> ldynamic;
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


        public Setting Get(int Id)
        {
            SettingData oSettingData = new (_ConnectionString);
            Setting oSetting;
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


        public void Update(Setting setting)
        {
            SettingData oSettingData = new (_ConnectionString);
            try
            {
                oSettingData.Update(setting);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public Setting Insert(Setting setting)
        {
            SettingData oSettingData = new (_ConnectionString);
            Setting oSetting;
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


        public void Delete(int Id)
        {
            SettingData oSettingData = new (_ConnectionString);
            try
            {
                oSettingData.Delete(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Disabled(int Id,bool Disabled)
        {
            SettingData oSettingData = new (_ConnectionString);
            try
            {
                oSettingData.Disabled(Id,Disabled);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
