using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MC.Enterprise.Data;
using MC.ControlPedido.Datos;
using MC.ControlPedido.Model;

namespace MC.ControlPedido.Datos
{
    public class ResponsableDAL: BaseML
    {
        public DataTable ListarResponsable(in23responsable oin23responsable)
        {
            DataTable dtData = null;
            _command = _database.GetStoredProcCommand("usp_ControlPedido_listarResponsable");
            try
            {

                _database.AddInParameter(_command, "@in23codemp", System.Data.DbType.String, oin23responsable.in23codemp );
                _database.AddInParameter(_command, "@in23SistemaUsuario", System.Data.DbType.String, oin23responsable.in23SistemaUsuario);

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
