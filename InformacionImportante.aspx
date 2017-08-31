<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformacionImportante.aspx.cs" Inherits="RegistroUsuarios.InformacionImportante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="CSS/Imagescss.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
         <marquee direction="up">
             <table><tr><td>
             <%--<asp:ImageButton CssClass="image-responsive" ID="btn5m" runat="server" ImageUrl="~/img5momPaHigi.png" />--%>
             <asp:ImageButton CssClass="img-responsive" ID="imag5m" runat="server" ImageUrl="~/images/img5momPaHigi.png" /></td></tr><tr><td>
             <asp:ImageButton CssClass="img-responsive" ID="btnHigieneManos" runat="server" ImageUrl="~/images/Higienemanos.png" /> 
              <%--<asp:ImageButton CssClass="img-responsive" ID="btn5momentos" runat="server" ImageUrl="~/images/5momen.png" OnClick="btn5momentos_Click" />--%> 
                 </td></tr></table>
         </marquee>
            <%-- <div>   
                 <table class="table table-responsive table-bordered">
                     <tr>
                         <td>
                            <asp:Panel ID="panel2" runat="server" Visible="true"> 
                                <asp:Image CssClass="Image1 img-responsive "  ID="Image1" runat="server" ImageUrl="~/images/5Momentos.png" />
                                <asp:Image CssClass="Image2 img-responsive " ID="Image2" runat="server"  ImageUrl="~/images/img0.png"/>  
                            </asp:Panel>
                         </td>
                     </tr>
                </table>  
            </div>              --%>    
       

       <%-- <div style="width: 927px; background-color: #FFFF00;">
  
    </div>
    <div style="width: 927px; background-color: #CCFFCC;">
      <marquee direction="right"><strong> Simple Marquee Text(Right Direction)</strong></marquee>
   </div> --%>
    </form>
</body>
</html>
