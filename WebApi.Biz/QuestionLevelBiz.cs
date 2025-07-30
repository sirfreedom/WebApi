using System;
using System.Collections.Generic;
using WebApi.Data;
using WebApi.Entity;

namespace WebApi.Biz
{
    public class QuestionLevelBiz
    {

        private string _ConnectionString = string.Empty;

        public QuestionLevelBiz(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public List<QuestionLevel> List(int IdDependency) 
        {
            QuestionLevelData Serv = new QuestionLevelData(_ConnectionString);
            List<QuestionLevel> lQuestionLevel;
            try
            {
                lQuestionLevel = Serv.List(IdDependency);
            }
            catch (Exception) 
            {
                throw;
            }
            return lQuestionLevel;
        }


        public QuestionLevel Get(int Id)
        {
            QuestionLevelData oQuestionLevelData = new QuestionLevelData(_ConnectionString);
            QuestionLevel oQuestionLevel;
            try
            {
                oQuestionLevel = oQuestionLevelData.Get(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return oQuestionLevel;
        }


        public void Update(QuestionLevel questionlevel)
        {
            QuestionLevelData oQuestionLevelData = new QuestionLevelData(_ConnectionString);
            try
            {
                oQuestionLevelData.Update(questionlevel);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void Insert(QuestionLevel questionlevel)
        {
            QuestionLevelData oQuestionLevelData = new QuestionLevelData(_ConnectionString);
            try
            {
                oQuestionLevelData.Insert(questionlevel);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void Delete(int Id)
        {
            QuestionLevelData oQuestionLevelData = new QuestionLevelData(_ConnectionString);
            try
            {
                oQuestionLevelData.Delete(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void Disabled(int Id, bool Disabled)
        {
            QuestionLevelData oQuestionLevelData = new QuestionLevelData(_ConnectionString);
            try
            {
                oQuestionLevelData.Disabled(Id, Disabled);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
