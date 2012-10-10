using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MC.ControlPedido.Model
{
    public interface IUsuarioService
    {
        Usuario ObtenerUsuario(string sistema, string login);
    }
}
