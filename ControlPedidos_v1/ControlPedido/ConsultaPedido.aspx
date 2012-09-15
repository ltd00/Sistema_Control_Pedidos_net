<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ConsultaPedido.aspx.cs"
    Inherits="ConsultaPedido" %>

<%@ Register TagPrefix="APNSoft" Namespace="APNSoft.WebControls" Assembly="APNSoftControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <link href="../Styles/Base.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Grid.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/ScrollableGridViewPlugin_ASP.NetAJAXmin.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $('#<%=gvBandeja.ClientID %>').Scrollable({
                ScrollHeight: 300,
                IsInUpdatePanel: true
            });
        });

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
                                    Año
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlAnio" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    Mes
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlmes" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    Area
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlarea" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    Estado de Flujo Pedido
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlflujopedido" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    Tipo de Pedido
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTipoPedido" runat="server">
                                    </asp:DropDownList>
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
                        <asp:UpdatePanel ID="up" runat="server">
                            <ContentTemplate>
                                
                                <asp:GridView ID="gvBandeja" SkinID="Principal" runat="server" AutoGenerateColumns="False"
                                    BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                    Font-Size="X-Small" Width="100%" EmptyDataText="No se encontraron registros."
                                    ShowHeaderWhenEmpty="True" OnRowDataBound="gvBandeja_RowDataBound" OnRowCreated="gvBandeja_RowCreated">
                                    <Columns>
                                        <asp:BoundField DataField="In60numped" HeaderText="Nro. Pedido" HeaderStyle-CssClass="GrdHeader">
                                            <HeaderStyle CssClass="GrdHeader" Width="42px" />
                                            <ItemStyle Width="42px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Código">
                                            <EditItemTemplate>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblIn60codart" runat="server" Text='<%# Bind("In60codart") %>'></asp:Label>
                                                <asp:HiddenField ID="hidIn60Aprobado" runat="server" Value='<%# Bind("In60Aprobado") %>' />
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="GrdHeader" Width="54px" />
                                            <ItemStyle Width="54px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="In60desart" HeaderText="Descripción" HeaderStyle-CssClass="GrdHeader">
                                            <HeaderStyle CssClass="GrdHeader" Width="188px" />
                                            <ItemStyle Width="188px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="In60NroParte" HeaderText="Nro. Parte" HeaderStyle-CssClass="GrdHeader">
                                            <HeaderStyle CssClass="GrdHeader" Width="70px" />
                                            <ItemStyle Width="70px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="In60unidad" HeaderText="U. Medida" HeaderStyle-CssClass="GrdHeader">
                                            <HeaderStyle CssClass="GrdHeader" Width="44px" />
                                            <ItemStyle Width="44px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="In60cantidad" HeaderText="Cantidad" HeaderStyle-CssClass="GrdHeader">
                                            <HeaderStyle CssClass="GrdHeader" Width="50px" />
                                            <ItemStyle Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="In60Equipo" HeaderText="Pedido" HeaderStyle-CssClass="GrdHeader">
                                            <HeaderStyle CssClass="GrdHeader" Width="41px" />
                                            <ItemStyle Width="41px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="In60FechaEstado1" HeaderText="F. Aproba" HeaderStyle-CssClass="GrdHeader">
                                            <HeaderStyle CssClass="GrdHeader" Width="43px" />
                                            <ItemStyle Width="43px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DesIn60Estado1" HeaderText="Est. Aproba" HeaderStyle-CssClass="GrdHeader">
                                            <HeaderStyle CssClass="GrdHeader" Width="71px" />
                                            <ItemStyle Width="71px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="In60FechaEstado2" HeaderText="F. Aproba" HeaderStyle-CssClass="GrdHeader">
                                            <HeaderStyle CssClass="GrdHeader" Width="43px" />
                                            <ItemStyle Width="43px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DesIn60Estado2" HeaderText="Est. Aproba" HeaderStyle-CssClass="GrdHeader">
                                            <HeaderStyle CssClass="GrdHeader" Width="63px" />
                                            <ItemStyle Width="63px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="In60CantidadNueva2" HeaderText="N. Cantidad" HeaderStyle-CssClass="GrdHeader">
                                            <HeaderStyle CssClass="GrdHeader" Width="50px" />
                                            <ItemStyle Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="In60FechaEstado3" HeaderText="F. Aproba" HeaderStyle-CssClass="GrdHeader">
                                            <HeaderStyle CssClass="GrdHeader" Width="43px" />
                                            <ItemStyle Width="43px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DesIn60Estado3" HeaderText="Est. Aproba" HeaderStyle-CssClass="GrdHeader">
                                            <HeaderStyle CssClass="GrdHeader" Width="63px" />
                                            <ItemStyle Width="63px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="In60CantidadNueva3" HeaderText="N. Cantidad" HeaderStyle-CssClass="GrdHeader">
                                            <HeaderStyle CssClass="GrdHeader" Width="50px" />
                                            <ItemStyle Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="In60FechaEstado4" HeaderText="F. Aproba" HeaderStyle-CssClass="GrdHeader">
                                            <HeaderStyle CssClass="GrdHeader" Width="43px" />
                                            <ItemStyle Width="43px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DesIn60Estado4" HeaderText="Est. Aproba" HeaderStyle-CssClass="GrdHeader">
                                            <HeaderStyle CssClass="GrdHeader" Width="63px" />
                                            <ItemStyle Width="63px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="In60CantidadNueva4" HeaderText="N. Cantidad" HeaderStyle-CssClass="GrdHeader">
                                            <HeaderStyle CssClass="GrdHeader" Width="50px" />
                                            <ItemStyle Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="In60FechaEstado5" HeaderText="F. Aproba" HeaderStyle-CssClass="GrdHeader">
                                            <HeaderStyle CssClass="GrdHeader" Width="43px" />
                                            <ItemStyle Width="43px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DesIn60Estado5" HeaderText="Est. Aproba" HeaderStyle-CssClass="GrdHeader">
                                            <HeaderStyle CssClass="GrdHeader" Width="43px" />
                                            <ItemStyle Width="43px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="In60CantidadNueva5" HeaderText="N. Cantidad" HeaderStyle-CssClass="GrdHeader">
                                            <HeaderStyle CssClass="GrdHeader" Width="50px" />
                                            <ItemStyle Width="50px" />
                                        </asp:BoundField>
                                    </Columns>
                                    <HeaderStyle Font-Size="Small" />
                                    <PagerSettings Visible="False" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
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
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
