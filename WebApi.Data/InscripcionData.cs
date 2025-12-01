using System.Collections.Generic;
using System;
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


		public void Insert(List<Inscripcion> Inscripciones)
		{
			IRepository<Inscripcion> InscripcionRepository = new ContextSQL<Inscripcion>(_ConnectionString);
			Dictionary<string, string> lParam = new Dictionary<string, string>();
			string sXmlInsert = string.Empty;
			try
			{
				sXmlInsert = Inscripcion.ToXml<Inscripcion>(Inscripciones);
                lParam.Add("XmlInsert", sXmlInsert);
				InscripcionRepository.ExecuteNonQuery("Insert", lParam);
			}
			catch (Exception)
			{
				throw;
			}
		}


		public void Delete(int Id)
		{
			IRepository<Inscripcion> InscripcionRepository = new ContextSQL<Inscripcion>(_ConnectionString);
			try
			{
				InscripcionRepository.Delete(Id);
			}
			catch (Exception)
			{
				throw;
			}
		}





	}

}