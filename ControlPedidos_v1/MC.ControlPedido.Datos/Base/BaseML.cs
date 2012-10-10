using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MC.Enterprise.Data
{
    /// <summary>
    /// Clase Abstracta, para heredar a las clases de capa de datos
    /// Fecha Crea  : 27-02-2012
    /// Creado por  : Edgar Huarcaya C.
    /// Empresa     : Minera Laytaruma S.A.
    /// </summary>
    public abstract class BaseML: IDisposable
    {
        protected Database _database;
        private ConnectionML _connection;
        protected DbCommand _command;

        public BaseML()
        { 
            _connection = new ConnectionML();
            _database = _connection.getDatabase();
        }

        /// <summary>
        /// Propiedad que devuelve objeto base de datos
        /// </summary>
        protected Database database
        {
            get { return _database; }
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Dispose();
            }
            _connection = null;
            _database = null;
            _command = null;
        }
    }
}
