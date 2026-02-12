using System.Collections.Generic;
using System;
using WebApi.Entity;
using WebApi.Data;
using System.Threading.Tasks;

namespace WebApi.Biz
{

	public class UsuarioDependencyBiz
	{

		private readonly string _ConnectionString = string.Empty;


		public UsuarioDependencyBiz (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public async Task<List<UsuarioDependency>> List()
		{
			UsuarioDependencyData oUsuarioDependencyData = new(_ConnectionString);
			List<UsuarioDependency> lUsuarioDependency;
			try
			{
				lUsuarioDependency = await oUsuarioDependencyData.List();
			}
			catch (Exception)
			{
				throw;
			}
			return lUsuarioDependency;
		}


		public async Task Insert(List<UsuarioDependency> lusuariodependency)
		{
			UsuarioDependencyData oUsuarioDependencyData = new(_ConnectionString);
			try
			{
				await oUsuarioDependencyData.Insert(lusuariodependency);
			}
			catch (Exception)
			{
				throw;
			}
		}


	}

}