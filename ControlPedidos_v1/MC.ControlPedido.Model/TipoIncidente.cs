using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MC.ControlPedido.Model
{
    /// <summary>
    /// Clase que gestiona datos de Tipos de Incidentes
    /// Fecha Crea. : 24-02-2012
    /// Creado por  : Edgar Huarcaya C.
    /// Empresa     : Minera Laytaruma S.A.
    /// </summary>
    public class TipoIncidente
    {
        private int _codigoTipoIncidente;
        private string _descricion;
        private string _alias;

        /// <summary>
        /// Codigo de tipo de incidente
        /// </summary>
        public int CodigoTipoIncidente
        {
            get { return _codigoTipoIncidente; }
            set { _codigoTipoIncidente = value; }
        }

        /// <summary>
        /// Descripcion de tipo de incidente
        /// </summary>
        public string Descricion
        {
            get { return _descricion; }
            set { _descricion = value; }
        }

        /// <summary>
        /// Estado de Incidente
        /// </summary>
        public string Alias
        {
            get { return _alias; }
            set { _alias = value; }
        }

    }
}
