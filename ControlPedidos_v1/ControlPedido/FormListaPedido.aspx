<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FormListaPedido.aspx.cs"
    Inherits="FormListaPedido" %>

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
                                    <asp:DropDownList ID="ddlArea" runat="server" 
                                        onselectedindexchanged="ddlArea_SelectedIndexChanged">
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
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:CheckBox ID="chkver" runat="server" Text="Ver todos los pedidos del Año" />
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
                                    Tipo</td>
                                <td>
                                    <asp:DropDownList ID="ddlTipoPedido" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    Estado Aprobacion</td>
                                <td>
                                    <asp:DropDownList ID="ddlEstadoAprob" runat="server">
                                    </asp:DropDownList>
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
                        <asp:Button ID="btnNuevo" runat="server" CssClass="boton" Text="Nuevo" OnClick="btnNuevo_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <asp:GridView ID="gvBandeja" SkinID="Principal" runat="server" AutoGenerateColumns="False"
                                BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                                CellPadding="4" Font-Size="Small" Width="100%" EmptyDataText="No se encontraron registros."
                                ShowHeaderWhenEmpty="True" AllowPaging="True" 
                                OnRowDataBound="gvBandeja_RowDataBound" 
                                onselectedindexchanged="gvBandeja_SelectedIndexChanged">
                                <HeaderStyle CssClass="GrdHeader" />
                                <AlternatingRowStyle CssClass="GrdAlternativeItem" />
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
                                    <asp:BoundField DataField="In60codres" HeaderText="Nombre Responsable" 
                                        HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="In60Area" HeaderText="Área" 
                                        HeaderStyle-CssClass="GrdHeader">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="In60TipoPedido" HeaderText="Tipo de pedido" 
                                        HeaderStyle-CssClass="GrdHeader">
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
                                            <asp:Label ID="lblSituacion" runat="server" Text='<%# Bind("In60Aprobado") %>'></asp:Label>
                                            <asp:HiddenField ID="hidSituacion" runat="server" Value='<%# Bind("In60Aprobado") %>' />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Operaciones" ItemStyle-HorizontalAlign="Center">
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                        <HeaderStyle CssClass="GrdHeader" />
                                        <ItemTemplate>
                                            <div>
                                                &nbsp;<asp:LinkButton ID="lnkEditar" runat="server" CommandArgument='<%# Eval("In60numped") %>'
                                                    CommandName='<%# Eval("In60Area") %>' OnClick="lnkEditar_Click">Editar</asp:LinkButton>

                                                &nbsp;<asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("In60numped") %>'
                                                    CommandName='<%# Eval("In60Area") %>' OnClick="lnkEliminar_Click">Eliminar</asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
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
