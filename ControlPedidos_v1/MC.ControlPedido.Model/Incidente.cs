using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using ML.Seguridad.Entidades;
using ML.Comun.Entidades;

namespace ML.CAU.Entidades
{    
    public enum EstadoIncidente
    { 
                
    }

    /// <summary>
    /// Clase que gestiona datos de las incidencias
    /// Fecha Crea. : 24-02-2012
    /// Creado por  : Edgar Huarcaya C.
    /// Empresa     : Minera Laytaruma S.A.
    /// </summary>
    public class Incidente: Auditoria, IDisposable
    {
        private int _codigoIncidente;
        private string _numeroIncidente;
        private DateTime _fechaIncidente;
        private string _titulo;
        private string _nombreContacto;
        private string _telefonoContacto;
        private string _descripcionIncidente;
        private int _estado;
        private int _situacion;
        private string _origen;
        private DateTime _fechaDerivacion;
        private Usuario _usuarioDeriva;
        private DateTime _fechaAsigna;
        private Usuario _usuarioAsigna;
        private DateTime _fechaCierre;
        private Usuario _usuarioCierre;
        private TipoIncidente _tipoIncidente;
        private Elemento _elemento;
        private Impacto _impacto;
        private Plataforma _plataforma;
        private Prioridad _prioridad;
        private IList<Atencion> _atenciones;
        private SolicitudCambio _solicitudCambio;
        private Categoria _categoria;
        private SubCategoria _subCategoria;
        private string _email;
        private Usuario _asesor;
        private Area _area;
        private Sede _sede;
        private Usuario _usuarioContacto;
        private int _solucionado;
        private string _conclusion;
     
        public Incidente()
        {
            _atenciones = new BindingList<Atencion>();
            _solicitudCambio = new SolicitudCambio();
            _tipoIncidente = new TipoIncidente();
            _elemento = new Elemento();
            _impacto = new Impacto();
            _plataforma = new Plataforma();
            _prioridad = new Prioridad();
            _solicitudCambio = new SolicitudCambio();

            _categoria = new Categoria();
            _subCategoria = new SubCategoria();

            _usuarioDeriva = new Usuario();
            _usuarioAsigna = new Usuario();
            _asesor = new Usuario();

            _area = new Area();
            _sede = new Sede();

            _usuarioContacto = new Usuario();
        }

        /// <summary>
        /// Id de incidente
        /// </summary>
        public int CodigoIncidente
        {
            get { return _codigoIncidente; }
            set { _codigoIncidente = value; }
        }
        
        /// <summary>
        /// Numero de incidencia generado
        /// </summary>
        public string NumeroIncidente
        {
            get { return _numeroIncidente; }
            set { _numeroIncidente = value; }
        }
        
        /// <summary>
        /// Fecha de Incidente
        /// </summary>
        public DateTime FechaIncidente
        {
            get { return _fechaIncidente; }
            set { _fechaIncidente = value; }
        }
        
        /// <summary>
        /// Titulo de incidente
        /// </summary>
        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }
        
        /// <summary>
        /// Nombre de contacto
        /// </summary>
        public string NombreContacto
        {
            get { return _nombreContacto; }
            set { _nombreContacto = value; }
        }
        
        /// <summary>
        /// Teléfono de contacto
        /// </summary>
        public string TelefonoContacto
        {
            get { return _telefonoContacto; }
            set { _telefonoContacto = value; }
        }
 
        /// <summary>
        /// Descripcion de incidente
        /// </summary>
        public string DescripcionIncidente
        {
            get { return _descripcionIncidente; }
            set { _descripcionIncidente = value; }
        }
        
        /// <summary>
        /// Estado de incidente
        /// </summary>
        public int Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        
        /// <summary>
        /// Situación de incidente
        /// </summary>
        public int Situacion
        {
            get { return _situacion; }
            set { _situacion = value; }
        }
        
        /// <summary>
        /// Origen de incidente
        /// </summary>
        public string Origen
        {
            get { return _origen; }
            set { _origen = value; }
        }
        
        /// <summary>
        /// Fecha de derivación
        /// </summary>
        public DateTime FechaDerivacion
        {
            get { return _fechaDerivacion; }
            set { _fechaDerivacion = value; }
        }
        
        /// <summary>
        /// Usuario derivado
        /// </summary>
        public Usuario UsuarioDeriva
        {
            get { return _usuarioDeriva; }
            set { _usuarioDeriva = value; }
        }

        /// <summary>
        /// Fecha de Asignacion
        /// </summary>
        public DateTime FechaAsigna
        {
            get { return _fechaAsigna; }
            set { _fechaAsigna = value; }
        }        

        /// <summary>
        /// Usuario asignado
        /// </summary>
        public Usuario UsuarioAsigna
        {
            get { return _usuarioAsigna; }
            set { _usuarioAsigna = value; }
        }
        
        /// <summary>
        /// Fecha de cierre
        /// </summary>
        public DateTime FechaCierre
        {
            get { return _fechaCierre; }
            set { _fechaCierre = value; }
        }
        
        /// <summary>
        /// Usuario de cierre
        /// </summary>
        public Usuario UsuarioCierre
        {
            get { return _usuarioCierre; }
            set { _usuarioCierre = value; }
        }

        /// <summary>
        /// Tipo de incidente
        /// </summary>
        public TipoIncidente TipoIncidente
        {
            get { return _tipoIncidente; }
            set { _tipoIncidente = value; }
        }
        
        /// <summary>
        /// Elemento afectado
        /// </summary>
        public Elemento Elemento
        {
            get { return _elemento; }
            set { _elemento = value; }
        }
        
        /// <summary>
        /// Impacto de incidente
        /// </summary>
        public Impacto Impacto
        {
            get { return _impacto; }
            set { _impacto = value; }
        }
        
        /// <summary>
        /// Plataforma a derivar
        /// </summary>
        public Plataforma Plataforma
        {
            get { return _plataforma; }
            set { _plataforma = value; }
        }
        
        /// <summary>
        /// Perioridad del incidente
        /// </summary>
        public Prioridad Prioridad
        {
            get { return _prioridad; }
            set { _prioridad = value; }
        }

        /// <summary>
        /// Lista de atenciones
        /// </summary>
        public IList<Atencion> Atenciones
        {
            get { return _atenciones; }
            set { _atenciones = value; }
        }

        /// <summary>
        /// Propiedad que almacena las solicitud de cambio
        /// </summary>
        public SolicitudCambio SolicitudCambio
        {
            get { return _solicitudCambio; }
            set { _solicitudCambio = value; }
        }

        /// <summary>
        /// Propiedad que almacena la categoria
        /// </summary>
        public Categoria Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }

        /// <summary>
        /// Propiedad que almacena la subCategoria
        /// </summary>
        public SubCategoria SubCategoria
        {
            get { return _subCategoria; }
            set { _subCategoria = value; }
        }               

        /// <summary>
        /// Correo electrónico
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        /// <summary>
        /// Asesor quien se hace cargo de la incidencia
        /// </summary>
        public Usuario Asesor
        {
            get { return _asesor; }
            set { _asesor = value; }
        }

        /// <summary>
        /// Area donde se genera la incidencia
        /// </summary>
        public Area Area
        {
            get { return _area; }
            set { _area = value; }
        }

        /// <summary>
        /// Sede donde se genera la incidencia
        /// </summary>
        public Sede Sede
        {
            get { return _sede; }
            set { _sede = value; }
        }

        /// <summary>
        /// Usuario quien reporta la incidencia
        /// </summary>
        public Usuario UsuarioContacto
        {
            get { return _usuarioContacto; }
            set { _usuarioContacto = value; }
        }

        /// <summary>
        /// Indicado si está solucionado o no
        /// </summary>
        public int Solucionado
        {
            get { return _solucionado; }
            set { _solucionado = value; }
        }

        /// <summary>
        /// Conclusiones de las atenciones de la incidencia
        /// </summary>
        public string Conclusion
        {
            get { return _conclusion; }
            set { _conclusion = value; }
        }


        #region IDisposible
        public void Dispose()
        {
            _solicitudCambio = null;
            _tipoIncidente = null;
            _elemento = null;
            _impacto = null;
            _plataforma = null;
            _prioridad = null;
            _solicitudCambio = null;

            _categoria = null;
            _subCategoria = null;

            _usuarioDeriva = null;
            _usuarioAsigna = null;
            _asesor = null;

            _area = null;
            _sede = null;

            _usuarioContacto = null;

            _atenciones = null;
        }
        #endregion
    }
}