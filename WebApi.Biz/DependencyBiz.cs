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
		DependencyData oDependencyData = new DependencyData(_ConnectionString); 
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
		DependencyData oDependencyData = new DependencyData(_ConnectionString); 
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
		DependencyData oDependencyData = new DependencyData(_ConnectionString); 
		try
		{
			oDependencyData.Update(dependency); 
		}
		catch (Exception) 
		{
			throw;
		}
		}


		public void Insert(Dependency dependency)
		{
		DependencyData oDependencyData = new DependencyData(_ConnectionString); 
		try
		{
			oDependencyData.Insert(dependency);
		}
		catch (Exception) 
		{
			throw;
		}
		}


		public void Delete(int Id)
		{
		DependencyData oDependencyData = new DependencyData(_ConnectionString); 
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
            DependencyData oDependencyData = new DependencyData(_ConnectionString);
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