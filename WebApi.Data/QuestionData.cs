using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
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

        public List<Question> List(int IdDependency, int CodLevel = 0) 
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
            return lQuestion;
        }


        public Question Get(int Id)
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
            return oQuestion;
        }


        public void Update(Question question)
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
        }


        public Question Insert(Question question)
        {
            IRepository<Question> QuestionRepository = new ContextSQL<Question>(_ConnectionString);
            Question oQuestion;
            DataTable dt;
            try
            {
                 dt = QuestionRepository.Fill("Insert", question.ToDictionary());
                 oQuestion = Question.ToList<Question>(dt).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return oQuestion;
        }


        public void Delete(int Id)
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
        }


        public void Disabled(int Id, bool Disabled)
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
        }



    }
}
