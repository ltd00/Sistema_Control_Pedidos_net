using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MC.ControlPedido.Model
{
    /// <summary>
    /// Clase que gestiona datos de las prioridades
    /// Fecha Crea. : 24-02-2012
    /// Creado por  : Edgar Huarcaya C.
    /// Empresa     : Minera Laytaruma S.A.
    /// </summary>
    public class Prioridad
    {
        private int _codigoPrioridad;
        private string _nombrePrioridad;
        private int _numeroOrden;
        private string _estado;

        /// <summary>
        /// Id de prioridad
        /// </summary>
        public int CodigoPrioridad
        {
            get { return _codigoPrioridad; }
            set { _codigoPrioridad = value; }
        }
        
        /// <summary>
        /// Nombre de prioridad
        /// </summary>
        public string NombrePrioridad
        {
            get { return _nombrePrioridad; }
            set { _nombrePrioridad = value; }
        }
        
        /// <summary>
        /// Número de orden
        /// </summary>
        public int NumeroOrden
        {
            get { return _numeroOrden; }
            set { _numeroOrden = value; }
        }
        
        /// <summary>
        /// Estado de prioridad
        /// </summary>
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }


    }
}
