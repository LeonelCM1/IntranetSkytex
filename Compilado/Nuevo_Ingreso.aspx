<%@ Page Title="" Language="C#" MasterPageFile="~/Noticias.Master" AutoEventWireup="true" CodeBehind="Nuevo_Ingreso.aspx.cs" Inherits="WebAppIntranetSkytex.Nuevo_Ingreso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-6">
                        <h1>Nuevos Ingresos</h1>
                    </div>
                    <div class="col-md-6" style="text-align:right;">
                        <h3><%=DateTime.Today.ToString("dd / MMMM / yyyy") %></h3>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <div class="container text-center">
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-10">
                            <asp:DataList ID="ListaNuevosIngresos" runat="server" RepeatDirection="Horizontal" RepeatColumns="2">
                                <ItemTemplate>
                                    <div class="row">
                                        <div class="col-md-6" style="text-align:left;">
                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# miniatura(Eval("imagenUrl")) %>' CssClass="img-rounded" BorderStyle="Double" BorderWidth="1"/>
                                        </div>
                                        <div class="col-md-6">
                                            <h5>Nombre: <%#Eval("titulo").ToString() %></h5>
                                            <h5>Puesto: <%#Eval("noticia").ToString() %></h5>
                                            <h5>Area: <%#Eval("resumen").ToString() %></h5>
                                        </div>
                                    </div>
                                    <br />
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# miniatura(Eval("imagenUrl")) %>' CssClass="img-rounded" BorderStyle="Double" BorderWidth="1"/>
                                        </div>
                                        <div class="col-md-6" style="text-align:left;">
                                            <h5>Nombre: <%#Eval("titulo").ToString() %></h5>
                                            <h5>Puesto: <%#Eval("noticia").ToString() %></h5>
                                            <h5>Area: <%#Eval("resumen").ToString() %></h5>
                                        </div>
                                    </div>
                                    <br />
                                </AlternatingItemTemplate>
                            </asp:DataList>
                        </div>
                    </div>
                </div>
            </div>
            <%if (Session["rol"]!=null)
              {
                  if (Session["rol"].ToString()=="2")
                  {%>
            <div class="panel-footer">
                <div class="container">
                    <div class="row">
                        <div class="col-md-2"></div>
                        <div class="col-md-8">
                            <ul class="nav nav-tabs" role="tablist">
                                <li role="presentation" class="active">
                                    <a href="#Agregar" aria-controls="home" role="tab" data-toggle="tab">Agregar</a>
                                </li>
                                <li role="presentation">
                                    <a href="#Editar" aria-controls="profile" role="tab" data-toggle="tab">Editar</a>
                                </li>
                                <li role="presentation">
                                    <a href="#Eliminar" aria-controls="profile" role="tab" data-toggle="tab">Eliminar</a>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-10">
                            <div class="tab-content">
                                <div role="tabpanel" class="tab-pane active" id="Agregar"><!-- Pestaña de Agregar -->
                                    <br />
                                    <div class="row" >
                                        <div class="col-md-2">
                                        </div>
                                        <div class="col-md-2" style="text-align:right;">
                                            <h4><asp:Label ID="lblNombre" runat="server" Text="Nombre:" ></asp:Label></h4>
                                            <h4><asp:Label ID="lblPuesto" runat="server" Text="Puesto:"></asp:Label></h4>
                                            <h4><asp:Label ID="lblArea" runat="server" Text="Area:"></asp:Label></h4>
                                            <h4><asp:Label ID="lblFoto" runat="server" Text="Foto:"></asp:Label></h4>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:TextBox ID="txtPuesto" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:TextBox ID="txtArea" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:FileUpload ID="Foto" runat="server"/>
                                        </div>
                                        <div class="col-md-1"></div>
                                        <div class="col-md-1">
                                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-success" OnClick="btnAgregar_Click" OnClientClick="return validar()"/>
                                        </div>
                                    </div>
                                    <br />
                                </div>
                                <div role="tabpanel" class="tab-pane" id="Editar"><!-- Pestaña de editar Empleado -->
                                    <br />
                                    <div class="row" >
                                        <div class="col-md-2">
                                        </div>
                                        <div class="col-md-2" style="text-align:right;">
                                            <h4><asp:Label ID="Label1" runat="server" Text="Nombre:" ></asp:Label></h4>
                                            <h4><asp:Label ID="Label2" runat="server" Text="Puesto:"></asp:Label></h4>
                                            <h4><asp:Label ID="Label3" runat="server" Text="Area:"></asp:Label></h4>
                                            <h4><asp:Label ID="Label4" runat="server" Text="Foto:"></asp:Label></h4>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:DropDownList ID="ListaEmpleados" runat="server" CssClass="form-control"></asp:DropDownList>
                                            <asp:TextBox ID="txtEditPuesto" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:TextBox ID="txtEditArea" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:FileUpload ID="FotoEdit" runat="server"/>
                                        </div>
                                        <div class="col-md-1"></div>
                                        <div class="col-md-1">
                                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-info" OnClick="btnGuardar_Click" OnClientClick="return validarEdit()"/>
                                        </div>
                                    </div>
                                    <br />
                                </div>
                                <div role="tabpanel" class="tab-pane" id="Eliminar">  <!-- Pestaña de eliminar  -->
                                    <br />
                                    <div class="row" >
                                        <div class="col-md-2">
                                        </div>
                                        <div class="col-md-2" style="text-align:right;">
                                            <h4><asp:Label ID="Label5" runat="server" Text="Nombre:" ></asp:Label></h4>
                                            <br /><br /><br />
                                        </div>
                                        <div class="col-md-3">
                                            <asp:DropDownList ID="ListaEmpleadosEliminar" runat="server" CssClass="form-control"></asp:DropDownList>
                                            <br /><br /><br />
                                        </div>
                                        <div class="col-md-1"></div>
                                        <div class="col-md-1">
                                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" OnClientClick="return validarEliminar()"/>
                                        </div>
                                    </div>
                                    <br />
                                    <br />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
                  <%}
              } %>
        </div>
    </div>
    <script type="text/javascript">
        function validar() {
            if ($('#<%=txtNombre.ClientID%>').val() === '') {
                alert('Completar todos los campos');
                return false;
            } else if ($('#<%=txtArea.ClientID%>').val() === '') {
                alert('Completar todos los campos');
                return false;
            } else if ($('#<%=txtPuesto.ClientID%>').val() === '') {
                alert('Completar todos los campos');
                return false;
            } else if (document.getElementById('<%= Foto.ClientID %>').files.length === 0) {
                alert('Completar todos los campos');
                return false;
            } else {
                return true;
            }
        }
        function validarEdit() {
            if ($('#<%=ListaEmpleados.ClientID%>').val() === 'NA') {
                alert('Completar todos los campos');
                return false;
            } else if ($('#<%=txtEditArea.ClientID%>').val() === '') {
                alert('Completar todos los campos');
                return false;
            } else if ($('#<%=txtEditPuesto.ClientID%>').val() === '') {
                alert('Completar todos los campos');
                return false;
            } else {
                return true;
            }
        }
        function validarEliminar() {
            if ($('#<%=ListaEmpleadosEliminar.ClientID%>').val() === 'NA') {
                alert('Completar todos los campos');
                return false;
            } else {
                return true;
            }
}
    </script>
</asp:Content>
