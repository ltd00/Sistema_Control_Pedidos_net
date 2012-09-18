using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MC.ControlPedido.Model
{
    /// <summary>
    /// Clase que gestiona datos de las atenciones de incidencias
    /// Fecha Crea. : 24-02-2012
    /// Creado por  : Edgar Huarcaya C.
    /// Empresa     : Minera Laytaruma S.A.
    /// </summary>
    public class Atencion: Auditoria, IDisposable
    {
        private int _codigoAtencion;
        private DateTime _fechaAtencion;
        private string _descripcionAtencion;
        private string _solucionado;
        private MetodoSolucion _metodoSolucion;
        private decimal _horas;
        private string _adjunto;
        private int _codigoIncidente;
        private string _estado;
        private DateTime _fechaInicioTarea;
        private DateTime _fechaFinalTarea;

        public Atencion()
        {
            _metodoSolucion = new MetodoSolucion();
        }

        /// <summary>
        /// Código o Id de atencion
        /// </summary>
        public int CodigoAtencion
        {
            get { return _codigoAtencion; }
            set { _codigoAtencion = value; }
        }
        
        /// <summary>
        /// Fecha de atencion
        /// </summary>
        public DateTime FechaAtencion
        {
            get { return _fechaAtencion; }
            set { _fechaAtencion = value; }
        }
        
        /// <summary>
        /// Descripcion de atencion
        /// </summary>
        public string DescripcionAtencion
        {
            get { return _descripcionAtencion; }
            set { _descripcionAtencion = value; }
        }
        
        /// <summary>
        /// Indicador si ha solucionado o no
        /// </summary>
        public string Solucionado
        {
            get { return _solucionado; }
            set { _solucionado = value; }
        }
        
        /// <summary>
        /// Metodo de solución
        /// </summary>
        public MetodoSolucion MetodoSolucion
        {
            get { return _metodoSolucion; }
            set { _metodoSolucion = value; }
        }
        
        public void Dispose()
        {
            _metodoSolucion = null;
        }

        /// <summary>
        /// Numero de horas inventidas en la solucion
        /// </summary>
        public decimal Horas
        {
            get { return _horas; }
            set { _horas = value; }
        }

        /// <summary>
        /// Archivo adjunto
        /// </summary>
        public string Adjunto
        {
            get { return _adjunto; }
            set { _adjunto = value; }
        }

        /// <summary>
        /// Codigo de Incidente
        /// </summary>
        public int CodigoIncidente
        {
            get { return _codigoIncidente; }
            set { _codigoIncidente = value; }
        }

        /// <summary>
        /// Estado de atencion A=Activo, I=Inactivo
        /// </summary>
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        /// <summary>
        /// Fecha de Inicio de Tarea
        /// </summary>
        public DateTime FechaInicioTarea
        {
            get { return _fechaInicioTarea; }
            set { _fechaInicioTarea = value; }
        }

        /// <summary>
        /// Fecha Final de Tarea
        /// </summary>
        public DateTime FechaFinalTarea
        {
            get { return _fechaFinalTarea; }
            set { _fechaFinalTarea = value; }
        }
    }
}
