using System.Collections.Generic;
using System;
using WebApi.Entity;

namespace WebApi.Data
{

	public class ExamResultData
	{

		private readonly string _ConnectionString = string.Empty;

		public ExamResultData (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public List<ExamResult> List ()
		{
		IRepository<ExamResult> ExamResultRepository = new ContextSQL<ExamResult>(_ConnectionString);
		List<ExamResult> examResults;
		try
		{
			examResults = ExamResultRepository.List();
		}
		catch (Exception) 
		{
			throw;
		}
		return examResults;
		}


		public void Insert(ExamResult examresult)
		{
		IRepository<ExamResult> ExamResultRepository = new ContextSQL<ExamResult>(_ConnectionString);
		try
		{
			ExamResultRepository.Insert(examresult);
		}
		catch (Exception) 
		{
			throw;
		}
		}


	}

}