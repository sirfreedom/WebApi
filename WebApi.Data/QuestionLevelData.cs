using System;
using System.Collections.Generic;
using System.Data;
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

        public List<QuestionLevel> List(int IdDependency) 
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
            return lQuestionLevel;
        }


        public QuestionLevel Get(int Id)
        {
            IRepository<QuestionLevel> QuestionLevelRepository = new ContextSQL<QuestionLevel>(_ConnectionString);
            QuestionLevel oQuestionLevel;
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


        public void Update(QuestionLevel questionlevel)
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
        }


        public QuestionLevel Insert(QuestionLevel questionlevel)
        {
            IRepository<QuestionLevel> QuestionLevelRepository = new ContextSQL<QuestionLevel>(_ConnectionString);
            QuestionLevel oQuestionLevel;
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


        public void Delete(int Id)
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
        }

        public void Disabled(int Id, bool Disabled)
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
        }



    }
}
