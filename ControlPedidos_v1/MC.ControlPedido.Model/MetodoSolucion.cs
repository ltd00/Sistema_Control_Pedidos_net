using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MC.ControlPedido.Model
{
    /// <summary>
    /// Clase que gestiona datos de Metodo de solucion
    /// Fecha Crea. : 24-02-2012
    /// Creado por  : Edgar Huarcaya C.
    /// Empresa     : Minera Laytaruma S.A.
    /// </summary>
    public class MetodoSolucion
    {
        private int _codigoMetodo;
        private string _nombreMetodo;

        /// <summary>
        /// Código de método de solución
        /// </summary>
        public int CodigoMetodo
        {
            get { return _codigoMetodo; }
            set { _codigoMetodo = value; }
        }
        
        /// <summary>
        /// Nombre de método de solución
        /// </summary>
        public string NombreMetodo
        {
            get { return _nombreMetodo; }
            set { _nombreMetodo = value; }
        }
    }
}
