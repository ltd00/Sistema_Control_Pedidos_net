using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MC.ControlPedido.Model
{
    /// <summary>
    /// Clase abstracta para hacer herencia a los de mas clases
    /// Fecha Crea. : 24-02-2012
    /// Creado por  : Edgar Huarcaya C.
    /// Empresa     : Minera Laytaruma S.A.
    /// </summary>
    public abstract class Auditoria
    {
        private Guid _usuarioCrea;
        private Guid _usuarioModifica;
        private DateTime _fechaCrea;
        private DateTime _fechaModifica;

        public Guid UsuarioCrea
        {
            get { return _usuarioCrea; }
            set { _usuarioCrea = value; }
        }

        public Guid UsuarioModifica
        {
            get { return _usuarioModifica; }
            set { _usuarioModifica = value; }
        }
        
        public DateTime FechaCrea
        {
            get { return _fechaCrea; }
            set { _fechaCrea = value; }
        }
        
        public DateTime FechaModifica
        {
            get { return _fechaModifica; }
            set { _fechaModifica = value; }
        }
        
    }
}