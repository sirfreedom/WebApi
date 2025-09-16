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
            IRepository<QuestionLevel> Serv = new ContextSQL<QuestionLevel>(_ConnectionString);
            Dictionary<string,string> lParam = new Dictionary<string, string>(); 
            Task<DataTable> dt;
            Task<List<QuestionLevel>> lQuestionLevel;
            try
            {
                lParam.Add("IdDependency", IdDependency.ToString());

                dt = Serv.Fill("ListByDependency", lParam);
                lQuestionLevel = Task.FromResult(QuestionLevel.ToList<QuestionLevel>(dt.Result));
            }
            catch (Exception) 
            {
                throw;
            }
            return lQuestionLevel;
        }


        public Task<QuestionLevel> Get(int Id)
        {
            IRepository<QuestionLevel> QuestionLevelRepository = new ContextSQL<QuestionLevel>(_ConnectionString);
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
            Task task;
            try
            {
                task = QuestionLevelRepository.Update(questionlevel);
            }
            catch (Exception)
            {
                throw;
            }
            return task;
        }


        public Task<QuestionLevel> Insert(QuestionLevel questionlevel)
        {
            IRepository<QuestionLevel> QuestionLevelRepository = new ContextSQL<QuestionLevel>(_ConnectionString);
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
            IRepository<QuestionLevel> QuestionLevelRepository = new ContextSQL<QuestionLevel>(_ConnectionString);
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
            IRepository<QuestionLevel> SettingRepository = new ContextSQL<QuestionLevel>(_ConnectionString);
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
