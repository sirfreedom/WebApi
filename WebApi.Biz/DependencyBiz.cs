using System.Collections.Generic;
using System;
using WebApi.Entity;
using WebApi.Data;
using System.Threading.Tasks;

namespace WebApi.Biz
{

	public class DependencyBiz
	{

		private readonly string _ConnectionString = string.Empty;


		public DependencyBiz (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public Task<List<Dependency>> List() 
		{
		DependencyData oDependencyData = new DependencyData(_ConnectionString); 
		Task<List<Dependency>> lDependency;
		try 
		{
			lDependency = oDependencyData.List();
		}
		catch (Exception) 
		{
			throw;
		}
		return lDependency;
		}


		public Task<Dependency> Get(int Id) 
		{
		DependencyData oDependencyData = new DependencyData(_ConnectionString); 
		Task<Dependency> oDependency;
		try
		{
			oDependency = oDependencyData.Get(Id);
		}
		catch (Exception) 
		{
			throw;
		}
		return oDependency;
		}


		public Task Update(Dependency dependency)
		{
			DependencyData oDependencyData = new DependencyData(_ConnectionString);
			Task task;
			try
			{
				task = oDependencyData.Update(dependency);
			}
			catch (Exception)
			{
				throw;
			}
			return task;
		}


		public Task<Dependency> Insert(Dependency dependency)
		{
			DependencyData oDependencyData = new DependencyData(_ConnectionString);
			Task<Dependency> oDependency;
			try
			{
				oDependency = oDependencyData.Insert(dependency);
			}
			catch (Exception)
			{
				throw;
			}
			return oDependency;
		}


		public Task Delete(int Id)
		{
		DependencyData oDependencyData = new DependencyData(_ConnectionString);
		Task task;
			try
			{
				task = oDependencyData.Delete(Id);
			}
			catch (Exception)
			{
				throw;
			}
			return task;			
		}

        public Task Disabled(int Id, bool Disabled)
        {
            DependencyData oDependencyData = new DependencyData(_ConnectionString);
			Task task;
            try
            {
                task = oDependencyData.Disabled(Id, Disabled);
            }
            catch (Exception)
            {
                throw;
            }
			return task;
        }

    }

}