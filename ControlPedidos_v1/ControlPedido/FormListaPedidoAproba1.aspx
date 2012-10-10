<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FormListaPedidoAproba1.aspx.cs"
    Inherits="FormListaPedidoAproba1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <link href="../Styles/Base.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function VistaSolicitud(id) {

            /*alert(id);*/
            modalConsulta = $('<iframe  src="../Request/VistaSolicitud.aspx?id="' + id + ' frameborder=0 marginheight=0 marginwidth=0 scrolling=no  AllowTransparency />').dialog({
                title: '',
                width: 940,
                height: 600,
                modal: true,
                resizable: false,
                zIndex: 10,
                draggable: false
            }).width(930).height(580);
        }

        function goSolicitudFicha(id) {
            // alert(file);
            height = '600px';
            width = '800px';
            url = "../Request/VistaSolicitud.aspx?id=" + id;
            xpos = (window.screen.width / 2) - (width / 2);
            ypos = (window.screen.height / 2) - (height / 2);
            name = ''

            window.showModalDialog(url, name, 'dialogHeight:' + height + ',dialogWidth:' + width + ',toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,modal=yes,center=yes,top=' + ypos + ',left=' + xpos);
            return false;
        }

        function goHistorialIncidencia(id) {
            // alert(file);
            height = '700';
            width = '800';
            url = "../Incident/HistorialIncidente.aspx?id=" + id;
            xpos = 0; //(window.screen.width / 2) - (width / 2);
            ypos = 0; // (window.screen.height / 2) - (height / 2);
            name = ''

            window.open(url, name, 'width=' + width + ',height=' + height + ',toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,modal=yes,top=' + ypos + ',left=' + xpos);
            return false;
        }
    </script>
    <asp:UpdatePanel ID="upBandeja" runat="server" EnableViewState="true" UpdateMode="Conditional">
        <ContentTemplate>
            <h2>
                <asp:Label ID="lblTitulo" runat="server"></asp:Label>
            </h2>
            <table width="100%">
                <tr>
                    <td>
                        <table width="100%" class="table-border-bottom">
                            <tr>
                                <td>
                                    Área
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlArea" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    Jefe de Área
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlJefeArea" runat="server" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    Tipo de pedido
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTipoPedido" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:HiddenField ID="hidFlujoProceso" runat="server" 
                                         />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Nro. Pedido
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNroPedido" runat="server" Width="100px"></asp:TextBox>
                                </td>
                                <td>
                                    Fecha
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFecha" runat="server" Width="70px"></asp:TextBox>
                                    <act:CalendarExtender ID="txtFecha_CalendarExtender" runat="server" TargetControlID="txtFecha"
                                        PopupButtonID="imbFecha" Enabled="true" Format="dd/MM/yyyy">
                                    </act:CalendarExtender>
                                    <asp:ImageButton ID="imbFecha" runat="server" ImageUrl="~/images/icons/calendar.gif" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="boton" BackColor="#D5D8DF"
                                        OnClick="btnBuscar_Click" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <asp:GridView ID="gvBandeja" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                                CellPadding="4" EmptyDataText="No se encontraron registros." Font-Size="Small"
                                ShowFooter="false" ShowHeaderWhenEmpty="true" SkinID="Principal" 
                                Width="100%" onselectedindexchanged="gvBandeja_SelectedIndexChanged">
                                <HeaderStyle CssClass="GrdHeader" />
                                <AlternatingRowStyle />
                                <Columns>
                                    <asp:BoundField DataField="In60numped" HeaderText="Nro. Pedido" HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="In60fecha" HeaderText="Fecha de Pedido" HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="In60Obser" HeaderText="Asunto" HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NombreResponsable" HeaderText="Responsable" HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="In60Area" HeaderText="Área" HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="In60TipoPedido" HeaderText="Tipo de pedido" HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Estado">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEstado" runat="server" Text='<%# Bind("In60Estado") %>'></asp:Label>
                                            <asp:HiddenField ID="hidEstado" runat="server" Value='<%# Bind("In60Estado") %>' />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Situación">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSituacion" runat="server" Text='<%# Bind("DescIn60Aprobado") %>'></asp:Label>
                                            <asp:HiddenField ID="hidSituacion" runat="server" Value='<%# Bind("In60Aprobado") %>' />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Operaciones" ItemStyle-HorizontalAlign="Center">
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSeguimiento" runat="server" CommandArgument='<%# Eval("In60numped") + "|" + Eval("In60Area") + "|" + Eval("in60FlujoProceso") %>'
                                                CommandName='<%# Eval("In60Area") %>' OnClick="lnkSeguimiento_Click">Seguimiento</asp:LinkButton>
                                                <asp:LinkButton ID="lnkAnularSeguimiento" runat="server" CommandArgument='<%# Eval("In60numped") %>'
                                                CommandName='<%# Eval("In60Area") %>' OnClick="lnkAnularSeguimiento_Click">Anular 
                                            Seguimiento</asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="GrdHeader" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle Font-Size="Small" />
                                <PagerSettings Visible="False" />
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table border="0" width="100%">
                            <tr>
                                <td style="width: 75%">
                                    <b>
                                        <asp:Literal ID="litNumeroRegistros" runat="server"></asp:Literal>
                                    </b>
                                </td>
                                <td align="right">
                                    <table border="0" style="text-align: right">
                                        <tr>
                                            <td align="right">
                                                <b>
                                                    <asp:Literal ID="litPagina" runat="server"></asp:Literal>
                                                </b>
                                            </td>
                                            <td>
                                                <asp:ImageButton runat="server" ID="imgbtnStart" ImageUrl="~/images/icons/icono_inicio_off.jpg"
                                                    onmouseout="cambia(this,'../images/icons/icono_inicio_off.jpg');" onmouseover="cambia(this,'../images/icons/icono_inicio_on.jpg');"
                                                    ToolTip="ir a la página inicial" />
                                            </td>
                                            <td>
                                                <asp:ImageButton runat="server" ID="imgbtnNext" ImageUrl="~/images/icons/icono_siguiente_off.jpg"
                                                    onmouseout="cambia(this,'../images/icons/icono_siguiente_off.jpg');" onmouseover="cambia(this,'../images/icons/icono_siguiente_on.jpg');"
                                                    ToolTip="ir a la página siguiente" />
                                            </td>
                                            <td>
                                                <asp:ImageButton runat="server" ID="imgbtnBack" ImageUrl="~/images/icons/icono_anterior_off.jpg"
                                                    onmouseout="cambia(this,'../images/icons/icono_anterior_off.jpg');" onmouseover="cambia(this,'../images/icons/icono_anterior_on.jpg');"
                                                    ToolTip="ir a la página anterior" />
                                            </td>
                                            <td>
                                                <asp:ImageButton runat="server" ID="imgbtnEnd" ImageUrl="~/images/icons/icono_final_off.jpg"
                                                    onmouseout="cambia(this,'../images/icons/icono_final_off.jpg');" onmouseover="cambia(this,'../images/icons/icono_final_on.jpg');"
                                                    ToolTip="ir a la página final" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
