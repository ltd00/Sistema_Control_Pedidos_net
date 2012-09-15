using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MC.ControlPedido.Logica;
using MC.ControlPedido.Model;
using System.Data;

public partial class FormListaPedidoAproba1 : UIPage
{
    #region Inicio
    protected override void OnLoad(EventArgs e)
    {
        //Cargamos eventos en los botones de paginación
        this.gvBandeja.RowDataBound += new GridViewRowEventHandler(gvBandeja_RowDataBound);
        imgbtnStart.Click += new ImageClickEventHandler(imgbtnStart_Click);
        imgbtnNext.Click += new ImageClickEventHandler(imgbtnNext_Click);
        imgbtnBack.Click += new ImageClickEventHandler(imgbtnBack_Click);
        imgbtnEnd.Click += new ImageClickEventHandler(imgbtnEnd_Click);

        if (IsPostBack == false)
        {
            this.hidFlujoProceso.Value = Request.Params["p"];
            this.lblTitulo.Text = General.AsignarTitulo(this.hidFlujoProceso.Value);
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

            ListarArea();
            ListarJefeArea();
            CargarTipoPedido();
            PaginacionEnabled(false);
            ListarPedido();
        }
    }

     #endregion

    #region Metodos

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
            else
            {
                oin23responsable.in23SistemaUsuario = string.Empty;
            }

            Bind(this.ddlJefeArea, oResponsableBLL.ListarResponsable(oin23responsable), "in23Codigo", "In23Descri");
            if (this.hidFlujoProceso.Value.CompareTo(UIConstante.FlujoProceso.JefeArea.ToString()) != 0)
            {
                this.ddlJefeArea.Items.Insert(0, new ListItem("--Todos--", "0"));
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
                this.ddlArea.Items.Insert(0, new ListItem("--Todos--", "0"));
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }

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

    /// <summary>
    /// Lista pedidos
    /// </summary>
    private void ListarPedido()
    {
        try
        {
            

            In60pedido oIn60pedido = new In60pedido();
            In60detalleSeg oIn60DetalleSeg = new In60detalleSeg();

            oIn60DetalleSeg.In60codemp=_auditoria.CodigoEmpresa;
            oIn60DetalleSeg.in60FlujoProceso = int.Parse(this.hidFlujoProceso.Value);
            oIn60DetalleSeg.In60Area = this.ddlArea.SelectedValue;
            oIn60DetalleSeg.In60numped = this.txtNroPedido.Text;
            oIn60pedido.In60TipoPedido = this.ddlTipoPedido.SelectedValue;

            
            DataTable dtData;
            dtData = new PedidoBLL().ListarPedidoSeguimientoxarea(oIn60DetalleSeg, oIn60pedido);

            this.gvBandeja.DataSource = dtData;
            this.gvBandeja.DataBind();

            //Invoca al metodo para paginar la grilla
            Paginar(dtData, this.gvBandeja, this.litNumeroRegistros, this.litPagina);

            
        }
        catch (Exception)
        {

            throw;
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
    protected void lnkSeguimiento_Click(object sender, EventArgs e)
    {
        LinkButton lnkSeguimiento = (LinkButton)sender;
        
        char[] delimitador = { '|' };
        string[] args = lnkSeguimiento.CommandArgument.Split(delimitador);

        string numeroPedido = args[0];
        string area = args[1].Trim();
        string flujopedido = args[2]; // El flujo propio del numero de pedido
        String flujo = hidFlujoProceso.Value;  // El flujo del proceso, osea en la pantalla donde esta

        Response.Redirect("FormPedidoAproba1.aspx?id=" + numeroPedido + "&area=" + area + "&p=" + flujo + "&pe=" + flujopedido , false);

    }

    protected void lnkAnularSeguimiento_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkAnularSeguimiento = (LinkButton)sender;
            char[] delimitador = { '|' };
            string[] args = lnkAnularSeguimiento.CommandArgument.Split(delimitador);

            string numeroPedido = args[0];
            string area = args[1];
            string flujo = args[2];     // El flujo del pedido
            string nrointento = args[3]; // Nro de intento

            In60detalleSeg oIn60detalleSeg = new In60detalleSeg();
            oIn60detalleSeg.In60codemp = _auditoria.CodigoEmpresa;
            oIn60detalleSeg.In60aa = _auditoria.Periodo;
            oIn60detalleSeg.In60Area = area;
            oIn60detalleSeg.In60numped = numeroPedido;
            oIn60detalleSeg.In60NroIntento = int.Parse(nrointento);
            oIn60detalleSeg.in60FlujoProceso = int.Parse(flujo);

            new PedidoBLL().DeshacerAprobacion(oIn60detalleSeg);
            oIn60detalleSeg = null;
            GC.Collect();

            ListarPedido();
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    protected void gvBandeja_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView fila = (DataRowView)e.Row.DataItem;

                LinkButton lnkAnularSeguimiento = (LinkButton)e.Row.FindControl("lnkAnularSeguimiento");
                HiddenField hidSituacion = (HiddenField)e.Row.FindControl("hidSituacion");
                Label lblSituacion = (Label)e.Row.FindControl("lblSituacion");

                lnkAnularSeguimiento.CommandArgument = Convert.ToString(fila["In60numped"]) + "|" + Convert.ToString(fila["In60Area"]) + "|" + Convert.ToString(fila["in60FlujoProceso"]) + "|" + Convert.ToString(fila["In60NroIntento"]);

                //Si Flujo de proceso  = Flujo de proceso del pedido
                if (int.Parse(this.hidFlujoProceso.Value) == int.Parse(fila["in60FlujoProceso"].ToString()))
                    {
                        lnkAnularSeguimiento.Attributes.Add("onclick", "return confirm('¿Está seguro de deshacer la aprobación del pedido?');");
                        lnkAnularSeguimiento.Enabled = true;
                    }
                else 
                    {
                        lnkAnularSeguimiento.Enabled = false;
                        lnkAnularSeguimiento.ToolTip = "Opción deshabilitada. El pedido aun no se ha aprobado";
                    }

                /*
                if (int.Parse(hidSituacion.Value) == int.Parse(this.hidFlujoProceso.Value))
                {
                    lnkAnularSeguimiento.Attributes.Add("onclick", "return confirm('¿Está seguro de deshacer la aprobación del pedido?');");
                    lnkAnularSeguimiento.Enabled = true;
                }
                else
                {
                    if (int.Parse(hidSituacion.Value) < int.Parse(this.hidFlujoProceso.Value))
                    {
                        lnkAnularSeguimiento.Enabled = false;
                        lnkAnularSeguimiento.ToolTip = "Opción deshabilitada. El pedido aun no se ha aprobado";
                    }
                    else
                    {
                        lnkAnularSeguimiento.Enabled = false;
                        lnkAnularSeguimiento.ToolTip = "Opción deshabilitada. El pedido ya fue aprobado en el siguiente proceso";
                    }
                }
                */

                #region Se pinta el color según el flujo de aprobacion

                if (int.Parse(hidSituacion.Value) == UIConstante.FlujoProceso.JefeArea)
                {
                    //e.Row.BackColor = System.Drawing.Color.Green;
                    lblSituacion.ForeColor = System.Drawing.Color.Blue;
                    //lblSituacion.ForeColor = System.Drawing.Color.Blue;
                    lblSituacion.Font.Bold = true;
                }

                if (int.Parse(hidSituacion.Value) == UIConstante.FlujoProceso.JefeAlmacen)
                {
                    lblSituacion.ForeColor = System.Drawing.Color.Gold;
                    lblSituacion.Font.Bold = true;
                }

                if (int.Parse(hidSituacion.Value) == UIConstante.FlujoProceso.JefeSuperintendente)
                {
                    lblSituacion.ForeColor = System.Drawing.Color.Red;
                    lblSituacion.Font.Bold = true;

                }

                if (int.Parse(hidSituacion.Value) == UIConstante.FlujoProceso.JefeOperacion)
                {
                    lblSituacion.ForeColor = System.Drawing.Color.Orange;
                    lblSituacion.Font.Bold = true;
                }

                if (int.Parse(hidSituacion.Value) == UIConstante.FlujoProceso.JefeCompras)
                {
                    //e.Row.BackColor = System.Drawing.Color.Green;
                    //e.Row.ForeColor = System.Drawing.Color.White;
                    lblSituacion.ForeColor = System.Drawing.Color.Green;
                    lblSituacion.Font.Bold = true;
                }
                #endregion
            }

        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void gvBandeja_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
   
}