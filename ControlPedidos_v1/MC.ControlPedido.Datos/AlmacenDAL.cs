using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MC.Enterprise.Data;

namespace MC.ControlPedido.Datos
{
    public class AlmacenDAL: BaseML
    {
        public DataTable ListarAlmacen(string codEmpresa)
        {
            DataTable dtData = null;
            _command = _database.GetStoredProcCommand("usp_ControlPedido_ListarIn09Almacen");
            try
            {

                _database.AddInParameter(_command, "@in09codemp", System.Data.DbType.String, codEmpresa);

                dtData = _database.ExecuteDataSet(_command).Tables[0];
                return dtData;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
