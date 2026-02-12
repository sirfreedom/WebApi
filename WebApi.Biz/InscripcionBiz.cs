using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Entity;


namespace WebApi.Biz
{

	public class InscripcionBiz
	{

		private readonly string _ConnectionString = string.Empty;

		public InscripcionBiz (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public async Task<List<Inscripcion>> List()
		{
			InscripcionData oIncripcionData = new (_ConnectionString);
			List<Inscripcion> lIncripcion;
			try
			{
				lIncripcion = await oIncripcionData.List();
			}
			catch (Exception)
			{
				throw;
			}
			return lIncripcion;
		}


		public async Task<List<dynamic>> Find(Dictionary<string,string> lParam)
		{
			InscripcionData oIncripcionData = new (_ConnectionString);
			List<dynamic> lIncripcion;
			try
			{
				lIncripcion = await oIncripcionData.Find(lParam);
			}
			catch (Exception)
			{
				throw;
			}
			return lIncripcion;
        }


        public async Task Insert(string InscripcionXml)
		{
			InscripcionData oIncripcionData = new (_ConnectionString);
			try
			{
				await oIncripcionData.Insert(InscripcionXml);
			}
			catch (Exception)
			{
				throw;
			}
		}


		public async Task Conected(int Id, bool IsConected) 
		{
            InscripcionData oIncripcionData = new(_ConnectionString);
            try
            {
				await oIncripcionData.Contacted(Id, IsConected);
			}
            catch (Exception)
            {
                throw;
            }
        }


        public async Task Error(int Id, bool IsError)
        {
            InscripcionData oIncripcionData = new(_ConnectionString);
            try
            {
                await oIncripcionData.Error(Id, IsError);
            }
            catch (Exception)
            {
                throw;
            }
        }


		public async Task ChangeTipoInscripcion(string InscripcionXml, int IdTipoInscripcion) 
		{
            InscripcionData oIncripcionData = new(_ConnectionString);
            try
            {
                await oIncripcionData.ChangeTipoInscripcion(InscripcionXml, IdTipoInscripcion);
            }
            catch (Exception)
            {
                throw;
            }
        }




    }

}