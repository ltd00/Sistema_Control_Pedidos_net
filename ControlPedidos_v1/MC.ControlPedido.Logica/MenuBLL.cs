using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MC.ControlPedido.Datos;
using MC.ControlPedido.Model;

namespace MC.ControlPedido.Logica
{
    public class MenuBLL
    {
        public DataTable ListarMenu(string vSistema, int vPerfil)
        {
            return new MenuDAL().ListarMenu(vSistema, vPerfil);
        }
    }
}
