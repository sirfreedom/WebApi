using System.Collections.Generic;
using System;
using WebApi.Entity;

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


		public void Insert(Answer answer)
		{
		IRepository<Answer> AnswerRepository = new ContextSQL<Answer>(_ConnectionString);
		try
		{
			AnswerRepository.Insert(answer);
		}
		catch (Exception) 
		{
			throw;
		}
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


	}

}