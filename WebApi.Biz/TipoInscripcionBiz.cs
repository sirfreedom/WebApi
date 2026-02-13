using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Entity;

namespace WebApi.Biz
{
    public class TipoInscripcionBiz
    {
        private readonly string _ConnectionString = string.Empty;

        public TipoInscripcionBiz(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public async Task<List<TipoInscripcion>> List()
        {
            TipoInscripcionData oIncripcionData = new(_ConnectionString);
            List<TipoInscripcion> lTipoIncripcion;
            try
            {
                lTipoIncripcion = await oIncripcionData.List();
            }
            catch (Exception)
            {
                throw;
            }
            return lTipoIncripcion;
        }


        public async Task<TipoInscripcion> Get(int Id)
        {
            TipoInscripcionData oIncripcionData = new(_ConnectionString);
            TipoInscripcion oTipoIncripcion;
            try
            {
                oTipoIncripcion = await oIncripcionData.Get(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return oTipoIncripcion;
        }


        public async Task Update(TipoInscripcion tipoInscripcion)
        {
            TipoInscripcionData oIncripcionData = new(_ConnectionString);
            try
            {
                await oIncripcionData.Update(tipoInscripcion);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<List<TipoInscripcion>> ListMenu() 
        {
            TipoInscripcionData oIncripcionData = new(_ConnectionString);
            List<TipoInscripcion> lTipoInscripcion = new List<TipoInscripcion>();
            try
            {
                lTipoInscripcion = await oIncripcionData.ListMenu();
            }
            catch (Exception)
            {
                throw;
            }
            return lTipoInscripcion;
        }




    }
}
