using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ML.CAU.UIC;
using MC.ControlPedido.Logica;
using MC.ControlPedido.Model;
using System.Data;

public partial class Login : UIPage
{
    #region Inicio

    protected override void OnLoad(EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ddlPeriodo.Items.Add(new ListItem("2012", "2012"));
            this.ddlPeriodo.Items.Add(new ListItem("2013", "2013"));
            this.ddlPeriodo.Items.Add(new ListItem("2014", "2014"));

            this.ddlMes.Items.Add(new ListItem("Enero", "01"));
            this.ddlMes.Items.Add(new ListItem("Febrero", "02"));
            this.ddlMes.Items.Add(new ListItem("Marzo", "03"));
            this.ddlMes.Items.Add(new ListItem("Abril", "04"));
            this.ddlMes.Items.Add(new ListItem("Mayo", "05"));
            this.ddlMes.Items.Add(new ListItem("Junio", "06"));
            this.ddlMes.Items.Add(new ListItem("Julio", "07"));
            this.ddlMes.Items.Add(new ListItem("Agosto", "08"));
            this.ddlMes.Items.Add(new ListItem("Setiembre", "09"));
            this.ddlMes.Items.Add(new ListItem("Octubre", "10"));
            this.ddlMes.Items.Add(new ListItem("Noviembre", "11"));
            this.ddlMes.Items.Add(new ListItem("Diciembre", "12"));
        }
    }

    #endregion

    #region Metodos
    /// <summary>
    /// Metodo para inicializar la session de usuario
    /// </summary>
    private void InicializarSession()
    {
        try
        {
            Usuario objUsuario;
            objUsuario = new Usuario();

            DataTable dtData;
            string sistema = System.Configuration.ConfigurationManager.AppSettings["appId"].ToString();
            dtData = new UsuarioBLL().ListarUsuario(sistema, this.txtUser.Text);

            string claveEncriptado = null;
            string clave = null;

            if (dtData.Rows.Count > 0)
            {
                this.txtUser.ReadOnly = true;
                claveEncriptado = dtData.Rows[0]["Clave"].ToString();

                //clave = General.DesencriptaClave(claveEncriptado);

                //if (this.txtPass.Text.CompareTo(clave) != 0)
                //{
                //    this.lblMensaje.Text = "clave de Acceso no es válido";
                //    return;
                //}

                objUsuario.Nombre = dtData.Rows[0]["Nombre"].ToString();
                objUsuario.NombreComp = dtData.Rows[0]["NombreComp"].ToString();

                DataTable dtMenu;
                dtMenu = new MenuBLL().ListarMenu(sistema, int.Parse(this.ddlPerfil.SelectedValue));

                Session["_usuario"] = objUsuario;
                Session["_menu"] = dtMenu;
                Session["_anio"] = this.ddlPeriodo.SelectedValue;
                Session["_idMes"] = this.ddlMes.SelectedValue;
                Session["_nombreMes"] = this.ddlMes.SelectedItem.Text;
                Session["_nombrePerfil"] = this.ddlPerfil.SelectedItem.Text;
                Session["_idPerfil"] = this.ddlPerfil.SelectedValue;

                Response.Redirect("../Default.aspx", false);
            }
            else
            {
                this.lblMensaje.Text = "Usuario no existe o se encuentra bloqueado.";
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion

    protected void btnIngresar_Click(object sender, ImageClickEventArgs e)
    {
        InicializarSession();
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtData;
            string sistema = System.Configuration.ConfigurationManager.AppSettings["appId"].ToString();
            dtData = new UsuarioBLL().ListarUsuario(sistema, this.txtUser.Text);
            string claveEncriptado = null;
            string clave = null;

            this.lblMensaje.Text = "";

            if (dtData.Rows.Count > 0)
            {
                this.txtUser.ReadOnly = true;
                claveEncriptado = dtData.Rows[0]["Clave"].ToString();

                //clave = General.DesencriptaClave(claveEncriptado);
                //clave = MC.Comun.Util.Desencripta(claveEncriptado);

                //if (this.txtPass.Text.CompareTo(clave) != 0)
                //{
                //    this.lblMensaje.Text = "clave de Acceso no es válido";
                //    return;
                //}

                dtData = new UsuarioBLL().ListarUsuarioPerfil(sistema, this.txtUser.Text);
                this.ddlPerfil.DataSource = dtData;

                this.ddlPerfil.DataTextField = "NombrePerfil";
                this.ddlPerfil.DataValueField = "IdPerfil";
                this.ddlPerfil.DataBind();

                this.pnlAcceso.Visible = true;
            }
            else {
                this.lblMensaje.Text = "El usuario no se encuentra registrado.";
            }

        }
        catch (Exception)
        {
            
            throw;
        }
    }
}