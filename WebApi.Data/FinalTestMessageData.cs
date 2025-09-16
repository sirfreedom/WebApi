using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WebApi.Entity;

namespace WebApi.Data
{
    public class FinalTestMessageData 
    {

        private readonly string _ConnectionString = string.Empty;

        public FinalTestMessageData(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public Task<List<FinalTestMessage>> List(int IdDependency) 
        {
            Dictionary<string,string> lParam = new Dictionary<string, string>();
            Task<DataTable> dt;
            Task<List<FinalTestMessage>> lFinalTestMessage;
            try
            {
                IRepository<FinalTestMessage> Serv = new ContextSQL<FinalTestMessage>(_ConnectionString);
                lParam.Add("IdDependency", IdDependency.ToString());
                dt = Serv.Fill("ListByDependency", lParam);
                lFinalTestMessage = Task.FromResult(FinalTestMessage.ToList<FinalTestMessage>(dt.Result));
            }
            catch (Exception) 
            { 
                throw;
            }
            return lFinalTestMessage;
        }

        public Task<FinalTestMessage> Get(int Id)
        {
            IRepository<FinalTestMessage> FinalTestMessageRepository = new ContextSQL<FinalTestMessage>(_ConnectionString);
            Task<FinalTestMessage> oFinalTestMessage;
            try
            {
                oFinalTestMessage = FinalTestMessageRepository.Get(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return oFinalTestMessage;
        }


        public Task Update(FinalTestMessage finaltestmessage)
        {
            IRepository<FinalTestMessage> FinalTestMessageRepository = new ContextSQL<FinalTestMessage>(_ConnectionString);
            try
            {
                FinalTestMessageRepository.Update(finaltestmessage);
            }
            catch (Exception)
            {
                throw;
            }
            return Task.CompletedTask;
        }


        public Task<FinalTestMessage> Insert(FinalTestMessage finaltestmessage)
        {
            IRepository<FinalTestMessage> FinalTestMessageRepository = new ContextSQL<FinalTestMessage>(_ConnectionString);
            Task<FinalTestMessage> oFinalTestMessage;
            try
            {
                oFinalTestMessage = FinalTestMessageRepository.Insert(finaltestmessage);
            }
            catch (Exception)
            {
                throw;
            }
            return oFinalTestMessage;   
        }


        public Task Delete(int Id)
        {
            IRepository<FinalTestMessage> FinalTestMessageRepository = new ContextSQL<FinalTestMessage>(_ConnectionString);
            try
            {
                FinalTestMessageRepository.Delete(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return Task.CompletedTask;
        }

        public Task Disabled(int Id, bool Disabled)
        {
            IRepository<FinalTestMessage> SettingRepository = new ContextSQL<FinalTestMessage>(_ConnectionString);
            Dictionary<string, string> lParam = new Dictionary<string, string>();
            try
            {
                lParam.Add("Id", Id.ToString());
                lParam.Add("Disabled", Disabled.ToString());
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
