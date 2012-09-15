using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MC.ControlPedido.Logica;
using MC.ControlPedido.Model;
using System.Data;
using APNSoft.WebControls;

public partial class ConsultaPedido : UIPage
{
    #region Inicio
    protected override void OnLoad(EventArgs e)
    {
        //this.gvBandeja.RowDataBound += new GridViewRowEventHandler(gvBandeja_RowDataBound);

        //Cargamos eventos en los botones de paginación
        //this.gvBandeja.RowDataBound += new GridViewRowEventHandler(gvBandeja_RowDataBound);
        //imgbtnStart.Click += new ImageClickEventHandler(imgbtnStart_Click);
        //imgbtnNext.Click += new ImageClickEventHandler(imgbtnNext_Click);
        //imgbtnBack.Click += new ImageClickEventHandler(imgbtnBack_Click);
        //imgbtnEnd.Click += new ImageClickEventHandler(imgbtnEnd_Click);

        if (IsPostBack == false)
        {
            ListarAnios();
            ListaMeses();
            ListaEstFlujoProceso();
            ListarArea();
            CargarTipoPedido();
            //
            PaginacionEnabled(false);
            //ListarPedidoSeguimiento();
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

    private void ListaEstFlujoProceso()
    {
        try
        {
            this.ddlflujopedido.Items.Add(new ListItem("--Todos--", "0"));
            this.ddlflujopedido.Items.Add(new ListItem("Aprobado X J.Area", UIConstante.FlujoProceso.JefeArea.ToString()));
            this.ddlflujopedido.Items.Add(new ListItem("Aprobado X J.Almacen", UIConstante.FlujoProceso.JefeAlmacen.ToString()));
            this.ddlflujopedido.Items.Add(new ListItem("Aprobado X SuperIntendente", UIConstante.FlujoProceso.JefeSuperintendente.ToString()));
            this.ddlflujopedido.Items.Add(new ListItem("Aprobado X Gerente Operaciones", UIConstante.FlujoProceso.JefeOperacion.ToString()));
            this.ddlflujopedido.Items.Add(new ListItem("Aprobado X Jefe de Compras", UIConstante.FlujoProceso.JefeCompras.ToString()));

        }
        catch (Exception ex)
        {

            throw;
        }
    }

    private void ListarAnios()
    {
        try
        {
            Bind(this.ddlAnio, oPeriodoBll.ListarAnios(_auditoria.CodigoEmpresa), "PeriodoCod", "PeriodoDesc");
            BuscarValueDropDownList(ddlAnio,_auditoria.Periodo);
            }
        catch (Exception ex)
        {

            throw;
        }
    }
  private void ListaMeses()
    {
        try
        {
            Bind(this.ddlmes, oPeriodoBll.ListarMeses(_auditoria.CodigoEmpresa, this.ddlAnio.SelectedValue), "ccb03cod", "ccb03des");
            this.ddlmes.Items.Insert(0, new ListItem("--Todos--", ""));
            BuscarValueDropDownList(ddlmes,_auditoria.Mes);
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
            Bind(this.ddlarea, oAreaBLL.ListarArea(_auditoria.CodigoEmpresa, string.Empty), "In20CodArea", "In20Descripcion");
            this.ddlarea.Items.Insert(0, new ListItem("--Todos--", "0"));
            }
        catch (Exception ex)
        {

            throw;
        }
    }

    /// <summary>
    /// Lista pedidos
    /// </summary>
    private void ListarPedidoSeguimiento()
    {
        try
        {
            //NUEVO
            System.Threading.Thread.Sleep(Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["TiempoAjax"])); 
            In60pedido oIn60pedido = new In60pedido();
            oIn60pedido.In60codemp = _auditoria.CodigoEmpresa;
            oIn60pedido.In60aa = this.ddlAnio.SelectedValue;
            oIn60pedido.in60mm = this.ddlmes.SelectedValue;
            oIn60pedido.In60Area = this.ddlarea.SelectedValue;
            oIn60pedido.In60numped = this.txtNroPedido.Text;
            oIn60pedido.In60TipoPedido = this.ddlTipoPedido.SelectedValue;
            oIn60pedido.in60nivelflujo = int.Parse(this.ddlflujopedido.SelectedValue);

            /*
            if (this.txtFecha.Text.Length == 0)
            {
                oIn60pedido.In60fecha = null;
            }
            else
            {
                oIn60pedido.In60fecha = Convert.ToDateTime(this.txtFecha.Text);
            }
            */
            //oIn60pedido.In60codres = this.ddlJefeArea.SelectedValue;
            //oIn60pedido.In60Estado = UIConstante.EstadoPedido.Todos;
            

            oIn60pedido.In60TipoPedido = this.ddlTipoPedido.SelectedValue;

            DataTable dtData;
            dtData = new PedidoBLL().ListarReportePedidoSeguimiento(oIn60pedido);

            this.gvBandeja.DataSource = dtData;
            this.gvBandeja.DataBind();
            //this.gvBandeja.ShowHeader = false;
            //this.gvBandeja.HeaderStyle.Height = 0;

            ////this.myDataGrid.KeyFieldName = "In60numped";
            //this.myDataGrid.DataSource = dtData;
            //this.myDataGrid.DataBind();

            //myDataGrid.Columns["In60numped"].Sortable = false;
            //myDataGrid.Columns["In60desart"].Sorted = GridColumn.SortedValues.Ascending;

            //DataTable dtTitulo = dtData;
            //foreach (DataRow item in dtData.Rows)
            //{
            //    dtTitulo.Rows.Remove(item);
            //}

            //DataTable dtTitulo = dtData;
            //dtTitulo.Rows.Clear();

            //dtData.Rows.Clear();
            //this.gvTitulo.DataSource = dtData;
            //this.gvTitulo.DataBind();
            
                           
            //Invoca al metodo para paginar la grilla
            //Paginar(dtData, this.gvBandeja, this.litNumeroRegistros, null);

        }
        catch (Exception ex)
        {

            CScript.MessageBox(0, ex.Message, upBandeja);
        }
    }

    #endregion

    #region Eventos Paginado

    void Inicializar()
    {
        try
        {

            //this.imgbtnBack.Visible = false;
            //this.imgbtnStart.Visible = false;
            //this.imgbtnEnd.Visible = false;
            //this.imgbtnNext.Visible = false;

            //this.imgbtnBack.Enabled = false;
            //this.imgbtnStart.Enabled = false;
            //this.imgbtnEnd.Enabled = false;
            //this.imgbtnNext.Enabled = false;

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
                ListarPedidoSeguimiento();

                //this.imgbtnStart.Enabled = true;
                //this.imgbtnBack.Enabled = true;
                //this.imgbtnEnd.Enabled = false;
                //this.imgbtnNext.Enabled = false;
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
                ListarPedidoSeguimiento();

                if (this.gvBandeja.PageIndex > 0)
                {
                    //this.imgbtnStart.Enabled = true;
                    //this.imgbtnBack.Enabled = true;
                }
                else
                {
                    //this.imgbtnStart.Enabled = false;
                    //this.imgbtnBack.Enabled = false;
                }

                //this.imgbtnEnd.Enabled = true;
                //this.imgbtnNext.Enabled = true;
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

                ListarPedidoSeguimiento();

                //this.imgbtnStart.Enabled = true;
                //this.imgbtnBack.Enabled = true;

                //if (this.gvBandeja.PageIndex == (this.gvBandeja.PageCount - 1))
                //{
                //    this.imgbtnEnd.Enabled = false;
                //    this.imgbtnNext.Enabled = false;
                //}
                //else
                //{
                //    this.imgbtnEnd.Enabled = true;
                //    this.imgbtnNext.Enabled = true;
                //}

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
                ListarPedidoSeguimiento();

                //this.imgbtnStart.Enabled = false;
                //this.imgbtnBack.Enabled = false;
                //this.imgbtnNext.Enabled = true;
                //this.imgbtnEnd.Enabled = true;
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
    /// <Empresa>Minera Colquisiri S.A.</Empresa>
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
                    //this.imgbtnEnd.Enabled = true;
                    //this.imgbtnNext.Enabled = true;
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
            //imgbtnStart.Visible = valor;
            //imgbtnNext.Visible = valor;
            //imgbtnBack.Visible = valor;
            //imgbtnEnd.Visible = valor;
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
            //imgbtnStart.Enabled = valor;
            //imgbtnNext.Enabled = valor;
            //imgbtnBack.Enabled = valor;
            //imgbtnEnd.Enabled = valor;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        ListarPedidoSeguimiento();
    }

    protected void gvBandeja_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "Pedido";
            HeaderCell.ColumnSpan = 8;
            HeaderCell.BackColor = System.Drawing.Color.AliceBlue;
            HeaderCell.ForeColor = System.Drawing.Color.Black;
            HeaderCell.Font.Bold = true;

            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell = new TableCell();
            HeaderCell.Text = "Jefe de Área";
            HeaderCell.ColumnSpan = 2;
            HeaderCell.BackColor = System.Drawing.Color.Yellow;
            HeaderCell.ForeColor = System.Drawing.Color.Black;
            HeaderCell.Font.Bold = true;

            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell = new TableCell();
            HeaderCell.Text = "Jefe de Almacén";
            HeaderCell.ColumnSpan = 3;
            HeaderCell.BackColor = System.Drawing.Color.Orange;
            HeaderCell.ForeColor = System.Drawing.Color.Black;
            HeaderCell.Font.Bold = true;

            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell = new TableCell();
            HeaderCell.Text = "Superintendente";
            HeaderCell.ColumnSpan = 3;
            HeaderCell.BackColor = System.Drawing.Color.Blue;
            HeaderCell.ForeColor = System.Drawing.Color.White;
            HeaderCell.Font.Bold = true;

            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell = new TableCell();
            HeaderCell.Text = "Gerente de Operaciones";
            HeaderCell.ColumnSpan = 3;
            HeaderCell.BackColor = System.Drawing.Color.LawnGreen;
            HeaderCell.ForeColor = System.Drawing.Color.Black;
            HeaderCell.Font.Bold = true;

            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell = new TableCell();
            HeaderCell.Text = "Jefe de Compras";
            HeaderCell.ColumnSpan = 3;
            HeaderCell.BackColor = System.Drawing.Color.Green;
            HeaderCell.ForeColor = System.Drawing.Color.White;
            HeaderCell.Font.Bold = true;

            HeaderGridRow.Cells.Add(HeaderCell);
            gvBandeja.Controls[0].Controls.AddAt(0, HeaderGridRow);
        }
    }

    protected void gvBandeja_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView fila = (DataRowView)e.Row.DataItem;

                HiddenField hidIn60Aprobado = (HiddenField)e.Row.FindControl("hidIn60Aprobado");

                #region Se pinta el color según el flujo de aprobacion

                e.Row.BackColor = System.Drawing.Color.AliceBlue ;

                if (int.Parse(hidIn60Aprobado.Value) == UIConstante.FlujoProceso.JefeArea)
                {
                    //e.Row.BackColor = System.Drawing.Color.Yellow;
                    //e.Row.ForeColor = System.Drawing.Color.White;
                    for (int i = 0; i < 10; i++)
                    {
                        e.Row.Cells[i].BackColor = System.Drawing.Color.Yellow;
                    }                    
                }

                if (int.Parse(hidIn60Aprobado.Value) == UIConstante.FlujoProceso.JefeAlmacen)
                {
                    //e.Row.BackColor = System.Drawing.Color.Orange;
                    //e.Row.ForeColor = System.Drawing.Color.White;
                    for (int i = 0; i < 13; i++)
                    {
                        e.Row.Cells[i].BackColor = System.Drawing.Color.Orange;
                    }    
                }

                if (int.Parse(hidIn60Aprobado.Value) == UIConstante.FlujoProceso.JefeSuperintendente)
                {
                    //e.Row.BackColor = System.Drawing.Color.Blue;
                    //e.Row.ForeColor = System.Drawing.Color.White;
                    for (int i = 0; i < 16; i++)
                    {
                        e.Row.Cells[i].ForeColor = System.Drawing.Color.White;
                        e.Row.Cells[i].BackColor = System.Drawing.Color.Blue;
                    }  
                }

                if (int.Parse(hidIn60Aprobado.Value) == UIConstante.FlujoProceso.JefeOperacion)
                {
                    //e.Row.BackColor = System.Drawing.Color.LawnGreen;
                    //e.Row.ForeColor = System.Drawing.Color.Black;
                    for (int i = 0; i < 19; i++)
                    {
                        e.Row.Cells[i].ForeColor = System.Drawing.Color.Black;
                        e.Row.Cells[i].BackColor = System.Drawing.Color.LawnGreen;
                    }  
                }

                if (int.Parse(hidIn60Aprobado.Value) == UIConstante.FlujoProceso.JefeCompras)
                {
                    //e.Row.BackColor = System.Drawing.Color.Green;
                    //e.Row.ForeColor = System.Drawing.Color.White;
                    for (int i = 0; i < 21; i++)
                    {
                        e.Row.Cells[i].ForeColor = System.Drawing.Color.White;
                        e.Row.Cells[i].BackColor = System.Drawing.Color.Green;
                    } 
                }
                #endregion
            }

        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void gvTitulo_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "Pedido";
            HeaderCell.ColumnSpan = 8;
            HeaderCell.BackColor = System.Drawing.Color.AliceBlue;
            HeaderCell.ForeColor = System.Drawing.Color.Black;
            HeaderCell.Font.Bold = true;

            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell = new TableCell();
            HeaderCell.Text = "Jefe de Área";
            HeaderCell.ColumnSpan = 2;
            HeaderCell.BackColor = System.Drawing.Color.Yellow;
            HeaderCell.ForeColor = System.Drawing.Color.Black;
            HeaderCell.Font.Bold = true;

            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell = new TableCell();
            HeaderCell.Text = "Jefe de Almacén";
            HeaderCell.ColumnSpan = 3;
            HeaderCell.BackColor = System.Drawing.Color.Orange;
            HeaderCell.ForeColor = System.Drawing.Color.Black;
            HeaderCell.Font.Bold = true;

            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell = new TableCell();
            HeaderCell.Text = "Superintendente";
            HeaderCell.ColumnSpan = 3;
            HeaderCell.BackColor = System.Drawing.Color.Blue;
            HeaderCell.ForeColor = System.Drawing.Color.White;
            HeaderCell.Font.Bold = true;

            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell = new TableCell();
            HeaderCell.Text = "Gerente de Operaciones";
            HeaderCell.ColumnSpan = 3;
            HeaderCell.BackColor = System.Drawing.Color.LawnGreen;
            HeaderCell.ForeColor = System.Drawing.Color.Black;
            HeaderCell.Font.Bold = true;

            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell = new TableCell();
            HeaderCell.Text = "Jefe de Compras";
            HeaderCell.ColumnSpan = 3;
            HeaderCell.BackColor = System.Drawing.Color.Green;
            HeaderCell.ForeColor = System.Drawing.Color.White;
            HeaderCell.Font.Bold = true;

            HeaderGridRow.Cells.Add(HeaderCell);
            //gvTitulo.Controls[0].Controls.AddAt(0, HeaderGridRow);
        }
    }

    #region Evento Ajax

    #endregion
}