using System.Collections.Generic;
using System;
using WebApi.Entity;
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

		public Task<Answer> Get(int Id)
		{
			IRepositoryAsync<Answer> AnswerRepository = new ContextSQLAsync<Answer>(_ConnectionString);
			Task<Answer> oAnswer;
			try
			{
				oAnswer = AnswerRepository.Get(Id);
			}
			catch (Exception)
			{
				throw;
			}
			return oAnswer;
		}


		public Task Update(Answer answer)
		{
			IRepositoryAsync<Answer> AnswerRepository = new ContextSQLAsync<Answer>(_ConnectionString);
			Task task;
			try
			{
				task = AnswerRepository.Update(answer);
			}
			catch (Exception)
			{
				throw;
			}
			return task;
		}


		public Task<Answer> Insert(Answer answer)
		{
			IRepositoryAsync<Answer> AnswerRepository = new ContextSQLAsync<Answer>(_ConnectionString);
			Task<Answer> oAnswer;
			try
			{
				oAnswer = AnswerRepository.Insert(answer);
			}
			catch (Exception)
			{
				throw;
			}
			return oAnswer;
		}


		public Task Delete(int Id)
		{
			IRepositoryAsync<Answer> AnswerRepository = new ContextSQLAsync<Answer>(_ConnectionString);
			Task task;
			try
			{
				task = AnswerRepository.Delete(Id);
			}
			catch (Exception)
			{
				throw;
			}
			return task;
		}

        public Task Disabled(int Id, bool Disabled)
        {
            IRepositoryAsync<Answer> SettingRepository = new ContextSQLAsync<Answer>(_ConnectionString);
            Dictionary<string, string> lParam = new Dictionary<string, string>();
			Task<int> task;
            try
            {
                lParam.Add("Id", Id.ToString());
                lParam.Add("Disabled", Disabled.ToString());
                task = SettingRepository.ExecuteNonQuery("Disabled", lParam);
            }
            catch (Exception)
            {
                throw;
            }
			return task;
        }


    }

}