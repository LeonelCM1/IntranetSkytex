<%@ Page Title="" Language="C#" MasterPageFile="~/Noticias.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="WebAppIntranetSkytex.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
<div class="row">
    <div class="col-md-3">
        <div class="panel panel-default">
            <div class="panel-heading"><b>Anuncios</b></div>
            <div class="panel-body"  style="max-height:257px; overflow-y:auto;">
                <div class="list-group">
                    <asp:DataList ID="dtAnuncios" runat="server" Width="100%">
                        <ItemTemplate>
                            <a href="#" class="list-group-item" data-toggle="modal" data-target="#ModalAnuncio" data-titulo="<%#Eval("titulo") %>" data-texto="<%#Eval("texto") %>" data-folio="<%# Eval("num_fol") %>"><%# Eval("titulo").ToString() %></a>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <a href="#" data-toggle="modal" data-target="#NuevoAnuncio"><span aria-hidden="true" class="glyphicon glyphicon-plus"></span> Nuevo Anuncio</a>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading"><b>Prox. Eventos</b></div>
            <div class="panel-body">
                <asp:Calendar ID="Calendario" runat="server" ShowGridLines="true" Width="100%" SelectionMode="Day" OnDayRender="Calendario_DayRender" TitleStyle-BackColor="#042644" 
                    TitleStyle-ForeColor="White" TitleStyle-Font-Bold="true" NextPrevStyle-ForeColor="White" DayHeaderStyle-BackColor="#042644" DayHeaderStyle-ForeColor="White"
                    OtherMonthDayStyle-BackColor="LightGray" OnSelectionChanged="Calendario_SelectionChanged" SelectedDayStyle-BackColor="#042644">
                    <SelectedDayStyle BackColor="#042644" ForeColor="White" />
                </asp:Calendar>
                <br />
                <div class="list-group">
                    <asp:DataList ID="dlEventos" runat="server" Width="100%">
                        <ItemTemplate>
                            <div class="row">
                                <div class="col-md-6">
                                    <%#Eval("titulo").ToString() %>
                                </div>
                                <div class="col-md-6" style="text-align:right;">
                                    <%# DevuelveDiaMes(Eval("fecha_ini"),1) %> - <%# DevuelveDiaMes(Eval("fecha_fin"),1) %> <%# DevuelveDiaMes(Eval("fecha_ini"),2) %>
                                </div>
                            </div>
                        </ItemTemplate>
                        <ItemStyle CssClass="list-group-item"/>
                    </asp:DataList>
                </div>
                <a href="#" data-toggle="modal" data-target="#NuevoEvento"><span aria-hidden="true" class="glyphicon glyphicon-plus"></span> Nuevo Evento</a>
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
            <asp:GridView ID="GridNoticias" runat="server" AutoGenerateColumns="false" BorderStyle="None" GridLines="None" CssClass="list-group" Width="100%">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <a href="/Noticia.aspx?n=<%# Convert.ToInt32(Eval("num_folio")) %>&Titulo=<%# Eval("titulo").ToString() %>" class="list-group-item">
                            <div id="noticia1">
                              <div style="width:100%;">
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
                                      <div class="col-md-4  text-center" style="<%# validaImagen(Eval("imagenUrl")) %>" >
                                          <!-- Imagen de la noticia -->
                                          <asp:Image ID="Image1" runat="server" ImageUrl='<%# miniatura(Eval("imagenUrl")) %>' CssClass="img-rounded" BorderStyle="Double" BorderWidth="1"/>
                                      </div> 
                                      <div class="<%# validaImagen2(Eval("imagenUrl")) %>">
                                          <!-- Texto de la noticia -->
                                           <h3> <%# Eval("resumen").ToString() %></h3>
                                      </div>
                                  </div>
                              </div>
                            </div></a>
                            <div style="height:5px;"></div>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <a href="/Noticia.aspx?n=<%# Convert.ToInt32(Eval("num_folio")) %>&Titulo=<%# Eval("titulo").ToString() %>" class="list-group-item">
                            <div id="noticia1">
                              <div style="width:100%;">
                                  <div class="row">
                                      <div class="col-md-3" style="text-align:left;">
                                          <%# Eval("fecha").ToString() %><!--Fecha -->
                                      </div>
                                      <div class="col-md-9" style="margin-top:-3%; text-align:right">
                                          <!-- Titulo de la noticia -->
                                          <h1><%# Eval("titulo").ToString() %></h1>
                                      </div>
                                  </div>
                                  <div class="row">
                                      <div class="<%# validaImagen2(Eval("imagenUrl")) %>">
                                          <!-- Texto de la noticia -->
                                           <h3> <%# Eval("resumen").ToString() %></h3>
                                      </div>
                                      <div class="col-md-4  text-center" style="<%# validaImagen(Eval("imagenUrl")) %>" >
                                          <!-- Imagen de la noticia -->
                                          <asp:Image ID="Image1" runat="server" ImageUrl='<%# miniatura(Eval("imagenUrl")) %>' CssClass="img-rounded" BorderStyle="Double" BorderWidth="1"/>
                                      </div>
                                  </div>
                              </div>
                            </div></a>
                            <div style="height:5px;"></div>
                        </AlternatingItemTemplate>
                        <ItemStyle BorderStyle="none"/>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</div>
<!-- Modal para mostrar anuncios -->
<div class="modal fade" id="ModalAnuncio" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
          <h3><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h3>
      </div>
      <div class="modal-body">
          <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
          <br /><br />
      </div>
      <div class="modal-footer">
          <div style="text-align:right;">
            <a id="btnEditAnuncio" class="btn btn-info" href="#" role="button">Editar Anuncio</a>
          </div>
      </div>
    </div>
  </div>
</div>
<!-- FIN  Modal para mostrar anuncios -->
<!-- Modal para Agregar anuncios -->
<div class="modal fade" id="NuevoAnuncio" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
          <h3>Nuevo Anuncio</h3>
      </div>
      <div class="modal-body">
          <div class="row">
              <div class="col-md-2">
                  <h4>Titulo:</h4>
              </div>
              <div class="col-md-10">
                  <asp:TextBox ID="txtNuevoTitulo" runat="server" CssClass="form-control"></asp:TextBox>
              </div>
          </div>
          <br />
          <div class="row">
              <div class="col-md-2">
                  <h4>Aviso:</h4>
              </div>
              <div class="col-md-10">
                  <asp:TextBox ID="txtNuevoTexto" runat="server" CssClass="form-control" Rows="5" TextMode="MultiLine"></asp:TextBox>
              </div>
          </div>
          <br />
          <div class="row">
              <div class="col-md-2"></div>
              <div class="col-md-3">
                  <h4>Fecha de fin:</h4>
              </div>
              <div class="col-md-4">
                  <asp:TextBox ID="txtNuevaFechaFin" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
              </div>
          </div>
      </div>
      <div class="modal-footer">
          <div class="text-center">
              <div class="row">
                  <div class="col-md-12 text-center">
                      <asp:Button ID="btnAgregarAnuncio" runat="server" Text="Agregar" CssClass="btn btn-success" OnClientClick="return validar()" OnClick="btnAgregarAnuncio_Click" />
                      <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                  </div>
              </div>
          </div>
      </div>
    </div>
  </div>
</div>
<!-- FIN Modal para Agregar anuncios -->
<!--    Modal para seleccionar evento -->
<div class="modal fade" id="SeleccionarEvento" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header text-center">
          <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
          <h3>Eventos Para el día <asp:Label ID="lblSeleccionaEventoDia" runat="server" Text=""></asp:Label></h3>
      </div>
      <div class="modal-body">
          <div class="list-group">
            <div class="row">
                <div class="col-md-3"></div>
                <div class="col-md-6">
                    <asp:DataList ID="ListaEventos" runat="server" Width="100%">
                        <ItemTemplate>
                            <asp:Button ID="btnEventos2" runat="server" Text='<%# Eval("titulo").ToString() %>' CssClass="list-group-item" OnClick="btnEventos_Click" style="width:100%" CustomParameter='<%# Eval("num_fol") %>'/>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
          </div>
      </div>
    </div>
  </div>
</div>
<!-- FIN   Modal para seleccionar evento -->
<!-- Modal para mostrar eventos -->
<div class="modal fade" id="ModalEvento" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
          <h2><asp:Label ID="lblTituloEvento" runat="server" Text="Label"></asp:Label></h2>
          <h5><asp:Label ID="lblFechaInicio" runat="server" Text="Label"></asp:Label> - <asp:Label ID="lblFechaFin" runat="server" Text="Label"></asp:Label></h5>
      </div>
      <div class="modal-body">
          <asp:Label ID="lblTextoEvento" runat="server" Text="Label"></asp:Label>
      </div>
      <div class="modal-footer text-center">
          <asp:Label ID="lblNumFolEvento" runat="server" Text="Label" style="display:none"></asp:Label>
          <asp:Button ID="btnEditarEvento" runat="server" Text="Editar Evento" CssClass="btn btn-info" OnClick="btnEditarEvento_Click" />
      </div>
    </div>
  </div>
</div>
<!-- FIN  Modal para mostrar Eventos -->
<div class="modal fade" id="NuevoEvento" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
          <h3>Nuevo Anuncio</h3>
      </div>
      <div class="modal-body">
          <div class="row">
              <div class="col-md-2">
                  <h4>Titulo:</h4>
              </div>
              <div class="col-md-10">
                  <asp:TextBox ID="txtNuevoTituloEvento" runat="server" CssClass="form-control"></asp:TextBox>
              </div>
          </div>
          <br />
          <div class="row">
              <div class="col-md-2">
                  <h4>Evento:</h4>
              </div>
              <div class="col-md-10">
                  <asp:TextBox ID="txtNuevoTextoEvento" runat="server" CssClass="form-control" Rows="5" TextMode="MultiLine"></asp:TextBox>
              </div>
          </div>
          <br />
          <div class="row">
              <div class="col-md-2" style="text-align:right;">
                  <h4>Inicio:</h4>
              </div>
              <div class="col-md-4">
                  <asp:TextBox ID="txtNuevaFechaIniEvento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
              </div>
              <div class="col-md-2" style="text-align:right;">
                  <h4>Fin:</h4>
              </div>
              <div class="col-md-4">
                  <asp:TextBox ID="txtNuevaFechaFinEvento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
              </div>
          </div>
      </div>
      <div class="modal-footer">
          <div class="text-center">
              <div class="row">
                  <div class="col-md-12 text-center">
                      <asp:Button ID="btnNuevoEvento" runat="server" Text="Agregar" CssClass="btn btn-success" OnClientClick="return validarEvento()" OnClick="btnNuevoEvento_Click"/>
                      <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                  </div>
              </div>
          </div>
      </div>
    </div>
  </div>
</div>
<!-- FIN Modal para Agregar anuncios -->
<script type="text/javascript">
    function SeleccionaEvento() {//Para mostrar el modal desde code behind
        $('#SeleccionarEvento').modal('show');
    }
    function MuestraEvento() {//Para mostrar el modal desde code behind
        $('#ModalEvento').modal('show');
    }
    $('#ModalAnuncio').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget) // Button that triggered the modal
        var titulo = button.data('titulo')
        var texto = button.data('texto')
        var folio = button.data('folio')
        $('#<%=Label1.ClientID%>').text(titulo);
        $('#<%=Label2.ClientID%>').text(texto);
        $('#btnEditAnuncio').attr('href', '/Editar_Anuncio.aspx?fol='+folio);
    })
    function validar() {
        if ($('#<%=txtNuevoTitulo.ClientID%>').val() === '') {
            alert('Completar todos los campos');
            return false;
        } else if ($('#<%=txtNuevoTexto.ClientID%>').val() === '') {
            alert('Completar todos los campos');
            return false;
        } else if ($('#<%=txtNuevaFechaFin.ClientID%>').val() === '') {
            alert('Completar todos los campos');
            return false;
        } else {
            return true;
        }
    }
    function validarEvento() {
        if ($('#<%=txtNuevoTituloEvento.ClientID%>').val() === '') {
            alert('Completar todos los campos');
            return false;
        } else if ($('#<%=txtNuevoTextoEvento.ClientID%>').val() === '') {
            alert('Completar todos los campos');
            return false;
        } else if ($('#<%=txtNuevaFechaIniEvento.ClientID%>').val() === '') {
            alert('Completar todos los campos');
            return false;
        } else if ($('#<%=txtNuevaFechaFinEvento.ClientID%>').val() === '') {
            alert('Completar todos los campos');
            return false;
        } else {
            return true;
        }
}
</script>
</asp:Content>
