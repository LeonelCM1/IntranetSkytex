<%@ Page Title="" Language="C#" MasterPageFile="~/Noticias.Master" AutoEventWireup="true" CodeBehind="AgregarNoticia.aspx.cs" Inherits="WebAppIntranetSkytex.AgregarNoticia" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-body">
                <h1>Agregar Noticia</h1>
                <br />
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-3" style="text-align:right;">
                        <h4><strong>Titulo:</strong></h4>
                        <br />
                        <br />
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control"></asp:TextBox>
                        <br />
                        <br />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-1" style="text-align:right;">
                        <h4><strong>Resumen:</strong></h4>
                        <br />
                    </div>
                    <div class="col-md-11">
                        <asp:TextBox ID="txtResumen" runat="server" TextMode="MultiLine" CssClass="form-control" MaxLength="10"></asp:TextBox>
                        <br />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <CKEditor:CKEditorControl ID="CKEditor1" BasePath="~/ckeditor" runat="server"></CKEditor:CKEditorControl>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-4" style="text-align:right;">
                        Miniatura: 
                    </div>
                    <div class="col-md-4">
                        <asp:FileUpload ID="Imagen" runat="server" />
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12 text-center">
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-success btn-lg" OnClick="btnAgregar_Click" OnClientClick="return validar()"/>
                        &nbsp;
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger btn-lg" OnClick="btnCancelar_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function validar() {
            var contenido = CKEDITOR.instances['<%=CKEditor1.ClientID%>'].getData();
            if ($('#<%=txtTitulo.ClientID%>').val() === '') {
                alert('Completar todos los campos');
                return false;
            } else if ($('#<%=txtResumen.ClientID%>').val() === '') {
                alert('Completar todos los campos');
                return false;
            } else if (contenido==='') {
                alert('Completar todos los campos');
                return false;
            } else if (document.getElementById('<%= Imagen.ClientID %>').files.length === 0) {
                return confirm('¿Desea agregar la noticia sin miniatura?');
            }else {
                return true;
            }
        }
    </script>
</asp:Content>
