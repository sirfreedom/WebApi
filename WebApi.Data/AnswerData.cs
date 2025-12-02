using System.Collections.Generic;
using System;
using WebApi.Entity;
using System.Data;
using System.Linq;

namespace WebApi.Data
{

	public class AnswerData
	{

		private readonly string _ConnectionString = string.Empty;


		public AnswerData (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public Answer Get(int Id) 
		{
		IRepository<Answer> AnswerRepository = new ContextSQL<Answer>(_ConnectionString);
		Answer oAnswer;
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


		public void Update(Answer answer)
		{
			IRepository<Answer> AnswerRepository = new ContextSQL<Answer>(_ConnectionString);
			try
			{
				AnswerRepository.Update(answer);
			}
			catch (Exception)
			{
				throw;
			}
		}


		public Answer Insert(Answer answer)
		{
			IRepository<Answer> AnswerRepository = new ContextSQL<Answer>(_ConnectionString);
			Answer oAnswer;
			DataTable dt;
			try
			{
				dt = AnswerRepository.Fill("Insert", answer.ToDictionary());
				oAnswer = Answer.ToList<Answer>(dt).SingleOrDefault();
			}
			catch (Exception)
			{
				throw;
			}
			return oAnswer;
		}


		public void Delete(int Id)
		{
		IRepository<Answer> AnswerRepository = new ContextSQL<Answer>(_ConnectionString);
		try
		{
			AnswerRepository.Delete(Id);
		}
		catch (Exception) 
		{
			throw;
		}
		}

        public void Disabled(int Id, bool Disabled)
        {
            IRepository<Answer> SettingRepository = new ContextSQL<Answer>(_ConnectionString);
            Dictionary<string, string> lParam = new Dictionary<string, string>();
            try
            {
                lParam.Add("Id", Id.ToString());
                lParam.Add("Disabled", Disabled.ToString());
                SettingRepository.ExecuteNonQuery("Disabled", lParam);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }

}