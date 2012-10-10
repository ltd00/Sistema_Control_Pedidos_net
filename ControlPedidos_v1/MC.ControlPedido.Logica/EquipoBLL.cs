using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MC.ControlPedido.Datos;
using MC.ControlPedido.Model;

namespace MC.ControlPedido.Logica
{
    public class EquipoBLL
    {
        public DataTable ListarEquipo(string vcodigoEmpresa, string descEquipo)
        {
            return new EquipoDAL().ListarEquipo(vcodigoEmpresa, descEquipo);
        }
    }
}
