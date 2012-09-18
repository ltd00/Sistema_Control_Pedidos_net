using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using System.Web.Mail;
using System.Data;
using System.Collections;
using MC.ControlPedido.Logica;
using MC.ControlPedido.Model;

namespace ML.CAU.UIC
{
    /// <summary>
    /// Clase para heredar
    /// </summary>
    public class UIPage : System.Web.UI.Page
    {

        #region Variables publicas

       public UIAuditoria _auditoria = new UIAuditoria();

        #endregion

        #region Inicio
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent() { }

        private void Page_Init(object sender, System.EventArgs e)
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que llena una grilla con datatable
        /// </summary>
        /// <param name="oGridView"></param>
        /// <param name="data"></param>
        public void BindGridView(GridView gridView, DataTable data)
        {
            gridView.DataSource = data;
            gridView.DataBind();
        }

        /// <summary>
        /// Metodo para llenar un DropdownList
        /// </summary>
        /// <param name="dropDownList"></param>
        /// <param name="data"></param>
        public void Bind(DropDownList dropDownList, DataTable data, string value, string text)
        {
            dropDownList.DataSource = data;
            dropDownList.DataValueField = value;
            dropDownList.DataTextField = text;
            dropDownList.DataBind();
        }

        /// <summary>
        /// Metodo para llenar un DropdownList
        /// </summary>
        /// <param name="dropDownList"></param>
        /// <param name="data"></param>
        public void Bind(DropDownList dropDownList, IList data, string value, string text)
        {
            dropDownList.DataSource = data;
            dropDownList.DataValueField = value;
            dropDownList.DataTextField = text;
            dropDownList.DataBind();
        }

        /// <summary>
        /// Metodo que permite seleccionar el SelectValue en un DropDownList
        /// </summary>
        /// <param name="control"></param>
        /// <param name="value"></param>
        public void BuscarValueDropDownList(DropDownList control, string value)
        {
            if (control.Items.FindByValue(value) != null) control.Items.FindByValue(value).Selected = true;
        }
        #endregion



    }
}
