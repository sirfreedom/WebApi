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

        public async Task<List<FinalTestMessage>> List(int IdDependency) 
        { 
            FinalTestMessageData Serv = new (_ConnectionString);
            List<FinalTestMessage> lFinalTestMessage;
            try
            {
                lFinalTestMessage = await Serv.List(IdDependency);
            }
            catch (Exception)
            {
                throw;
            }
            return lFinalTestMessage;
        }

        public async Task<FinalTestMessage> Get(int Id)
        {
            FinalTestMessageData oFinalTestMessageData = new (_ConnectionString);
            FinalTestMessage oFinalTestMessage;
            try
            {
                oFinalTestMessage = await oFinalTestMessageData.Get(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return oFinalTestMessage;
        }


        public async Task Update(FinalTestMessage finaltestmessage)
        {
            FinalTestMessageData oFinalTestMessageData = new (_ConnectionString);
            try
            {
                await oFinalTestMessageData.Update(finaltestmessage);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<FinalTestMessage> Insert(FinalTestMessage finaltestmessage)
        {
            FinalTestMessageData oFinalTestMessageData = new (_ConnectionString);
            FinalTestMessage oFinalTestMessage;
            try
            {
                oFinalTestMessage = await oFinalTestMessageData.Insert(finaltestmessage);
            }
            catch (Exception)
            {
                throw;
            }
            return oFinalTestMessage;
        }


        public async Task Delete(int Id)
        {
            FinalTestMessageData oFinalTestMessageData = new (_ConnectionString);
            try
            {
                await oFinalTestMessageData.Delete(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Disabled(int Id, bool Disabled)
        {
            FinalTestMessageData oFinalTestMessageData = new (_ConnectionString);
            try
            {
                await oFinalTestMessageData.Disabled(Id, Disabled);
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
