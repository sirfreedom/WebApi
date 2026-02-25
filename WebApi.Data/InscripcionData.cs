using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Entity;

namespace WebApi.Data
{
	public class InscripcionData
	{
		private readonly string _ConnectionString = string.Empty;

		public InscripcionData (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		public async Task<List<Inscripcion>> List()
		{
			IRead<Inscripcion> InscripcionRepository = new ContextSQL<Inscripcion>(_ConnectionString);
			List<Inscripcion> lInscripcion;
			try
			{
				lInscripcion = await InscripcionRepository.List();
			}
			catch (Exception)
			{
				throw;
			}
			return lInscripcion;
		}

        public async Task<List<dynamic>> Find(Dictionary<string,string> lParam)
        {
            IRead<Inscripcion> InscripcionRepository = new ContextSQL<Inscripcion>(_ConnectionString);
            List<dynamic> lInscripcion;
            try
            {
				lInscripcion = await InscripcionRepository.Find(lParam);
            }
            catch (Exception)
            {
                throw;
            }
            return lInscripcion;
        }

        public async Task Insert(string InscripcionXml)
		{
			IWrite<Inscripcion> InscripcionRepository = new ContextSQL<Inscripcion>(_ConnectionString);
			Dictionary<string, string> lParam = new Dictionary<string, string>();
			string sXmlInsert = string.Empty;
			try
			{
                lParam.Add("XmlInsert", InscripcionXml);
				await InscripcionRepository.ExecuteNonQuery("Insert", lParam);
			}
			catch (Exception)
			{
				throw;
			}
		}
	
		public async Task Contacted(int Id, bool IsContacted)
		{
			IWrite<Inscripcion> InscripcionRepository = new ContextSQL<Inscripcion>(_ConnectionString);
			Dictionary<string, string> lParam = new Dictionary<string, string>();
			try
			{
				lParam.Add("Id", Id.ToString());
				lParam.Add("IsContacted", IsContacted ? "1" : "0");
				await InscripcionRepository.ExecuteNonQuery("Contacted", lParam);
			}
			catch (Exception)
			{
				throw;
			}
        }

        public async Task Error(int Id, bool IsError)
        {
            IWrite<Inscripcion> InscripcionRepository = new ContextSQL<Inscripcion>(_ConnectionString);
            Dictionary<string, string> lParam = new Dictionary<string, string>();
            try
            {
                lParam.Add("Id", Id.ToString());
                lParam.Add("IsError", IsError ? "1" : "0");
                await InscripcionRepository.ExecuteNonQuery("Error", lParam);
            }
            catch (Exception)
            {
                throw;
            }
        }


		public async Task ChangeTipoInscripcion(string InscripcionXml, int IdTipoInscripcion) 
		{
            IWrite<Inscripcion> InscripcionRepository = new ContextSQL<Inscripcion>(_ConnectionString);
            Dictionary<string, string> lParam = new Dictionary<string, string>();
            try
            {
                lParam.Add("XmlInsert", InscripcionXml);
                lParam.Add("IdTipoInscripcion", IdTipoInscripcion.ToString());
                await InscripcionRepository.ExecuteNonQuery("ChangeTipoInscripcion", lParam);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }

}