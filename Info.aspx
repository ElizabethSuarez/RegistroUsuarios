<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="RegistroUsuarios.Info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>    
    <link rel="stylesheet" href="CSS/bootstrap.min.css"/>
    <script src="js/jquery.min.js"></script>    
    <script src="js/bootstrap.min.js"></script>
    <link rel="stylesheet" type="text/css" href="Style.css" /> 
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="container">
  <h2>Carousel Example</h2>  
  <div id="myCarousel" class="carousel slide" data-ride="carousel">
    <!-- Indicators -->
    <ol class="carousel-indicators">
      <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
      <li data-target="#myCarousel" data-slide-to="1"></li>
      <li data-target="#myCarousel" data-slide-to="2"></li>
    </ol>

    <!-- Wrapper for slides -->
    <div class="carousel-inner">
      <div class="item active">
        <img src="images\5.jpg" alt="Los Angeles" style="width:100%;"/>
      </div>

      <div class="item">
        <img src="images\ima5.jpg" alt="Chicago" style="width:100%;"/>
      </div>
    
      <div class="item">
        <img src="images\5.jpg" alt="New york" style="width:100%;"/>
      </div>
    </div>

    <!-- Left and right controls -->
    <a class="left carousel-control" href="#myCarousel" data-slide="prev">
      <span class="glyphicon glyphicon-chevron-left"></span>
      <span class="sr-only">Previous</span>
    </a>
    <a class="right carousel-control" href="#myCarousel" data-slide="next">
      <span class="glyphicon glyphicon-chevron-right"></span>
      <span class="sr-only">Next</span>
    </a>
  </div>
</div>
    </div>
    </form>
</body>
</html>
