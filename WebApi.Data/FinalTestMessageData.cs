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
            DataSet ds = new DataSet();
            IRepository<FinalTestMessage> Serv = new ContextSQL<FinalTestMessage>(_ConnectionString);
            lParam.Add("IdDependency",IdDependency.ToString());
            ds = Serv.Fill("ListByDependency", lParam);
            return FinalTestMessage.ToList<FinalTestMessage>(ds.Tables[0]);
        }

        public List<FinalTestMessage> List()
        {
            IRepository<FinalTestMessage> Serv;
            Serv = new ContextSQL<FinalTestMessage>(_ConnectionString);
            return Serv.List();
        }

        public List<dynamic> Find(FinalTestMessage finalTestMessage) 
        {
            IRepository<FinalTestMessage> Serv;
            Serv = new ContextSQL<FinalTestMessage>(_ConnectionString);
            return Serv.Find(finalTestMessage);
        }

        public void Update(FinalTestMessage finalTestMessage) 
        {
            IRepository<FinalTestMessage> Serv;
            Serv = new ContextSQL<FinalTestMessage>(_ConnectionString);
            Serv.Update(finalTestMessage);
        }

        public void Insert(FinalTestMessage finalTestMessage) 
        {
            IRepository<FinalTestMessage> Serv;
            Serv = new ContextSQL<FinalTestMessage>(_ConnectionString);
            Serv.Insert(finalTestMessage);
        }

        public void Delete(int Id)
        {
            IRepository<FinalTestMessage> Serv;
            Serv = new ContextSQL<FinalTestMessage>(_ConnectionString);
            Serv.Delete(Id);
        }

        







    }
}
