using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MC.ControlPedido.Datos;
using MC.ControlPedido.Model;

namespace MC.ControlPedido.Logica
{
    public class ArticuloBLL
    {
        public DataTable ListarArticulo(in01arti oin01arti, string vcodigoAlmacen, string vMes)
        {
            return new ArticuloDAL().ListarArticulo(oin01arti, vcodigoAlmacen, vMes);
        }
    }
}
