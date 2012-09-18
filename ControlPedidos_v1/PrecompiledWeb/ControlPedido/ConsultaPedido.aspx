<%@ page language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="ConsultaPedido, App_Web_xrmuxvno" %>

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
                Bandeja de Pedidos
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
                                    Tipo
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
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="overflow: scroll; height: 100%; width: 100%">
                            <asp:GridView ID="gvBandeja" SkinID="Principal" runat="server" AutoGenerateColumns="False"
                                BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                Font-Size="X-Small" Width="100%" EmptyDataText="No se encontraron registros."
                                ShowHeaderWhenEmpty="True" AllowPaging="True" OnRowCreated="gvBandeja_RowCreated"
                                OnRowDataBound="gvBandeja_RowDataBound">
                                <HeaderStyle CssClass="GrdHeader" />
                                <AlternatingRowStyle />
                                <Columns>
                                    <asp:BoundField DataField="In60numped" HeaderText="Nro. Pedido" HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Código">
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblIn60codart" runat="server" Text='<%# Bind("In60codart") %>'></asp:Label>
                                            <asp:HiddenField ID="hidIn60Aprobado" runat="server" Value='<%# Bind("In60Aprobado") %>' />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="In60desart" HeaderText="Descripción" HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="In60NroParte" HeaderText="Nro. Parte" HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="In60unidad" HeaderText="U. Medida" HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="In60cantidad" HeaderText="Cantidad" HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="In60Equipo" HeaderText="Pedido" HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="In60fecha" HeaderText="Fecha" HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="In60FechaEstado1" HeaderText="F. Aproba" HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DesIn60Estado1" HeaderText="Est. Aproba" HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="In60FechaEstado2" HeaderText="F. Aproba" HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DesIn60Estado2" HeaderText="Est. Aproba" HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="In60CantidadNueva2" HeaderText="N. Cantidad" HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="In60FechaEstado3" HeaderText="F. Aproba" HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DesIn60Estado3" HeaderText="Est. Aproba" HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="In60CantidadNueva3" HeaderText="N. Cantidad" HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="In60FechaEstado4" HeaderText="F. Aproba" HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DesIn60Estado4" HeaderText="Est. Aproba" HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="In60CantidadNueva4" HeaderText="N. Cantidad" HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="In60FechaEstado5" HeaderText="F. Aproba" HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DesIn60Estado5" HeaderText="Est. Aproba" HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="In60CantidadNueva5" HeaderText="N. Cantidad" HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
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
                                                    onmouseout="cambia(this,'images/icons/icono_inicio_off.jpg');" onmouseover="cambia(this,'images/icons/icono_inicio_on.jpg');"
                                                    ToolTip="ir a la página inicial" />
                                            </td>
                                            <td>
                                                <asp:ImageButton runat="server" ID="imgbtnNext" ImageUrl="~/images/icons/icono_siguiente_off.jpg"
                                                    onmouseout="cambia(this,'images/icons/icono_siguiente_off.jpg');" onmouseover="cambia(this,'images/icons/icono_siguiente_on.jpg');"
                                                    ToolTip="ir a la página siguiente" />
                                            </td>
                                            <td>
                                                <asp:ImageButton runat="server" ID="imgbtnBack" ImageUrl="~/images/icons/icono_anterior_off.jpg"
                                                    onmouseout="cambia(this,'images/icons/icono_anterior_off.jpg');" onmouseover="cambia(this,'images/icons/icono_anterior_on.jpg');"
                                                    ToolTip="ir a la página anterior" />
                                            </td>
                                            <td>
                                                <asp:ImageButton runat="server" ID="imgbtnEnd" ImageUrl="~/images/icons/icono_final_off.jpg"
                                                    onmouseout="cambia(this,'images/icons/icono_final_off.jpg');" onmouseover="cambia(this,'images/icons/icono_final_on.jpg');"
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
