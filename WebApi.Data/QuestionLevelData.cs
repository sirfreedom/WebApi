using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WebApi.Entity;

namespace WebApi.Data
{
    public class QuestionLevelData 
    {
        private readonly string _ConnectionString = string.Empty;

        public QuestionLevelData(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public Task<List<QuestionLevel>> List(int IdDependency) 
        { 
            Dictionary<string,string> lParam = new Dictionary<string, string>(); 
            DataTable dt;
            List<QuestionLevel> lQuestionLevel;
            try
            {
                lParam.Add("IdDependency", IdDependency.ToString());
                IRepository<QuestionLevel> Serv = new ContextSQL<QuestionLevel>(_ConnectionString);
                dt = Serv.Fill("ListByDependency", lParam);
                lQuestionLevel = QuestionLevel.ToList<QuestionLevel>(dt);
            }
            catch (Exception) 
            {
                throw;
            }
            return Task.FromResult(lQuestionLevel);
        }


        public Task<QuestionLevel> Get(int Id)
        {
            IRepositoryAsync<QuestionLevel> QuestionLevelRepository = new ContextSQLAsync<QuestionLevel>(_ConnectionString);
            Task<QuestionLevel> oQuestionLevel;
            try
            {
                oQuestionLevel = QuestionLevelRepository.Get(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return oQuestionLevel;
        }


        public Task Update(QuestionLevel questionlevel)
        {
            IRepository<QuestionLevel> QuestionLevelRepository = new ContextSQL<QuestionLevel>(_ConnectionString);
            try
            {
                QuestionLevelRepository.Update(questionlevel);
            }
            catch (Exception)
            {
                throw;
            }
            return Task.CompletedTask;
        }


        public Task<QuestionLevel> Insert(QuestionLevel questionlevel)
        {
            IRepositoryAsync<QuestionLevel> QuestionLevelRepository = new ContextSQLAsync<QuestionLevel>(_ConnectionString);
            Task<QuestionLevel> oQuestionLevel;
            try
            {
                oQuestionLevel = QuestionLevelRepository.Insert(questionlevel);
            }
            catch (Exception)
            {
                throw;
            }
            return oQuestionLevel;
        }


        public Task Delete(int Id)
        {
            IRepositoryAsync<QuestionLevel> QuestionLevelRepository = new ContextSQLAsync<QuestionLevel>(_ConnectionString);
            try
            {
                QuestionLevelRepository.Delete(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return Task.CompletedTask;
        }

        public Task Disabled(int Id, bool Disabled)
        {
            IRepositoryAsync<QuestionLevel> SettingRepository = new ContextSQLAsync<QuestionLevel>(_ConnectionString);
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
