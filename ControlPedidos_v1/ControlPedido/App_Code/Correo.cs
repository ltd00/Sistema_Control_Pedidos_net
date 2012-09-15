using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.Mail;

using ML.CAU.UIC;
using MC.ControlPedido.Logica;
using MC.ControlPedido.Model;

using ML.Seguridad.Entidades;
using ML.Seguridad.Logica;

using ML.Comun.Entidades;
using ML.Comun.Logica;

/// <summary>
/// Summary description for Correo
/// </summary>
public class Correo
{
    private string _from;
    private string _to;
    private string _subject;
    private string _body;
    private string _smtp;

    #region Patron Singleton

    private static Correo _instance;

    /// <summary>
    /// Uso de patrón singleton que asegura exista un solo objeto instanciado
    /// </summary>
    public static Correo Instance
    {
        get
        {

            if (_instance == null) _instance = new Correo();
            return _instance;
        }
    }

    #endregion

    #region Propiedades

    /// <summary>
    /// Correo de quien envia el correo
    /// </summary>
    public string From
    {
        get { return _from; }
        set { _from = value; }
    }

    /// <summary>
    /// Correo destino
    /// </summary>
    public string To
    {
        get { return _to; }
        set { _to = value; }
    }

    /// <summary>
    /// Asunto del correo
    /// </summary>
    public string Subject
    {
        get { return _subject; }
        set { _subject = value; }
    }

    /// <summary>
    /// Mensaje para el correo
    /// </summary>
    public string Body
    {
        get { return _body; }
        set { _body = value; }
    }

    /// <summary>
    /// Servidor SMTP Host para salida del correo
    /// </summary>
    public string Smtp
    {
        get { return _smtp; }
        set { _smtp = value; }
    }
    #endregion

    public Correo()
    {
        //
        // TODO: Add constructor logic here
        //

        _smtp = System.Web.Configuration.WebConfigurationManager.AppSettings["smtpServer"];
        _from = System.Web.Configuration.WebConfigurationManager.AppSettings["correoSaliente"];

    }

    /// <summary>
    /// Metodo para enviar correo electrónico a usuarios finales
    /// </summary>
    public void Enviar()
    {
        try
        {
            if (System.Web.Configuration.WebConfigurationManager.AppSettings["enviarCorreo"].CompareTo("N") == 0) return;

            if (_from.Length == 0) return;
            if (_to.Length == 0) return;
            if (_smtp.Length == 0) return;

            MailMessage email = new MailMessage();

            email.From = new MailAddress(_from);
            email.To.Add(To);
            email.Subject = Subject;
            email.Body = Body;
            email.IsBodyHtml = false;
            email.Priority = System.Net.Mail.MailPriority.Normal;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = _smtp;

            try
            {
                smtp.Send(email);
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    
}