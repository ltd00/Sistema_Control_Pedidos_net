using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MC.Enterprise.Data
{
    /// <summary>
    /// Clase para manejar los nulos en la base de datos
    /// Fecha crea. : 29-02-2012
    /// Creado por  : Edgar Huarcaya C.
    /// </summary>
    public class DBNulls
    {
        public static object NullValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return DBNull.Value;
            }
            return value;
        }

        public static object NullValue(int value)
        {
            if (value==0)
            {
                return DBNull.Value;
            }
            return value;
        }

        public static object NullValue(DateTime value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }

            if (value.ToShortDateString().CompareTo("01/01/0001") == 0)
            {
                return DBNull.Value;
            }

            return value;
        }

        public static object NullValue(Guid value)
        {
            if (value == Guid.Empty)
            {
                return DBNull.Value;
            }

            if (value == null)
            {
                return DBNull.Value;
            }
            return value;
        }
    }
}
