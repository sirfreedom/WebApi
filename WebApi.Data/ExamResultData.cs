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

		public List<dynamic> Find (Dictionary<string, string> lParam)
		{
		IRepository<ExamResult> ExamResultRepository = new ContextSQL<ExamResult>(_ConnectionString);
		List<dynamic> ldynamic;
		try
		{
			ldynamic = ExamResultRepository.Find(lParam);
		}
		catch (Exception) 
		{
			throw;
		}
		return ldynamic;
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