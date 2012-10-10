using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MC.ControlPedido.Datos;
using System.Data;

namespace MC.ControlPedido.Logica
{
    public class UsuarioBLL
    {

        public DataTable ListarUsuario(string vSistema, string vNombre)
        {
            return new UsuarioDAL().ListarUsuario(vSistema, vNombre);
        }

        public DataTable ListarUsuarioPerfil(string vSistema, string vNombre)
        {
            return new UsuarioDAL().ListarUsuarioPerfil(vSistema, vNombre);
        }

    }  
}
