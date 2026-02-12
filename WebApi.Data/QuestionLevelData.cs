using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public async Task<List<QuestionLevel>> List(int IdDependency) 
        { 
            Dictionary<string,string> lParam = new Dictionary<string, string>(); 
            DataTable dt;
            List<QuestionLevel> lQuestionLevel;
            try
            {
                lParam.Add("IdDependency", IdDependency.ToString());
                IRepository<QuestionLevel> Serv = new ContextSQL<QuestionLevel>(_ConnectionString);
                dt = await Serv.Fill("ListByDependency", lParam);
                lQuestionLevel = QuestionLevel.ToList<QuestionLevel>(dt);
            }
            catch (Exception) 
            {
                throw;
            }
            return lQuestionLevel;
        }


        public async Task<QuestionLevel> Get(int Id)
        {
            IRepository<QuestionLevel> QuestionLevelRepository = new ContextSQL<QuestionLevel>(_ConnectionString);
            QuestionLevel oQuestionLevel;
            try
            {
                oQuestionLevel = await QuestionLevelRepository.Get(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return oQuestionLevel;
        }


        public async Task Update(QuestionLevel questionlevel)
        {
            IRepository<QuestionLevel> QuestionLevelRepository = new ContextSQL<QuestionLevel>(_ConnectionString);
            try
            {
               await QuestionLevelRepository.Update(questionlevel);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<QuestionLevel> Insert(QuestionLevel questionlevel)
        {
            IRepository<QuestionLevel> QuestionLevelRepository = new ContextSQL<QuestionLevel>(_ConnectionString);
            QuestionLevel oQuestionLevel;
            DataTable dt;
            try
            {
                dt = await QuestionLevelRepository.Fill("Insert", questionlevel.ToDictionary());
                oQuestionLevel = QuestionLevel.ToList<QuestionLevel>(dt).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return oQuestionLevel;
        }


        public async Task Delete(int Id)
        {
            IRepository<QuestionLevel> QuestionLevelRepository = new ContextSQL<QuestionLevel>(_ConnectionString);
            try
            {
               await QuestionLevelRepository.Delete(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Disabled(int Id, bool Disabled)
        {
            IRepository<QuestionLevel> SettingRepository = new ContextSQL<QuestionLevel>(_ConnectionString);
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
