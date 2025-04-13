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

        public List<FinalTestMessage> Find(int IdDependency)
        {
            IFindRepository oServ;
            List<FinalTestMessage> lFinalTestMessage = new List<FinalTestMessage>();
            Dictionary<string,string> ld = new Dictionary<string,string>();
            ld.Add("IdDependency", IdDependency.ToString());
            oServ = new FinalTestMessageData(new ContextSQL<FinalTestMessage>(_ConnectionString));
            lFinalTestMessage = FinalTestMessage.ToList<FinalTestMessage>(oServ.Find(ld));
            return lFinalTestMessage;
        }





    }
}
