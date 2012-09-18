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
    public class PeriodoBll
    {
        public DataTable ListarAnios(string codEmpresa)
        {
            return new PeriodoDAL().ListarPeriodos(codEmpresa);
        }

        public DataTable ListarMeses(string codEmpresa, string anio)
        {
            return new PeriodoDAL().ListarMeses(codEmpresa,anio);
        }
    }
}
