<%@ Page Title="" Language="C#" MasterPageFile="~/Noticias.Master" AutoEventWireup="true" CodeBehind="Adm_Usuarios.aspx.cs" Inherits="WebAppIntranetSkytex.Adm_Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3><strong>Administración de Usuarios</strong></h3>
            </div>
            <div class="panel-body">
                <br />
                <div class="row">
                    <div class="col-md-2"></div>
                    <div class="col-md-1">
                        <h5>Usuarios:</h5>
                    </div>
                    <div class="col-md-6">
                        <asp:DropDownList ID="ddlUsuarios" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlUsuarios_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
                <br /><br />
            <div runat="server" id="divBody" visible="false">
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-1" style="border:2px solid;">
                        <h5>Usuario:</h5>
                    </div>
                    <div class="col-md-3" style="border:2px solid;">
                        <h5>Nombre:</h5>
                    </div>
                    <div class="col-md-2" style="border:2px solid;">
                        <h5>Rol:</h5>
                    </div>
                    <div class="col-md-2" style="border:2px solid;"> 
                        <h5>Aplicaciones</h5>
                    </div>
                    <div class="col-md-2" style="border:2px solid;"> 
                        <h5>Acciones</h5>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-1" >
                        <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:RadioButtonList ID="ListaRoles" runat="server" Visible="false">
                            <asp:ListItem Value="0" Text="Usuario" ></asp:ListItem>
                            <asp:ListItem Value="1" Text="Administrador" ></asp:ListItem>
                            <asp:ListItem Value="2" Text="SuperUsuario" ></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div class="col-md-2"> 
                        <asp:CheckBoxList ID="ListaApps" runat="server"></asp:CheckBoxList>
                    </div>
                    <div class="col-md-2 text-center">
                        <br />
                        <asp:LinkButton ID="btnBloquear" runat="server" OnClientClick="return validar()" OnClick="btnBloquear_Click">
                            <span class="glyphicon glyphicon-ban-circle" aria-hidden="true" style="font-size:x-large;"></span>
                        </asp:LinkButton><br />
                        <asp:Label ID="lblBloqueo" runat="server" Text="Bloquear Usuario"></asp:Label>
                    </div>
                </div>
                <br />
            </div>
                <div class="text-center">
                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-success" OnClick="btnActualizar_Click" Enabled="false"/>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function validar() {
            var bloqueo = $('#<%=lblBloqueo.ClientID%>').text();
            if (bloqueo == "Bloquear Usuario") {
                return confirm('¿Desea bloquear este usuario? \n Ya no tendra acceso a la intranet');
            } else {
                return confirm('¿Desea desbloquear este usuario?');
            }
        }
    </script>
</asp:Content>
