using System.Collections.Generic;
using System;
using WebApi.Entity;
using WebApi.Data;

namespace WebApi.Biz
{

	public class UsuarioDependencyBiz
	{

		private readonly string _ConnectionString = string.Empty;


		public UsuarioDependencyBiz (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public List<UsuarioDependency> List() 
		{
		UsuarioDependencyData oUsuarioDependencyData = new UsuarioDependencyData(_ConnectionString); 
		List<UsuarioDependency> lUsuarioDependency;
		try 
		{
			lUsuarioDependency = oUsuarioDependencyData.List();
		}
		catch (Exception) 
		{
			throw;
		}
		return lUsuarioDependency;
		}



		public void Insert(List<UsuarioDependency> lusuariodependency)
		{
		UsuarioDependencyData oUsuarioDependencyData = new UsuarioDependencyData(_ConnectionString); 
		try
		{
			oUsuarioDependencyData.Insert(lusuariodependency);
		}
		catch (Exception) 
		{
			throw;
		}
		}


	}

}