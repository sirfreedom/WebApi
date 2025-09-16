using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Entity;

namespace WebApi.Biz
{
    public class QuestionBiz
    {

        private string _ConnectionString = string.Empty;

        public QuestionBiz(string ConnectionString) 
        { 
            _ConnectionString = ConnectionString;
        }

        public Task<List<Question>> List(int IdDependency, int CodLevel) 
        { 
            QuestionData Serv = new QuestionData(_ConnectionString);
            Task<List<Question>> lQuestion;
            try
            {
                lQuestion = Serv.List(IdDependency, CodLevel);
            }
            catch (Exception) 
            {
                throw;
            }
            return lQuestion;
        }


        public Task<Question> Get(int Id)
        {
            QuestionData oQuestionData = new QuestionData(_ConnectionString);
            Task<Question> oQuestion;
            try
            {
                oQuestion = oQuestionData.Get(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return oQuestion;
        }


        public Task Update(Question question)
        {
            QuestionData oQuestionData = new QuestionData(_ConnectionString);
            Task task;
            try
            {
                task = oQuestionData.Update(question);
            }
            catch (Exception)
            {
                throw;
            }
            return task;
        }


        public Task<Question> Insert(Question question)
        {
            QuestionData oQuestionData = new QuestionData(_ConnectionString);
            Task<Question> oQuestion;
            try
            {
                 oQuestion = oQuestionData.Insert(question);
            }
            catch (Exception)
            {
                throw;
            }
            return oQuestion;
        }


        public Task Delete(int Id)
        {
            QuestionData oQuestionData = new QuestionData(_ConnectionString);
            Task task;
            try
            {
                task = oQuestionData.Delete(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return task;
        }

        public Task Disabled(int Id, bool Disabled)
        {
            QuestionData oQuestionData = new QuestionData(_ConnectionString);
            Task task;
            try
            {
                 task = oQuestionData.Disabled(Id, Disabled);
            }
            catch (Exception)
            {
                throw;
            }
            return task;
        }


    }
}
