<?php session_start();
require("conectar.php");
setlocale(LC_TIME, 'es_VE');
date_default_timezone_set('America/Caracas');
extract($_GET);
$F=date('d-m-Y');
$H=$_GET['hora'];
$fini=$_GET['fi'];
$ffin=$_GET['ff'];
$ids=$_GET['id'];


$ffi=date("d-m-Y", strtotime($fini));
$fff=$f=date("d-m-Y", strtotime($ffin));
$titulo="";
if($fini==""&&$ffin==""&&$ids!=-1){
	
	$titulo=$ids;
 $sql="SELECT cli.ced_rif,cli.nombre_rs,a.nombre,pv.n_solicitud,pv.fecha_desde,pv.fecha_hasta,pv.status,pv.tipoP FROM cliente cli INNER JOIN poliza_vehiculo pv  ON pv.id_asegurado=cli.id INNER JOIN aseguradora a  ON pv.id_aseguradora=a.id where pv.status='$ids' union SELECT cli.ced_rif,cli.nombre_rs,a.nombre,ps.n_solicitud,ps.fecha_desde,ps.fecha_hasta,ps.status,ps.tipoP FROM cliente cli INNER JOIN poliza_salud ps  ON ps.id_asegurado=cli.id INNER JOIN aseguradora a  ON ps.id_aseguradora=a.id where ps.status='$ids'";
 
 }
 if($fini==""&&$ffin==""&&$ids==-1){
	 
 $sql="SELECT cli.ced_rif,cli.nombre_rs,a.nombre,pv.n_solicitud,pv.fecha_desde,pv.fecha_hasta,pv.status,pv.tipoP FROM cliente cli INNER JOIN poliza_vehiculo pv  ON pv.id_asegurado=cli.id INNER JOIN aseguradora a  ON pv.id_aseguradora=a.id union SELECT cli.ced_rif,cli.nombre_rs,a.nombre,ps.n_solicitud,ps.fecha_desde,ps.fecha_hasta,ps.status,ps.tipoP FROM cliente cli INNER JOIN poliza_salud ps  ON ps.id_asegurado=cli.id INNER JOIN aseguradora a  ON ps.id_aseguradora=a.id";
 
 }
 if(($fini!="")&($ffin!="")&($ids!=-1)){
	
	$titulo=$ids." desde ".$ffi." hasta ".$fff;
 $sql="SELECT cli.ced_rif,cli.nombre_rs,a.nombre,pv.n_solicitud,pv.fecha_desde,pv.fecha_hasta,pv.status,pv.tipoP FROM cliente cli INNER JOIN poliza_vehiculo pv  ON pv.id_asegurado=cli.id INNER JOIN aseguradora a  ON pv.id_aseguradora=a.id where pv.status='$ids' and pv.fecha_desde between '$fini' and '$ffin' union SELECT cli.ced_rif,cli.nombre_rs,a.nombre,ps.n_solicitud,ps.fecha_desde,ps.fecha_hasta,ps.status,ps.tipoP FROM cliente cli INNER JOIN poliza_salud ps  ON ps.id_asegurado=cli.id INNER JOIN aseguradora a  ON ps.id_aseguradora=a.id where ps.status='$ids' and ps.fecha_desde between '$fini' and '$ffin'";
 
 }
 if(($fini!="")&($ffin!="")&($ids==-1)){
	
	$titulo=" desde ".$ffi." hasta ".$fff;
 $sql="SELECT cli.ced_rif,cli.nombre_rs,a.nombre,pv.n_solicitud,pv.fecha_desde,pv.fecha_hasta,pv.status,pv.tipoP FROM cliente cli INNER JOIN poliza_vehiculo pv  ON pv.id_asegurado=cli.id INNER JOIN aseguradora a  ON pv.id_aseguradora=a.id where  pv.fecha_desde between '$fini' and '$ffin' union SELECT cli.ced_rif,cli.nombre_rs,a.nombre,ps.n_solicitud,ps.fecha_desde,ps.fecha_hasta,ps.status,ps.tipoP FROM cliente cli INNER JOIN poliza_salud ps  ON ps.id_asegurado=cli.id INNER JOIN aseguradora a  ON ps.id_aseguradora=a.id where  ps.fecha_desde between '$fini' and '$ffin'";
 
 }
  

//mysql_close($conexion);

require_once("dompdf_config.inc.php");



$html='
<link href="hoja_estilo.css" rel="stylesheet" type="text/css">
<table width="100%" >
  <tr>
    <td   align="left"><img src="imagenes/asesores.png" height="50" width="50"/></td>
    <td colspan="6"  align="left"><span class="etiquetas_nomodi" ><h3>REPORTE DE PÓLIZAS '.$titulo.'</h3></span></td>
  </tr>
  <tr>
    <td colspan="7" class="etiquetas_nomodi" align="right">FECHA: '.$F.' HORA: '.$H.' USUARIO: '.$_SESSION['nombrecompleto'].'</td>
  </tr>
  <tr>
    <td class="etiquetas_nomodi" align="left">Póliza</td>
    <td align="left" class="etiquetas_nomodi">Tipo</td>
    <td  align="left" class="etiquetas_nomodi">Desde</td>
    <td  align="left" class="etiquetas_nomodi">Hasta</td>    
    <td  align="left" class="etiquetas_nomodi">Aseguradora</td>
    <td  align="left" class="etiquetas_nomodi">Asegurado</td>
	<td  align="left" class="etiquetas_nomodi">Estatus</td>
  </tr>';

   
	$res=mysql_query($sql);
	while($r=mysql_fetch_array($res)){
      $f=date("d-m-Y", strtotime($r["fecha_desde"]));
	  $ff=date("d-m-Y", strtotime($r["fecha_hasta"]));
   $html.='
   
  <tr>
    <td class="cajatexto" align="center">'.$r["n_solicitud"].'</td>
    <td class="cajatexto" align="left">'.$r["tipoP"].'</td>
    <td class="cajatexto" align="center">'.$f.'</td>
    <td class="cajatexto" align="left">'.$ff.'</td>    
    <td class="cajatexto" align="left">'.$r["nombre"].'</td>
    <td class="cajatexto" align="left">'.$r["nombre_rs"].'</td>
	<td class="cajatexto" align="left">'.$r["status"].'</td>
  </tr>
  '; }
  
   
  


$html.='<div style="page-break-before:auto;"></div></table>';

  $dompdf = new DOMPDF();
  ini_set("memory_limit","16M");
  $dompdf->load_html(utf8_decode($html));
  $dompdf->set_paper('letter',"portrail");
  
  
  
  $dompdf->render();
  $nombre="Polizas ".$titulo.".pdf";
  
  
  $dompdf->stream($nombre);
  ?>
