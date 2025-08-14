using System;
using System.Collections.Generic;
using WebApi.Data;
using WebApi.Entity;

namespace WebApi.Biz
{
    public class FinalTestMessageBiz 
    {
        private readonly string _ConnectionString = string.Empty;
        
        public FinalTestMessageBiz(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public List<FinalTestMessage> List(int IdDependency) 
        { 
            FinalTestMessageData Serv = new FinalTestMessageData(_ConnectionString);
            List<FinalTestMessage> lFinalTestMessage;
            try
            {
                lFinalTestMessage = Serv.List(IdDependency);
            }
            catch (Exception)
            {
                throw;
            }
            return lFinalTestMessage;
        }

        public FinalTestMessage Get(int Id)
        {
            FinalTestMessageData oFinalTestMessageData = new FinalTestMessageData(_ConnectionString);
            FinalTestMessage oFinalTestMessage;
            try
            {
                oFinalTestMessage = oFinalTestMessageData.Get(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return oFinalTestMessage;
        }


        public void Update(FinalTestMessage finaltestmessage)
        {
            FinalTestMessageData oFinalTestMessageData = new FinalTestMessageData(_ConnectionString);
            try
            {
                oFinalTestMessageData.Update(finaltestmessage);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public FinalTestMessage Insert(FinalTestMessage finaltestmessage)
        {
            FinalTestMessageData oFinalTestMessageData = new FinalTestMessageData(_ConnectionString);
            FinalTestMessage oFinalTestMessage;
            try
            {
                oFinalTestMessage = oFinalTestMessageData.Insert(finaltestmessage);
            }
            catch (Exception)
            {
                throw;
            }
            return oFinalTestMessage;
        }


        public void Delete(int Id)
        {
            FinalTestMessageData oFinalTestMessageData = new FinalTestMessageData(_ConnectionString);
            try
            {
                oFinalTestMessageData.Delete(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Disabled(int Id, bool Disabled)
        {
            FinalTestMessageData oFinalTestMessageData = new FinalTestMessageData(_ConnectionString);
            try
            {
                oFinalTestMessageData.Disabled(Id, Disabled);
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
