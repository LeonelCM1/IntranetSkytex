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
                    <a class="btn btn-info" href="/Editar_Noticia.aspx?n=<%=fol%>" role="button">Editar</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
