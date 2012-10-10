using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MC.Enterprise.Data;

namespace MC.ControlPedido.Datos
{
    public class MenuDAL: BaseML
    {
        public DataTable ListarMenu(string vSistema, int vPerfil)
        {
            DataTable dtData = null;
            _command = _database.GetStoredProcCommand("usp_ControlPedido_ListarMenu");
            try
            {
                _database.AddInParameter(_command, "@Sistema", System.Data.DbType.String, vSistema);
                _database.AddInParameter(_command, "@IdPerfil", System.Data.DbType.Int16, vPerfil);

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
