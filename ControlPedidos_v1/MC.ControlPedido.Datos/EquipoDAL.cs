using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using MC.Enterprise.Data;
using MC.ControlPedido.Datos;
using MC.ControlPedido.Model;

namespace MC.ControlPedido.Datos
{
    public class EquipoDAL: BaseML
    {
        public DataTable ListarEquipo(string vcodigoEmpresa, string descEquipo)
        {
            DataTable dtData = null;
            _command = _database.GetStoredProcCommand("usp_ControlPedido_ccm03act_control");
            try
            {

                _database.AddInParameter(_command, "@ccmc03emp", System.Data.DbType.String, vcodigoEmpresa);
                _database.AddInParameter(_command, "@ccmc03des", System.Data.DbType.String, descEquipo);


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
