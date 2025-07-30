using System;
using System.Collections.Generic;
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

        public List<Question> List(int IdDependency, int CodLevel) 
        { 
            QuestionData Serv = new QuestionData(_ConnectionString);
            List<Question> lQuestion;
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


        public Question Get(int Id)
        {
            QuestionData oQuestionData = new QuestionData(_ConnectionString);
            Question oQuestion;
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


        public void Update(Question question)
        {
            QuestionData oQuestionData = new QuestionData(_ConnectionString);
            try
            {
                oQuestionData.Update(question);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void Insert(Question question)
        {
            QuestionData oQuestionData = new QuestionData(_ConnectionString);
            try
            {
                oQuestionData.Insert(question);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void Delete(int Id)
        {
            QuestionData oQuestionData = new QuestionData(_ConnectionString);
            try
            {
                oQuestionData.Delete(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Disabled(int Id, bool Disabled)
        {
            QuestionData oQuestionData = new QuestionData(_ConnectionString);
            try
            {
                oQuestionData.Disabled(Id, Disabled);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
