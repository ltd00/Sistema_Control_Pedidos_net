using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MC.ControlPedido.Logica;
using MC.ControlPedido.Model;
using System.Data;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod(true)][System.Web.Script.Services.ScriptMethod()]
    public string[] ObtenerProductos(string prefixText, int count)
    {
        try
        {
            UIAuditoria auditoria = new UIAuditoria();

            in01arti oin01arti = new in01arti();
            oin01arti.IN01CODEMP = auditoria.CodigoEmpresa;
            oin01arti.IN01AA = auditoria.Periodo;
            oin01arti.IN01KEY = string.Empty;
            oin01arti.IN01DESLAR = prefixText;

            DataTable dtData;
            dtData = new ArticuloBLL().ListarArticulo(oin01arti, auditoria.CodigoEmpresa, auditoria.Mes);

            List<string> lista = new List<string>();

            for (int i = 0; i < dtData.Rows.Count; i++)
            {
                lista.Add(dtData.Rows[i]["IN01DESLAR"].ToString());
            }

            return lista.ToArray();
        }
        catch (Exception)
        {

            throw;
        }
    }

}
