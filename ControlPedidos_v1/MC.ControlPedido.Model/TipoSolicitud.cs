using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MC.ControlPedido.Model
{
    /// <summary>
    /// Clase que gestiona datos de Tipos de Solicitudes
    /// Fecha Crea. : 27-02-2012
    /// Creado por  : Edgar Huarcaya C.
    /// Empresa     : Minera Laytaruma S.A.
    /// </summary>
    public class TipoSolicitud
    {
        private int _tipoOperacion;
        private int _codigoTipoSolicitud;
        private string _nombreTipoSolicitud;

        /// <summary>
        /// Tipo de operacion a realizar en la Base de datos
        /// </summary>
        public int TipoOperacion
        {
            get { return _tipoOperacion; }
            set { _tipoOperacion = value; }
        }

        /// <summary>
        /// Codigo de tipo de solicitud
        /// </summary>
        public int CodigoTipoSolicitud
        {
            get { return _codigoTipoSolicitud; }
            set { _codigoTipoSolicitud = value; }
        }
        
        /// <summary>
        /// Nombre de tipo de solicitud
        /// </summary>
        public string NombreTipoSolicitud
        {
            get { return _nombreTipoSolicitud; }
            set { _nombreTipoSolicitud = value; }
        }


    }
}
