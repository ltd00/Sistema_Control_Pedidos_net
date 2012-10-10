using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MC.ControlPedido.Model
{
    /// <summary>
    /// Clase que gestiona datos de las categorias
    /// Fecha Crea. : 24-02-2012
    /// Creado por  : Edgar Huarcaya C.
    /// Empresa     : Minera Laytaruma S.A.
    /// </summary>
    public class Categoria
    {
        private int _tipoOperacion;
        private int _codigoCategoria;
        private string _nombreCategoria;
        private string _estado;
        private IList<SubCategoria> _subCategorias;

        public Categoria()
        {
            _subCategorias = new BindingList<SubCategoria>();
        }

        /// <summary>
        /// Tipo de Operacion a Realizar
        /// </summary>
        public int TipoOperacion
        {
            get { return _tipoOperacion; }
            set { _tipoOperacion = value; }
        }

        /// <summary>
        /// Código de categoría
        /// </summary>
        public int CodigoCategoria
        {
            get { return _codigoCategoria; }
            set { _codigoCategoria = value; }
        }
        
        /// <summary>
        /// Nombre de categoría
        /// </summary>
        public string NombreCategoria
        {
            get { return _nombreCategoria; }
            set { _nombreCategoria = value; }
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
        /// Lista de subcategorías
        /// </summary>
        public IList<SubCategoria> SubCategorias
        {
            get { return _subCategorias; }
            set { _subCategorias = value; }
        }
    }
}