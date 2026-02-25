using System.Collections.Generic;
using System;
using WebApi.Entity;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data
{

	public class AnswerData
	{

		private readonly string _ConnectionString = string.Empty;


		public AnswerData (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public async Task<Answer> Get(int Id)
		{
			IRead<Answer> AnswerRepository = new ContextSQL<Answer>(_ConnectionString);
			Answer oAnswer;
			try
			{
				oAnswer = await AnswerRepository.Get(Id);
			}
			catch (Exception)
			{
				throw;
			}
			return oAnswer;
		}


		public async Task Update(Answer answer)
		{
			IWrite<Answer> AnswerRepository = new ContextSQL<Answer>(_ConnectionString);
			try
			{
				await AnswerRepository.Update(answer);
			}
			catch (Exception)
			{
				throw;
			}
		}


		public async Task<Answer> Insert(Answer answer)
		{
			IRead<Answer> AnswerRepository = new ContextSQL<Answer>(_ConnectionString);
			Answer oAnswer;
			DataTable dt;
			try
			{
				dt = await AnswerRepository.Fill("Insert", answer.ToDictionary());
				oAnswer = Answer.ToList<Answer>(dt).SingleOrDefault();
			}
			catch (Exception)
			{
				throw;
			}
			return oAnswer;
		}


		public async Task Delete(int Id)
		{
			IWrite<Answer> AnswerRepository = new ContextSQL<Answer>(_ConnectionString);
			try
			{
				await AnswerRepository.Delete(Id);
			}
			catch (Exception)
			{
				throw;
			}
		}

        public async Task Disabled(int Id, bool Disabled)
        {
            IWrite<Answer> SettingRepository = new ContextSQL<Answer>(_ConnectionString);
            Dictionary<string, string> lParam = new ();
            try
            {
                lParam.Add("Id", Id.ToString());
                lParam.Add("Disabled", Disabled.ToString());
                await SettingRepository.ExecuteNonQuery("Disabled", lParam);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }

}