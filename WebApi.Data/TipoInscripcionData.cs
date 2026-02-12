using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
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

        public async Task<List<TipoInscripcion>> List()
        {
            IRepository<TipoInscripcion> TipoInscripcionRepository = new ContextSQL<TipoInscripcion>(_ConnectionString);
            List<TipoInscripcion> lTipoInscripcion;
            try
            {
                lTipoInscripcion = await TipoInscripcionRepository.List();
            }
            catch (Exception)
            {
                throw;
            }
            return lTipoInscripcion;
        }


        public async Task Update(TipoInscripcion tipoInscripcion)
        {
            IRepository<TipoInscripcion> TipoInscripcionRepository = new ContextSQL<TipoInscripcion>(_ConnectionString);
            try
            {
                await TipoInscripcionRepository.Update(tipoInscripcion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TipoInscripcion> Get(int Id)
        {
            IRepository<TipoInscripcion> TipoInscripcionRepository = new ContextSQL<TipoInscripcion>(_ConnectionString);
            TipoInscripcion oTipoInscripcion;
            try
            {
                oTipoInscripcion = await TipoInscripcionRepository.Get(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return oTipoInscripcion;
        }

        public async Task<List<TipoInscripcion>> ListMenu() 
        {
            IRepository<TipoInscripcion> TipoInscripcionRepository = new ContextSQL<TipoInscripcion>(_ConnectionString);
            List<TipoInscripcion> lTipoInscripcion;
            DataTable dt;
            try
            {
                dt = await TipoInscripcionRepository.Fill("Menu", new Dictionary<string, string>());
                lTipoInscripcion = TipoInscripcion.ToList<TipoInscripcion>(dt);
            }
            catch (Exception)
            {
                throw;
            }
            return lTipoInscripcion;
        }



    }
}
