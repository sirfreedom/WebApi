using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public Task<List<FinalTestMessage>> List(int IdDependency) 
        { 
            FinalTestMessageData Serv = new FinalTestMessageData(_ConnectionString);
            Task<List<FinalTestMessage>> lFinalTestMessage;
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

        public Task<FinalTestMessage> Get(int Id)
        {
            FinalTestMessageData oFinalTestMessageData = new FinalTestMessageData(_ConnectionString);
            Task<FinalTestMessage> oFinalTestMessage;
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


        public Task Update(FinalTestMessage finaltestmessage)
        {
            FinalTestMessageData oFinalTestMessageData = new FinalTestMessageData(_ConnectionString);
            Task task;
            try
            {
                task = oFinalTestMessageData.Update(finaltestmessage);
            }
            catch (Exception)
            {
                throw;
            }
            return task;
        }


        public Task<FinalTestMessage> Insert(FinalTestMessage finaltestmessage)
        {
            FinalTestMessageData oFinalTestMessageData = new FinalTestMessageData(_ConnectionString);
            Task<FinalTestMessage> oFinalTestMessage;
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


        public Task Delete(int Id)
        {
            FinalTestMessageData oFinalTestMessageData = new FinalTestMessageData(_ConnectionString);
            Task task;
            try
            {
                task = oFinalTestMessageData.Delete(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return task;    
        }

        public Task Disabled(int Id, bool Disabled)
        {
            FinalTestMessageData oFinalTestMessageData = new FinalTestMessageData(_ConnectionString);
            Task task;
            try
            {
                task = oFinalTestMessageData.Disabled(Id, Disabled);
            }
            catch (Exception)
            {
                throw;
            }
            return task;
        }



    }
}
