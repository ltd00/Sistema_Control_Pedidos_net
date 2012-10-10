using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MC.ControlPedido.Model
{    
    /// <summary>
    /// Clase que gestiona Elemento Afectados
    /// Fecha Crea. : 24-02-2012
    /// Creado por  : Edgar Huarcaya C.
    /// Empresa     : Minera Laytaruma S.A.
    /// </summary>
    public class Elemento
    {
        private int _tipoOperacion;
        private int _codigoElemento;
        private string _nombreElemento;
        private string _observacion;
        private string _estado;

        /// <summary>
        /// Tipo de operacion a realizar en la base de datos
        /// </summary>
        public int TipoOperacion
        {
            get { return _tipoOperacion; }
            set { _tipoOperacion = value; }
        }

        /// <summary>
        /// Código de elemento afectado
        /// </summary>
        public int CodigoElemento
        {
            get { return _codigoElemento; }
            set { _codigoElemento = value; }
        }        

        /// <summary>
        /// Nombre de elemento afectado
        /// </summary>
        public string NombreElemento
        {
            get { return _nombreElemento; }
            set { _nombreElemento = value; }
        }
        
        /// <summary>
        /// Observacion de elemento afectado
        /// </summary>
        public string Observacion
        {
            get { return _observacion; }
            set { _observacion = value; }
        }
        
        /// <summary>
        /// Estado de elemento afectado
        /// </summary>
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
    }
}