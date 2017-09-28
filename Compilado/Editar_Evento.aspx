<%@ Page Title="" Language="C#" MasterPageFile="~/Noticias.Master" AutoEventWireup="true" CodeBehind="Editar_Evento.aspx.cs" Inherits="WebAppIntranetSkytex.Editar_Evento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<div class="container">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h1>Editar Evento</h1>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-1">
                    <h4><strong>Titulo:</strong></h4>
                    <br />
                    <br />
                </div>
                <div class="col-md-6" style="height:100%">
                    <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-1">
                    <h4><strong>Evento:</strong></h4>
                    <br />
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtAnuncio" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="5"></asp:TextBox>
                    <br />
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-2" style="text-align:right;">
                    <h4><strong>Fecha de inicio:</strong></h4>
                    <br />
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="txtFechaIni" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    <br />
                </div>
                <div class="col-md-2" style="text-align:right;">
                    <h4><strong>Fecha de Fin:</strong></h4>
                    <br />
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="txtFechaFin" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    <br />
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-8 text-center">
                    <asp:Button ID="btnAgregar" runat="server" Text="Actualizar" CssClass="btn btn-success btn-lg" OnClientClick="return validar()" OnClick="btnAgregar_Click"/>
                    &nbsp;
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger btn-lg" OnClick="btnCancelar_Click"/>
                </div>
                <div class="col-md-2" style="text-align:right;">
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClientClick="return (confirm('¿Desea eliminar este anuncio? Esta acción no se puede deshacer'))" CssClass="btn btn-danger btn-lg" OnClick="btnEliminar_Click"/>
                </div>
            </div>
            <br />
        </div>
    </div>
</div>
<script type="text/javascript">
    function validar() {
        if ($('#<%=txtTitulo.ClientID%>').val() === '') {
            alert('Completar todos los campos');
            return false;
        } else if ($('#<%=txtAnuncio.ClientID%>').val() === '') {
            alert('Completar todos los campos');
            return false;
        } else if ($('#<%=txtFechaIni.ClientID%>').val() === '') {
            alert('Completar todos los campos');
            return false;
        } else if ($('#<%=txtFechaFin.ClientID%>').val() === '') {
            alert('Completar todos los campos');
            return false;
        } else {
            return true;
        }
}
</script>
</asp:Content>
