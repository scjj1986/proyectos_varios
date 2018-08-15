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
$idc=$_GET['idc'];

$ffi=date("d-m-Y", strtotime($fini));
$fff=$f=date("d-m-Y", strtotime($ffin));
$titulo="";
if($fini==""&&$ffin==""&&$idc==-1&&$ids!=-1){
	$qr_asg=mysql_query("SELECT * FROM aseguradora where id='$ids'");
    $asg=mysql_fetch_array($qr_asg);
	$titulo='ASEGURADORA '.$asg['nombre'];
 $sql="select n.codigo,n.descripcion,n.fecha,n.prioridad,n.status,a.nombre,c.nombre_rs from notificacion n inner join poliza_vehiculo pv on pv.id_asegurado=n.id_cliente inner join cliente c on c.id=n.id_cliente inner join aseguradora a on a.id=pv.id_aseguradora where n.status='APROBADA' and a.id='$ids'";
 
 }
 if($fini==""&&$ffin==""&&$idc!=-1&&$ids==-1){
	 $qr_asg=mysql_query("SELECT * FROM cliente where id='$idc'");
    $asg=mysql_fetch_array($qr_asg);
	$titulo='ASEGURADO '.$asg['nombre_rs'];
 $sql="select n.codigo,n.descripcion,n.fecha,n.prioridad,n.status,a.nombre,c.nombre_rs from notificacion n inner join poliza_vehiculo pv on pv.id_asegurado=n.id_cliente inner join cliente c on c.id=n.id_cliente inner join aseguradora a on a.id=pv.id_aseguradora where n.status='APROBADA' and c.id='$idc'";
 
 }
 if($fini!=""&&$ffin!=""&&$idc==-1&&$ids!=-1){
	$qr_asg=mysql_query("SELECT * FROM aseguradora where id='$ids'");
    $asg=mysql_fetch_array($qr_asg);
	$titulo='ASEGURADORA '.$asg['nombre']." desde ".$ffi." hasta ".$fff;
 $sql="select n.codigo,n.descripcion,n.fecha,n.prioridad,n.status,a.nombre,c.nombre_rs from notificacion n inner join poliza_vehiculo pv on pv.id_asegurado=n.id_cliente inner join cliente c on c.id=n.id_cliente inner join aseguradora a on a.id=pv.id_aseguradora where n.status='APROBADA' and a.id='$ids' and n.fecha between '$fini' and '$ffin'";
 
 }
  if($fini!=""&&$ffin!=""&&$idc!=-1&&$ids==-1){
	 $qr_asg=mysql_query("SELECT * FROM cliente where id='$idc'");
    $asg=mysql_fetch_array($qr_asg);
	$titulo='ASEGURADO '.$asg['nombre_rs']." desde ".$ffi." hasta ".$fff;
 $sql="select n.codigo,n.descripcion,n.fecha,n.prioridad,n.status,a.nombre,c.nombre_rs from notificacion n inner join poliza_vehiculo pv on pv.id_asegurado=n.id_cliente inner join cliente c on c.id=n.id_cliente inner join aseguradora a on a.id=pv.id_aseguradora where n.status='APROBADA' and c.id='$idc' n.fecha between '$fini' and '$ffin'";
 
 }
 if($fini==""&&$ffin==""&&$idc==-1&&$ids==-1){
	
	
 $sql="select n.codigo,n.descripcion,n.fecha,n.prioridad,n.status,a.nombre,c.nombre_rs from notificacion n inner join poliza_vehiculo pv on pv.id_asegurado=n.id_cliente inner join cliente c on c.id=n.id_cliente inner join aseguradora a on a.id=pv.id_aseguradora where n.status='APROBADA'";
 
 }

//mysql_close($conexion);

require_once("dompdf_config.inc.php");



$html='
<link href="hoja_estilo.css" rel="stylesheet" type="text/css">
<table >
  <tr>
    <td   align="left"><img src="imagenes/asesores.png" height="50" width="50"/></td>
    <td colspan="6"  align="center"><span class="etiquetas_nomodi" ><h3>REPORTE DE SINIESTROS '.$titulo.'</h3></span></td>
  </tr>
  <tr>
    <td colspan="7" class="etiquetas_nomodi" align="right">FECHA: '.$F.' HORA: '.$H.' USUARIO: '.$_SESSION['nombrecompleto'].'</td>
  </tr>
  <tr>
    <td class="etiquetas_nomodi" align="left">Código</td>
    <td align="left" class="etiquetas_nomodi">Descripción</td>
    <td  align="left" class="etiquetas_nomodi">Fecha</td>
    <td  align="left" class="etiquetas_nomodi">Prioridad</td>
    <td  align="left" class="etiquetas_nomodi">Estatus</td>
    <td  align="left" class="etiquetas_nomodi">Aseguradora</td>
    <td  align="left" class="etiquetas_nomodi">Asegurado</td>
  </tr>';

   
	$res=mysql_query($sql);
	while($r=mysql_fetch_array($res)){
      $f=date("d-m-Y", strtotime($r["fecha"]));
   $html.='
   
  <tr>
    <td class="cajatexto" align="center">'.$r["codigo"].'</td>
    <td class="cajatexto" align="left">'.$r["descripcion"].'</td>
    <td class="cajatexto" align="center">'.$f.'</td>
    <td class="cajatexto" align="left">'.$r["prioridad"].'</td>
    <td class="cajatexto" align="left">'.$r["status"].'</td>
    <td class="cajatexto" align="left">'.$r["nombre"].'</td>
    <td class="cajatexto" align="left">'.$r["nombre_rs"].'</td>
  </tr>
  '; }
  
   
  


$html.='<div style="page-break-before:auto;"></div></table>';

  $dompdf = new DOMPDF();
  ini_set("memory_limit","16M");
  $dompdf->load_html(utf8_decode($html));
  $dompdf->set_paper('letter',"portrail");
  
  
  
  $dompdf->render();
  $nombre="Siniestros ".$titulo.".pdf";
  
  
  $dompdf->stream($nombre);
  ?>
