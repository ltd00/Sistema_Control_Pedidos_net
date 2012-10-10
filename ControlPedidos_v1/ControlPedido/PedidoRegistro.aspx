<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PedidoRegistro.aspx.cs"
    Inherits="PedidoRegistro" %>

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
                registro de pedidos
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
                                    <asp:Label ID="lblEstado" runat="server"></asp:Label>
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
                            </tr>
                            <tr>
                                <td>
                                    Asunto
                                </td>
                                <td colspan="5">
                                    <asp:TextBox ID="txtAsunto" MaxLength="80" runat="server" Width="90%"></asp:TextBox>
                                    &nbsp; &nbsp;&nbsp;
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
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    &nbsp;
                                    <asp:HiddenField ID="hidNumeroPedido" runat="server" />
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:HiddenField ID="hidArea" runat="server" />
                                </td>
                                <td colspan="2" valign="top">
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="btnGrabar" runat="server" CssClass="boton" OnClick="btnGrabar_Click"
                                        Text="Aceptar" Width="100px" />
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
                        <asp:Button ID="btnAgregar" runat="server" CssClass="boton" Text="Agregar Item" OnClick="btnAgregar_Click"
                            Width="100px" />
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <asp:GridView ID="gvBandeja" SkinID="Principal" runat="server" AutoGenerateColumns="False"
                                BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                                CellPadding="4" Font-Size="Small" Width="100%" AllowPaging="True" EmptyDataText="No se encontraron registros."
                                ShowHeaderWhenEmpty="True" OnRowDataBound="gvBandeja_RowDataBound" OnSelectedIndexChanged="gvBandeja_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField HeaderText="Item">
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblItem" runat="server" Text='<%# Bind("In60Item") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cod. Artículo">
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblIn60codart" runat="server" Text='<%# Bind("In60codart") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Descripción de Artículo">
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtIn60desart" runat="server" TextMode="MultiLine" Text='<%# Bind("In60desart") %>'></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unidad Medida">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtUniMed" runat="server" Width="100%" BorderStyle="None" Text='<%# Eval("In60unidad") %>'></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cantidad">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCantidad" runat="server" Width="100%" BorderStyle="None" Text='<%# Eval("In60cantidad") %>'
                                                OnKeyPress="return solonumerosypunto(event);"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nro. Lote">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNroLote" runat="server" Width="100%" BorderStyle="None" Text='<%# Eval("In60NroParte") %>'></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Equipo">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imbBuscarEquipo" runat="server" ImageUrl="~/images/icons/buscar.gif"
                                                CommandArgument='<%# Eval("In60Item") %>' OnClick="imbBuscarEquipo_Click" Style="height: 15px" />
                                            &nbsp;<asp:Label ID="lblEquipo" runat="server" Text='<%# Eval("ccmc03des") %>'></asp:Label>
                                            <asp:HiddenField ID="hidIdEquipo" runat="server" Value='<%# Eval("In60Equipo") %>' />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Prioridad">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlPrioridad" runat="server" DataTextField="Descripcion" DataValueField="Codigo">
                                                <asp:ListItem>Alta</asp:ListItem>
                                                <asp:ListItem>Medio</asp:ListItem>
                                                <asp:ListItem>Baja</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Observación">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtObservacion" runat="server" TextMode="MultiLine" Width="150px"
                                                BorderStyle="None" Text='<%# Eval("In60Observacion") %>'></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="GrdHeader" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Operaciones" ItemStyle-HorizontalAlign="Center">
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <div>
                                                <asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("In60Item") %>'
                                                    CommandName='<%# Eval("In60codart") %>' OnClick="lnkEliminar_Click">Eliminar Item</asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
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
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button ID="btnGuardarDetalle" runat="server" CssClass="boton" OnClick="btnGuardarDetalle_Click"
                                        Text="Grabar Pedido" Width="120px" />
                                    &nbsp;<asp:Button ID="btnRegresar" runat="server" CssClass="boton" OnClick="btnRegresar_Click"
                                        Text="Regresar a Listado" Width="120px" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button runat="server" ID="btnArticulo" Style="display: none" />
    <act:ModalPopupExtender ID="mpeArticulo" runat="server" BackgroundCssClass="BackgroundPopup"
        PopupControlID="pnArticulo" DropShadow="False" TargetControlID="btnArticulo" />
    <asp:Panel ID="pnArticulo" runat="server" CssClass="CajaDialogoGeneral" Width="800px"
        Height="500px" Style="display: block">
        <ajax:UpdatePanel ID="upArticulo" runat="server">
            <ContentTemplate>
                <div style="position: absolute; top: 5px; left: 770px;">
                    <asp:ImageButton runat="server" ToolTip="cerrar ventana" ImageUrl="~/images/icons/close.png"
                        ID="imbCerrarAtendido" OnClick="imbCerrarAtendido_Click" />
                </div>
                <table width="100%" class="bg_fondo_tabla">
                    <tr>
                        <td colspan="6" class="TituloPopup" align="center">
                            <asp:Literal ID="Literal1" runat="server" Text="Lista de Artículos"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Almacén
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlAlmacen" runat="server">
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
                        <td style="width: 25%">
                            Código de artículo
                        </td>
                        <td>
                            <asp:TextBox ID="txtCodArti" runat="server"></asp:TextBox>
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
                        <td style="width: 25%">
                            Descripción de artículo
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtDesArti" runat="server" Width="387px"></asp:TextBox>
                            <act:AutoCompleteExtender ID="txtDesArti_AutoCompleteExtender" runat="server" CompletionInterval="200"
                                CompletionSetCount="10" EnableCaching="true" Enabled="true" MinimumPrefixLength="4"
                                ServiceMethod="ObtenerProductos" ServicePath="~/WebService/WebService.asmx" TargetControlID="txtDesArti"
                                UseContextKey="true">
                            </act:AutoCompleteExtender>
                        </td>
                        <td>
                            <asp:Button ID="btnBuscar" runat="server" CssClass="boton" OnClick="btnGuardarAtencion_Click"
                                Text="Buscar" Width="100px" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <div style="height: auto">
                                <asp:GridView ID="gvBandejaArticulo" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                                    CellPadding="4" EmptyDataText="No se encontraron registros." Font-Size="Small"
                                    ShowFooter="false" ShowHeaderWhenEmpty="true" Width="100%" OnPageIndexChanging="gvBandejaArticulo_PageIndexChanging"
                                    OnRowDataBound="gvBandejaArticulo_RowDataBound">
                                    <HeaderStyle CssClass="GrdHeader" />
                                    <AlternatingRowStyle CssClass="GrdAlternativeItem" />
                                    <Columns>
                                        <asp:BoundField DataField="IN04CODALM" HeaderStyle-CssClass="GrdHeader" HeaderText="Almacén">
                                            <HeaderStyle CssClass="GrdHeader" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IN01KEY" HeaderStyle-CssClass="GrdHeader" HeaderText="Código de artículo">
                                            <HeaderStyle CssClass="GrdHeader" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IN01DESLAR" HeaderStyle-CssClass="GrdHeader" HeaderText="Descripción">
                                            <HeaderStyle CssClass="GrdHeader" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IN01UNIMED" HeaderStyle-CssClass="GrdHeader" HeaderText="Unidad Medida">
                                            <HeaderStyle CssClass="GrdHeader" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IN04STOCK" HeaderStyle-CssClass="GrdHeader" HeaderText="Stock">
                                            <HeaderStyle CssClass="GrdHeader" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Operaciones" ItemStyle-HorizontalAlign="Center">
                                            <EditItemTemplate>
                                            </EditItemTemplate>
                                            <HeaderStyle CssClass="GrdHeader" />
                                            <ItemTemplate>
                                                <div>
                                                    <asp:LinkButton ID="lnkSeleccione" runat="server" CommandArgument='<%# Eval("IN01KEY") %>'
                                                        CommandName='<%# Eval("IN01DESLAR") %>' OnClick="lnkSeleccione_Click">Seleccione</asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle Font-Size="Small" />
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25%">
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
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="6">
                            <asp:Button ID="btnCancelarAtencion" runat="server" CssClass="boton" Text="Cerrar"
                                OnClick="btnCancelarAtencion_Click" Width="100px" />
                        </td>
                    </tr>
                    <tr>
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
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </ajax:UpdatePanel>
    </asp:Panel>
    <asp:Button runat="server" ID="btnEquipo" Style="display: none" />
    <act:ModalPopupExtender ID="mpeEquipo" runat="server" BackgroundCssClass="BackgroundPopup"
        PopupControlID="pnEquipo" DropShadow="False" TargetControlID="btnEquipo" />
    <asp:Panel ID="pnEquipo" runat="server" CssClass="CajaDialogoGeneral" Width="600px"
        Height="300px" Style="display: block">
        <ajax:UpdatePanel ID="upEquipo" runat="server">
            <ContentTemplate>
                <div style="position: absolute; top: 5px; left: 570px;">
                    <asp:ImageButton runat="server" ToolTip="cerrar ventana" ImageUrl="~/images/icons/close.png"
                        ID="imbCerrarEquipo" OnClick="imbCerrarEquipo_Click" />
                </div>
                <table width="100%" class="bg_fondo_tabla">
                    <tr>
                        <td colspan="6" class="TituloPopup" align="center">
                            <asp:Literal ID="Literal2" runat="server" Text="Lista de Equipos"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25%">
                            Descripción de equipo
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtDescripEquipo" runat="server" Width="387px"></asp:TextBox>
                            <asp:HiddenField ID="hidItem" runat="server" />
                        </td>
                        <td>
                            <asp:Button ID="btnBuscarEquipo" runat="server" CssClass="boton" Text="Buscar" Width="100px"
                                OnClick="btnBuscarEquipo_Click" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <div style="height: auto">
                                <asp:GridView ID="gvEquipo" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                                    CellPadding="4" EmptyDataText="No se encontraron registros." Font-Size="Small"
                                    ShowFooter="false" ShowHeaderWhenEmpty="true" Width="100%" OnPageIndexChanging="gvEquipo_PageIndexChanging">
                                    <HeaderStyle CssClass="GrdHeader" />
                                    <AlternatingRowStyle CssClass="GrdAlternativeItem" />
                                    <Columns>
                                        <asp:BoundField DataField="ccmc03CodBarra" HeaderStyle-CssClass="GrdHeader" HeaderText="Código de equipo">
                                            <HeaderStyle CssClass="GrdHeader" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ccmc03des" HeaderStyle-CssClass="GrdHeader" HeaderText="Descripción">
                                            <HeaderStyle CssClass="GrdHeader" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Operaciones" ItemStyle-HorizontalAlign="Center">
                                            <EditItemTemplate>
                                            </EditItemTemplate>
                                            <HeaderStyle CssClass="GrdHeader" />
                                            <ItemTemplate>
                                                <div>
                                                    <asp:LinkButton ID="lnkSeleccioneEquipo" runat="server" CommandArgument='<%# Eval("ccmc03CodBarra") %>'
                                                        CommandName='<%# Eval("ccmc03des") %>' OnClick="lnkSeleccioneEquipo_Click">Seleccione</asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle Font-Size="Small" />
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25%">
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
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="6">
                            <asp:Button ID="btnCancelarEquipo" runat="server" CssClass="boton" Text="Cerrar"
                                Width="100px" OnClick="btnCancelarEquipo_Click" />
                        </td>
                    </tr>
                    <tr>
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
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </ajax:UpdatePanel>
    </asp:Panel>
</asp:Content>
