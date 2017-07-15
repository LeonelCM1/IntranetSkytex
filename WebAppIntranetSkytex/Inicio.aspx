﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Noticias.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="WebAppIntranetSkytex.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<div class="row">
    <div class="col-md-3">
        <div class="panel panel-default">
            <div class="panel-heading"><b>Anuncios</b></div>
            <div class="panel-body"  style="max-height:257px; overflow-y:auto;">
                <div class="list-group">
                    <asp:DataList ID="dtAnuncios" runat="server" Width="100%" >
                        <ItemTemplate>
                            <a href="#" class="list-group-item"><%# Eval("titulo").ToString() %></a>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading"><b>Prox. Eventos</b></div>
            <div class="panel-body">
                <asp:Calendar ID="Calendario" runat="server" ShowGridLines="true" Width="100%">
                    <SelectedDayStyle BackColor="#042644" ForeColor="White" />
                </asp:Calendar>
                <br />
                <div class="list-group">
                    <asp:DataList ID="dlEventos" runat="server" Width="100%">
                        <ItemTemplate>
                            <%#Eval("nombre").ToString() %>
                        </ItemTemplate>
                        <ItemStyle CssClass="list-group-item"/>
                    </asp:DataList>
                </div>
            </div>
        </div>
    </div>
        

    <div class="col-md-9">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <h4 class="col-md-6"><strong>NEWS</strong></h4>
                    <h4 class="col-md-6" style="text-align:right;"><strong><%= DateTime.Now.ToString("D") %></strong></h4>
                </div>
            </div>
        </div>
                    
        <div class="content-fluid" style="margin-top:-4%;">
            <asp:GridView ID="GridNoticias" runat="server" AutoGenerateColumns="false" BorderStyle="None" GridLines="None" CssClass="list-group">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <a href="#" class="list-group-item">
                            <div id="noticia1">
                              <div >
                                  <div class="row">
                                      <div class="col-md-9" style="margin-top:-3%;">
                                          <!-- Titulo de la noticia -->
                                          <h1><%# Eval("titulo").ToString() %></h1>
                                      </div>
                                      <div class="col-md-3" style="text-align:right;">
                                          <%# Eval("fecha").ToString() %><!--Fecha -->
                                      </div>
                                  </div>
                                  <div class="row">
                                      <div class="col-md-4  text-center" style="<%# validaImagen(Eval("imagenUrl")) %>;" >
                                          <!-- Imagen de la noticia -->
                                          <asp:Image ID="Image1" runat="server" ImageUrl='<%# miniatura(Eval("imagenUrl").ToString()) %>' CssClass="img-thumbnail"/>
                                      </div> 
                                      <div class="<%# validaImagen2(Eval("imagenUrl")) %>">
                                          <!-- Texto de la noticia -->
                                           <h3> <%# Eval("resumen").ToString() %></h3>
                                      </div>
                                  </div>
                              </div>
                            </div></a>
                        </ItemTemplate>
                        <ItemStyle BorderStyle="none"/>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</div>
</asp:Content>