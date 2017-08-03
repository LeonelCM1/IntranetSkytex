<%@ Page Title="" Language="C#" MasterPageFile="~/Noticias.Master" AutoEventWireup="true" CodeBehind="Cumpleañeros.aspx.cs" Inherits="WebAppIntranetSkytex.Cumpleañeros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <h2 class="col-md-6">Cumpleañeros</h2>
                    <h2 class="col-md-6" style="text-align:right;"><%= DateTime.Now.ToString("D") %></h2>
                </div>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-2"></div>
                    <div class="col-md-3">
                        <asp:Image ID="logoSkytex" runat="server" ImageUrl="~/Media/LogoSkytex.jpg" Width="100%"/>
                    </div>
                    <div class="col-md-6">
                        <br />
                        <div>
                            <h1><strong>Grupo Skytex Felicita a:</strong></h1>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-6 text-center">
                        <asp:DataList ID="DataList1" runat="server">
                            <ItemTemplate>
                                <asp:Image ID="Liston" runat="server" ImageUrl='<%#RutaImagen(Eval("nombre").ToString(),Eval("num").ToString()) %>' Width="100%" />
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
            </div>
            <div class="panel-footer">
                <h3>Cumpleañeros de la semana</h3>
                <div class="row">
                    <div class="col-md-12">
                        <asp:DataList ID="DataList2" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <h4 class="text-center"><strong><%# fecha_cumple(Eval("birthday")) %></strong></h4>
                                <asp:Image ID="ListonSemana" runat="server" ImageUrl='<%#RutaImagen(Eval("nombre").ToString(),Eval("num").ToString()) %>' Width="100%" />
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
