using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MC.ControlPedido.Logica;
using MC.ControlPedido.Model;
using System.Data;

/// <summary>    
/// Clase que gestiona las variables del sistema durante la Ejecucion
/// Fecha creacion  : 29-02-2012
/// Creado por      : Edgar Huarcaya C.
/// Empresa         : Minera Colquisiri S.A.    
/// </summary>
public class UIAuditoria : System.Web.UI.Page
{
    private DateTime _fechaSistema;

    /// <summary>
    /// Propiedad que almacena fecha del sistema
    /// </summary>
    public DateTime FechaSistema
    {
        get { return _fechaSistema; }
        set { _fechaSistema = value; }
    }

    /// <summary>
    /// Propiedad que almacena el usuario del sistema
    /// </summary>
    public Usuario usuario
    {
        get { return (Usuario)Session["_usuario"];}
    }

    /// <summary>
    /// Propiedad que almacena el usuario del sistema
    /// </summary>
    public DataTable Menu
    {
        get { return (DataTable)Session["_menu"]; }
    }

    /// <summary>
    /// Propiedad que almacena Id de Aplicacion
    /// </summary>
    public int AppId
    {
        get { return int.Parse(System.Web.Configuration.WebConfigurationManager.AppSettings["appId"]); }
    }

    public string CodigoEmpresa
    {
        get { return System.Web.Configuration.WebConfigurationManager.AppSettings["codigoEmpresa"]; }
    }

    public string Periodo
    {
        get { return Session["_anio"].ToString(); }
    }

    public string Mes
    {
        get { return Session["_idMes"].ToString(); }
    }

    public string NombreMes
    {
        get { return Session["_nombreMes"].ToString(); }
    }                    

    public string NombrePerfil
    {
        get { return Session["_nombrePerfil"].ToString(); }
    }                    

    public int IdPerfil
    {
        get { return int.Parse(Session["_idPerfil"].ToString()); }
    }                        

}