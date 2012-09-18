using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace MC.Enterprise.Data
{
    /// <summary>
    /// Clase que gestiona transacciones en la base de datos
    /// Fecha Crea  : 27-02-2012
    /// Creado por  : Edgar Huarcaya C.
    /// Empresa     : Minera Laytaruma S.A.
    /// </summary>
    public class TransactionML : IDisposable
    {
        private DbTransaction _dbTransaction;       //Objeto de tipo de transaccion
        private ConnectionML _mlconnection;         //Objeto de tipo MLConnection para obtener cadena de conexion a la base de datos
        private DbConnection _dbconnection;         //Objeto de tipo connection generica para abrir conexion a la base de datos

        public TransactionML()
        {
            _mlconnection = new ConnectionML();
        }

        /// <summary>
        /// Metodo que inicia transaccion en la base de datos
        /// </summary>
        public void BeginTransaction()
        {
            try
            {
                _dbconnection = (SqlConnection)_mlconnection.getDatabase().CreateConnection();  //Crea objeto de conexion de tipo SQLConnection
                _dbconnection.Open();
                _dbTransaction = _dbconnection.BeginTransaction();

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Metodo que termina transaccion exitosa
        /// </summary>
        public void CommitTransaction()
        {
            try
            {
                _dbTransaction.Commit();
                _dbTransaction.Dispose();
                _dbconnection.Close();
                _dbconnection = null;

                _mlconnection.Dispose();
                _mlconnection = null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Metodo que termina transaccion fallida
        /// </summary>
        public void RollbackTransaction()
        {
            try
            {
                _dbTransaction.Rollback();
                _dbTransaction.Dispose();
                _dbconnection.Close();
                _dbconnection = null;

                _mlconnection.Dispose();
                _mlconnection = null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Metodo que devuelve objeto de tipo Transaccion
        /// </summary>
        /// <returns></returns>
        public DbTransaction GetTransaction()
        {
            return _dbTransaction;
        }

        public void Dispose()
        {
            if (_dbTransaction != null)
            {
                _dbTransaction.Dispose();
            }
            _dbTransaction = null;


            if (_mlconnection != null)
            {
                _mlconnection.Dispose();
            }
            _mlconnection = null;

            if (_dbconnection != null)
            {
                _dbconnection.Dispose();
            }
            _dbconnection = null;
        }
    }
}