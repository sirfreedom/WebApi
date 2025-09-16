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
            Dictionary<string, string> lParam = new Dictionary<string, string>();
            DataTable dt = new DataTable();
            List<Question> lQuestion;
            try
            {
                IRepository<Question> Serv = new ContextSQL<Question>(_ConnectionString);
                lParam.Add("IdDependency", IdDependency.ToString());
                lParam.Add("CodLevel", CodLevel.ToString());
                dt = Serv.Fill("ListByDependency", lParam);
                lQuestion = Question.ToList<Question>(dt);
            }
            catch (Exception) 
            {
                throw;
            }
            return Task.FromResult(lQuestion);
        }


        public Task<Question> Get(int Id)
        {
            IRepository<Question> QuestionRepository = new ContextSQL<Question>(_ConnectionString);
            Question oQuestion;
            try
            {
                oQuestion = QuestionRepository.Get(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return Task.FromResult(oQuestion);
        }


        public Task Update(Question question)
        {
            IRepository<Question> QuestionRepository = new ContextSQL<Question>(_ConnectionString);
            try
            {
                QuestionRepository.Update(question);
            }
            catch (Exception)
            {
                throw;
            }
            return Task.CompletedTask;
        }


        public Task<Question> Insert(Question question)
        {
            IRepository<Question> QuestionRepository = new ContextSQL<Question>(_ConnectionString);
            Question oQuestion;
            try
            {
                 oQuestion = QuestionRepository.Insert(question);
            }
            catch (Exception)
            {
                throw;
            }
            return Task.FromResult(oQuestion);
        }


        public Task Delete(int Id)
        {
            IRepository<Question> QuestionRepository = new ContextSQL<Question>(_ConnectionString);
            try
            {
                QuestionRepository.Delete(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return Task.CompletedTask;
        }


        public Task Disabled(int Id, bool Disabled)
        {
            IRepository<Question> SettingRepository = new ContextSQL<Question>(_ConnectionString);
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
