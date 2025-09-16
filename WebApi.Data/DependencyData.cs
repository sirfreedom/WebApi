using System.Collections.Generic;
using System;
using WebApi.Entity;
using System.Threading.Tasks;

namespace WebApi.Data
{

	public class DependencyData
	{

		private readonly string _ConnectionString = string.Empty;


		public DependencyData (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public Task<List<Dependency>> List() 
		{
		IRepository<Dependency> DependencyRepository = new ContextSQL<Dependency>(_ConnectionString);
		Task<List<Dependency>> lDependency;
		try 
		{
			lDependency = DependencyRepository.List(); 
		}
		catch (Exception) 
		{
			throw;
		}
		return lDependency;
		}


		public Task<Dependency> Get(int Id) 
		{
		IRepository<Dependency> DependencyRepository = new ContextSQL<Dependency>(_ConnectionString);
		Task<Dependency> oDependency;
		try
		{
			oDependency = DependencyRepository.Get(Id);
		}
		catch (Exception) 
		{
			throw;
		}
		return oDependency;
		}


		public Task Update(Dependency dependency)
		{
			IRepository<Dependency> DependencyRepository = new ContextSQL<Dependency>(_ConnectionString);
			Task task;
			try
			{
				task = DependencyRepository.Update(dependency);
			}
			catch (Exception)
			{
				throw;
			}
			return task;
		}


		public Task<Dependency> Insert(Dependency dependency)
		{
			IRepository<Dependency> DependencyRepository = new ContextSQL<Dependency>(_ConnectionString);
			Task<Dependency> oDependency;
			try
			{
				oDependency = DependencyRepository.Insert(dependency);
			}
			catch (Exception)
			{
				throw;
			}
			return oDependency;
		}


		public Task Delete(int Id)
		{
			IRepository<Dependency> DependencyRepository = new ContextSQL<Dependency>(_ConnectionString);
			Task task;
			try
			{
				task = DependencyRepository.Delete(Id);
			}
			catch (Exception)
			{
				throw;
			}
			return task;
		}

        public Task Disabled(int Id, bool Disabled)
        {
            IRepository<Dependency> SettingRepository = new ContextSQL<Dependency>(_ConnectionString);
            Dictionary<string, string> lParam = new Dictionary<string, string>();
			Task<int> task;
            try
            {
                lParam.Add("Id", Id.ToString());
                lParam.Add("Disabled", Disabled.ToString());
                task = SettingRepository.ExecuteNonQuery("Disabled", lParam);
            }
            catch (Exception)
            {
                throw;
            }
			return task;
        }


    }

}