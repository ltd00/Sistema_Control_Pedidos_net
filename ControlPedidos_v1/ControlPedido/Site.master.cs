using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ML.CAU.UIC;
using MC.ControlPedido.Model;
using MC.ControlPedido.Logica;
using System.Data;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    MenuItem varmenu = null;
    MenuItem mhijo = null;

    #region Inicio

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        ValidarSesion();        

        if (!IsPostBack)
        {
            Usuario objUsuario = (Usuario)Session["_usuario"];
            UIAuditoria auditoria = new UIAuditoria();

            if (objUsuario != null)
            {
                this.litUsuario.Text = objUsuario.NombreComp + " | " + auditoria.NombrePerfil + " | " + auditoria.NombreMes + " " + auditoria.Periodo;
            }
        }

        #region Permisos

        CrearMenu();

        #endregion

    }

    #endregion

    #region Opciones de Menu

    /// <summary>
    /// Metodo que crea las opciones de menu
    /// </summary>
    private void CrearMenu()
    {
        try
        {
            //Limpiamos el Menu
            NavigationMenu.Items.Clear();

            //Cargamos las opciones de menu según el usuario Logueado
            #region Menu Inicio para cualquier usuario
            DataTable objMenu = (DataTable)Session["_menu"];
            varmenu = new MenuItem();
            varmenu.Text = "Inicio";
            varmenu.Value = "Inicio";
            varmenu.NavigateUrl = "~/Default.aspx";

            NavigationMenu.Items.Add(varmenu);
            #endregion

            if (objMenu == null) return;

            //Opciones de Menu según usuario
            foreach (DataRow _menu in objMenu.Rows)
            {
                if (int.Parse(_menu["MenuPadre"].ToString()) == 0)
                {
                    varmenu = new MenuItem();
                    varmenu.Text = _menu["Nombre"].ToString();
                    varmenu.Value = _menu["IdMenu"].ToString();
                    varmenu.NavigateUrl = _menu["Ruta"].ToString();

                    NavigationMenu.Items.Add(varmenu);

                    if (!cargarMenuHijo(objMenu)) NavigationMenu.Items.Remove(varmenu);
                }
            }

            //Si el usuario tiene más de un Perfil de Usuario


        }
        catch (Exception)
        {

            throw;
        }
    }

    /// <summary>
    /// Metodo que crea submenus
    /// </summary>
    /// <param name="objOpciones"></param>
    /// <returns></returns>
    protected bool cargarMenuHijo(DataTable objOpciones)
    {
        Int32 num_hijos_econtrados = 0;
        foreach (DataRow objOpcion in objOpciones.Rows)
        {
            if (varmenu.Value == objOpcion["MenuPadre"].ToString())
            {

                mhijo = new MenuItem();
                mhijo.Text = "   " + objOpcion["Nombre"].ToString();
                mhijo.Value = objOpcion["IdMenu"].ToString();

                mhijo.NavigateUrl = "~/" + objOpcion["Ruta"].ToString(); //La ruta
                
                varmenu.ChildItems.Add(mhijo);
                num_hijos_econtrados++;
            }
        }
        if (num_hijos_econtrados == 0) return false;
        else return true;
    }

    /// <summary>
    /// Metodo que crea menu de Perfiles de Usuario
    /// </summary>
    /// <param name="objOpciones"></param>
    protected void CargarMenuPerfil(List<ML.Seguridad.Entidades.Menu> objOpciones)
    {
        varmenu = new MenuItem();
        varmenu.Text = "Perfil";
        varmenu.Value = "999";
        varmenu.NavigateUrl = "";

        NavigationMenu.Items.Add(varmenu);

        //Cargamos los SubMenus

        //foreach (EPerfilUsuario oPerfil in colPerfiles.Valores)
        //{
        //    mhijo = new MenuItem();
        //    mhijo.Text = "   " + oPerfil.NombrePerfil.UINullable;
        //    mhijo.Value = oPerfil.CodigoPerfil.UINullable;
            
        //    mhijo.NavigateUrl = Request.ApplicationPath + System.Web.Configuration.WebConfigurationManager.AppSettings[K_RUTA_DEFAULT] + "?pstrPerfil=" + oPerfil.CodigoPerfil.UINullable + "&pstrCodPerfilUsuOfic=" + oPerfil.CodigoPerfilUsuarioOfi.UINullable;
        //    //mhijo.ImageUrl = "~/images/iconos/icon-16-config.png";
        //    mhijo.ToolTip = "cambiar perfil";
        //    varmenu.ChildItems.Add(mhijo);

        //}
    }

    #endregion

    /// <summary>
    /// Metodo para validar sesion de usuario
    /// </summary>
    protected void ValidarSesion()
    {
        String _url = System.Web.Configuration.WebConfigurationManager.AppSettings["rutaLogin"];
        try
        {
            if (Session["_usuario"] == null)
            {
                Session.RemoveAll();
                Session.Abandon();
                Response.Redirect(_url, false);
            }

        }
        catch (System.NullReferenceException ex)
        {
            if (Context.Session.Equals(null))
            {
                Response.Redirect(_url, false);
            }
            else
            {
                throw ex;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkCerrarSesion_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Session.Abandon();
        String _url = System.Web.Configuration.WebConfigurationManager.AppSettings["rutaLogin"];
        Response.Redirect(_url, false);
    }
}