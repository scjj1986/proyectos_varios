<?php
session_start();
require("conectar.php");
if ($_SESSION['perfil']=="ADMINISTRADOR"){

?>


<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>SISTEMA pb ASESORES</title>
  <link rel="stylesheet" href="css/bootstrap.css">
    <link rel="stylesheet" href="css/font-awesome.min.css">
    <link href="css/sweetalert.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="css/dataTables.bootstrap.min.css">
    <link rel="stylesheet" href="include/ui-1.10.0/ui-lightness/jquery-ui-1.10.0.custom.min.css" type="text/css" />
    <link rel="stylesheet" href="css/jquery.ui.timepicker.css?v=0.3.3" type="text/css" />

    <script src="js/jquery-3.1.1.min.js"></script>

    
    <!--------------------------------- TimePicker   ---------------------------------------->
    <script type="text/javascript" src="include/jquery-1.9.0.min.js"></script>
    <script type="text/javascript" src="include/ui-1.10.0/jquery.ui.core.min.js"></script>
    <script type="text/javascript" src="include/ui-1.10.0/jquery.ui.widget.min.js"></script>
    <script type="text/javascript" src="include/ui-1.10.0/jquery.ui.tabs.min.js"></script>
    <script type="text/javascript" src="include/ui-1.10.0/jquery.ui.position.min.js"></script>
    <!---------------------------------------------------------------------------------------->





    <script src="js/bootstrap.min.js"></script>


    <script src="js/sweetalert.min.js"></script>


    <script type="text/javascript" language="javascript" src="js/jquery.dataTables.min.js">
    </script>
    <script type="text/javascript" language="javascript" src="js/dataTables.bootstrap.min.js">
    </script>
    
    <script type="text/javascript" language="javascript" src="js/index.js"></script>

    <script type="text/javascript" src="js/jquery.numeric.js"></script>

    <script type="text/javascript" src="js/jquery.ui.timepicker.js?v=0.3.3"></script>
    <script type="text/javascript" src="js/jquery.ui.timepicker-es.js"></script>

    <script type="text/javascript" src="js/bootstrap-filestyle.js"></script>
    <script type="text/javascript" src="js/bootstrap-filestyle.min.js"></script>


</head>

<body style="padding-top: 60px; background-color:#A9D0F5;">


<nav class="navbar navbar-default navbar-fixed-top" role="navigation">
<img width="100%" height="150px" src="img/banner.png"/>
  <ul id="mainmenu" class="nav nav-pills">
    <li class=""><a id="inicio" href="#"><b>Inicio</b></a></li>
    <li><a id="asg" href="#"><b>Aseguradoras</b></a></li>
    <li><a id="bnc" href="#"><b>Bancos</b></a></li>
    <li><a id="cli" href="#"><b>Clientes</b></a></li>
    <li class="dropdown">
        <a href="#" data-toggle="dropdown" class="dropdown-toggle"><b>Pólizas</b><b class="caret"></b></a>
        <ul class="dropdown-menu">
            <li><a id="ssv" href="#">Solicitud de Seguro de Vehículos Terrestres</a></li>
            <li class="divider"></li>
            <li><a id="sss" href="#">Solicitud de Seguro de Salud</a></li>
        </ul>
    </li>

     <li class="dropdown">
        <a href="#" data-toggle="dropdown" class="dropdown-toggle"><b>Notificaciones</b><b class="caret"></b></a>
        <ul class="dropdown-menu">
            <li><a id="factura_listado" href="#">Facturas</a></li>
            <li class="divider"></li>
            <li><a id="siniestro_listado" href="#">Siniestros</a></li>
        </ul>
    </li>


     <li class="dropdown">
        <a href="#" data-toggle="dropdown" class="dropdown-toggle"><b>Reporte</b><b class="caret"></b></a>
        <ul class="dropdown-menu">
            <li><a id="" href="#">Siniestros</a></li>
            <li class="divider"></li>
            <li><a id="" href="#">Pólizas</a></li>
            <li class="divider"></li>
            <li><a id="" href="#">Facturas de reembolso</a></li>
             <li class="divider"></li>
            <li><a id="" href="#">Estadísticas de siniestros</a></li>
        </ul>
    </li>

    <li class="dropdown">
        <a href="#" data-toggle="dropdown" class="dropdown-toggle"><b>Base de Datos</b><b class="caret"></b></a>
        <ul class="dropdown-menu">
            <li><a id="rsp" href="#">Respaldo</a></li>
            <li class="divider"></li>
            <li><a id="rst" href="#">Restauración</a></li>
        </ul>
    </li>
    <li><a id="usuario_listado" href="#"><b>Usuarios</b></a></li>
    <li class="dropdown pull-right">
        <a width="100px" href="#" data-toggle="dropdown" class="dropdown-toggle"><b><div id="nomusu"><? echo $_SESSION['nombrecompleto']; ?></div></b><b class="caret"></b></a>
        <ul class="dropdown-menu">
            
            <li><a id="logout" href="#">Cerrar Sesión</a></li>
        </ul>
    </li>
</ul>

</nav>

<table align="center">

<tr><td>

<div class="modal-dialog" style="padding-top: 10em; width:1250px;">

    <div id="capa">
    </div>

            
</div>



</td></tr>


 </table>

  



</body>
</html>

<? 


}else{
  

  print("<script>window.location.replace('../index.php');</script>");
}



?>