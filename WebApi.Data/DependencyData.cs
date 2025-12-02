using System.Collections.Generic;
using System;
using WebApi.Entity;
using System.Data;
using System.Linq;

namespace WebApi.Data
{

	public class DependencyData
	{

		private readonly string _ConnectionString = string.Empty;


		public DependencyData (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public List<Dependency> List() 
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
		return lDependency;
		}


		public Dependency Get(int Id) 
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
		return oDependency;
		}


		public void Update(Dependency dependency)
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
		}


		public Dependency Insert(Dependency dependency)
		{
			IRepository<Dependency> DependencyRepository = new ContextSQL<Dependency>(_ConnectionString);
			Dependency oDependency;
			DataTable dt;
			try
			{
				dt = DependencyRepository.Fill("Insert", dependency.ToDictionary());
                oDependency = Dependency.ToList<Dependency>(dt).SingleOrDefault();
            }
			catch (Exception)
			{
				throw;
			}
			return oDependency;
		}


		public void Delete(int Id)
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
		}

        public void Disabled(int Id, bool Disabled)
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
        }


    }

}