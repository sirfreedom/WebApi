using System.Collections.Generic;
using System;
using WebApi.Entity;
using System.Threading.Tasks;

namespace WebApi.Data
{

	public class UsuarioDependencyData
	{

		private readonly string _ConnectionString = string.Empty;

		public UsuarioDependencyData (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}


		public async Task<List<UsuarioDependency>> List()
		{
			IRepository<UsuarioDependency> UsuarioDependencyRepository = new ContextSQL<UsuarioDependency>(_ConnectionString);
			List<UsuarioDependency> lUsuarioDependency;
			try
			{
				lUsuarioDependency = await UsuarioDependencyRepository.List();
			}
			catch (Exception)
			{
				throw;
			}
			return lUsuarioDependency;
		}


		public async Task Insert(List<UsuarioDependency> usuariodependency)
		{
			IRepository<UsuarioDependency> UsuarioDependencyRepository = new ContextSQL<UsuarioDependency>(_ConnectionString);
			Dictionary<string,string> lParam = new();
			string json = string.Empty;
			try
			{
				UsuarioDependency.ToJson(usuariodependency);
				lParam.Add("JsonInsert", json);
				await UsuarioDependencyRepository.ExecuteNonQuery("Insert",lParam);
			}
			catch (Exception)
			{
				throw;
			}
		}


	}

}