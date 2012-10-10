using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MC.ControlPedido.Model
{
    /// <summary>
    /// Clase que gestiona datos de Impacto de Incidencias
    /// Fecha Crea. : 24-02-2012
    /// Creado por  : Edgar Huarcaya C.
    /// Empresa     : Minera Laytaruma S.A.
    /// </summary>
    public class Impacto
    {
        private int _codigoImpacto;
        private string _nombreImpacto;
        private int _numeroOrden;
        private string _estado;

        /// <summary>
        /// Código de Impacto
        /// </summary>
        public int CodigoImpacto
        {
            get { return _codigoImpacto; }
            set { _codigoImpacto = value; }
        }        

        /// <summary>
        /// Nombre de Impacto
        /// </summary>
        public string NombreImpacto
        {
            get { return _nombreImpacto; }
            set { _nombreImpacto = value; }
        }
        
        /// <summary>
        /// Número de Orden
        /// </summary>
        public int NumeroOrden
        {
            get { return _numeroOrden; }
            set { _numeroOrden = value; }
        }
        
        /// <summary>
        /// Estado de Impacto
        /// </summary>
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
    }
}
