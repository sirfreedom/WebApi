using System;
using System.Collections.Generic;
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

        public List<TipoInscripcion> List()
        {
            TipoInscripcionData oIncripcionData = new(_ConnectionString);
            List<TipoInscripcion> lTipoIncripcion;
            try
            {
                lTipoIncripcion = oIncripcionData.List();
            }
            catch (Exception)
            {
                throw;
            }
            return lTipoIncripcion;
        }


        public TipoInscripcion Get(int Id)
        {
            TipoInscripcionData oIncripcionData = new(_ConnectionString);
            TipoInscripcion oTipoIncripcion;
            try
            {
                oTipoIncripcion = oIncripcionData.Get(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return oTipoIncripcion;
        }


        public void Update(TipoInscripcion tipoInscripcion)
        {
            TipoInscripcionData oIncripcionData = new(_ConnectionString);
            try
            {
                oIncripcionData.Update(tipoInscripcion);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<TipoInscripcion> ListMenu() 
        {
            TipoInscripcionData oIncripcionData = new(_ConnectionString);
            List<TipoInscripcion> lTipoInscripcion = new List<TipoInscripcion>();
            try
            {
                lTipoInscripcion = oIncripcionData.ListMenu();
            }
            catch (Exception)
            {
                throw;
            }
            return lTipoInscripcion;
        }




    }
}
