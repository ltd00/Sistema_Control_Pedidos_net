using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MC.Enterprise.Data;

namespace MC.ControlPedido.Datos
{
    public class AreaDAL: BaseML
    {
        public DataTable ListarArea(string codEmpresa, string codigoUsuario)
        {
            DataTable dtData = null;
            _command = _database.GetStoredProcCommand("usp_ControlPedido_listarArea");
            try
            {
                _database.AddInParameter(_command, "@In20Codemp", System.Data.DbType.String, codEmpresa);
                _database.AddInParameter(_command, "@in23SistemaUsuario", System.Data.DbType.String, codigoUsuario);

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
