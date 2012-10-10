using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ML.CAU.UIC
{
    public class UIConstante
    {
        /// <summary>
        /// Clase estado de solicitud
        /// </summary>
        public class EstadoSolicitud
        {
            public const string Registrado = "1";
            public const string Enviado = "2";
            public const string Recibido = "3";
            public const string Anulado = "4";
        }

        /// <summary>
        /// Clase estado de incidente
        /// </summary>
        public class EstadoIncidente
        {
            public const int Todos = 0;
            public const int Nuevo = 1;
            public const int Derivado = 2;
            public const int Asignado = 3;
            public const int EnProceso = 4;
            public const int Atendido = 5;
            public const int Anulado = 6;
        }

        /// <summary>
        /// Clase situación de incidente
        /// </summary>
        public class SituacionIncidente
        {
            public const int Todos = 0;
            public const int Abierto = 1;
            public const int Cerrado = 2;
        }

        /// <summary>
        /// Estado de Atencion de Incidencias
        /// </summary>
        public class EstadoAtencion
        {
            public const string Activo = "A";
            public const string Inactivo = "I";
        }

        /// <summary>
        /// Perfil de Usuario
        /// </summary>
        public class PerfilUsuario
        {
            public const string AdministradorSistema = "SD001";
            public const string AsignadorCAU = "SD002";
            public const string AsesorTI = "SD003";
            public const string Solicitante = "SD004";

        }

        /// <summary>
        /// Tipo de operacion a realizar en la base de datos
        /// </summary>
        public class TipoOperacionBD
        {
            public const int Alta = 0;
            public const int Baja = 1;
            public const int Cambio = 2;
        }

    }
}
