<%@ page language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="FormPedidoAproba1, App_Web_xrmuxvno" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <link href="../Styles/Base.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function BusquedaEquipo_callDialog() {

            modalEquipo = $('<iframe  src="About.aspx" frameborder=0 marginheight=0 marginwidth=0 scrolling=no  AllowTransparency />').dialog({
                title: '',
                width: 605,
                height: 400,
                modal: true,
                resizable: false,
                zIndex: 10,
                draggable: false
            }).width(600).height(380);

        }

        function BusquedaEquipo_callDialogIn(param) {

            var xtitle;
            xtitle = "Agregar observación";

            //document.getElementById("ctl00_MainContent_hidCodigoSolicitud").Value = param;

            //$("#ctl00_MainContent_hidCodigoSolicitud").val("150");
            $("#ctl00_MainContent_hidCodigoSolicitud").val(param);

            //$("#identificador").attr('value', 'valor para éste input');

            var dlg = $("#dialog").dialog({
                autoOpen: true,
                title: xtitle,
                width: 400,
                height: 220,
                modal: true,
                draggable: true,
                resizable: false,
                zIndex: 10,
                autoResize: true
            });
            dlg.parent().appendTo(jQuery("form:first"));
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
                                <td class="style1">
                                    Nro. Pedido
                                </td>
                                <td class="style1">
                                    <asp:TextBox ID="txtNroPedido" runat="server" Width="100px" Enabled="False"></asp:TextBox>
                                </td>
                                <td class="style1">
                                    Fecha
                                </td>
                                <td class="style1">
                                    <asp:TextBox ID="txtFecha" runat="server" Width="70px"></asp:TextBox>
                                    <act:CalendarExtender ID="txtFecha_CalendarExtender" runat="server" TargetControlID="txtFecha"
                                        PopupButtonID="imbFecha" Enabled="true" Format="dd/MM/yyyy">
                                    </act:CalendarExtender>
                                    <asp:ImageButton ID="imbFecha" runat="server" ImageUrl="~/images/icons/calendar.gif" />
                                </td>
                                <td class="style1">
                                    Estado
                                </td>
                                <td class="style1">
                                    <asp:Label ID="lblEstado" runat="server" Text="Nuevo"></asp:Label>
                                </td>
                                <td class="style1">
                                    &nbsp;
                                </td>
                                <td class="style1">
                                    &nbsp;
                                </td>
                            </tr>
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
                                    <asp:DropDownList ID="ddlJefeArea" runat="server">
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
                                    <asp:HiddenField ID="hidFlujoProceso" runat="server" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Asunto
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtAsunto" runat="server" Width="328px"></asp:TextBox>
                                    &nbsp;
                                    <asp:HiddenField ID="hidNumeroPedido" runat="server" />
                                </td>
                                <td>
                                    Situación</td>
                                <td>
                                    <asp:Label ID="lblSituacion" runat="server"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:HiddenField ID="hidArea" runat="server" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td colspan="2" valign="top">
                                    &nbsp;
                                    <asp:HiddenField ID="hidSituacion" runat="server" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;<asp:Button ID="btnAceptar" runat="server" CssClass="boton" Text="Aceptar"
                                        OnClick="btnAceptar_Click" />
                                    &nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="boton" Text="Ir a la lista de pedidos"
                                        OnClick="btnCancelar_Click" Width="150px" />
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
                                ShowHeaderWhenEmpty="True" SkinID="Principal" Width="100%">
                                <AlternatingRowStyle />
                                <Columns>
                                    <asp:TemplateField HeaderText="Item">
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblItem" runat="server" Text='<%# Bind("In60Item") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="In60codart" HeaderStyle-CssClass="GrdHeader" HeaderText="Cod. Artículo">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="In60desart" HeaderStyle-CssClass="GrdHeader" HeaderText="Descripción de Artículo">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="In60unidad" HeaderStyle-CssClass="GrdHeader" HeaderText="Unidad Medida">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="In60NroParte" HeaderStyle-CssClass="GrdHeader" HeaderText="Nro. Lote">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ccmc03des" HeaderStyle-CssClass="GrdHeader" HeaderText="Equipo">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="In60Prioridad" HeaderStyle-CssClass="GrdHeader" HeaderText="Prioridad">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="In60Observacion" HeaderStyle-CssClass="GrdHeader" HeaderText="Observación">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="In60cantidad" HeaderStyle-CssClass="GrdHeader" HeaderText="Cantidad">
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Estado Actual">
                                        <ItemTemplate>
                                            <ajax:UpdatePanel ID="upEstado" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlEstado" runat="server" Width="80px" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged">
                                                        <asp:ListItem Value="C">Conforme</asp:ListItem>
                                                        <asp:ListItem Value="R">Rechazado</asp:ListItem>
                                                        <asp:ListItem Value="N">Nueva cantidad</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <br />
                                                    <asp:Label ID="lblCantidadNueva" Text="Nueva cantidad" runat="server"></asp:Label>
                                                    <br />
                                                    <asp:TextBox ID="txtCantidadNueva" runat="server" Width="80px" Text='<%# Bind("In60CantidadNueva") %>'
                                                        onkeypress="return solonumerosypunto(event);"></asp:TextBox>
                                                </ContentTemplate>
                                            </ajax:UpdatePanel>
                                            <asp:HiddenField ID="hidEstado" runat="server" Value='<%# Bind("In60Estado") %>' />
                                            <asp:HiddenField ID="hidEstadoActual" runat="server" Value='<%# Bind("In60EstadoActual") %>' />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sustento" ControlStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtSustento" runat="server" Width="100%" MaxLength="100"
                                                TextMode="MultiLine" Text='<%# Bind("In60Observacion") %>'></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:TemplateField>
                                </Columns>
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
