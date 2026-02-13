using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entity;

namespace WebApi.Data
{

    /// <summary>
    /// Context es una entidad de uso, no de herencia, la implemetacion tipada IRepository sirve para hacer la abstraccion de sus metodos ya que context puede cambiar en el tiempo
    /// o puede usarse otro context que respete la firma IRepository
    /// </summary>
    /// <typeparam name="TEntity">
    /// la entidad TEntity es una entidad abstracta hasta que se implementa de forma concreta para poder interactuar con el List o demas metodos
    /// TEntity solo puede existir SOLO si esta heredada por EntityBase y tiene un constructor sin parametros asi lo exige la implementacion.
    /// </typeparam>
    public sealed class ContextSQL<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
    {

        #region Declaration

        private readonly string _conectionString;

        #endregion

        public ContextSQL(string conectionString)
        {
            _conectionString = conectionString;
        }

        public class ContextSQLException : Exception 
        {
            
            public ContextSQLException(string message) 
            { 
                _Message = message;
            }

            private string _Message = string.Empty;

            public override string Message 
            {
                get {
                    _Message = base.Message;
                    return _Message;
                }
            }
        }

        #region Properties

        public string EntityName
        {
            get
            {
                Type type = typeof(TEntity);
                return type.Name;
            }
        }

        public string MessageError
        {
            get; private set;
        }


        #endregion

        #region Catch Sql Errors


        /// <summary>
        /// Este evento devuelve errores de sql 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            MessageError = e.Message;
        }

        #endregion

        #region Interface Method

        public async Task<List<TEntity>> List()
        {
            DataTable dt;
            try
            {
                dt = await Fill("List");
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return EntityBase.ToList<TEntity>(dt);
        }

        public async Task<TEntity> Get(int Id)
        {
            Dictionary<string, string> lDictionary = [];
            DataTable dt;
            lDictionary.Add("Id", Id.ToString());
            try
            {
                dt = await Fill("Get", lDictionary);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return EntityBase.ToList<TEntity>(dt).SingleOrDefault();
        }

        public async Task<List<dynamic>> Find(Dictionary<string, string> lParam)
        {
            List<dynamic> lDynamic = [];
            DataTable dt;
            try
            {
                dt = await Fill("Find", lParam);
                if (dt.Rows.Count > 0)
                {
                    lDynamic = EntityBase.ToDynamic(dt);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lDynamic;
        }

        public async Task Delete(int Id)
        {
            Dictionary<string, string> lDictionary = new()
            {
                { "Id", Id.ToString() }
            };
            try
            {
                if (Id == 0) 
                {
                    throw new Exception("This Id not be zero");
                }
                await ExecuteNonQuery("Delete", lDictionary);
            }
            catch(SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Insert(TEntity oEntity)
        {
            Dictionary<string, string> lParam = [];
            try
            {
                lParam = EntityBase.ToDictionary(oEntity);
                await ExecuteNonQuery("Insert", lParam);
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update(TEntity oEntity)
        {
            Dictionary<string, string> lParam = [];
            try
            {
                lParam = EntityBase.ToDictionary(oEntity,true);
                await ExecuteNonQuery("Update", lParam);
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Store Procedures Common Function

        public async Task<DataTable> Fill(string FunctionName, Dictionary<string, string> Parameters = null)
        {
            SqlCommand cmd = new();
            DataSet ds = new();
            DataTable dt = new ();
            SqlDataAdapter da;
            StringBuilder sbKey = new();
            List<dynamic> lDynamic = [];
            StringBuilder sb = new();
            sb.Append(EntityName);
            sb.Append('_');
            sb.Append(FunctionName);
            try
            {
                Parameters = Parameters ?? [];
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sb.ToString();
                MessageError = string.Empty;
                da = new SqlDataAdapter(cmd);

                foreach (var d in Parameters)
                {
                    sbKey.Clear();
                    sbKey.Append('@');
                    sbKey.Append(d.Key);
                    cmd.Parameters.Add(new SqlParameter(sbKey.ToString(), d.Value));
                }

                using (SqlConnection cn = new SqlConnection(_conectionString))
                {
                    cmd.Connection = cn;
                    cn.InfoMessage += cn_InfoMessage;
                    cn.Open();
                    await Task.Run(() => da.Fill(ds));
                }

                if (ds.Tables.Count == 0)
                {
                    dt = new DataTable();
                }
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                if (MessageError.Length > 0)
                {
                    throw new ContextSQLException(MessageError);
                }
            }
            catch (ContextSQLException)
            {
                throw;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw ;
            }
            return dt;
        }


        public async Task ExecuteNonQuery(string FunctionName, Dictionary<string, string> Parameters = null)
        {
            SqlCommand cmd = new();
            StringBuilder sb = new();
            sb.Append(EntityName);
            sb.Append('_');
            sb.Append(FunctionName);
            MessageError = string.Empty;
            StringBuilder sbKey = new ();
            int iRowAffected = 0;
            try
            {
                Parameters = Parameters == null ? [] : Parameters;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sb.ToString();
                cmd.CommandTimeout = 60;

                foreach (var d in Parameters)
                {
                    sbKey.Clear();
                    sbKey.Append('@');
                    sbKey.Append(d.Key);
                    cmd.Parameters.Add(new SqlParameter(sbKey.ToString(), d.Value));
                }

                using (SqlConnection cn = new(_conectionString))
                {
                    cmd.Connection = cn;
                    cn.InfoMessage += cn_InfoMessage;
                    cn.Open();
                    iRowAffected = await cmd.ExecuteNonQueryAsync();
                }

                if (iRowAffected == 0)
                {
                    throw new Exception("No rows were affected by the operation.");
                }

                if (MessageError.Length > 0)
                {
                    throw new ContextSQLException(MessageError);
                }
            }
            catch (ContextSQLException)
            {
                throw;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

    }
}
