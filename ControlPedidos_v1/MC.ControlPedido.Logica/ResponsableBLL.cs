using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MC.ControlPedido.Datos;
using MC.ControlPedido.Model;

namespace MC.ControlPedido.Logica
{
    public class ResponsableBLL
    {
        public DataTable ListarResponsable(in23responsable oin23responsable)
        {
            return new ResponsableDAL().ListarResponsable(oin23responsable);
        }
    }
}
