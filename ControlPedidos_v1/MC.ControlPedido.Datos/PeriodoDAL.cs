using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MC.Enterprise.Data;

namespace MC.ControlPedido.Datos
{
    public class PeriodoDAL: BaseML
    {
        public DataTable ListarPeriodos(string codEmpresa)
        {
            DataTable dtData = null;
            _command = _database.GetStoredProcCommand("usp_ControlPedido_Trae_Periodos");
            try
            {

                _database.AddInParameter(_command, "@ccb03emp", System.Data.DbType.String, codEmpresa);

                dtData = _database.ExecuteDataSet(_command).Tables[0];
                return dtData;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable ListarMeses(string codEmpresa, String anio)
        {
            DataTable dtData = null;
            _command = _database.GetStoredProcCommand("usp_ControlPedido_Trae_MesxPer");
            _command = _database.GetStoredProcCommand("usp_ControlPedido_Trae_MesxPer");
            try
            {

                _database.AddInParameter(_command, "@ccb03emp", System.Data.DbType.String, codEmpresa);
                _database.AddInParameter(_command, "@Anio", System.Data.DbType.String, anio);

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
