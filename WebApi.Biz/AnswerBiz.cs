using System;
using WebApi.Entity;
using WebApi.Data;
using System.Threading.Tasks;

namespace WebApi.Biz
{

	public class AnswerBiz
	{

		private readonly string _ConnectionString = string.Empty;


		public AnswerBiz (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public Task<Answer> Get(int Id) 
		{
		AnswerData oAnswerData = new AnswerData(_ConnectionString); 
		Task<Answer> oAnswer;
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


		public Task Update(Answer answer)
		{
			AnswerData oAnswerData = new AnswerData(_ConnectionString);
			Task task;
			try
			{
				task = oAnswerData.Update(answer);
			}
			catch (Exception)
			{
				throw;
			}
			return task;
		}


		public Task<Answer> Insert(Answer answer)
		{
			AnswerData oAnswerData = new AnswerData(_ConnectionString);
			Task<Answer> oAnswer;
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


		public Task Delete(int Id)
		{
			AnswerData oAnswerData = new AnswerData(_ConnectionString);
			Task task;
			try
			{
				task = oAnswerData.Delete(Id);
			}
			catch (Exception)
			{
				throw;
			}
			return task;
		}

        public Task Disabled(int Id, bool Disabled)
        {
            AnswerData oAnswerData = new AnswerData(_ConnectionString);
			Task task;
            try
            {
                task = oAnswerData.Disabled(Id, Disabled);
            }
            catch (Exception)
            {
                throw;
            }
			return task;	
        }

    }

}