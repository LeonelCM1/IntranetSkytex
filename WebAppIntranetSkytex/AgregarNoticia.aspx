<%@ Page Title="" Language="C#" MasterPageFile="~/Noticias.Master" AutoEventWireup="true" CodeBehind="AgregarNoticia.aspx.cs" Inherits="WebAppIntranetSkytex.AgregarNoticia" %>
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
                    <div class="col-md-6" style="height:100%">
                        <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control"></asp:TextBox>
                        <br />
                        <br />
                    </div>
                </div>
                <asp:TextBox ID="txtContenido" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="10"></asp:TextBox>
                <br />
                <div class="text-center">
                    <asp:FileUpload runat="server" CssClass="text-center"/>
                    <br />
                    <asp:Image runat="server" ImageUrl="~/Media/Mini/z13wx0uhfwdy.png"/>
                    <br />
                    <br />
                </div>dsa
            </div>
        </div>
    </div>
</asp:Content>
