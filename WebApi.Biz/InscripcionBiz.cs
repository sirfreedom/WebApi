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
			InscripcionData oIncripcionData = new (_ConnectionString);
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


		public List<dynamic> Find(Dictionary<string,string> lParam)
		{
			InscripcionData oIncripcionData = new (_ConnectionString);
			List<dynamic> lIncripcion;
			try
			{
				lIncripcion = oIncripcionData.Find(lParam);
			}
			catch (Exception)
			{
				throw;
			}
			return lIncripcion;
        }


        public void Insert(string InscripcionXml)
		{
			InscripcionData oIncripcionData = new (_ConnectionString);
			try
			{
				oIncripcionData.Insert(InscripcionXml);
			}
			catch (Exception)
			{
				throw;
			}
		}


		public void DeleteAll()
		{
			InscripcionData oIncripcionData = new (_ConnectionString);
			try
			{
				oIncripcionData.DeleteAll();
			}
			catch (Exception)
			{
				throw;
			}
		}


		public void Conected(int Id, bool IsConected) 
		{
            InscripcionData oIncripcionData = new(_ConnectionString);
            try
            {
				oIncripcionData.Contacted(Id, IsConected);
			}
            catch (Exception)
            {
                throw;
            }
        }


        public void Error(int Id, bool IsError)
        {
            InscripcionData oIncripcionData = new(_ConnectionString);
            try
            {
                oIncripcionData.Error(Id, IsError);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateTipoInscripcion(string InscripcionXml)
        {
            InscripcionData oIncripcionData = new(_ConnectionString);
            try
            {
                oIncripcionData.UpdateTipoInscripcion(InscripcionXml);
            }
            catch (Exception)
            {
                throw;
            }
        }



    }

}