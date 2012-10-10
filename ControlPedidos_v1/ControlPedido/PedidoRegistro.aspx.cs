using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MC.ControlPedido.Logica;
using MC.ControlPedido.Model;
using System.Data;
using WebServiceMelchor;
using System.Reflection;
using System.ComponentModel;

public partial class PedidoRegistro : UIPage
{
    [Serializable]
    public class Producto
    {
        string _IN01KEY;
        string _IN01DESLAR;
        string _IN01UNIMED;
        string _IN04CODALM;
        string _IN04STOCK;

        public String IN01KEY
        {
            get;
            set;
        }

        public String IN01DESLAR
        {
            get;
            set;
        }

        public String IN01UNIMED
        {
            get;
            set;
        }

        public String IN04CODALM
        {
            get;
            set;
        }

        public String IN04STOCK
        {
            get;
            set;
        }
    }

    #region Inicio
    protected override void OnLoad(EventArgs e)
    {
        this.gvBandeja.RowDataBound += new GridViewRowEventHandler(gvBandeja_RowDataBound);
        //Cargamos eventos en los botones de paginación
        imgbtnStart.Click += new ImageClickEventHandler(imgbtnStart_Click);
        imgbtnNext.Click += new ImageClickEventHandler(imgbtnNext_Click);
        imgbtnBack.Click += new ImageClickEventHandler(imgbtnBack_Click);
        imgbtnEnd.Click += new ImageClickEventHandler(imgbtnEnd_Click);

        if (IsPostBack == false)
        {
            this.txtFecha.Text = DateTime.Now.ToShortDateString();
            this.btnAgregar.Visible = false;
            this.btnGuardarDetalle.Visible = false;
            ListarArea();
            ListarJefeArea();
            CargarTipoPedido();

            this.hidNumeroPedido.Value = Request.Params["id"];
            this.hidArea.Value = Request.Params["area"];

            if (this.hidNumeroPedido.Value.Length > 0)
            {
                this.txtNroPedido.Text = this.hidNumeroPedido.Value;
                this.btnAgregar.Visible = true;
                this.btnGuardarDetalle.Visible = true;
                this.ddlArea.Enabled = false;
                this.ddlJefeArea.Enabled = false;
                PaginacionEnabled(false);
                ListarPedido();
            }
            else
            {
                this.lblEstado.Text = "PENDIENTE";
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

            this.ddlTipoPedido.Items.Add(new ListItem("--Seleccione--", "0"));
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
            oin23responsable.in23SistemaUsuario = _auditoria.usuario.Nombre;

            Bind(this.ddlJefeArea, oResponsableBLL.ListarResponsable(oin23responsable), "in23Codigo", "In23Descri");
            //this.ddlJefeArea.Items.Insert(0, new ListItem("--Seleccione--", "0"));
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
            Bind(this.ddlArea, oAreaBLL.ListarArea(_auditoria.CodigoEmpresa, _auditoria.usuario.Nombre), "In20CodArea", "In20Descripcion");
            //this.ddlArea.Items.Insert(0, new ListItem("--Seleccione--", "0"));

        }
        catch (Exception ex)
        {

            throw;
        }
    }

    private void ListarEquipo()
    {
        try
        {
            gvEquipo.DataSource = GEquipoBLL.ListarEquipo(_auditoria.CodigoEmpresa, this.txtDescripEquipo.Text);
            gvEquipo.DataBind();

        }
        catch (Exception)
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
            oIn60pedido.In60numped = this.txtNroPedido.Text;

            oIn60pedido.In60fecha = null;

            oIn60pedido.In60codres = this.ddlJefeArea.SelectedValue;
            oIn60pedido.In60Estado = UIConstante.EstadoPedido.Todos;
            oIn60pedido.In60Area = this.hidArea.Value;

            oIn60pedido.In60TipoPedido = this.ddlTipoPedido.SelectedValue;

            DataTable dtData;
            dtData = new PedidoBLL().ListarPedido(oIn60pedido);

            if (dtData.Rows.Count > 0)
            {
                this.txtFecha.Text = dtData.Rows[0]["In60fecha"].ToString();
                this.ddlJefeArea.SelectedValue = dtData.Rows[0]["In60codres"].ToString();
                this.txtAsunto.Text = Convert.ToString(dtData.Rows[0]["In60Obser"]);
                this.ddlArea.SelectedValue = Convert.ToString(dtData.Rows[0]["In60Area"]);
                this.ddlTipoPedido.SelectedValue = dtData.Rows[0]["In60TipoPedido"].ToString().Trim();
                //this.lblEstado.Text = Convert.ToString(dtData.Rows[0]["DesIn60Estado"]);

                this.txtFecha.Enabled = false;
                this.ddlTipoPedido.Enabled = false;
                this.txtAsunto.Enabled = false;

                this.btnGrabar.Visible = false;

                // if (Convert.ToString(dtData.Rows[0]["In60Estado"]).CompareTo(UIConstante.EstadoPedido.Pendiente) == 0)
                // {
                //     this.btnGuardarDetalle.Visible = true;
                //     this.btnAgregar.Visible = true;
                // }
                // else
                // {
                //    this.btnGuardarDetalle.Visible = false;
                //    this.btnAgregar.Visible = false;
                //}
            }

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

            In60pedido oIn60pedido = new In60pedido();
            oIn60pedido.In60codemp = _auditoria.CodigoEmpresa;
            oIn60pedido.In60aa = _auditoria.Periodo;
            oIn60pedido.In60numped = this.txtNroPedido.Text;
            oIn60pedido.In60Area = this.ddlArea.SelectedValue;

            DataTable dtData;
            dtData = new PedidoBLL().ListarDetallePedido(oIn60pedido);

            this.gvBandeja.DataSource = dtData;
            this.gvBandeja.DataBind();

            //Invoca al metodo para paginar la grilla
            Paginar(dtData, this.gvBandeja, this.litNumeroRegistros, this.litPagina);

            Session.Add("Detalle", dtData);
        }
        catch (Exception)
        {

            throw;
        }
    }

    /// <summary>
    /// Metodo que permite registrar pedidos
    /// </summary>
    private void RegistrarPedido()
    {
        try
        {
            //Valido antes de grabar
            if (this.ddlTipoPedido.SelectedValue.CompareTo("0") == 0)
            {
                CScript.MessageBox(0, "Seleccione tipo de pedido", upBandeja);
                return;
            }

            In60pedido oIn60pedido = new In60pedido();

            oIn60pedido.In60codemp = _auditoria.CodigoEmpresa;
            oIn60pedido.In60aa = _auditoria.Periodo;
            oIn60pedido.In60cencos = this.ddlArea.SelectedValue;
            oIn60pedido.In60numped = this.txtNroPedido.Text;
            oIn60pedido.In60codcli = string.Empty;
            oIn60pedido.In60fecha = DateTime.Now;
            oIn60pedido.In60codres = this.ddlJefeArea.SelectedValue;
            oIn60pedido.In60EspTec = string.Empty;
            oIn60pedido.In60Obser = this.txtAsunto.Text;
            oIn60pedido.In60Estado = UIConstante.EstadoPedido.Pendiente;
            oIn60pedido.In60Aprobado = 0;
            oIn60pedido.In60Expor = "N";
            oIn60pedido.In60Area = this.ddlArea.SelectedValue;
            oIn60pedido.In60DestinoOrigen = string.Empty;
            oIn60pedido.In60TipoPedido = this.ddlTipoPedido.SelectedValue;
            oIn60pedido.In60NameUser = string.Empty;
            oIn60pedido.in60mm = _auditoria.Mes;
            oIn60pedido.in60tipo = "A";
            oIn60pedido.in60mmProv = _auditoria.Mes;
            oIn60pedido.in60aaProv = _auditoria.Periodo;

            //In60detalle oIn60detalle = null;
            //List<In60detalle> oIn60detalles = new List<In60detalle>();

            //for (int i = 0; i < gvBandeja.Rows.Count; i++)
            //{
            //    Label lblItem = (Label)this.gvBandeja.Rows[i].FindControl("lblItem");
            //    TextBox txtUniMed = (TextBox)this.gvBandeja.Rows[i].FindControl("txtUniMed");
            //    TextBox txtCantidad = (TextBox)this.gvBandeja.Rows[i].FindControl("txtCantidad");
            //    TextBox txtNroLote = (TextBox)this.gvBandeja.Rows[i].FindControl("txtNroLote");
            //    HiddenField hidIdEquipo = (HiddenField)this.gvBandeja.Rows[i].FindControl("hidIdEquipo");
            //    DropDownList ddlPrioridad = (DropDownList)this.gvBandeja.Rows[i].FindControl("ddlPrioridad");
            //    TextBox txtObservacion = (TextBox)this.gvBandeja.Rows[i].FindControl("txtObservacion");
            //    Label lblIn60codart = (Label)this.gvBandeja.Rows[i].FindControl("lblIn60codart");
            //    Label lbllblIn60desart = (Label)this.gvBandeja.Rows[i].FindControl("lblIn60desart");

            //    oIn60detalle = new In60detalle();
            //    oIn60detalle.In60codemp = _auditoria.CodigoEmpresa;
            //    oIn60detalle.In60aa = _auditoria.Periodo;
            //    oIn60detalle.In60numped = this.txtNroPedido.Text;
            //    oIn60detalle.In60codart = lblIn60codart.Text;
            //    oIn60detalle.In60desart = lbllblIn60desart.Text;
            //    oIn60detalle.In60Item = int.Parse(lblItem.Text);
            //    oIn60detalle.In60unidad = txtUniMed.Text;
            //    oIn60detalle.In60cantidad = double.Parse(txtCantidad.Text);
            //    oIn60detalle.In60Area = this.ddlArea.SelectedValue;
            //    oIn60detalle.In60NroParte = txtNroLote.Text;
            //    oIn60detalle.In60Prioridad = ddlPrioridad.SelectedValue;
            //    oIn60detalle.In60Equipo = hidIdEquipo.Value;
            //    oIn60detalle.In60Observacion = txtObservacion.Text;

            //    oIn60detalles.Add(oIn60detalle);
            //}

            if (this.txtNroPedido.Text.Length == 0)
            {
                string numeroPedido;
                numeroPedido = new PedidoBLL().RegistrarPedido(oIn60pedido, null);

                this.txtNroPedido.Text = numeroPedido;
            }
            else
            {
                new PedidoBLL().ActualizarPedido(oIn60pedido, null);
            }
            this.btnGrabar.Visible = false;
            this.btnGuardarDetalle.Visible = true;

            //oIn60detalles = null;

            this.btnAgregar.Visible = true;
            this.ddlArea.Enabled = false;
            this.ddlJefeArea.Enabled = false;

        }
        catch (Exception ex)
        {

            CScript.MessageBox(0, ex.Message, upBandeja);
        }
    }

    private void ListarAlmacen()
    {
        try
        {

            this.ddlAlmacen.DataSource = new AlmacenBLL().ListarAlmacen(_auditoria.CodigoEmpresa);
            this.ddlAlmacen.DataTextField = "in09descripcion";
            this.ddlAlmacen.DataValueField = "in09codigo";
            this.ddlAlmacen.DataBind();

        }
        catch (Exception)
        {

            throw;
        }
    }


    private void ListarArticulo()
    {
        try
        {

            in01arti oin01arti = new in01arti();
            oin01arti.IN01CODEMP = _auditoria.CodigoEmpresa;
            oin01arti.IN01AA = _auditoria.Periodo;
            oin01arti.IN01KEY = this.txtCodArti.Text;
            oin01arti.IN01DESLAR = this.txtDesArti.Text;
            //oin01arti.In04axal.IN04CODALM = this.ddlAlmacen.SelectedValue;

            DataTable dtData;
            dtData = new ArticuloBLL().ListarArticulo(oin01arti, this.ddlAlmacen.SelectedValue, _auditoria.Mes);

            this.gvBandejaArticulo.DataSource = dtData;
            this.gvBandejaArticulo.DataBind();


        }
        catch (Exception)
        {

            throw;
        }
    }

    //private void ListarArticulo()
    //{
    //    try
    //    {
    //        List<producto> lst = new List<producto>();
    //        List<Producto> lista = new List<Producto>();
    //        DataTable dt = new DataTable();
    //        using (MelchorServiceClient servicio = new MelchorServiceClient())
    //        {
    //            producto[] array = servicio.ObtenerListaProductos(_auditoria.CodigoEmpresa, _auditoria.Periodo, this.txtCodArti.Text, this.txtDesArti.Text, this.ddlAlmacen.SelectedValue, _auditoria.Mes);
    //            if (array != null)
    //                lst = array.ToList();
    //        }

    //        if (lst.Count > 0)
    //        {
    //            foreach (var item in lst)
    //            {
    //                Producto entidad = new Producto();
    //                entidad.IN01KEY = item.IN01KEY.ToString();
    //                entidad.IN01DESLAR = item.IN01DESLAR.ToString();
    //                entidad.IN01UNIMED = item.IN01UNIMED.ToString();
    //                entidad.IN04CODALM = item.IN04CODALM.ToString();
    //                entidad.IN04STOCK = item.IN04STOCK.ToString();
    //                lista.Add(entidad);
    //            }
    //            dt = ToDataTable(lista);
    //        }

    //        this.gvBandejaArticulo.DataSource = dt;
    //        this.gvBandejaArticulo.DataBind();
    //    }
    //    catch (Exception ex)
    //    {

    //        throw ex;
    //    }
    //}

    private void AgregarItem()
    {
        try
        {




        }
        catch (Exception)
        {

            throw;
        }
    }

    #endregion

    #region Eventos
    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        // Registra Pedido
        RegistrarPedido();
    }
    #endregion

    protected void btnCancelarAtencion_Click(object sender, EventArgs e)
    {
        mpeArticulo.Hide();
    }
    protected void btnGuardarAtencion_Click(object sender, EventArgs e)
    {
        ListarArticulo();
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        GuardarDetalles(false);

        ListarAlmacen();
        txtCodArti.Text = string.Empty;
        txtDesArti.Text = string.Empty;
        ListarArticulo();
        mpeArticulo.Show();
    }

    protected void lnkSeleccione_Click(object sender, EventArgs e)
    {
        try
        {

            In60detalle oIn60detalle = new In60detalle();
            LinkButton lnkSeleccione = (LinkButton)sender;

            char[] delimitador = { '|' };
            string[] args = lnkSeleccione.CommandArgument.Split(delimitador);

            string In60codart = args[0];
            string In60desart = args[1];
            string In60unidad = args[2];
            string IN04CODALM = args[3];

            oIn60detalle.In60codemp = _auditoria.CodigoEmpresa;
            oIn60detalle.In60aa = _auditoria.Periodo;
            oIn60detalle.In60cencos = this.ddlArea.SelectedValue;
            oIn60detalle.In60numped = this.txtNroPedido.Text;
            oIn60detalle.In60codalm = IN04CODALM;

            oIn60detalle.In60codart = In60codart;
            oIn60detalle.In60Item = 0;
            oIn60detalle.In60Id = 0;
            oIn60detalle.In60desart = In60desart;
            oIn60detalle.In60unidad = In60unidad;
            oIn60detalle.In60cantidad = 0;
            oIn60detalle.In60Estado = UIConstante.EstadoPedido.Pendiente;
            oIn60detalle.In60Area = this.ddlArea.SelectedValue;
            oIn60detalle.In60NameUser = _auditoria.usuario.Nombre;
            oIn60detalle.In60NroParte = string.Empty;
            oIn60detalle.In60Prioridad = string.Empty;
            oIn60detalle.In60Equipo = string.Empty;
            oIn60detalle.in60mm = _auditoria.Mes;

            new PedidoBLL().RegistrarDetallePedido(oIn60detalle);
            ListarDetallePedido();

            upBandeja.Update();
            mpeArticulo.Hide();
        }
        catch (Exception)
        {

            throw;
        }
    }

    private void GuardarDetalles(bool vmostramensaje)
    {
        try
        {
            In60pedido oIn60pedido = new In60pedido();

            oIn60pedido.In60codemp = _auditoria.CodigoEmpresa;
            oIn60pedido.In60aa = _auditoria.Periodo;
            oIn60pedido.In60cencos = this.ddlArea.SelectedValue;
            oIn60pedido.In60numped = this.txtNroPedido.Text;
            oIn60pedido.In60codcli = string.Empty;
            oIn60pedido.In60fecha = DateTime.Now;
            oIn60pedido.In60codres = this.ddlJefeArea.SelectedValue;
            oIn60pedido.In60EspTec = string.Empty;
            oIn60pedido.In60Obser = this.txtAsunto.Text;
            oIn60pedido.In60Estado = UIConstante.EstadoPedido.Pendiente;
            oIn60pedido.In60Aprobado = 0;
            oIn60pedido.In60Expor = "N";
            oIn60pedido.In60Area = this.ddlArea.SelectedValue;
            oIn60pedido.In60DestinoOrigen = string.Empty;
            oIn60pedido.In60TipoPedido = this.ddlTipoPedido.SelectedValue;
            oIn60pedido.In60NameUser = string.Empty;
            oIn60pedido.in60mm = _auditoria.Mes;
            oIn60pedido.in60tipo = "A";
            oIn60pedido.in60mmProv = _auditoria.Mes;
            oIn60pedido.in60aaProv = _auditoria.Periodo;

            In60detalle oIn60detalle = null;
            List<In60detalle> oIn60detalles = new List<In60detalle>();

            for (int i = 0; i < gvBandeja.Rows.Count; i++)
            {
                Label lblItem = (Label)this.gvBandeja.Rows[i].FindControl("lblItem");
                TextBox txtUniMed = (TextBox)this.gvBandeja.Rows[i].FindControl("txtUniMed");
                TextBox txtCantidad = (TextBox)this.gvBandeja.Rows[i].FindControl("txtCantidad");
                TextBox txtNroLote = (TextBox)this.gvBandeja.Rows[i].FindControl("txtNroLote");
                HiddenField hidIdEquipo = (HiddenField)this.gvBandeja.Rows[i].FindControl("hidIdEquipo");
                DropDownList ddlPrioridad = (DropDownList)this.gvBandeja.Rows[i].FindControl("ddlPrioridad");
                TextBox txtObservacion = (TextBox)this.gvBandeja.Rows[i].FindControl("txtObservacion");
                TextBox txtIn60desart = (TextBox)this.gvBandeja.Rows[i].FindControl("txtIn60desart");

                oIn60detalle = new In60detalle();
                oIn60detalle.In60codemp = _auditoria.CodigoEmpresa;
                oIn60detalle.In60aa = _auditoria.Periodo;
                oIn60detalle.In60numped = this.txtNroPedido.Text;
                oIn60detalle.In60Item = int.Parse(lblItem.Text);
                oIn60detalle.In60desart = txtIn60desart.Text.Trim();
                oIn60detalle.In60unidad = txtUniMed.Text;
                oIn60detalle.In60cantidad = double.Parse(txtCantidad.Text);
                oIn60detalle.In60Area = this.ddlArea.SelectedValue;
                oIn60detalle.In60NroParte = txtNroLote.Text;
                oIn60detalle.In60Prioridad = ddlPrioridad.SelectedValue;
                oIn60detalle.In60Equipo = hidIdEquipo.Value;
                oIn60detalle.In60Observacion = txtObservacion.Text.Trim();

                oIn60detalles.Add(oIn60detalle);
            }

            //Guardamos los detalles
            new PedidoBLL().ActualizarDetallePedido(oIn60pedido, oIn60detalles);
            oIn60pedido = null;
            oIn60detalles = null;

            if (vmostramensaje)
            {
                CScript.MessageBox(0, "El pedido se guardó con éxito", upBandeja);
            }

        }
        catch (Exception ex)
        {

            CScript.MessageBox(0, ex.Message, upBandeja);
        }
    }

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
    protected void btnGuardarDetalle_Click(object sender, EventArgs e)
    {
        GuardarDetalles(true);
    }

    protected void gvBandejaArticulo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gvBandejaArticulo.PageIndex = e.NewPageIndex;
        ListarArticulo();
    }

    protected void gvBandeja_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView fila = (DataRowView)e.Row.DataItem;

                LinkButton lnkEliminar = (LinkButton)e.Row.FindControl("lnkEliminar");
                lnkEliminar.Attributes.Add("onclick", "return confirm('¿Está seguro de eliminar el detalle pedido?');");

                DropDownList ddlPrioridad = (DropDownList)e.Row.FindControl("ddlPrioridad");
                ddlPrioridad.SelectedValue = fila["In60Prioridad"].ToString();
                Label lblIn60codart = (Label)e.Row.FindControl("lblIn60codart");
                TextBox txtIn60desart = (TextBox)e.Row.FindControl("txtIn60desart");

                if (lblIn60codart.Text.CompareTo(UIConstante.Articulo.CodigoVarios) != 0)
                {
                    txtIn60desart.Enabled = false;
                }

                //try
                //{

                //    DropDownList ddlEquipo = (DropDownList)e.Row.FindControl("ddlEquipo");
                //    ddlEquipo.DataSource = GEquipoBLL.ListarEquipo(_auditoria.CodigoEmpresa);
                //    ddlEquipo.DataTextField = "ccmc03des";
                //    ddlEquipo.DataValueField = "ccmc03CodBarra";
                //    ddlEquipo.DataBind();
                //    ddlEquipo.Items.Insert(0, new ListItem("--Seleccione--", "0"));

                //    BuscarValueDropDownList(ddlEquipo, Convert.ToString(fila["In60Equipo"]));
                //    //ddlEquipo.SelectedValue = Convert.ToString(fila["In60Equipo"]);
                //}
                //catch (Exception)
                //{

                //    throw;
                //}

            }

        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void lnkEliminar_Click(object sender, EventArgs e)
    {
        try
        {

            LinkButton lnkEliminar = (LinkButton)sender;
            In60detalle oIn60detalle = new In60detalle();

            oIn60detalle.In60codemp = _auditoria.CodigoEmpresa;
            oIn60detalle.In60aa = _auditoria.Periodo;
            oIn60detalle.In60numped = this.txtNroPedido.Text;
            oIn60detalle.In60Item = int.Parse(lnkEliminar.CommandArgument);
            oIn60detalle.In60Area = this.ddlArea.SelectedValue;

            new PedidoBLL().EliminarDetallePedido(oIn60detalle);
            ListarDetallePedido();

        }
        catch (Exception ex)
        {
            throw;
        }
    }


    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("FormListaPedido.aspx", false);
    }
    protected void imbCerrarAtendido_Click(object sender, ImageClickEventArgs e)
    {
        mpeArticulo.Hide();
    }
    protected void gvBandejaArticulo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView fila = (DataRowView)e.Row.DataItem;

            LinkButton lnkSeleccione = (LinkButton)e.Row.FindControl("lnkSeleccione");
            lnkSeleccione.CommandArgument = fila["IN01KEY"].ToString() + "|" + fila["IN01DESLAR"].ToString() + "|" + fila["IN01UNIMED"].ToString() + "|" + fila["IN04CODALM"].ToString();

        }
    }
    protected void lnkSeleccioneEquipo_Click(object sender, EventArgs e)
    {
        try
        {

            LinkButton lnkSeleccioneEquipo = (LinkButton)sender;
            for (int i = 0; i < this.gvBandeja.Rows.Count; i++)
            {
                Label lblItem = (Label)this.gvBandeja.Rows[i].FindControl("lblItem");
                if (lblItem.Text.CompareTo(this.hidItem.Value) == 0)
                {
                    HiddenField hidIdEquipo = (HiddenField)this.gvBandeja.Rows[i].FindControl("hidIdEquipo");
                    Label lblEquipo = (Label)this.gvBandeja.Rows[i].FindControl("lblEquipo");

                    hidIdEquipo.Value = lnkSeleccioneEquipo.CommandArgument;
                    lblEquipo.Text = lnkSeleccioneEquipo.CommandName;
                }
            }

            mpeEquipo.Hide();
            upBandeja.Update();
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void imbBuscarEquipo_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton imbBuscarEquipo = (ImageButton)sender;
            this.hidItem.Value = imbBuscarEquipo.CommandArgument;
            ListarEquipo();

            mpeEquipo.Show();

        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void btnCancelarEquipo_Click(object sender, EventArgs e)
    {
        mpeEquipo.Hide();
    }
    protected void btnBuscarEquipo_Click(object sender, EventArgs e)
    {
        ListarEquipo();
    }
    protected void imbCerrarEquipo_Click(object sender, ImageClickEventArgs e)
    {
        mpeEquipo.Hide();
    }
    protected void gvEquipo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEquipo.PageIndex = e.NewPageIndex;
        ListarEquipo();
    }

    protected void gvBandeja_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    #region Metodos Agregados Consumo

    public DataTable ToDataTable<T>(List<T> items)
    {
        DataTable dataTable = new DataTable(typeof(T).Name);
        //Get all the properties
        PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (PropertyInfo prop in Props)
        {
            //Setting column names as Property names
            dataTable.Columns.Add(prop.Name);
        }
        foreach (T item in items)
        {
            var values = new object[Props.Length];
            for (int i = 0; i < Props.Length; i++)
            {
                //inserting property values to datatable rows
                values[i] = Props[i].GetValue(item, null);
            }
            dataTable.Rows.Add(values);
        }
        //put a breakpoint here and check datatable
        return dataTable;
    }

    #endregion
}