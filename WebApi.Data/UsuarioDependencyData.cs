using System.Collections.Generic;
using System;
using WebApi.Entity;

namespace WebApi.Data
{

	public class UsuarioDependencyData
	{

		private readonly string _ConnectionString = string.Empty;

		public UsuarioDependencyData (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}


		public List<UsuarioDependency> List()
		{
			IRepository<UsuarioDependency> UsuarioDependencyRepository = new ContextSQL<UsuarioDependency>(_ConnectionString);
			List<UsuarioDependency> lUsuarioDependency;
			try
			{
				lUsuarioDependency = UsuarioDependencyRepository.List();
			}
			catch (Exception)
			{
				throw;
			}
			return lUsuarioDependency;
		}


		public void Insert(List<UsuarioDependency> usuariodependency)
		{
			IRepository<UsuarioDependency> UsuarioDependencyRepository = new ContextSQL<UsuarioDependency>(_ConnectionString);
			Dictionary<string,string> lParam = new();
			string json = string.Empty;
			try
			{
				UsuarioDependency.ToJson(usuariodependency);
				lParam.Add("JsonInsert", json);
				UsuarioDependencyRepository.ExecuteNonQuery("Insert",lParam);
			}
			catch (Exception)
			{
				throw;
			}
		}


	}

}