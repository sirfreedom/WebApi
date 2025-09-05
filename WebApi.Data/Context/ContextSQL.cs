using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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
    internal sealed class ContextSQL<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
    {

        #region Declaration

        private readonly ConnectionCommandPool _connectionCommandPool; // ObjectPooling maneja las conexiones

        #endregion

        public ContextSQL(string ConnectionString)
        {
            _connectionCommandPool = new ConnectionCommandPool(ConnectionString,10); // Initialize the pool
        }

        public class ContextSQLException : Exception 
        {
            public ContextSQLException() { }
            
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

        public List<TEntity> List()
        {
            DataTable dt;
            try
            {
                dt = Fill("List");
            }
            catch (ContextSQLException ex)
            {
                throw new ContextSQLException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return EntityBase.ToList<TEntity>(dt);
        }

        public TEntity Get(int Id)
        {
            Dictionary<string, string> lDictionary = [];
            DataTable dt;
            lDictionary.Add("Id", Id.ToString());
            try
            {
                dt = Fill("Get", lDictionary);
            }
            catch (ContextSQLException ex)
            {
                throw new ContextSQLException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return EntityBase.ToList<TEntity>(dt).SingleOrDefault();
        }

        public List<dynamic> Find(Dictionary<string, string> lParam)
        {
            List<dynamic> lDynamic = [];
            DataTable dt;
            try
            {
                dt = Fill("Find", lParam);
                if (dt.Rows.Count > 0)
                {
                    lDynamic = EntityBase.ToDynamic(dt);
                }
            }
            catch (ContextSQLException ex)
            {
                throw new ContextSQLException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lDynamic;
        }

        public void Delete(int Id)
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
                ExecuteNonQuery("Delete", lDictionary);
            }
            catch (ContextSQLException ex)
            {
                throw new ContextSQLException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TEntity Insert(TEntity oEntity)
        {
            Dictionary<string, string> lParam = [];
            DataTable dt;
            try
            {
                lParam = EntityBase.ToDictionary(oEntity);
                dt = Fill("Insert", lParam);
            }
            catch (ContextSQLException ex)
            {
                throw new ContextSQLException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return EntityBase.ToList<TEntity>(dt).SingleOrDefault();
        }

        public void Update(TEntity oEntity)
        {
            Dictionary<string, string> lParam = [];
            try
            {
                lParam = EntityBase.ToDictionary(oEntity,true);
                ExecuteNonQuery("Update", lParam);
            }
            catch (ContextSQLException ex)
            {
                throw new ContextSQLException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Store Procedures Common Function


        /// <summary>
        /// Fill 
        /// </summary>
        /// <param name="FunctionName">
        /// Nombre del store luego del nombre de la entidad
        /// </param>
        /// <param name="Parameters">
        /// parametros del store procedure en formato dictionarary
        /// </param>
        /// <returns>
        /// devuelve una tabla con los datos solicitados
        /// </returns>
        /// <exception cref="ContextSQLException">
        /// puede devolver un error contemplado de la base de datos o errores ocurridos mientras se solicitaban los datos.
        /// </exception>
        /// <exception cref="Exception">
        /// puede devolver un error no contemplado de la operacion solicitada
        /// </exception>
        public DataTable Fill(string FunctionName, Dictionary<string, string> Parameters = null)
        {
            DataSet ds = new();
            DataTable dt = new DataTable();
            SqlCommand cmd;
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
                cmd = _connectionCommandPool.GetCommand();   // Get command from pool
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

                using (SqlConnection cn = _connectionCommandPool.GetConnection())
                {
                    cmd.Connection = cn;
                    cn.InfoMessage += cn_InfoMessage;
                    da.Fill(ds);
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
            catch (ContextSQLException ex) 
            {
                throw new ContextSQLException(ex.Message);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }


        /// <summary>
        /// ExecuteNonQuery ejecuta un store procedure con o sin parametros
        /// </summary>
        /// <param name="FunctionName">
        /// nombre del store a continuacion del nombre de la entidad
        /// </param>
        /// <param name="Parameters">
        /// parametros si los tuviera.
        /// </param>
        /// <returns>
        /// retorna los registros modificados o alterados, en el caso de que sea cero, retorna un error de "NoRowAffected"
        /// </returns>
        /// <exception cref="ContextSQLException"></exception>
        /// <exception cref="Exception"></exception>
        public int ExecuteNonQuery(string FunctionName, Dictionary<string, string> Parameters = null)
        {
            StringBuilder sb = new();
            sb.Append(EntityName);
            sb.Append('_');
            sb.Append(FunctionName);
            SqlCommand cmd;
            MessageError = string.Empty;
            StringBuilder sbKey = new ();
            int iRowAffected = 0;
            try
            {
                cmd = _connectionCommandPool.GetCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sb.ToString();
                cmd.CommandTimeout = 60;

                Parameters = Parameters == null ? [] : Parameters;

                foreach (var d in Parameters)
                {
                    sbKey.Clear();
                    sbKey.Append('@');
                    sbKey.Append(d.Key);
                    cmd.Parameters.Add(new SqlParameter(sbKey.ToString(), d.Value));
                }

                using (SqlConnection cn = _connectionCommandPool.GetConnection())
                {
                    cn.InfoMessage += cn_InfoMessage;
                    cmd.Connection = cn;
                    iRowAffected = cmd.ExecuteNonQuery();
                }

                if (MessageError.Length > 0)
                {
                    throw new ContextSQLException(MessageError);
                }

                if (iRowAffected == 0) 
                {
                    throw new ContextSQLException("No row Affected");
                }
            }
            catch (ContextSQLException ex)
            {
                throw new ContextSQLException(ex.Message);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return iRowAffected;
        }

        #endregion

    }
}
