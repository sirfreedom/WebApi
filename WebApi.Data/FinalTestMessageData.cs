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

 

        







    }
}
