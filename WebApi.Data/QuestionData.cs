using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WebApi.Entity;

namespace WebApi.Data
{
    public class QuestionData 
    {
        private readonly string _ConnectionString = string.Empty;

        public QuestionData(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public Task<List<Question>> List(int IdDependency, int CodLevel = 0) 
        {
            IRepository<Question> Serv = new ContextSQL<Question>(_ConnectionString);
            Dictionary<string, string> lParam = new Dictionary<string, string>();
            Task<DataTable> dt;
            Task<List<Question>> lQuestion;
            try
            {
                lParam.Add("IdDependency", IdDependency.ToString());
                lParam.Add("CodLevel", CodLevel.ToString());
                dt = Serv.Fill("ListByDependency", lParam);
                lQuestion = Task.FromResult(Question.ToList<Question>(dt.Result));
            }
            catch (Exception) 
            {
                throw;
            }
            return lQuestion;
        }


        public Task<Question> Get(int Id)
        {
            IRepository<Question> QuestionRepository = new ContextSQL<Question>(_ConnectionString);
            Task<Question> oQuestion;
            try
            {
                oQuestion = QuestionRepository.Get(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return oQuestion;
        }


        public Task Update(Question question)
        {
            IRepository<Question> QuestionRepository = new ContextSQL<Question>(_ConnectionString);
            Task task;
            try
            {
                task = QuestionRepository.Update(question);
            }
            catch (Exception)
            {
                throw;
            }
            return task;
        }


        public Task<Question> Insert(Question question)
        {
            IRepository<Question> QuestionRepository = new ContextSQL<Question>(_ConnectionString);
            Task<Question> oQuestion;
            try
            {
                 oQuestion = QuestionRepository.Insert(question);
            }
            catch (Exception)
            {
                throw;
            }
            return oQuestion;
        }


        public Task Delete(int Id)
        {
            IRepository<Question> QuestionRepository = new ContextSQL<Question>(_ConnectionString);
            Task task;
            try
            {
                task = QuestionRepository.Delete(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return task;
        }


        public Task Disabled(int Id, bool Disabled)
        {
            IRepository<Question> SettingRepository = new ContextSQL<Question>(_ConnectionString);
            Dictionary<string, string> lParam = new Dictionary<string, string>();
            Task<int> task;
            try
            {
                lParam.Add("Id", Id.ToString());
                lParam.Add("Disabled", Disabled.ToString());
                task = SettingRepository.ExecuteNonQuery("Disabled", lParam);
            }
            catch (Exception)
            {
                throw;
            }
            return task;
        }



    }
}
