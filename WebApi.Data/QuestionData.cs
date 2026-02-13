using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public async Task<List<Question>> List(int IdDependency, int CodLevel = 0) 
        {
            Dictionary<string, string> lParam = new Dictionary<string, string>();
            DataTable dt;
            List<Question> lQuestion;
            try
            {
                IRepository<Question> Serv = new ContextSQL<Question>(_ConnectionString);
                lParam.Add("IdDependency", IdDependency.ToString());
                lParam.Add("CodLevel", CodLevel.ToString());
                dt = await Serv.Fill("ListByDependency", lParam);
                lQuestion = Question.ToList<Question>(dt);
            }
            catch (Exception) 
            {
                throw;
            }
            return lQuestion;
        }


        public async Task<Question> Get(int Id)
        {
            IRepository<Question> QuestionRepository = new ContextSQL<Question>(_ConnectionString);
            Question oQuestion;
            try
            {
                oQuestion = await QuestionRepository.Get(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return oQuestion;
        }


        public async Task Update(Question question)
        {
            IRepository<Question> QuestionRepository = new ContextSQL<Question>(_ConnectionString);
            try
            {
                await QuestionRepository.Update(question);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<Question> Insert(Question question)
        {
            IRepository<Question> QuestionRepository = new ContextSQL<Question>(_ConnectionString);
            Question oQuestion;
            DataTable dt;
            try
            {
                 dt = await QuestionRepository.Fill("Insert", question.ToDictionary());
                 oQuestion = Question.ToList<Question>(dt).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return oQuestion;
        }


        public async Task Delete(int Id)
        {
            IRepository<Question> QuestionRepository = new ContextSQL<Question>(_ConnectionString);
            try
            {
                 await QuestionRepository.Delete(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task Disabled(int Id, bool Disabled)
        {
            IRepository<Question> SettingRepository = new ContextSQL<Question>(_ConnectionString);
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
