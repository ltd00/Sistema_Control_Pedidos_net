using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MC.ControlPedido.Model;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using MC.Enterprise.Data;

namespace MC.ControlPedido.Datos
{
    public class UsuarioDAL: BaseML
    {
        public DataTable ListarUsuario(string vSistema, string vNombre)
        {
            DataTable dtData = null;
            _command = _database.GetStoredProcCommand("usp_ControlPedido_ListarUsuario");
            try
            {
                _database.AddInParameter(_command, "@Sistema", System.Data.DbType.String, vSistema);
                _database.AddInParameter(_command, "@Nombre", System.Data.DbType.String, vNombre);

                dtData = _database.ExecuteDataSet(_command).Tables[0];
                return dtData;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable ListarUsuarioPerfil(string vSistema, string vNombre)
        {
            DataTable dtData = null;
            _command = _database.GetStoredProcCommand("usp_ControlPedido_ListarUsuarioPerfil");
            try
            {
                _database.AddInParameter(_command, "@Sistema", System.Data.DbType.String, vSistema);
                _database.AddInParameter(_command, "@Nombre", System.Data.DbType.String, vNombre);

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
