using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ML.CAU.Entidades
{
    /// <summary>
    /// Clase que gestiona datos de las solicitudes de cambio
    /// Fecha Crea. : 24-02-2012
    /// Creado por  : Edgar Huarcaya C.
    /// Empresa     : Minera Laytaruma S.A.
    /// </summary>
    public class SolicitudCambio: Auditoria, IDisposable
    {
        private int _codigoSolicitud;
        private string _numeroSolicitud;
        private DateTime _fechaSolicitud;
        private string _asuntoSolicitud;
        private string _tituloSolicitud;
        private string _descripcion;
        private string _motivo;
        private string _estado;
        private string _archivoAdjunto;
        private string _observacion;
        private Area _area;
        private Sede _sede;
        private TipoSolicitud _tipoSolicitud;
        private string _nombreAutoriza;

        public SolicitudCambio()
        {
            _area = new Area();
            _sede = new Sede();
            _tipoSolicitud = new TipoSolicitud();
        }

        /// <summary>
        /// Id solicitud de cambio
        /// </summary>
        public int CodigoSolicitud
        {
            get { return _codigoSolicitud; }
            set { _codigoSolicitud = value; }
        }
        
        /// <summary>
        /// Numero de solicitud
        /// </summary>
        public string NumeroSolicitud
        {
            get { return _numeroSolicitud; }
            set { _numeroSolicitud = value; }
        }
        
        /// <summary>
        /// Fecha de solicitud
        /// </summary>
        public DateTime FechaSolicitud
        {
            get { return _fechaSolicitud; }
            set { _fechaSolicitud = value; }
        }
        
        /// <summary>
        /// Asunto de solicitud
        /// </summary>
        public string AsuntoSolicitud
        {
            get { return _asuntoSolicitud; }
            set { _asuntoSolicitud = value; }
        }
        
        /// <summary>
        /// Titulo de la solicitud
        /// </summary>
        public string TituloSolicitud
        {
            get { return _tituloSolicitud; }
            set { _tituloSolicitud = value; }
        }
        
        /// <summary>
        /// Descripción de la solicitud
        /// </summary>
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        
        /// <summary>
        /// Motivo de la solicitud
        /// </summary>
        public string Motivo
        {
            get { return _motivo; }
            set { _motivo = value; }
        }
        
        /// <summary>
        /// Estado de la solicitud
        /// </summary>
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        
        /// <summary>
        /// Archivo adjunto en la solicitud
        /// </summary>
        public string ArchivoAdjunto
        {
            get { return _archivoAdjunto; }
            set { _archivoAdjunto = value; }
        }
        
        /// <summary>
        /// Observacion en la solicitud
        /// </summary>
        public string Observacion
        {
            get { return _observacion; }
            set { _observacion = value; }
        }
        
        /// <summary>
        /// Area a la que pertenece la solicitud
        /// </summary>
        public Area Area
        {
            get { return _area; }
            set { _area = value; }
        }

        /// <summary>
        /// Sede a la que pertenece la solicitud
        /// </summary>
        public Sede Sede
        {
            get { return _sede; }
            set { _sede = value; }
        }

        public void Dispose()
        {
            _area = null;
            _sede = null;
            _tipoSolicitud = null;
        }
        
        /// <summary>
        /// Tipo de solicitud
        /// </summary>
        public TipoSolicitud TipoSolicitud
        {
            get { return _tipoSolicitud; }
            set { _tipoSolicitud = value; }
        }

        /// <summary>
        /// Nombre de usuario que autoriza la solicitud
        /// </summary>
        public string NombreAutoriza
        {
            get { return _nombreAutoriza; }
            set { _nombreAutoriza = value; }
        }

    }
}