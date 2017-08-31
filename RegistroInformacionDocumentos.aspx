<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroInformacionDocumentos.aspx.cs" Inherits="RegistroUsuarios.RegistroInformacionDocumentos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro de Informacion de Documentos</title>
    <link rel="stylesheet" href="CSS/bootstrap.min.css"/>
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link rel="stylesheet" type="text/css" href="Style.css" />     
</head>
<body>    
    <form id="form1" runat="server"> 
        
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"> </asp:ScriptManager>       
                <div class="padre center-block">                    
                    <h2 class="text-center">
                        <asp:Label ID="lblRegistro" runat="server" Text="Registro de Información de Documentos"  CssClass="text-primary" >
                        </asp:Label>
                    </h2>
                    <table class="table table-bordered table-condensed table-responsive"> 
                     <tr>
                    <td><asp:DropDownList CssClass="form-control btn-default"  ID="cbIdDepBusqueda" DataValueField="IdDepartamento" runat="server" ToolTip="Selecione"  AppendDataBoundItems="true">
                    <asp:ListItem value="0"> Todos los Departamentos</asp:ListItem>
                    </asp:DropDownList></td>
                         <td>
                    <asp:Button ID="btnConsulta" CssClass="btn btn-primary btn-block" runat="server" Text="Consulta" ToolTip="Muestra el grid de Consulta" OnClick="btnConsulta_Click" /></td>
                    </tr>
                    </table>
                   <asp:Button ID="btnNuevoRegistro" CssClass="btn btn-primary btn-block" runat="server" Text="Nuevo Registro" ToolTip="Muestra Tabla para realizar un nuevo registro" OnClick="btnNuevoRegistro_Click"/>
                    
                    <div>
                    <table class="table table-bordered table-condensed table-responsive">    
                        <tr>
                            <td><strong> <asp:TextBox CssClass="form-control text-center alert-danger"  ID="MsjResultado" Enabled="false" runat="server" Font-Size="Medium"></asp:TextBox></strong></td>
                        </tr>                  
                                           
                        <tr>
                        <td>
                        <asp:Panel ID="PanelFormulario" runat="server" Visible="true" >  
                    <table class="table table-condensed table-responsive">                       
                        <tr>
                            <td><%--Id Documento:<br />--%>
                            <asp:TextBox Visible="false" Enabled="false" CssClass="form-control"  ID="txtIdDocument" runat="server"  ToolTip="Ingrese Id del Documento" MaxLength="4" ></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Nombre del documento:<br />
                            <asp:TextBox CssClass="form-control" ID="txtNombreDocument" runat="server"> </asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Codigo:<br />
                            <asp:TextBox CssClass="form-control" ID="txtCodigo" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Versión:<br />
                            <asp:TextBox CssClass="form-control" ID="txtVersio" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Departamento:<br />                            
                            <asp:DropDownList CssClass="form-control"  ID="cbIdDepartament" runat="server" ToolTip="Selecione Departamento">
                            <asp:ListItem > Selecciona un Departamento</asp:ListItem>
                            </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>Fecha de publicación:<br />                         
                            <asp:TextBox CssClass="form-control" ID="txtFechaPublicacio" runat="server"></asp:TextBox> 

                                <ajaxToolkit:CalendarExtender ID="txtFechaPublicacio_CalendarExtender" runat="server" TargetControlID="txtFechaPublicacio" />

                            </td>
                        </tr>
                        <tr>
                            <td>Fecha de modificación:<br />
                             <asp:TextBox CssClass="form-control" ID="txtFechaModificacio" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="txtFechaModificacio_CalendarExtender" runat="server" TargetControlID="txtFechaModificacio" />
                            </td>
                        </tr>
                        <tr>
                            <td>Fecha de Revición:<br />                       
                            <asp:TextBox CssClass="form-control" ID="txtFechaRevicio" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="txtFechaRevicio_CalendarExtender" runat="server" TargetControlID="txtFechaRevicio" />
                            </td>
                        </tr>
                        <tr> 
                            <td>
                                <table class="table table-condensed">
                                <tr>
                                    <td>Status del documento:<br />                      
                                        <asp:CheckBox CssClass="form-control"  runat="server" ID="chbStatu"/></td>
                                    <td>Uso General:<br />
                                        <asp:CheckBox CssClass="form-control" runat="server" ID="chbUsoGenerl"/></td>
                                </tr>
                                </table>
                            </td>                            
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnGrabar" CssClass="btn btn-primary btn-block" runat="server" Text="Grabar" ToolTip="Grabar Información del Documento" OnClick="btnGrabar_Click" />                                
                            </td>
                        </tr>
                        <tr>    
                            <td>
                                <asp:Button ID="Cancelar" CssClass="btn btn-primary btn-block" runat="server" Text="Cancelar" OnClick="Cancelar_Click"  />
                                <ajaxToolkit:ConfirmButtonExtender ID="Cancelar_ConfirmButtonExtender" ConfirmText="¿Esta Seguro de Cancelar el registro?" runat="server" TargetControlID="Cancelar" />
                            </td>
                        </tr>
                    </table> 
                    </asp:Panel>
                        </td>
                        </tr>                        
                    
                    </table>
                        
                        </div>
                    <div>
                    
                    <table  class="table table-bordered table-condensed table-responsive">
                    <tr>
                     <td>                    
                    <asp:MultiView ID="MultiView2" runat="server" ActiveViewIndex="0">
                        <asp:View ID="View2" runat="server">
                            
                            <asp:GridView   CssClass="GridUsuario table  table-striped table-hover table-condensed small-top-margin" ID="GridInformacionDocumento" runat="server"  DataKeyNames="IdDocumento" GridLines="None" OnPageIndexChanging="GridInformacionDocumento_PageIndexChanging" AllowPaging="False" CellPadding="4"
                                OnRowCancelingEdit="GridInformacionDocumento_RowCancelingEdit" OnRowEditing="GridInformacionDocumento_RowEditing"   AutoGenerateColumns="False" OnRowDeleting="GridInformacionDocumento_RowDeleting" OnRowUpdating="GridInformacionDocumento_RowUpdating" >

                                <Columns>
                                    <asp:TemplateField HeaderText="Id Doc" ControlStyle-CssClass="btn-block">
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server"  Enabled="False" ID="txtIdDocumento" Text='<%# Bind("IdDocumento") %>'> </asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                         <asp:Label ID="Label1" runat="server" Enabled="False" Text='<%# Bind("IdDocumento") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Nombre de Documento" ControlStyle-CssClass="btn-block">
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="txtNombreDocumento" Text='<%#Bind("NombreDocumento") %>'> </asp:TextBox>
                                        </EditItemTemplate>                                    
                                        <ItemTemplate>
                                         <asp:Label ID="Label2" runat="server" Text='<%#Bind("NombreDocumento") %>'></asp:Label>
                                        </ItemTemplate>                                                                                           
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Código">
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="txtCodigo" Text='<%#Bind("Codigo") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%#Bind("Codigo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Versión">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtVersion" runat="server"  Text='<%#Bind("Version") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%#Bind("Version") %>'></asp:Label>
                                            </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Departamento">
                                        <EditItemTemplate>
                                            <asp:DropDownList runat="server" ID="cbIdDepartamento" DataSourceID="ConexionDepartamento" DataTextField="NombreDepartamento" 
                                DataValueField="IdDepartamento" SelectedValue='<%# Bind("IdDepartamento") %>'></asp:DropDownList>
                             <asp:SqlDataSource ID="ConexionDepartamento" runat="server" 
                                        ConnectionString="Data Source=localhost;Initial Catalog=ControlDocumental;Integrated Security=True" 
                                        SelectCommand="SELECT * FROM Departamento"></asp:SqlDataSource>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" runat="server" Text='<%#Bind ("IdDepartamento") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Fecha de Publicación">
                                        <EditItemTemplate>                                            
                                            <asp:TextBox runat="server" ID="txtFechaPublicacion" Text='<%#Bind("FechaPublicacion","{0:d}") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("FechaPublicacion","{0:d}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Fecha de Modificación">
                                        <EditItemTemplate>                                            
                                            <asp:TextBox ID="txtFechaModificacion"  runat="server" Text='<%#Bind("FechaModificacion", "{0:d}") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label7" runat="server"  Text='<%#Bind("FechaModificacion","{0:d}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Fecha de Revisión">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtFechaRevicion" runat="server" Text='<%#Bind ("FechaRevicion", "{0:d}")%>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label8" runat="server" Text='<%#Bind("FechaRevicion","{0:d}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Status">
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="chbStatus" runat="server" Checked='<%#Bind("Status") %>'></asp:CheckBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label9" runat="server" Text='<%#Bind("Status") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Uso General">
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="chbUsoGeneral" runat="server" Checked='<%#Bind("UsoGeneral") %>'></asp:CheckBox>
                                        </EditItemTemplate>
                                        
                                        <ItemTemplate>
                                            <asp:Label ID="Label10" runat="server" Text='<%#Bind ("UsoGeneral") %>'></asp:Label>
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
                </div>  
    </form>
</body>
</html>
