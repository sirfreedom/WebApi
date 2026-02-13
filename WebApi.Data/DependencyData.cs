using System.Collections.Generic;
using System;
using WebApi.Entity;
using System.Data;
using System.Linq;
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

		public async Task<List<Dependency>> List()
		{
			IRepository<Dependency> DependencyRepository = new ContextSQL<Dependency>(_ConnectionString);
			List<Dependency> lDependency;
			try
			{
				lDependency = await DependencyRepository.List();
			}
			catch (Exception)
			{
				throw;
			}
			return lDependency;
		}


		public async Task<Dependency> Get(int Id)
		{
			IRepository<Dependency> DependencyRepository = new ContextSQL<Dependency>(_ConnectionString);
			Dependency oDependency;
			try
			{
				oDependency = await DependencyRepository.Get(Id);
			}
			catch (Exception)
			{
				throw;
			}
			return oDependency;
		}


		public async Task Update(Dependency dependency)
		{
			IRepository<Dependency> DependencyRepository = new ContextSQL<Dependency>(_ConnectionString);
			try
			{
				await DependencyRepository.Update(dependency);
			}
			catch (Exception)
			{
				throw;
			}
		}


		public async Task<Dependency> Insert(Dependency dependency)
		{
			IRepository<Dependency> DependencyRepository = new ContextSQL<Dependency>(_ConnectionString);
			Dependency oDependency;
			DataTable dt;
			try
			{
				dt = await DependencyRepository.Fill("Insert", dependency.ToDictionary());
                oDependency = Dependency.ToList<Dependency>(dt).SingleOrDefault();
            }
			catch (Exception)
			{
				throw;
			}
			return oDependency;
		}


		public async Task Delete(int Id)
		{
			IRepository<Dependency> DependencyRepository = new ContextSQL<Dependency>(_ConnectionString);
			try
			{
				await DependencyRepository.Delete(Id);
			}
			catch (Exception)
			{
				throw;
			}
		}


        public async Task Disabled(int Id, bool Disabled)
        {
            IRepository<Dependency> SettingRepository = new ContextSQL<Dependency>(_ConnectionString);
            Dictionary<string, string> lParam = new Dictionary<string, string>();
            try
            {
                lParam.Add("Id", Id.ToString());
                lParam.Add("Disabled", Disabled.ToString());
                await SettingRepository.ExecuteNonQuery("Disabled", lParam);
            }
            catch (Exception)
            {
                throw;
            }
        }



    }

}