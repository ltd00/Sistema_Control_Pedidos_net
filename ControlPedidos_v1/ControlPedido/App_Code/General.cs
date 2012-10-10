using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using System.Net.Mail;

using ML.CAU.UIC;
using MC.ControlPedido.Logica;
using MC.ControlPedido.Model;

using ML.Seguridad.Entidades;
using ML.Seguridad.Logica;

using ML.Comun.Entidades;
using ML.Comun.Logica;

/// <summary>
/// Summary description for General
/// </summary>
public class General
{
    public General()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// Metodo que permite adjuntar archivos en el servidor
    /// </summary>
    /// <param name="control"></param>
    /// <param name="vstrFileName"></param>
    /// <returns></returns>
    public static string UpLoadFile(System.Web.UI.WebControls.FileUpload control, string vstrFileName)
    {
        string nombreFichero = string.Empty;
        string strNombreArchivo = string.Empty;
        try
        {
            if (control.HasFile)
            {
                HttpPostedFile miFichero = control.PostedFile;
                nombreFichero = Path.GetFileName(miFichero.FileName);

                strNombreArchivo = vstrFileName;
                string strExtension = Path.GetExtension(nombreFichero);

                strExtension = strExtension.ToLower();
                strNombreArchivo = strNombreArchivo + strExtension;

                if ((strExtension.CompareTo(".doc") == 0) || (strExtension.CompareTo(".docx") == 0) || (strExtension.CompareTo(".pdf") == 0) ||
                    (strExtension.CompareTo(".jpg") == 0) || (strExtension.CompareTo(".gif") == 0) || (strExtension.CompareTo(".bmp") == 0))
                {


                    //int intFileSize = miFichero.ContentLength;
                    //int intFileSizePermitido = int.Parse(System.Web.Configuration.WebConfigurationManager.AppSettings["tamanoArchivoSubir"]);

                    //if (intFileSize > intFileSizePermitido)
                    //{
                    //    throw new Exception("El tamaño de archivo a subir supera el tamaño permitido. El tamaño permitido es " + intFileSize.ToString().Trim() + "MB");
                    //}

                    String carpeta = System.Web.Configuration.WebConfigurationManager.AppSettings["carpetaArchivoLocal"];

                    //Se arma el nombre de archivo y se guarda en la ruta
                    string strFileCompleto = carpeta + strNombreArchivo;
                    miFichero.SaveAs(strFileCompleto);
                }
                else
                {
                    throw new Exception("Tipo de archivo no es válido. Adjunte sólo archivos de tipo (.doc, .docx, .pdf, .jpg, .gif, .bmp)");
                }
            }

            return strNombreArchivo;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Asignar titulo
    /// </summary>
    /// <param name="vFlujo"></param>
    /// <returns></returns>
    public static string AsignarTitulo(string vFlujo)
    {
        string titulo = string.Empty;

        if (vFlujo.CompareTo(UIConstante.FlujoProceso.JefeArea.ToString()) == 0)
        {
            titulo = "Aprobación por Jefe de Area";
        }
        else if (vFlujo.CompareTo(UIConstante.FlujoProceso.JefeAlmacen.ToString()) == 0)
        {
            titulo = "Aprobación por Jefe de Almacén";
        }
        else if (vFlujo.CompareTo(UIConstante.FlujoProceso.JefeSuperintendente.ToString()) == 0)
        {
            titulo = "Aprobación por Superintendente";
        }
        else if (vFlujo.CompareTo(UIConstante.FlujoProceso.JefeOperacion.ToString()) == 0)
        {
            titulo = "Aprobación por Gerente de Operaciones";
        }
        else if (vFlujo.CompareTo(UIConstante.FlujoProceso.JefeCompras.ToString()) == 0)
        {
            titulo = "Aprobación por Jefe de Compras";
        }

        return titulo;
    }

    ///Hace falta poner using System.Text al principio para esta
    public static int Asc(string s)
    {
        return System.Text.Encoding.ASCII.GetBytes(s)[0];
    }

    public static char Chr(int c)
    {
        return Convert.ToChar(c);
    }

    /// <summary>
    /// Metodo para descriptar la clave de usuario
    /// </summary>
    /// <param name="clave"></param>
    /// <returns></returns>
    public static string DesencriptaClave(string vclave)
    {
        try
        {
            string clave = vclave.Trim();
            string retorno = clave.Substring(clave.Length - 1, 1);
            int letra;

            for (int i = clave.Length - 1; i >= 1; i--)
            {
                letra = Asc(clave.Substring(i, 1)) - Asc(retorno.Substring(0, 1));
                char c = Chr(letra);
                string display = string.Empty;

                if (char.IsWhiteSpace(c))
                {
                    switch (c)
                    {
                        case '\t':
                            display = "\\t";
                            break;

                        case '\n':
                            display = "\\n";
                            break;

                        case '\r':
                            display = "\\r";
                            break;

                        case '\v':
                            display = "\\v";
                            break;

                        case '\f':
                            display = "\\f";
                            break;
                    }

                    retorno = display + retorno;
                }
                else {
                    retorno = Chr(letra) + retorno;
                }                
            }

            return retorno;
        }
        catch (Exception)
        {

            throw;
        }
    }
}