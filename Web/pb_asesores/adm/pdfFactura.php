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
 $sql="SELECT cli.ced_rif,cli.nombre_rs,a.nombre,f.numero,f.rif,f.razon,f.fecha,f.monto,f.status FROM cliente cli INNER JOIN facturas f  ON f.id_cliente=cli.id INNER JOIN poliza_salud pv ON pv.id_asegurado=cli.id INNER JOIN aseguradora a ON a.id=pv.id_aseguradora where f.status='$ids'";
 
 }
 if($fini==""&&$ffin==""&&$ids==-1){
	 
 $sql="SELECT cli.ced_rif,cli.nombre_rs,a.nombre,f.numero,f.rif,f.razon,f.fecha,f.monto,f.status FROM cliente cli INNER JOIN facturas f  ON f.id_cliente=cli.id INNER JOIN poliza_salud pv ON pv.id_asegurado=cli.id INNER JOIN aseguradora a ON a.id=pv.id_aseguradora";
 
 }
 if(($fini!="")&($ffin!="")&($ids!=-1)){
	
	$titulo=$ids." desde ".$ffi." hasta ".$fff;
 $sql="SELECT cli.ced_rif,cli.nombre_rs,a.nombre,f.numero,f.rif,f.razon,f.fecha,f.monto,f.status FROM cliente cli INNER JOIN facturas f  ON f.id_cliente=cli.id INNER JOIN poliza_salud pv ON pv.id_asegurado=cli.id INNER JOIN aseguradora a ON a.id=pv.id_aseguradora where f.status='$ids' and f.fecha between '$fini' and '$ffin'";
 
 }
 if(($fini!="")&($ffin!="")&($ids==-1)){
	
	$titulo=" desde ".$ffi." hasta ".$fff;
 $sql="SELECT cli.ced_rif,cli.nombre_rs,a.nombre,f.numero,f.rif,f.razon,f.fecha,f.monto,f.status FROM cliente cli INNER JOIN facturas f  ON f.id_cliente=cli.id INNER JOIN poliza_salud pv ON pv.id_asegurado=cli.id INNER JOIN aseguradora a ON a.id=pv.id_aseguradora where f.fecha between '$fini' and '$ffin'";
 
 }
  

//mysql_close($conexion);

require_once("dompdf_config.inc.php");



$html='
<link href="hoja_estilo.css" rel="stylesheet" type="text/css">
<table width="100%" >
  <tr>
    <td   align="left"><img src="imagenes/asesores.png" height="50" width="50"/></td>
    <td colspan="6"  align="left"><span class="etiquetas_nomodi" ><h3>REPORTE DE FACTURAS DE REEMBOLSO '.$titulo.'</h3></span></td>
  </tr>
  <tr>
    <td colspan="7" class="etiquetas_nomodi" align="right">FECHA: '.$F.' HORA: '.$H.' USUARIO: '.$_SESSION['nombrecompleto'].'</td>
  </tr>
  <tr>
    <td class="etiquetas_nomodi" align="left">Nº</td>
    <td align="left" class="etiquetas_nomodi">Fecha</td>
    <td  align="left" class="etiquetas_nomodi">Rif</td>
    <td  align="left" class="etiquetas_nomodi">Razón</td>    
    <td  align="left" class="etiquetas_nomodi">Monto Bs.</td>
    <td  align="left" class="etiquetas_nomodi">Aseguradora</td>
	<td  align="left" class="etiquetas_nomodi">Estatus</td>
  </tr>';

   
	$res=mysql_query($sql);
	while($r=mysql_fetch_array($res)){
      $f=date("d-m-Y", strtotime($r["fecha"]));
	  $mo=number_format($r["monto"], 2, ',', '.');
   $html.='
   
  <tr>
    <td class="cajatexto" align="center">'.$r["numero"].'</td>
	<td class="cajatexto" align="center">'.$f.'</td>
    <td class="cajatexto" align="left">'.$r["rif"].'</td>  
    <td class="cajatexto" align="left">'.$r["razon"].'</td>
    <td class="cajatexto" align="left">'.$mo.'</td>
	<td class="cajatexto" align="left">'.$r["nombre"].'</td>
	<td class="cajatexto" align="left">'.$r["status"].'</td>
  </tr>
  '; }
  
   
  


$html.='<div style="page-break-before:auto;"></div></table>';

  $dompdf = new DOMPDF();
  ini_set("memory_limit","16M");
  $dompdf->load_html(utf8_decode($html));
  $dompdf->set_paper('letter',"portrail");
  
  
  
  $dompdf->render();
  $nombre="Facturas de reembolso ".$titulo.".pdf";
  
  
  $dompdf->stream($nombre);
  ?>
