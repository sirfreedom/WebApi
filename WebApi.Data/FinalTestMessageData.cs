using System;
using System.Collections.Generic;
using System.Data;
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

        public List<FinalTestMessage> List(int IdDependency) 
        {
            Dictionary<string,string> lParam = new Dictionary<string, string>();
            DataTable dt = new DataTable();
            IRepository<FinalTestMessage> Serv = new ContextSQL<FinalTestMessage>(_ConnectionString);
            lParam.Add("IdDependency",IdDependency.ToString());
            dt = Serv.Fill("ListByDependency", lParam);
            return FinalTestMessage.ToList<FinalTestMessage>(dt);
        }

        public FinalTestMessage Get(int Id)
        {
            IRepository<FinalTestMessage> FinalTestMessageRepository = new ContextSQL<FinalTestMessage>(_ConnectionString);
            FinalTestMessage oFinalTestMessage;
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


        public void Update(FinalTestMessage finaltestmessage)
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
        }


        public void Insert(FinalTestMessage finaltestmessage)
        {
            IRepository<FinalTestMessage> FinalTestMessageRepository = new ContextSQL<FinalTestMessage>(_ConnectionString);
            try
            {
                FinalTestMessageRepository.Insert(finaltestmessage);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void Delete(int Id)
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
        }



    }
}
