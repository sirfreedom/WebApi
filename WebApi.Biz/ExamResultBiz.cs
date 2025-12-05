using System.Collections.Generic;
using System;
using WebApi.Entity;
using WebApi.Data;

namespace WebApi.Biz
{

	public class ExamResultBiz
	{

		private readonly string _ConnectionString = string.Empty;

		public ExamResultBiz (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public List<ExamResult> List ()
		{
		ExamResultData oExamResultData = new (_ConnectionString);
			List<ExamResult> examResults;
		try
		{
			examResults = oExamResultData.List();
		}
		catch (Exception) 
		{
			throw;
		}
		return examResults;
		}


		public void Insert(ExamResult examresult)
		{
		ExamResultData oExamResultData = new (_ConnectionString); 
		try
		{
			oExamResultData.Insert(examresult);
		}
		catch (Exception) 
		{
			throw;
		}
		}


	}

}