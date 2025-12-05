using System;
using WebApi.Entity;
using WebApi.Data;

namespace WebApi.Biz
{

	public class AnswerBiz
	{

		private readonly string _ConnectionString = string.Empty;


		public AnswerBiz (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public Answer Get(int Id) 
		{
		AnswerData oAnswerData = new (_ConnectionString); 
		Answer oAnswer;
		try
		{
			oAnswer = oAnswerData.Get(Id);
		}
		catch (Exception) 
		{
			throw;
		}
		return oAnswer;
		}


		public void Update(Answer answer)
		{
		AnswerData oAnswerData = new (_ConnectionString); 
		try
		{
			oAnswerData.Update(answer); 
		}
		catch (Exception) 
		{
			throw;
		}
		}


		public Answer Insert(Answer answer)
		{
			AnswerData oAnswerData = new (_ConnectionString);
			Answer oAnswer;
			try
			{
			 	oAnswer = oAnswerData.Insert(answer);
			}
			catch (Exception)
			{
				throw;
			}
			return oAnswer;
		}


		public void Delete(int Id)
		{
		AnswerData oAnswerData = new (_ConnectionString); 
		try
		{
			oAnswerData.Delete(Id);
		}
		catch (Exception) 
		{
			throw;
		}
		}

        public void Disabled(int Id, bool Disabled)
        {
            AnswerData oAnswerData = new (_ConnectionString);
            try
            {
                oAnswerData.Disabled(Id, Disabled);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

}