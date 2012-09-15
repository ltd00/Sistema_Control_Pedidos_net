using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MC.ControlPedido.Logica;
using MC.ControlPedido.Model;
using System.Data;

public partial class FormListaPedido : UIPage
{
    #region Inicio

    protected override void OnLoad(EventArgs e)
    {
        this.gvBandeja.RowDataBound += new GridViewRowEventHandler(gvBandeja_RowDataBound);

        //Cargamos eventos en los botones de paginación
        //this.gvBandeja.RowDataBound += new GridViewRowEventHandler(gvBandeja_RowDataBound);
        imgbtnStart.Click += new ImageClickEventHandler(imgbtnStart_Click);
        imgbtnNext.Click += new ImageClickEventHandler(imgbtnNext_Click);
        imgbtnBack.Click += new ImageClickEventHandler(imgbtnBack_Click);
        imgbtnEnd.Click += new ImageClickEventHandler(imgbtnEnd_Click);

        if (IsPostBack == false)
        {
           /*
            Usuario usu = new Usuario();
            usu.Nombre = "VBONIFAZ";

            Session["_usuario"] = usu;
            Session["_anio"] = "2012";
            Session["_idMes"] = "05";
            Session["_nombreMes"] = "Mayo";
            Session["_Nom"] = "01";
            Session["_nombrePerfil"] = "adm";
            Session["_idPerfil"] = "0";
            */
            PaginacionEnabled(false);

            ListarJefeArea();
            ListarArea();     
       
            CargarEstado();
            CargarTipoPedido();
            ListarPedido();
        }
    }


    #endregion

    #region Metodos
    /// <summary>
    /// Carga tipo de pedidos
    /// </summary>
    private void CargarTipoPedido()
    {
        try
        {
            this.ddlTipoPedido.Items.Add(new ListItem("--Todos--", "0"));
            this.ddlTipoPedido.Items.Add(new ListItem("Planificado", UIConstante.TipoPedido.Planificado));
            this.ddlTipoPedido.Items.Add(new ListItem("Emergencia", UIConstante.TipoPedido.Emergencia));
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    private void CargarEstado()
    {
        this.ddlEstadoAprob.Items.Add(new ListItem("Todos", "0"));
        this.ddlEstadoAprob.Items.Add(new ListItem("PENDIENTE", UIConstante.EstadoPedido.Pendiente));
        this.ddlEstadoAprob.Items.Add(new ListItem("REVISADO", UIConstante.EstadoPedido.Revisado));
        this.ddlEstadoAprob.Items.Add(new ListItem("ANULADO", UIConstante.EstadoPedido.Anulado));

    }

    private void ListarArea()
    {
        try
        {
            Bind(this.ddlArea, oAreaBLL.ListarArea(_auditoria.CodigoEmpresa, _auditoria.usuario.Nombre), "In20CodArea", "In20Descripcion");
            //this.ddlArea.Items.Insert(0, new ListItem("--Todos--", "0"));
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    private void ListarJefeArea()
    {
        try
        {
            in23responsable oin23responsable = new in23responsable();
            oin23responsable.in23codemp = _auditoria.CodigoEmpresa;
            oin23responsable.in23SistemaUsuario = _auditoria.usuario.Nombre;
            
            Bind(this.ddlJefeArea, oResponsableBLL.ListarResponsable(oin23responsable), "in23Codigo", "In23Descri");
            //this.ddlJefeArea.Items.Insert(0, new ListItem("--Todos--", "0"));
        }
        catch (Exception ex)
        {
            
            throw;
        }
    }

   


    /// <summary>
    /// Lista pedidos
    /// </summary>
    private void ListarPedido()
    {
        try
        {
            In60pedido oIn60pedido = new In60pedido();
            oIn60pedido.In60codemp = _auditoria.CodigoEmpresa;
            oIn60pedido.In60aa = _auditoria.Periodo;
            if (chkver.Checked=false)
            {
                oIn60pedido.in60mm = _auditoria.Mes;    
            }
            else
            {
                oIn60pedido.in60mm = "";
            }
            
            oIn60pedido.In60numped = this.txtNroPedido.Text;
            oIn60pedido.In60TipoPedido = this.ddlTipoPedido.SelectedValue;
            oIn60pedido.In60Area = this.ddlArea.SelectedValue.Trim();
            //this.ddlEstadoAprob.SelectedValue;
            oIn60pedido.in60nivelflujo = 0;

            DataTable dtData;
            dtData = new PedidoBLL().ListarPedido(oIn60pedido);

            this.gvBandeja.DataSource = dtData;
            this.gvBandeja.DataBind();

            //Invoca al metodo para paginar la grilla
            Paginar(dtData, this.gvBandeja, this.litNumeroRegistros, this.litPagina);


        }
        catch (Exception ex)
        {
            throw ex;
            
        }
        
    }

    #endregion

    #region Eventos Paginado

    void Inicializar()
    {
        try
        {

            this.imgbtnBack.Visible = false;
            this.imgbtnStart.Visible = false;
            this.imgbtnEnd.Visible = false;
            this.imgbtnNext.Visible = false;

            this.imgbtnBack.Enabled = false;
            this.imgbtnStart.Enabled = false;
            this.imgbtnEnd.Enabled = false;
            this.imgbtnNext.Enabled = false;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    void imgbtnEnd_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (this.gvBandeja.PageIndex < (this.gvBandeja.PageCount - 1))
            {
                this.gvBandeja.PageIndex = this.gvBandeja.PageCount - 1;
                ListarPedido();

                this.imgbtnStart.Enabled = true;
                this.imgbtnBack.Enabled = true;
                this.imgbtnEnd.Enabled = false;
                this.imgbtnNext.Enabled = false;
            }

        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message);
        }
    }

    void imgbtnBack_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (this.gvBandeja.PageIndex > 0)
            {
                this.gvBandeja.PageIndex = (this.gvBandeja.PageIndex - 1);
                ListarPedido();

                if (this.gvBandeja.PageIndex > 0)
                {
                    this.imgbtnStart.Enabled = true;
                    this.imgbtnBack.Enabled = true;
                }
                else
                {
                    this.imgbtnStart.Enabled = false;
                    this.imgbtnBack.Enabled = false;
                }

                this.imgbtnEnd.Enabled = true;
                this.imgbtnNext.Enabled = true;
            }

        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message);
        }
    }

    void imgbtnNext_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (this.gvBandeja.PageIndex < (this.gvBandeja.PageCount - 1))
            {
                this.gvBandeja.PageIndex = this.gvBandeja.PageIndex + 1;

                ListarPedido();

                this.imgbtnStart.Enabled = true;
                this.imgbtnBack.Enabled = true;

                if (this.gvBandeja.PageIndex == (this.gvBandeja.PageCount - 1))
                {
                    this.imgbtnEnd.Enabled = false;
                    this.imgbtnNext.Enabled = false;
                }
                else
                {
                    this.imgbtnEnd.Enabled = true;
                    this.imgbtnNext.Enabled = true;
                }

            }
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message);
        }
    }

    void imgbtnStart_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (this.gvBandeja.PageIndex > 0)
            {
                this.gvBandeja.PageIndex = 0;
                ListarPedido();

                this.imgbtnStart.Enabled = false;
                this.imgbtnBack.Enabled = false;
                this.imgbtnNext.Enabled = true;
                this.imgbtnEnd.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message);
        }
    }

    #endregion

    #region paginacion
    /// <summary>
    /// Metodo que permite paginar un GridView
    /// </summary>
    /// <param name="dtData"></param>
    /// <param name="gvLista"></param>
    /// <param name="litRowCount"></param>
    /// <param name="litPage"></param>
    /// <returns></returns>
    /// <Empresa>Minera Laytaruma S.A.</Empresa>
    /// <Creado por>Edgar Huarcaya C.</Creado>
    /// <Fecha Crea>01 mar 2012</Fecha>
    void Paginar(System.Data.DataTable dtData, System.Web.UI.WebControls.GridView gvLista, System.Web.UI.WebControls.Literal litRowCount, System.Web.UI.WebControls.Literal litPage)
    {
        try
        {

            Int16 pageSize = Int16.Parse(System.Web.Configuration.WebConfigurationManager.AppSettings["numeroRegistrosPorPagina"]);
            if (dtData != null)
            {
                if (dtData.Rows.Count >= pageSize)
                {
                    //PaginacionVisible(true);
                    this.imgbtnEnd.Enabled = true;
                    this.imgbtnNext.Enabled = true;
                }
                else
                {
                    //Inicializar();
                    //PaginacionVisible(false);
                    PaginacionEnabled(false);
                    litRowCount.Text = string.Format("Número de Registros encontrados : {0}", 0);
                    litPage.Text = "Página: 0 de 0";
                }

                Int16 intPag;
                try
                {
                    intPag = short.Parse(Math.Ceiling(Convert.ToDouble(dtData.Rows.Count) / pageSize).ToString());
                    if (intPag == 0) intPag = 1;
                }
                catch (Exception e)
                {
                    intPag = 0;
                }

                litRowCount.Text = string.Format("Número de Registros encontrados : {0}", dtData.Rows.Count);
                litPage.Text = "Página: " + Convert.ToString(this.gvBandeja.PageIndex + 1) + " de " + intPag.ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Metodo para paginacion en la grilla
    /// </summary>
    /// <param name="valor"></param>
    void PaginacionVisible(bool valor)
    {
        try
        {
            imgbtnStart.Visible = valor;
            imgbtnNext.Visible = valor;
            imgbtnBack.Visible = valor;
            imgbtnEnd.Visible = valor;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Metodo para paginacion en la grilla
    /// </summary>
    /// <param name="valor"></param>
    void PaginacionEnabled(bool valor)
    {
        try
        {
            imgbtnStart.Enabled = valor;
            imgbtnNext.Enabled = valor;
            imgbtnBack.Enabled = valor;
            imgbtnEnd.Enabled = valor;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        ListarPedido();
    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("PedidoRegistro.aspx?id=", false);
    }

    protected void gvBandeja_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkEliminar = (LinkButton)e.Row.FindControl("lnkEliminar");
                HiddenField hidEstado = (HiddenField)e.Row.FindControl("hidEstado");
               
                if (hidEstado.Value.CompareTo("P") == 0)
                {
                    lnkEliminar.Attributes.Add("onclick", "return confirm('¿Está seguro de eliminar el pedido?');");
                }
                else {
                    lnkEliminar.ToolTip = "Opción deshabilitada. Pedido con estado revisado no se puede eliminar.";
                } 
            }
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void lnkEditar_Click(object sender, EventArgs e)
    {
        LinkButton lnkEditar = (LinkButton)sender;
        Response.Redirect("PedidoRegistro.aspx?id=" + lnkEditar.CommandArgument + "&area=" + lnkEditar.CommandName, false);

    }
    protected void lnkEliminar_Click(object sender, EventArgs e)
    {
        try
        {

            LinkButton lnkEliminar = (LinkButton)sender;
            In60pedido oIn60pedido = new In60pedido();

            oIn60pedido.In60codemp = _auditoria.CodigoEmpresa;
            oIn60pedido.In60aa = _auditoria.Periodo;
            oIn60pedido.In60numped = lnkEliminar.CommandArgument;
            oIn60pedido.In60Area = lnkEliminar.CommandName.Trim();

            new PedidoBLL().EliminarPedido(oIn60pedido);
            ListarPedido();

        }
        catch (Exception ex)
        {

           CScript.MessageBox(0,ex.Message,upBandeja);
        }
    }
    protected void gvBandeja_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}