using System;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Entity;

namespace WebApi.Biz
{

	public class AnswerBiz
	{

		private readonly string _ConnectionString = string.Empty;


		public AnswerBiz (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public async Task<Answer> Get(int Id) 
		{
		AnswerData oAnswerData = new (_ConnectionString); 
		Answer oAnswer;
		try
		{
			oAnswer = await oAnswerData.Get(Id);
		}
		catch (Exception) 
		{
			throw;
		}
		return oAnswer;
		}


		public async Task Update(Answer answer)
		{
		AnswerData oAnswerData = new (_ConnectionString); 
		try
		{
		 	await oAnswerData.Update(answer); 
		}
		catch (Exception) 
		{
			throw;
		}
		}


		public async Task<Answer> Insert(Answer answer)
		{
			AnswerData oAnswerData = new (_ConnectionString);
			Answer oAnswer;
			try
			{
			 	oAnswer = await oAnswerData.Insert(answer);
			}
			catch (Exception)
			{
				throw;
			}
			return oAnswer;
		}


		public async Task Delete(int Id)
		{
			AnswerData oAnswerData = new(_ConnectionString);
			try
			{
				await oAnswerData.Delete(Id);
			}
			catch (Exception)
			{
				throw;
			}
		}

        public async Task Disabled(int Id, bool Disabled)
        {
            AnswerData oAnswerData = new (_ConnectionString);
            try
            {
                await oAnswerData.Disabled(Id, Disabled);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

}