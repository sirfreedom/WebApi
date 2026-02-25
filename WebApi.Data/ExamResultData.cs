using System.Collections.Generic;
using System;
using WebApi.Entity;
using System.Threading.Tasks;

namespace WebApi.Data
{

	public class ExamResultData
	{

		private readonly string _ConnectionString = string.Empty;

		public ExamResultData (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public async Task<List<ExamResult>> List()
		{
			IRead<ExamResult> ExamResultRepository = new ContextSQL<ExamResult>(_ConnectionString);
			List<ExamResult> examResults;
			try
			{
				examResults = await ExamResultRepository.List();
			}
			catch (Exception)
			{
				throw;
			}
			return examResults;
		}


		public async Task Insert(ExamResult examresult)
		{
			IWrite<ExamResult> ExamResultRepository = new ContextSQL<ExamResult>(_ConnectionString);
			try
			{
				await ExamResultRepository.Insert(examresult);
			}
			catch (Exception)
			{
				throw;
			}
		}


	}

}