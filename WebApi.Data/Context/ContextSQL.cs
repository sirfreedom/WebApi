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
    public sealed class ContextSQL<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
    {

        public ContextSQL(string ConnectionString)
        {
            _SettingConexion = ConnectionString;
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


        #region Declaration

        private readonly string _SettingConexion;

        #endregion

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
                ExecuteNonQuery("Delete", lDictionary);
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Store Procedures Common Function

        public DataTable Fill(string FunctionName, Dictionary<string, string> Parameters = null)
        {
            DataSet ds = new();
            DataTable dt = new DataTable();
            SqlCommand cmd = new();
            SqlDataAdapter da;
            StringBuilder sbKey = new();
            List<dynamic> lDynamic = [];
            StringBuilder sb = new();
            sb.Append(EntityName);
            sb.Append('_');
            sb.Append(FunctionName);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sb.ToString();
            try
            {
                Parameters = Parameters ?? [];

                foreach (var d in Parameters)
                {
                    sbKey.Clear();
                    sbKey.Append('@');
                    sbKey.Append(d.Key);
                    cmd.Parameters.Add(new SqlParameter(sbKey.ToString(), d.Value));
                }

                using (SqlConnection cn = new())
                {
                    cn.ConnectionString = _SettingConexion;
                    cmd.Connection = cn;
                    MessageError = string.Empty;
                    da = new SqlDataAdapter(cmd);
                    cn.InfoMessage += cn_InfoMessage;
                    cn.Open();
                    da.Fill(ds);
                    cn.Close();
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
            finally
            {
                cmd.Dispose();
            }
            return dt;
        }


        public void ExecuteNonQuery(string FunctionName, Dictionary<string, string> Parameters = null)
        {
            StringBuilder sb = new();
            sb.Append(EntityName);
            sb.Append('_');
            sb.Append(FunctionName);
            SqlCommand cmd = new ();
            MessageError = string.Empty;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sb.ToString();
            StringBuilder sbKey = new ();
            cmd.CommandTimeout = 60;
            try
            {
                Parameters = Parameters == null ? [] : Parameters;

                foreach (var d in Parameters)
                {
                    sbKey.Clear();
                    sbKey.Append('@');
                    sbKey.Append(d.Key);
                    cmd.Parameters.Add(new SqlParameter(sbKey.ToString(), d.Value));
                }

                using (SqlConnection cn = new())
                {
                    cn.ConnectionString = _SettingConexion;
                    cn.InfoMessage += cn_InfoMessage;
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
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
        }

        #endregion

    }
}
