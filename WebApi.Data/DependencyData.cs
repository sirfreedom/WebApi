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
		List<Dependency> lDependency;
		try 
		{
			lDependency = DependencyRepository.List(); 
		}
		catch (Exception) 
		{
			throw;
		}
		return Task.FromResult(lDependency);
		}


		public Task<Dependency> Get(int Id) 
		{
		IRepository<Dependency> DependencyRepository = new ContextSQL<Dependency>(_ConnectionString);
		Dependency oDependency;
		try
		{
			oDependency = DependencyRepository.Get(Id);
		}
		catch (Exception) 
		{
			throw;
		}
		return Task.FromResult(oDependency);
		}


		public Task Update(Dependency dependency)
		{
			IRepository<Dependency> DependencyRepository = new ContextSQL<Dependency>(_ConnectionString);
			try
			{
				DependencyRepository.Update(dependency);
			}
			catch (Exception)
			{
				throw;
			}
			return Task.CompletedTask;
		}


		public Task<Dependency> Insert(Dependency dependency)
		{
			IRepository<Dependency> DependencyRepository = new ContextSQL<Dependency>(_ConnectionString);
			Dependency oDependency;
			try
			{
				oDependency = DependencyRepository.Insert(dependency);
			}
			catch (Exception)
			{
				throw;
			}
			return Task.FromResult(oDependency);
		}


		public Task Delete(int Id)
		{
			IRepository<Dependency> DependencyRepository = new ContextSQL<Dependency>(_ConnectionString);
			try
			{
				DependencyRepository.Delete(Id);
			}
			catch (Exception)
			{
				throw;
			}
			return Task.CompletedTask;
		}

        public Task Disabled(int Id, bool Disabled)
        {
            IRepository<Dependency> SettingRepository = new ContextSQL<Dependency>(_ConnectionString);
            Dictionary<string, string> lParam = new Dictionary<string, string>();
            try
            {
                lParam.Add("Id", Id.ToString());
                lParam.Add("Disabled", Disabled.ToString());
                SettingRepository.ExecuteNonQuery("Disabled", lParam);
            }
            catch (Exception)
            {
                throw;
            }
			return Task.CompletedTask;
        }


    }

}