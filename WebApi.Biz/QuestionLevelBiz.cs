using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<List<QuestionLevel>> List(int IdDependency) 
        {
            QuestionLevelData Serv = new (_ConnectionString);
            List<QuestionLevel> lQuestionLevel;
            try
            {
                lQuestionLevel = await Serv.List(IdDependency);
            }
            catch (Exception) 
            {
                throw;
            }
            return lQuestionLevel;
        }


        public async Task<QuestionLevel> Get(int Id)
        {
            QuestionLevelData oQuestionLevelData = new (_ConnectionString);
            QuestionLevel oQuestionLevel;
            try
            {
                oQuestionLevel = await oQuestionLevelData.Get(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return oQuestionLevel;
        }


        public async Task Update(QuestionLevel questionlevel)
        {
            QuestionLevelData oQuestionLevelData = new (_ConnectionString);
            try
            {
                await oQuestionLevelData.Update(questionlevel);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<QuestionLevel> Insert(QuestionLevel questionlevel)
        {
            QuestionLevelData oQuestionLevelData = new (_ConnectionString);
            QuestionLevel oQuestionLevel;
            try
            {
                oQuestionLevel = await oQuestionLevelData.Insert(questionlevel);
            }
            catch (Exception)
            {
                throw;
            }
            return oQuestionLevel;
        }


        public async Task Delete(int Id)
        {
            QuestionLevelData oQuestionLevelData = new (_ConnectionString);
            try
            {
                await oQuestionLevelData.Delete(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task Disabled(int Id, bool Disabled)
        {
            QuestionLevelData oQuestionLevelData = new (_ConnectionString);
            try
            {
                await oQuestionLevelData.Disabled(Id, Disabled);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
