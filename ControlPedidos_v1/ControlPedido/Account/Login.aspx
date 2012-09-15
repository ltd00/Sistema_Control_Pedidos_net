<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=System.Web.Configuration.WebConfigurationManager.AppSettings["title"]%>
    </title>
    <link href="../Styles/Base.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/sd.css" rel="stylesheet" type="text/css" />
</head>
<body oncontextmenu="return false" style="vertical-align: baseline" onload="document.getElementById('txtUser').focus();">
    <form id="Form1" method="post" runat="server">
    <div align="center">
        <table id="principal" style="height: 100%; width: 100%; vertical-align: middle" bgcolor="#ffffff"
            cellspacing="30">
            <tr>
                <td valign="middle" align="center">
                    <table style="width: 750px; height: 450px; vertical-align: middle" align="center"
                        cellspacing="0" cellpadding="0" border="0" class="GrdLoginDetalle">
                        <tr>
                            <td class="TituloPopup" colspan="2" style="width: 100%">
                                <h3>
                                    SISTEMA DE CONTROL DE PEDIDOS</h3>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="width: 100%" class="GrdLoginLine">
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 450px; background-image: url('../images/Help-desk-6.jpg');
                                background-repeat: no-repeat;" valign="bottom" align="right">
                            </td>
                            <td style="width: 100%; height: 450px;" valign="middle" align="right">
                                <table width="100%">
                                    <tr>
                                        <td align="center">
                                            <br />
                                            <br />
                                            <h3>
                                                Control de Pedidos v1.0</h3>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <table id="Table2" style="width: 400px; height: 96px;" border="0">
                                    <tr>
                                        <td align="left" style="height: 33px" colspan="2">
                                            Introduzca su contraseña respectiva y luego haga click en ingresar
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Usuario
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtUser" runat="server" Width="140px" ValidationGroup="logeo" CssClass="text"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUser"
                                                ErrorMessage="Ingrese cuenta de usuario" ForeColor="Red" ValidationGroup="logeo">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Password
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Width="140px" ValidationGroup="logeo"
                                                CssClass="text"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPass"
                                                ErrorMessage="Ingrese clave de usuario" ForeColor="Red" ValidationGroup="logeo">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btnLogin" runat="server" CssClass="boton" OnClick="btnLogin_Click"
                                                Text="Login" ValidationGroup="logeo" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            &nbsp;</td>
                                        <td align="left">
                                            <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="2">
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="pnlAcceso" runat="server" Visible="false">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" colspan="2">
                                                                        Seleccione su perfil y período de ejercicio
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        <asp:Label ID="lblPerfil" runat="server" Text="Perfil"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:DropDownList ID="ddlPerfil" runat="server">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        Periodo
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:DropDownList ID="ddlPeriodo" runat="server">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        Mes
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:DropDownList ID="ddlMes" runat="server">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        &nbsp;</td>
                                                                    <td align="left">
                                                                        <asp:ImageButton ID="btnIngresar" runat="server" 
                                                                            ImageUrl="~/images/buttons/imgIngresar.gif" OnClick="btnIngresar_Click" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    </table>
                            </td>
                        </tr>
                        <tr style="height: 10px">
                            <td colspan="2" style="width: 100%; border-top-style: none; border-right-style: none;
                                border-left-style: none; border-bottom-style: none" valign="middle" align="center">
                                Minera Colquisiri&nbsp; &copy; 2012
                            </td>
                        </tr>
                        <tr style="height: 10px">
                            <td colspan="2" style="width: 100%; border-top-style: none; border-right-style: none;
                                border-left-style: none; border-bottom-style: none" valign="middle" align="center">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
