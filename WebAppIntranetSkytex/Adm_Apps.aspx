<%@ Page Title="" Language="C#" MasterPageFile="~/Noticias.Master" AutoEventWireup="true" CodeBehind="Adm_Apps.aspx.cs" Inherits="WebAppIntranetSkytex.Adm_Apps" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3><strong>Administración de Aplicaciones</strong></h3>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-6">
                        <asp:DropDownList ID="ListaApps" runat="server" CssClass="form-control" 
                        OnTextChanged="ListaApps_TextChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
                <br />
                <div>
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-1" style="border:2px double">
                            <h5><strong>Folio</strong></h5>
                        </div>
                        <div class="col-md-3"style="border:2px double">
                            <h5><strong>Nombre</strong></h5>
                        </div>
                        <div class="col-md-4"style="border:2px double">
                            <h5><strong>Url</strong></h5>
                        </div>
                        <div class="col-md-2"style="border:2px double">
                            <h5><strong>Restricción</strong></h5>
                        </div>
                    </div>
                    <br />
                    <div class="row" id="DivForm" runat="server" visible="false">
                        <div class="col-md-1"></div>
                        <div class="col-md-1">
                            <h5><strong><asp:Label ID="lblFolio" runat="server" Text="0"></asp:Label></strong></h5>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtUrl" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                                <asp:DropDownList ID="ddlTipoDeApp" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="2" Text="Seleccionar" Selected disabled></asp:ListItem>
                                    <asp:ListItem Value="0" Text="Publico"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Restringido"></asp:ListItem>
                                </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <div id="DivBotonesGuardar" runat="server" visible="false" class="text-center">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnGuardar_Click" OnClientClick="return validar()"/>
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click"/>
                    </div>
                    <div id="DivBotonesActualizar" runat="server" visible="false" class="text-center">
                        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-success" OnClick="btnActualizar_Click" OnClientClick="return validar()" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Desea eliminar esta aplicación?')"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function validar() {
            if ($('#<%=txtNombre.ClientID%>').val() === '') {
                alert('Completar todos los campos');
                return false;
            } else if ($('#<%=txtUrl.ClientID%>').val() === '') {
                alert('Completar todos los campos');
                return false;
            } else if ($('#<%=ddlTipoDeApp.ClientID%>').val() === null) {
                alert('Completar todos los campos');
                return false;
            } else {
                return true;
            }
        }
    </script>
</asp:Content>
