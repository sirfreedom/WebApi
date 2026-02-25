using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public async Task<List<FinalTestMessage>> List(int IdDependency) 
        {
            Dictionary<string,string> lParam = new ();
            DataTable dt;
            IRead<FinalTestMessage> Serv = new ContextSQL<FinalTestMessage>(_ConnectionString);
            List<FinalTestMessage> lFinalMessage;
            try
            {
                lParam.Add("IdDependency", IdDependency.ToString());
                dt = await Serv.Fill("ListByDependency", lParam);
                lFinalMessage = FinalTestMessage.ToList<FinalTestMessage>(dt);
            }
            catch (Exception)
            {
                throw;
            }
            return lFinalMessage;
        }

        public async Task<FinalTestMessage> Get(int Id)
        {
            IRead<FinalTestMessage> FinalTestMessageRepository = new ContextSQL<FinalTestMessage>(_ConnectionString);
            FinalTestMessage oFinalTestMessage;
            try
            {
                oFinalTestMessage = await FinalTestMessageRepository.Get(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return oFinalTestMessage;
        }


        public async Task Update(FinalTestMessage finaltestmessage)
        {
            IWrite<FinalTestMessage> FinalTestMessageRepository = new ContextSQL<FinalTestMessage>(_ConnectionString);
            try
            {
                await FinalTestMessageRepository.Update(finaltestmessage);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<FinalTestMessage> Insert(FinalTestMessage finaltestmessage)
        {
            IRead<FinalTestMessage> FinalTestMessageRepository = new ContextSQL<FinalTestMessage>(_ConnectionString);
            FinalTestMessage oFinalTestMessage;
            DataTable dt;
            try
            {
                dt = await FinalTestMessageRepository.Fill("Insert", finaltestmessage.ToDictionary());
                oFinalTestMessage = FinalTestMessage.ToList<FinalTestMessage>(dt).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return oFinalTestMessage;   
        }


        public async Task Delete(int Id)
        {
            IWrite<FinalTestMessage> FinalTestMessageRepository = new ContextSQL<FinalTestMessage>(_ConnectionString);
            try
            {
                await FinalTestMessageRepository.Delete(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Disabled(int Id, bool Disabled)
        {
            IWrite<FinalTestMessage> SettingRepository = new ContextSQL<FinalTestMessage>(_ConnectionString);
            Dictionary<string, string> lParam = new Dictionary<string, string>();
            try
            {
                lParam.Add("Id", Id.ToString());
                lParam.Add("Disabled", Disabled.ToString());
                await SettingRepository.ExecuteNonQuery("Disabled", lParam);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
