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
    public sealed class ContextSQLAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : EntityBase, new()
    {

        #region Declaration

        private readonly ConnectionCommandPool _connectionCommandPool; // ObjectPooling maneja las conexiones

        #endregion

        public ContextSQLAsync(string ConnectionString)
        {
            _connectionCommandPool = new ConnectionCommandPool(ConnectionString, 10); // Initialize the pool
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
                get
                {
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
                dt = await Fill("List"); // Cambiar .Result por await
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

        public Task<TEntity> Get(int Id)
        {
            Dictionary<string, string> lDictionary = [];
            DataTable dt;
            lDictionary.Add("Id", Id.ToString());
            try
            {
                dt = Fill("Get", lDictionary).Result;
            }
            catch (ContextSQLException ex)
            {
                throw new ContextSQLException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Task.FromResult(EntityBase.ToList<TEntity>(dt).SingleOrDefault());
        }

        public Task<List<dynamic>> Find(Dictionary<string, string> lParam)
        {
            List<dynamic> lDynamic = [];
            DataTable dt;
            try
            {
                dt = Fill("Find", lParam).Result;
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
            return Task.FromResult(lDynamic);
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
                await ExecuteNonQuery("Delete", lDictionary); // Await the async call
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

        public Task<TEntity> Insert(TEntity oEntity)
        {
            Dictionary<string, string> lParam = [];
            DataTable dt;
            try
            {
                lParam = EntityBase.ToDictionary(oEntity);
                dt = Fill("Insert", lParam).Result;
            }
            catch (ContextSQLException ex)
            {
                throw new ContextSQLException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Task.FromResult(EntityBase.ToList<TEntity>(dt).SingleOrDefault());
        }

        public Task Update(TEntity oEntity)
        {
            Dictionary<string, string> lParam = [];
            try
            {
                lParam = EntityBase.ToDictionary(oEntity, true);
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
            return Task.FromResult(Task.CompletedTask);
        }

        #endregion

        #region Store Procedures Common Function


        /// <summary>
        /// Fill : devuelve un datatable lleno con datos asincronicamente
        /// </summary>
        /// <param name="FunctionName">
        /// Nombre de la funcion a ejecutar
        /// </param>
        /// <param name="Parameters">
        /// parametros del store procedure 
        /// </param>
        /// <returns>
        /// devueve una tarea asincronica con un datatable dentro.
        /// </returns>
        /// <exception cref="ContextSQLException">
        /// puede llegar a tener exepciones de sql controladas
        /// </exception>
        /// <exception cref="Exception">
        /// puede llegar a tener excepciones no controladas de codigo.
        /// </exception>
        public Task<DataTable> Fill(string FunctionName, Dictionary<string, string> Parameters = null)
        {
            DataSet ds = new();
            StringBuilder sbKey = new();
            StringBuilder sbFunctionName = new();
            DataTable dt = new DataTable();
            SqlCommand cmd = null; 
            SqlDataAdapter da;
            try
            {
                sbFunctionName.Append(EntityName);
                sbFunctionName.Append('_');
                sbFunctionName.Append(FunctionName);

                Parameters = Parameters ?? [];
                cmd = _connectionCommandPool.GetCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sbFunctionName.ToString();
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
            return Task.FromResult(dt);
        }


        /// <summary>
        /// ExecuteNonQuery : Ejecuta y devuelve cantidad de registros modificados
        /// </summary>
        /// <param name="FunctionName"></param>
        /// <param name="Parameters"></param>
        /// <returns>
        /// Cantidad de filas afectadas
        /// </returns>
        /// <exception cref="ContextSQLException"></exception>
        /// <exception cref="Exception"></exception>
        public Task<int> ExecuteNonQuery(string FunctionName, Dictionary<string, string> Parameters = null)
        {
            StringBuilder sb = new();
            sb.Append(EntityName);
            sb.Append('_');
            sb.Append(FunctionName);
            SqlCommand cmd;
            MessageError = string.Empty;
            StringBuilder sbKey = new();
            Task<int> iRowAffected;
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
                    iRowAffected = cmd.ExecuteNonQueryAsync();
                }

                if (MessageError.Length > 0)
                {
                    throw new ContextSQLException(MessageError);
                }

                if (iRowAffected.Result == 0) 
                {
                    throw new ContextSQLException("No row affected");
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
