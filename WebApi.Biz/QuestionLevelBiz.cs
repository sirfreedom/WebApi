using System.Collections.Generic;
using WebApi.Data;
using WebApi.Entity;

namespace WebApi.Biz
{
    public class QuestionLevelBiz
    {

        private string _ConectionString = string.Empty;

        public QuestionLevelBiz(string ConectionString)
        {
            _ConectionString = ConectionString;
        }

        public List<QuestionLevel> List(int IdDependency) 
        {
            QuestionLevelData Serv = new QuestionLevelData(_ConectionString);
            return Serv.List(IdDependency);
        }

    }
}
