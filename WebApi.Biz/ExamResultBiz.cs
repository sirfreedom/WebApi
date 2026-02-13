using System.Collections.Generic;
using System;
using WebApi.Entity;
using WebApi.Data;
using System.Threading.Tasks;

namespace WebApi.Biz
{

	public class ExamResultBiz
	{

		private readonly string _ConnectionString = string.Empty;

		public ExamResultBiz (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public async Task<List<ExamResult>> List()
		{
			ExamResultData oExamResultData = new(_ConnectionString);
			List<ExamResult> examResults;
			try
			{
				examResults = await oExamResultData.List();
			}
			catch (Exception)
			{
				throw;
			}
			return examResults;
		}


		public async Task Insert(ExamResult examresult)
		{
			ExamResultData oExamResultData = new(_ConnectionString);
			try
			{
				await oExamResultData.Insert(examresult);
			}
			catch (Exception)
			{
				throw;
			}
		}




	}

}