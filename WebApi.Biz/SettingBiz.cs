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
            SettingData Serv = new SettingData(_ConnectionString);
            return Serv.GetByDependency(IdDependency);
        }

        public List<Setting> List()
        {
            SettingData oSettingData = new SettingData(_ConnectionString);
            List<Setting> lSetting;
            try
            {
                lSetting = oSettingData.List();
            }
            catch (Exception)
            {
                throw;
            }
            return lSetting;
        }


        public Setting Get(int Id)
        {
            SettingData oSettingData = new SettingData(_ConnectionString);
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
            SettingData oSettingData = new SettingData(_ConnectionString);
            try
            {
                oSettingData.Update(setting);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void Insert(Setting setting)
        {
            SettingData oSettingData = new SettingData(_ConnectionString);
            try
            {
                oSettingData.Insert(setting);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void Delete(int Id)
        {
            SettingData oSettingData = new SettingData(_ConnectionString);
            try
            {
                oSettingData.Delete(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
