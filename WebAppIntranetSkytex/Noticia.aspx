<%@ Page Title="" Language="C#" MasterPageFile="~/Noticias.Master" AutoEventWireup="true" CodeBehind="Noticia.aspx.cs" Inherits="WebAppIntranetSkytex.Noticia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-2">
                        <asp:Image ID="Image1" runat="server" CssClass="img-circle"/>
                    </div>
                    <div class="col-md-8 text-center">
                        <asp:Label ID="lblTitulo" runat="server" Font-Size="48px"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-10">
                        <asp:Label ID="lblNoticia" runat="server" ></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
