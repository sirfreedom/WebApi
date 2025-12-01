using System.Collections.Generic;
using System;
using WebApi.Entity;
using WebApi.Data;

namespace WebApi.Biz
{

	public class InscripcionBiz
	{

		private readonly string _ConnectionString = string.Empty;

		public InscripcionBiz (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public List<Inscripcion> List()
		{
			InscripcionData oIncripcionData = new InscripcionData(_ConnectionString);
			List<Inscripcion> lIncripcion;
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


		public void Insert(List<Inscripcion> Incripciones)
		{
			InscripcionData oIncripcionData = new InscripcionData(_ConnectionString);
			try
			{
				oIncripcionData.Insert(Incripciones);
			}
			catch (Exception)
			{
				throw;
			}
		}


		public void Delete(int Id)
		{
			InscripcionData oIncripcionData = new InscripcionData(_ConnectionString);
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