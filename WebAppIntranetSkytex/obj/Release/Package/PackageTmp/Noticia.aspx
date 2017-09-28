<%@ Page Title="" Language="C#" MasterPageFile="~/Noticias.Master" AutoEventWireup="true" CodeBehind="Noticia.aspx.cs" Inherits="WebAppIntranetSkytex.Noticia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="<%=ResolveUrl("~/Content/estilos.css")%>" />
    <div class="container">
        <ol class="breadcrumb">
            <li><a href="Inicio.aspx">Noticias</a></li>
            <li class="active"><%= lblTitulo.Text %></li>
        </ol>
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-1" id="divVacio" runat="server"></div>
                    <div class="col-md-2" id="divImagen" runat="server" style="align-content:center;">
                        <asp:Image ID="Image1" runat="server" CssClass="img-circle img-responsive" style="max-width:100%;"/>
                    </div>
                    <div class="<%=Validar() %>">
                        <asp:Label ID="lblTitulo" runat="server" Font-Size="48px"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-10">
                        <!--<asp:Label ID="lblNoticia" runat="server" ></asp:Label>-->
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="text-center">
                    <% if (Convert.ToInt16(Session["rol"]) == 1 || Convert.ToInt16(Session["rol"]) == 2){ %>
                        <a class="btn btn-info" href="Editar_Noticia.aspx?n=<%=Convert.ToInt32(Request.QueryString["n"])%>" role="button">Editar</a>
                    <%} %>
                </div>
            </div>
        </div>
        <div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4>Comentarios</h4>
                </div>
                <div class="panel-body" runat="server" id="divBody">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-1"></div>
                            <div class="col-md-10">
                                <asp:DataList ID="ListaComentarios" runat="server" Width="100%" OnEditCommand="ListaComentarios_ItemCommand" OnDeleteCommand="ListaComentarios_DeleteCommand" OnCancelCommand="ListaComentarios_CancelCommand">
                                    <ItemTemplate>
                                        <div class="well">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <h5><strong><%# nombreDelUsuario(Eval("user_cve").ToString())%>:</strong></h5>
                                                    <asp:TextBox ID="txtNumFolComent" runat="server" Text='<%# Eval("num_fol").ToString() %>' style="display:none;"></asp:TextBox>
                                                </div>
                                                <div class="col-md-6" style="text-align:right;">
                                                    <h5><%#Eval("fecha_publi").ToString()%></h5>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-1"></div>
                                                <div class="col-md-8">
                                                    <p><%#Eval("comentario").ToString()%></p>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="row">
                                                        <div class="col-md-4">
                                                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-info" CommandName="Edit" Visible='<%#validaUserComentarios(Eval("user_cve").ToString())%>'/>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <asp:Button ID="btnBorrar" runat="server" Text="Borrar" CssClass="btn btn-danger" CommandName="Delete" OnClientClick="return confirm('¿Desea eliminar este comentario?')" Visible='<%# validaUserComentarios(Eval("user_cve").ToString()) %>'/>
                                                        </div>
                                                        <%if (Convert.ToInt16(Session["rol"]) == 1 || Convert.ToInt16(Session["rol"]) == 2){%>
                                                        <div class="col-md-4">
                                                            <asp:LinkButton ID="btnOcultar" runat="server" CommandName="Cancel" CssClass='<%# estiloBoton(Eval("sw_visible").ToString()) %>'><span class="glyphicon glyphicon glyphicon-eye-close" style="font-size:medium;" aria-hidden="true"></span></asp:LinkButton>
                                                        </div>
                                                        <%} %>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:DataList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-footer">
                    <div class="row">
                        <div class="col-md-2">
                            <asp:TextBox ID="txtFolio" runat="server" style="display:none;"></asp:TextBox>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtUsuarioComentario" runat="server" CssClass="form-control" Enabled="false" Text="Iniciar Sesión para realizar un comentario"></asp:TextBox>
                            <asp:TextBox ID="txtComentario" runat="server" CssClass="form-control" Wrap="true" TextMode="MultiLine" Rows="5" Width="100%" style="resize:none;"></asp:TextBox>
                            <div style="text-align:right;">
                                <asp:Button ID="btnComentar" runat="server" Text="Comentar" CssClass="btn btn-default" OnClick="btnComentar_Click" OnClientClick="return validar()"/>
                                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success" Visible="false" OnClick="btnGuardar_Click" OnClientClick="return validar()"/>
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" Visible="false" OnClick="btnCancelar_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function validar() {
            if ($('#<%=txtComentario.ClientID%>').val() === '') {
                alert('Completar todos los campos');
                return false;
            } else {
                return true;
            }
        }
    </script>
</asp:Content>
