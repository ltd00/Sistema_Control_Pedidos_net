using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MC.ControlPedido.Logica;
using MC.ControlPedido.Model;
using System.Data;

public partial class FormPedidoAproba1 : UIPage
{
    #region Inicio
    protected override void OnLoad(EventArgs e)
    {
        //Cargamos eventos en los botones de paginación
        imgbtnStart.Click += new ImageClickEventHandler(imgbtnStart_Click);
        imgbtnNext.Click += new ImageClickEventHandler(imgbtnNext_Click);
        imgbtnBack.Click += new ImageClickEventHandler(imgbtnBack_Click);
        imgbtnEnd.Click += new ImageClickEventHandler(imgbtnEnd_Click);

        if (IsPostBack == false)
        {
            this.txtFecha.Text = DateTime.Now.ToShortDateString();
            ListarArea();
            ListarJefeArea();
            CargarTipoPedido();

            this.hidNumeroPedido.Value = Request.Params["id"];
            this.hidArea.Value = Request.Params["area"].Trim();
            this.hidFlujoProceso.Value = Request.Params["p"];
            this.hidFlujopedido.Value = Request.Params["pe"];
            this.lblTitulo.Text = General.AsignarTitulo(this.hidFlujoProceso.Value);

            if (this.hidNumeroPedido.Value.Length > 0)
            {
                this.txtNroPedido.Text = this.hidNumeroPedido.Value;
                this.ddlArea.Enabled = false;
                this.ddlJefeArea.Enabled = false;
                this.ddlTipoPedido.Enabled = false;
                PaginacionEnabled(false);
                ListarPedido();
            }

            ListarDetallePedido();
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

    private void ListarJefeArea()
    {
        try
        {
            in23responsable oin23responsable = new in23responsable();
            oin23responsable.in23codemp = _auditoria.CodigoEmpresa;

            if (this.hidFlujoProceso.Value.CompareTo(UIConstante.FlujoProceso.JefeArea.ToString()) == 0)
            {
                oin23responsable.in23SistemaUsuario = _auditoria.usuario.Nombre;
            }
            else {
                oin23responsable.in23SistemaUsuario = string.Empty;
            }

            Bind(this.ddlJefeArea, oResponsableBLL.ListarResponsable(oin23responsable), "in23Codigo", "In23Descri");
            if (this.hidFlujoProceso.Value.CompareTo(UIConstante.FlujoProceso.JefeArea.ToString()) != 0)
            {
                this.ddlJefeArea.Items.Insert(0, new ListItem("--Seleccione--", "0"));
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    private void ListarArea()
    {
        try
        {
            if (this.hidFlujoProceso.Value.CompareTo(UIConstante.FlujoProceso.JefeArea.ToString()) == 0)
            {
                Bind(this.ddlArea, oAreaBLL.ListarArea(_auditoria.CodigoEmpresa, _auditoria.usuario.Nombre), "In20CodArea", "In20Descripcion");                
            }
            else {
                Bind(this.ddlArea, oAreaBLL.ListarArea(_auditoria.CodigoEmpresa, string.Empty), "In20CodArea", "In20Descripcion");                
            }
            this.ddlArea.Items.Insert(0, new ListItem("--Seleccione--", "0"));

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
            In60detalleSeg oIn60DetalleSeg = new In60detalleSeg();

            oIn60DetalleSeg.In60codemp = _auditoria.CodigoEmpresa;
            oIn60DetalleSeg.in60FlujoProceso = int.Parse(this.hidFlujopedido.Value);
            oIn60DetalleSeg.In60Area = this.hidArea.Value.Trim();
            oIn60DetalleSeg.In60numped = this.txtNroPedido.Text;
            oIn60pedido.In60TipoPedido = "0";


            DataTable dtData;
            dtData = new PedidoBLL().ListarPedidoSeguimientoxarea(oIn60DetalleSeg, oIn60pedido);


           if (dtData.Rows.Count > 0)
            {
                //this.txtFecha.Text = dtData.Rows[0]["In60fecha"].ToString();
                this.ddlJefeArea.SelectedValue = dtData.Rows[0]["In60codres"].ToString();
                this.txtAsunto.Text = Convert.ToString(dtData.Rows[0]["In60Obser"]);
                this.ddlArea.SelectedValue = Convert.ToString(dtData.Rows[0]["In60Area"]);
                this.ddlTipoPedido.SelectedValue = dtData.Rows[0]["In60TipoPedido"].ToString().Trim();
                this.lblEstado.Text = dtData.Rows[0]["DesIn60Estado"].ToString();
                this.lblSituacion.Text = dtData.Rows[0]["DescIn60Aprobado"].ToString();
                this.hidSituacion.Value = dtData.Rows[0]["In60Aprobado"].ToString();
            }

            //if (int.Parse(this.hidSituacion.Value) > int.Parse(this.hidFlujoProceso.Value))
            //{
             //   this.btnAceptar.Visible = false;
            //}

        }
        catch (Exception)
        {

            throw;
        }
    }

    /// <summary>
    /// Lista de detalle de pedidos
    /// </summary>
    private void ListarDetallePedido()
    {
        try
        {

            In60detalleSeg oIn60detalleSeg = new In60detalleSeg();
            oIn60detalleSeg.In60codemp = _auditoria.CodigoEmpresa;
            oIn60detalleSeg.In60aa = _auditoria.Periodo;
            oIn60detalleSeg.In60numped = this.txtNroPedido.Text;
            oIn60detalleSeg.In60Area = this.hidArea.Value.Trim();
            oIn60detalleSeg.in60FlujoProceso = int.Parse(this.hidFlujopedido.Value);

            DataTable dtData;
            dtData = new PedidoBLL().ListarDetallePedidoSeguimiento(oIn60detalleSeg);

            this.gvBandeja.DataSource = dtData;
            this.gvBandeja.DataBind();

            //NUEVO
            for (int i = 0; i < this.gvBandeja.Rows.Count; i++)
            {
                HiddenField hidEstado = (HiddenField)this.gvBandeja.Rows[i].FindControl("hidEstado");
                DropDownList ddlEstado = (DropDownList)this.gvBandeja.Rows[i].FindControl("ddlEstado");
                HiddenField hidEstadoActual = (HiddenField)this.gvBandeja.Rows[i].FindControl("hidEstadoActual");
                Label lblCantidadNueva = (Label)this.gvBandeja.Rows[i].FindControl("lblCantidadNueva");
                TextBox txtCantidadNueva = (TextBox)this.gvBandeja.Rows[i].FindControl("txtCantidadNueva");

                if (string.IsNullOrEmpty(hidEstadoActual.Value))
                {
                    ddlEstado.SelectedValue = UIConstante.EstadoPedidoSeguimiento.Conforme;
                    ddlEstado.ForeColor = System.Drawing.Color.Red;
                    ddlEstado.ToolTip = "Estado pendiente por aprobar";
                }
                else
                {
                    ddlEstado.SelectedValue = hidEstadoActual.Value;
                    ddlEstado.ForeColor = System.Drawing.Color.Blue;

                }

                if (ddlEstado.SelectedValue.CompareTo(UIConstante.EstadoPedidoSeguimiento.NuevoValor) == 0)
                {
                    lblCantidadNueva.Visible = true;
                    txtCantidadNueva.Visible = true;
                }
                else
                {
                    lblCantidadNueva.Visible = false;
                    txtCantidadNueva.Visible = false;
                }

            }

            //Invoca al metodo para paginar la grilla
            Paginar(dtData, this.gvBandeja, this.litNumeroRegistros, this.litPagina);

            Session.Add("Detalle", dtData);
        }
        catch (Exception ex)
        {

            CScript.MessageBox(0, ex.Message, upBandeja);
        }
    }

    /// <summary>
    /// Se registra estado
    /// </summary>
    private void RegistrarEstado()
    {
        try
        {
            //NUEVO
            List<In60detalleSeg> oIn60detalleSegs = new List<In60detalleSeg>();
            In60detalleSeg oIn60detalleSeg = null;

            for (int i = 0; i < this.gvBandeja.Rows.Count; i++)
            {
                oIn60detalleSeg = new In60detalleSeg();

                Label lblItem = (Label)this.gvBandeja.Rows[i].FindControl("lblItem");
                TextBox txtCantidadNueva = (TextBox)this.gvBandeja.Rows[i].FindControl("txtCantidadNueva");
                DropDownList ddlEstado = (DropDownList)this.gvBandeja.Rows[i].FindControl("ddlEstado");
                TextBox txtSustento = (TextBox)this.gvBandeja.Rows[i].FindControl("txtSustento");

                oIn60detalleSeg.In60codemp = _auditoria.CodigoEmpresa;
                oIn60detalleSeg.In60aa = _auditoria.Periodo;
                oIn60detalleSeg.In60numped = this.txtNroPedido.Text;
                oIn60detalleSeg.In60Area = this.ddlArea.SelectedValue.Trim();
                oIn60detalleSeg.In60Item = int.Parse(lblItem.Text);
                oIn60detalleSeg.in60FlujoProceso = int.Parse(this.hidFlujoProceso.Value);
                oIn60detalleSeg.In60EstadoAprob = ddlEstado.SelectedValue;
                if (txtCantidadNueva.Text.Length > 0)
                {
                    oIn60detalleSeg.In60CantidadNueva = double.Parse(txtCantidadNueva.Text);
                }
                else
                {
                    oIn60detalleSeg.In60CantidadNueva = 0.0;
                }

                oIn60detalleSeg.In60Observacion = txtSustento.Text.Trim();
                oIn60detalleSeg.in60UsuarioMod= _auditoria.usuario.Nombre;
                
                oIn60detalleSegs.Add(oIn60detalleSeg);
                oIn60detalleSeg = null;
            }

            PedidoBLL oPedido = new PedidoBLL();
            oPedido.RegistrarDetallePedidoSeguimientos(oIn60detalleSegs);

            ListarDetallePedido();

            upBandeja.Update();

            #region Envio Correo
            string nombreJefeArea = string.Empty;
            string correo = string.Empty;
             
            In60pedido pedido = new In60pedido();
            pedido.In60codemp =  _auditoria.CodigoEmpresa;
            pedido.In60aa = _auditoria.Periodo;
            pedido.In60Area = this.ddlArea.SelectedValue.ToString();
            pedido.In60numped = this.txtNroPedido.Text.Trim();
            pedido.In60codres = this.ddlJefeArea.SelectedValue.Trim();

            oPedido.ObtenerCorreoJefeArea(pedido, _auditoria.IdPerfil, ref nombreJefeArea, ref correo);

            if (correo.Length > 0)
            {
                Correo ocorreo = new Correo();
                ocorreo.Subject = "Pedido Nro. " + this.txtNroPedido.Text + " Aprobado";

                ocorreo.Body = "El pedido ha sido aprobado";
                ocorreo.To = correo;
                try
                {
                    ocorreo.Enviar(); 
                }
                catch (Exception)
                {
                    
                 
                }                
            }

            #endregion

            oPedido = null;

            CScript.MessageBox(0, "Aprobación se registró satisfactoriamente.", upBandeja);
            //Response.Redirect("FormListaPedidoAproba1.aspx?p=" + this.hidFlujoProceso.Value, false);
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    #endregion

    #region Eventos

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

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        RegistrarEstado();
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("FormListaPedidoAproba1.aspx?p=" + this.hidFlujoProceso.Value, false);
    }
    protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlEstado = (DropDownList)sender;

        #region Asigna Nuevo Valor
        if (ddlEstado.SelectedValue.CompareTo(UIConstante.EstadoPedidoSeguimiento.NuevoValor) == 0)
        {
            for (int i = 0; i < this.gvBandeja.Rows.Count; i++)
            {
                Label lblItem = (Label)this.gvBandeja.Rows[i].FindControl("lblItem");
                if (lblItem.Text.Trim().CompareTo(ddlEstado.ValidationGroup.Trim()) == 0)
                {
                    Label lblCantidadNueva = (Label)this.gvBandeja.Rows[i].FindControl("lblCantidadNueva");
                    TextBox txtCantidadNueva = (TextBox)this.gvBandeja.Rows[i].FindControl("txtCantidadNueva");

                    lblCantidadNueva.Visible = true;
                    txtCantidadNueva.Visible = true;
                    txtCantidadNueva.Text = "0";
                    break;
                }
            }

        }
        else
        {
            for (int i = 0; i < this.gvBandeja.Rows.Count; i++)
            {
                Label lblItem = (Label)this.gvBandeja.Rows[i].FindControl("lblItem");
                if (lblItem.Text.Trim().CompareTo(ddlEstado.ValidationGroup.Trim()) == 0)
                {
                    Label lblCantidadNueva = (Label)this.gvBandeja.Rows[i].FindControl("lblCantidadNueva");
                    TextBox txtCantidadNueva = (TextBox)this.gvBandeja.Rows[i].FindControl("txtCantidadNueva");

                    lblCantidadNueva.Visible = false;
                    txtCantidadNueva.Visible = false;
                    txtCantidadNueva.Text = "0";
                    break;
                }
            }
        }
        #endregion
    }


    protected void hidSituacion_ValueChanged(object sender, EventArgs e)
    {

    }
}
