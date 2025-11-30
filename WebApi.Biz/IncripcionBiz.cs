using System.Collections.Generic;
using System;
using WebApi.Entity;
using WebApi.Data;

namespace WebApi.Biz
{

	public class IncripcionBiz
	{

		private readonly string _ConnectionString = string.Empty;

		public IncripcionBiz (string ConnectionString)
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
			IncripcionData oIncripcionData = new IncripcionData(_ConnectionString);
			try
			{
				oIncripcionData.Insert(oIncripcion);
			}
			catch (Exception)
			{
				throw;
			}
		}


		public void Delete(int Id)
		{
			IncripcionData oIncripcionData = new IncripcionData(_ConnectionString);
			try
			{
				oIncripcionData.Delete(Id);
			}
			catch (Exception)
			{
				throw;
			}
		}



	}

}