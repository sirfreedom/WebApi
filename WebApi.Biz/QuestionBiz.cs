using System.Collections.Generic;
using System.Data;
using WebApi.Data;
using WebApi.Entity;

namespace WebApi.Biz
{
    public class QuestionBiz
    {

        private string _ConectionString = string.Empty;

        public QuestionBiz(string ConectionString) 
        { 
            _ConectionString = ConectionString;
        }

        public List<Question> List(int IdDependency, int CodLevel) 
        { 
            QuestionData Serv = new QuestionData(_ConectionString);
            return Serv.List(IdDependency, CodLevel);
        }

    }
}
