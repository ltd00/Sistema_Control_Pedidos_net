using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MC.ControlPedido.Model
{
   
    /// <summary>
    /// Clase que gestiona datos de las subcategorias
    /// Fecha Crea. : 24-02-2012
    /// Creado por  : Edgar Huarcaya C.
    /// Empresa     : Minera Laytaruma S.A.
    /// </summary>
    public class SubCategoria
    {
        private int _tipoOperacion;
        private int _codigoSubCategoria;
        private string _nombreSubCategoria;
        private string _estado;
        private int _codigoCategoria;

        /// <summary>
        /// Tipo de operacion a realizar en DB
        /// </summary>
        public int TipoOperacion
        {
            get { return _tipoOperacion; }
            set { _tipoOperacion = value; }
        }


        /// <summary>
        /// Código de subcategoría
        /// </summary>
        public int CodigoSubCategoria
        {
            get { return _codigoSubCategoria; }
            set { _codigoSubCategoria = value; }
        }        

        /// <summary>
        /// Nombre de subcategoría
        /// </summary>
        public string NombreSubCategoria
        {
            get { return _nombreSubCategoria; }
            set { _nombreSubCategoria = value; }
        }
        
        /// <summary>
        /// Estado de categoría
        /// </summary>
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        /// <summary>
        /// Código de categoria
        /// </summary>
        public int CodigoCategoria
        {
            get { return _codigoCategoria; }
            set { _codigoCategoria = value; }
        }

    }
}