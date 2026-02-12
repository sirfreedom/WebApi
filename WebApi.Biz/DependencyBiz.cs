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

		public async Task<List<Dependency>> List() 
		{
		DependencyData oDependencyData = new (_ConnectionString); 
		List<Dependency> lDependency;
		try 
		{
			lDependency = await oDependencyData.List();
		}
		catch (Exception) 
		{
			throw;
		}
		return lDependency;
		}


		public async Task<Dependency> Get(int Id)
		{
			DependencyData oDependencyData = new(_ConnectionString);
			Dependency oDependency;
			try
			{
				oDependency = await oDependencyData.Get(Id);
			}
			catch (Exception)
			{
				throw;
			}
			return oDependency;
		}


		public async Task Update(Dependency dependency)
		{
			DependencyData oDependencyData = new(_ConnectionString);
			try
			{
				await oDependencyData.Update(dependency);
			}
			catch (Exception)
			{
				throw;
			}
		}


		public async Task<Dependency> Insert(Dependency dependency)
		{
			DependencyData oDependencyData = new (_ConnectionString);
			Dependency oDependency;
			try
			{
				oDependency = await oDependencyData.Insert(dependency);
			}
			catch (Exception)
			{
				throw;
			}
			return oDependency;
		}


		public async Task Delete(int Id)
		{
			DependencyData oDependencyData = new(_ConnectionString);
			try
			{
				await oDependencyData.Delete(Id);
			}
			catch (Exception)
			{
				throw;
			}
		}

        public async Task Disabled(int Id, bool Disabled)
        {
            DependencyData oDependencyData = new (_ConnectionString);
            try
            {
                await oDependencyData.Disabled(Id, Disabled);
            }
            catch (Exception)
            {
                throw;
            }
        }



    }

}