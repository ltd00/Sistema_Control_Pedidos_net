using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MC.ControlPedido.Model
{
    /// <summary>
    /// Clase que gestiona datos de Plataforma
    /// Fecha Crea. : 24-02-2012
    /// Creado por  : Edgar Huarcaya C.
    /// Empresa     : Minera Laytaruma S.A.
    /// </summary>
    public class Plataforma
    {
        private int _codigoPlataforma;
        private string _nombrePlataforma;
        private string _estado;
        private int _requiereAsesor;

        /// <summary>
        /// Código de plataforma
        /// </summary>
        public int CodigoPlataforma
        {
            get { return _codigoPlataforma; }
            set { _codigoPlataforma = value; }
        }
        
        /// <summary>
        /// Nombre de plataforma
        /// </summary>
        public string NombrePlataforma
        {
            get { return _nombrePlataforma; }
            set { _nombrePlataforma = value; }
        }

        /// <summary>
        /// Estado de plataforma
        /// </summary>
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        /// <summary>
        /// Requiere asesor
        /// </summary>
        public int RequiereAsesor
        {
            get { return _requiereAsesor; }
            set { _requiereAsesor = value; }
        }
    }
}
