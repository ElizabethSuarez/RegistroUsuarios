<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegUsuario.aspx.cs" Inherits="RegistroUsuarios.RegUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro de Usuarios</title>
    <link rel="stylesheet" href="CSS/bootstrap.min.css"/>
    <script src="js/jquery.min.js"></script>    
    <script src="js/bootstrap.min.js"></script>
    <link rel="stylesheet" type="text/css" href="Style.css" />    
</head>
<body>
    <form id="form1" runat="server">
    
        <div class="padre center-block">
            <h2 class="text-center">
                <asp:Label ID="Label1" runat="server" Text="Registro de Usuarios"  CssClass="text-primary" >
                </asp:Label>
            </h2>
            <table class="table table-condensed">
                <tr>
                    <td>                       
                        <asp:TextBox ID="bst" runat="server" CssClass="form-control btn-default" ToolTip="R0000" placeholder="R0000" >
                        </asp:TextBox>
                    </td>                       
                    <td>
                        <asp:Button ID="Busqueda" CssClass="btn btn-primary dropdown-toggle" runat="server" Text="Buscar"  ToolTip="Buscar por Usuario" OnClick="Busqueda_Click"/> 
                    </td>
                    <td> 
                        
                        <asp:DropDownList CssClass="form-control btn-default"  ID="cbIdDepBusqueda" DataValueField="IdDepartamento" runat="server" ToolTip="Selecione"  AppendDataBoundItems="true">
                            <asp:ListItem value="0"> Todos los Departamentos</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                    
                        <asp:Button ID="BusquedaDepartamento" CssClass="btn btn-primary dropdown-toggle" runat="server" Text="Buscar"  ToolTip="Buscar por Departamento" OnClick="BusquedaDepartamento_Click"  />
                    </td> 
                    <td>
                        <asp:DropDownList CssClass="form-control btn-default"  ID="BusquedaPorMetodo" runat="server" ToolTip="Selecione">
                            <asp:ListItem value="0"> Selecciona Tipo de Busqueda</asp:ListItem>
                            <asp:ListItem Value="1">Activos</asp:ListItem>
                            <asp:ListItem Value="2">Inactivos</asp:ListItem>
                            <asp:ListItem Value="3">Responsables de Departamentos</asp:ListItem>
                            <asp:ListItem Value="4">No Responsables de Departamentos</asp:ListItem>
                            <asp:ListItem Value="5">Activos Responsables de Departamento</asp:ListItem>
                            <asp:ListItem Value="6">Activos No Responsables de Departamentos</asp:ListItem>
                         </asp:DropDownList>
                    </td>  
                    <td>
                        <asp:Button ID="UsuariosActivos" CssClass="btn btn-primary dropdown-toggle" runat="server" Text="Buscar"  ToolTip="Busqueda Especifica" OnClick="UsuariosActivos_Click1"  />
                    </td>                              
                </tr>                                  
             </table>
               
            <table class="table table-bordered table-condensed table-responsive" >
            <tr>
                <td>
                    <asp:TextBox CssClass="form-control text-center alert-danger"  ID="txtMensaje" runat="server" ></asp:TextBox>
                </td>
                </tr>
                <tr>
               <td>
                   <asp:Button ID="btnNuevoRegistro" CssClass="btn btn-primary btn-block" runat="server" Text="Nuevo Registro" OnClick="btnNuevoRegistro_Click" ToolTip="Agregar Nuevo Usuario" />
               </td>
           </tr>                
            <tr>
             <td>
               <asp:Panel ID="PanelFormulario" runat="server" Visible="true" >  
            <table class="table table-responsive">
            <tr>
            <td>Id Usuario <br />
                        <asp:TextBox CssClass="form-control"  ID="txtIdUsuari" runat="server"  ToolTip="Ingrese Id de Usuario" MaxLength="6" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td >Nombre de Usuario <br />
                    <asp:TextBox  CssClass="form-control"  ID="txtNombreUsuari" runat="server" ToolTip="Ingrese Nombre de Usuario"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td >Apellido Paterno <br />
                    <asp:TextBox  CssClass="form-control"  ID="txtApellidoPatern" runat="server" ToolTip="Ingrese Apellido Paterno"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Apellido Materno <br />
                    <asp:TextBox CssClass="form-control"  ID="txtApellidoMatern" runat="server" ToolTip="Ingrese Apellido Materno"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Numero de Nomina <br />
                    <asp:TextBox  CssClass="form-control"  ID="txtNumeroDeNomin" runat="server" ToolTip="Ingrese Numero de Nomina" MaxLength="4"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Status <br />
                    <asp:DropDownList  CssClass="form-control"  ID="cbStatu" runat="server" ToolTip="Selecione Status" >
                        <asp:ListItem >Selecciona</asp:ListItem>
                        <asp:ListItem Value="true">Activo</asp:ListItem>
                        <asp:ListItem Value="false">Inactivo</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Departamento <br />
                    <asp:DropDownList CssClass="form-control"  ID="cbIdDepartament" runat="server" ToolTip="Selecione Departamento">
                        <asp:ListItem> Selecciona un Departamento</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Rol <br />
                    <asp:DropDownList CssClass="form-control"  ID="cbIdRo" runat="server" ToolTip="Selecione El Rol">
                        <asp:ListItem Value="IdRo"> Selecciona un Rol</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Responsable de Departamento <br />
                    <asp:DropDownList CssClass="form-control"  ID="cbResponsableDeDepartament" runat="server" ToolTip="Selecione Sexo">
                        <asp:ListItem > Selecciona</asp:ListItem>
                        <asp:ListItem Value="true">Si</asp:ListItem>
                        <asp:ListItem Value="false">No</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>

                    <asp:Button ID="btnGrabar" CssClass="btn btn-primary btn-block" runat="server" Text="Grabar" OnClick="btnGrabar_Click" ToolTip="Grabar Personal"/>
                    <br />
                    <asp:Button ID="btnCancelar" CssClass="btn btn-primary btn-block" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" ToolTip="Cancelar" />
                </td>
            </tr>            
            </table>
               </asp:Panel>
            </td>
            </tr>
            <tr>              
                <td> <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="-1">
                     <asp:View ID="View1" runat="server" >  
                               
            <asp:GridView  CssClass="GridUsuario table  table-striped table-hover table-condensed small-top-margin"  ID="GridUsuario" runat="server" CellPadding="4" GridLines="None" 
                AllowPaging="False" OnPageIndexChanging="GridUsuario_PageIndexChanging" 
                 OnRowDeleting="GridUsuario_RowDeleting" 
                OnRowEditing="GridUsuario_RowEditing" OnRowUpdating="GridUsuario_RowUpdating" DataKeyNames="IdUsuario" 
                OnRowCancelingEdit="GridUsuario_RowCancelingEdit" AutoGenerateColumns="False" EnableViewState="true" OnRowCommand="GridUsuario_RowCommand" >  
         
                <Columns>
                   <asp:TemplateField HeaderText="IdUsuario">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtIdUsuario" runat="server" Text='<%# Bind("IdUsuario") %>' ></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("IdUsuario") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Nombre">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNombreUsuario" runat="server" Text='<%# Bind("NombreUsuario") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("NombreUsuario") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Apellido Pat">                        
                        <EditItemTemplate>
                            <asp:TextBox ID="txtApellidoPaterno" runat="server" Text='<%# Bind("ApellidoPaterno") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("ApellidoPaterno") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Apellido Mat">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtApellidoMaterno" runat="server" Text='<%# Bind("ApellidoMaterno") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("ApellidoMaterno") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="No de Nomina">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNumeroDeNomina" runat="server" Text='<%# Bind("NumeroDeNomina") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("NumeroDeNomina") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Status">
                        <EditItemTemplate>
                            <asp:CheckBox ID="cbStatus" runat="server" Checked='<%# Bind("Status") %>'>
                            </asp:CheckBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                        </ItemTemplate>
                       
                    </asp:TemplateField>

                    <asp:TemplateField  HeaderText="Departamento">
                        <EditItemTemplate>
                            <asp:DropDownList ID="cbIdDepartamento" runat="server" DataSourceID="ConexionDepartamento" DataTextField="NombreDepartamento" 
                                DataValueField="IdDepartamento" SelectedValue='<%# Bind("IdDepartamento") %>'></asp:DropDownList>
                             <asp:SqlDataSource ID="ConexionDepartamento" runat="server" 
                                        ConnectionString="Data Source=localhost;Initial Catalog=ControlDocumental;Integrated Security=True" 
                                        SelectCommand="SELECT * FROM Departamento"></asp:SqlDataSource>
                        </EditItemTemplate>  
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("IdDepartamento") %>'></asp:Label>
                        </ItemTemplate>                     
                    </asp:TemplateField>   
                                                         
                    <asp:TemplateField HeaderText="Rol">
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server"  Text='<%# Bind("IdRol")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="cbIdRol" runat="server" DataSourceID="ConexionRol" DataTextField="NombreRol" 
                                DataValueField="IdRol"  SelectedValue='<%# Bind("IdRol")%>'> </asp:DropDownList>
                                    <asp:SqlDataSource ID="ConexionRol" runat="server" 
                                        ConnectionString="Data Source=localhost;Initial Catalog=ControlDocumental;Integrated Security=True" 
                                        SelectCommand="SELECT * FROM Roles"></asp:SqlDataSource>
                        </EditItemTemplate>
                    </asp:TemplateField>
                                        
                    <asp:TemplateField HeaderText="Responsable">
                        <EditItemTemplate>
                            <asp:CheckBox ID="cbResponsableDepartamento" runat="server" Checked='<%# Bind("ResponsableDepartamento") %>'>
                            </asp:CheckBox>                        
                        </EditItemTemplate>
                        <ItemTemplate>                            
                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("ResponsableDepartamento") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>   
                    <asp:CommandField ItemStyle-CssClass="btn btn-primary dropdown-toggle" ButtonType="Button" ShowEditButton="True" ControlStyle-ForeColor="#003366">
                    <ControlStyle />
                    <ItemStyle CssClass="btn btn-primary btn-xs" />
                    </asp:CommandField>
                    <asp:CommandField ItemStyle-CssClass="btn btn-primary dropdown-toggle" ButtonType="Button" ShowDeleteButton="True" ControlStyle-ForeColor="#003366">
                    <ControlStyle />
                    <ItemStyle CssClass="btn btn-primary btn-xs" />
                    </asp:CommandField>
                </Columns> 
                </asp:GridView> 
            </asp:View>
            </asp:MultiView>
               </td> 
            </tr>
        </table> 
       </div>
        

            
            
        
    </form>
</body>
</html>
