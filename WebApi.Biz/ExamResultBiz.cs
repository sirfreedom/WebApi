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

		public List<dynamic> Find (Dictionary<string, string> lParam)
		{
		ExamResultData oExamResultData = new ExamResultData(_ConnectionString); 
		List<dynamic> ldynamic;
		try
		{
			ldynamic = oExamResultData.Find(lParam);
		}
		catch (Exception) 
		{
			throw;
		}
		return ldynamic;
		}


		public void Insert(ExamResult examresult)
		{
		ExamResultData oExamResultData = new ExamResultData(_ConnectionString); 
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