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

        public async Task<List<Question>> List(int IdDependency, int CodLevel) 
        { 
            QuestionData Serv = new (_ConnectionString);
            List<Question> lQuestion;
            try
            {
                lQuestion = await Serv.List(IdDependency, CodLevel);
            }
            catch (Exception) 
            {
                throw;
            }
            return lQuestion;
        }


        public async Task<Question> Get(int Id)
        {
            QuestionData oQuestionData = new (_ConnectionString);
            Question oQuestion;
            try
            {
                oQuestion = await oQuestionData.Get(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return oQuestion;
        }


        public async Task Update(Question question)
        {
            QuestionData oQuestionData = new (_ConnectionString);
            try
            {
                await oQuestionData.Update(question);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<Question> Insert(Question question)
        {
            QuestionData oQuestionData = new (_ConnectionString);
            Question oQuestion;
            try
            {
                 oQuestion = await oQuestionData.Insert(question);
            }
            catch (Exception)
            {
                throw;
            }
            return oQuestion;
        }


        public async Task Delete(int Id)
        {
            QuestionData oQuestionData = new (_ConnectionString);
            try
            {
                await oQuestionData.Delete(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Disabled(int Id, bool Disabled)
        {
            QuestionData oQuestionData = new (_ConnectionString);
            try
            {
                await oQuestionData.Disabled(Id, Disabled);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
