using System;
using System.Collections.Generic;
using WebApi.Entity;

namespace WebApi.Data
{
    public class TipoInscripcionData
    {

        private readonly string _ConnectionString = string.Empty;

        public TipoInscripcionData(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public List<TipoInscripcion> List()
        {
            IRepository<TipoInscripcion> TipoInscripcionRepository = new ContextSQL<TipoInscripcion>(_ConnectionString);
            List<TipoInscripcion> lTipoInscripcion;
            try
            {
                lTipoInscripcion = TipoInscripcionRepository.List();
            }
            catch (Exception)
            {
                throw;
            }
            return lTipoInscripcion;
        }


        public void Update(TipoInscripcion tipoInscripcion)
        {
            IRepository<TipoInscripcion> TipoInscripcionRepository = new ContextSQL<TipoInscripcion>(_ConnectionString);
            try
            {
                TipoInscripcionRepository.Update(tipoInscripcion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TipoInscripcion Get(int Id)
        {
            IRepository<TipoInscripcion> TipoInscripcionRepository = new ContextSQL<TipoInscripcion>(_ConnectionString);
            TipoInscripcion oTipoInscripcion;
            try
            {
                oTipoInscripcion = TipoInscripcionRepository.Get(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return oTipoInscripcion;
        }



    }
}
