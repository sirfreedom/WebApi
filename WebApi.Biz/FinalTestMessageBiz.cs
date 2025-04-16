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
            return Serv.List(IdDependency);
        }


    }
}
