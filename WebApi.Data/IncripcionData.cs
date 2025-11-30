using System.Collections.Generic;
using System;
using WebApi.Entity;

namespace WebApi.Data
{

	public class IncripcionData
	{

		private readonly string _ConnectionString = string.Empty;

		public IncripcionData (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public List<Incripcion> List() 
		{
		IncripcionData oIncripcionData = new IncripcionData(_ConnectionString); 
		List<Incripcion> lIncripcion;
		try 
		{
			lIncripcion = oIncripcionData.List();
		}
		catch (Exception) 
		{
			throw;
		}
		return lIncripcion;
		}


		public void Insert(Incripcion oIncripcion)
		{
			IRepository<Incripcion> IncripcionRepository = new ContextSQL<Incripcion>(_ConnectionString);
			try
			{
				IncripcionRepository.Insert(oIncripcion);
			}
			catch (Exception)
			{
				throw;
			}
		}


		public void Delete(int Id)
		{
			IRepository<Incripcion> IncripcionRepository = new ContextSQL<Incripcion>(_ConnectionString);
			try
			{
				IncripcionRepository.Delete(Id);
			}
			catch (Exception)
			{
				throw;
			}
		}




	}

}