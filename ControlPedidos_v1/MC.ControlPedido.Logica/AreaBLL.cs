using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MC.Enterprise.Data;
using MC.ControlPedido.Datos;
using MC.ControlPedido.Model;

namespace MC.ControlPedido.Logica
{
    public class AreaBLL
    {
        public DataTable ListarArea(string codEmpresa, string codigoUsuario)
        {
            return new AreaDAL().ListarArea(codEmpresa, codigoUsuario);
        }
    }
}
