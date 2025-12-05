using System.Collections.Generic;
using System;
using WebApi.Entity;
using WebApi.Data;

namespace WebApi.Biz
{

	public class DependencyBiz
	{

		private readonly string _ConnectionString = string.Empty;


		public DependencyBiz (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public List<Dependency> List() 
		{
		DependencyData oDependencyData = new (_ConnectionString); 
		List<Dependency> lDependency;
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


		public Dependency Get(int Id) 
		{
		DependencyData oDependencyData = new (_ConnectionString); 
		Dependency oDependency;
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


		public void Update(Dependency dependency)
		{
		DependencyData oDependencyData = new (_ConnectionString); 
		try
		{
			oDependencyData.Update(dependency); 
		}
		catch (Exception) 
		{
			throw;
		}
		}


		public Dependency Insert(Dependency dependency)
		{
			DependencyData oDependencyData = new (_ConnectionString);
			Dependency oDependency;
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


		public void Delete(int Id)
		{
		DependencyData oDependencyData = new (_ConnectionString); 
		try
		{
			oDependencyData.Delete(Id);
		}
		catch (Exception) 
		{
			throw;
		}
		}

        public void Disabled(int Id, bool Disabled)
        {
            DependencyData oDependencyData = new (_ConnectionString);
            try
            {
                oDependencyData.Disabled(Id, Disabled);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

}