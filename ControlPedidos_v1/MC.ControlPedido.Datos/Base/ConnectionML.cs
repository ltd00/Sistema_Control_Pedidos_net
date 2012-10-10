using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MC.Enterprise.Data
{
    /// <summary>
    /// Clase que gestiona conexion a la base de datos
    /// Utilizando Enterprise Library de Micrsoft
    /// Creado por  : Edgar Huarcaya C.
    /// Fecha Crea  : 27-02-2012
    /// Empresa     : Minera Laytaruma S.A.
    /// </summary>
    public class ConnectionML: IDisposable
    {
        private string _connectionString;
        private Database _database;

        public ConnectionML()
        {
            _database = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("DBPedidosConnectionString");
            _connectionString = _database.ConnectionString;
        }

        /// <summary>
        /// Metodo que devuelve cadena de conexión a la base de datos
        /// </summary>
        /// <returns></returns>
        public string getConnecionString()
        {
            return _connectionString;
        }

        /// <summary>
        /// Metodo que devuelve database
        /// </summary>
        /// <returns></returns>
        public Database getDatabase()
        {
            return _database;
        }

        public void Dispose()
        {
            _connectionString = null;
            _database = null;
        }
    }
}
