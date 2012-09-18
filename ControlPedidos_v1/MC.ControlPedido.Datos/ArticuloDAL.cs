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
    public class ArticuloDAL: BaseML
    {
        public DataTable ListarArticulo(in01arti oin01arti, string vcodigoAlmacen, string vMes)
        {
            DataTable dtData = null;
            _command = _database.GetStoredProcCommand("usp_ControlPedido_Listarin01arti");
            try
            {

                _database.AddInParameter(_command, "@IN01CODEMP", System.Data.DbType.String, oin01arti.IN01CODEMP);
                _database.AddInParameter(_command, "@IN01AA", System.Data.DbType.String, oin01arti.IN01AA);
                _database.AddInParameter(_command, "@IN01KEY", System.Data.DbType.String, oin01arti.IN01KEY);
                _database.AddInParameter(_command, "@IN01DESLAR", System.Data.DbType.String, oin01arti.IN01DESLAR);
                _database.AddInParameter(_command, "@IN04CODALM", System.Data.DbType.String, vcodigoAlmacen);
                _database.AddInParameter(_command, "@IN04MM", System.Data.DbType.String, vMes);

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
