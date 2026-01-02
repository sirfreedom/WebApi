using System;
using System.Buffers.Text;
using System.Collections.Generic;
using WebApi.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApi.Data
{

	public class InscripcionData
	{

		private readonly string _ConnectionString = string.Empty;

		public InscripcionData (string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}


		public List<Inscripcion> List()
		{
			IRepository<Inscripcion> InscripcionRepository = new ContextSQL<Inscripcion>(_ConnectionString);
			List<Inscripcion> lInscripcion;
			try
			{
				lInscripcion = InscripcionRepository.List();
			}
			catch (Exception)
			{
				throw;
			}
			return lInscripcion;
		}


        public List<dynamic> Find(Dictionary<string,string> lParam)
        {
            IRepository<Inscripcion> InscripcionRepository = new ContextSQL<Inscripcion>(_ConnectionString);
            List<dynamic> lInscripcion;
            try
            {
				lInscripcion = InscripcionRepository.Find(lParam);
            }
            catch (Exception)
            {
                throw;
            }
            return lInscripcion;
        }



        public void Insert(string InscripcionXml)
		{
			IRepository<Inscripcion> InscripcionRepository = new ContextSQL<Inscripcion>(_ConnectionString);
			Dictionary<string, string> lParam = new Dictionary<string, string>();
			string sXmlInsert = string.Empty;
			try
			{
                lParam.Add("XmlInsert", InscripcionXml);
				InscripcionRepository.ExecuteNonQuery("Insert", lParam);
			}
			catch (Exception)
			{
				throw;
			}
		}


	
		public void Contacted(int Id, bool IsContacted)
		{
			IRepository<Inscripcion> InscripcionRepository = new ContextSQL<Inscripcion>(_ConnectionString);
			Dictionary<string, string> lParam = new Dictionary<string, string>();
			try
			{
				lParam.Add("Id", Id.ToString());
				lParam.Add("IsContacted", IsContacted ? "1" : "0");
				InscripcionRepository.ExecuteNonQuery("Contacted", lParam);
			}
			catch (Exception)
			{
				throw;
			}
        }


        public void Error(int Id, bool IsError)
        {
            IRepository<Inscripcion> InscripcionRepository = new ContextSQL<Inscripcion>(_ConnectionString);
            Dictionary<string, string> lParam = new Dictionary<string, string>();
            try
            {
                lParam.Add("Id", Id.ToString());
                lParam.Add("IsError", IsError ? "1" : "0");
                InscripcionRepository.ExecuteNonQuery("Error", lParam);
            }
            catch (Exception)
            {
                throw;
            }
        }






    }

}