<?php

session_start();
require("conectar.php");

//var_dump($_POST);
//exit();

$id=$_POST["id"];
$idpsa=$_POST["idpsa"];

$consulta=mysql_query("SELECT * FROM poliza_vehiculo WHERE id_aseguradora=$id") or die(mysql_error());
$nreg=mysql_num_rows($consulta);
$correlativo="";

$nreg++;
if ($id==5)//Caracas
	$correlativo="75-56-";
else if ($id==7)//Uniseguros
	$correlativo="1-29-";
else if ($id==8)//La Previsora
	$correlativo="AUTO-002401-";




if ($nreg<9)
	$correlativo=$correlativo."00000".(string)$nreg;
else if ($nreg<99)
	$correlativo="0000".(string)$nreg;
else if ($nreg<999)
	$correlativo="000".(string)$nreg;
else if ($nreg<9999)
	$correlativo="00".(string)$nreg;
else if ($nreg<99999)
	$correlativo="0".(string)$nreg;
else
	$correlativo=(string)$nreg;


if ($idpsa!=""){
	$consulta=mysql_query("SELECT * FROM poliza_vehiculo WHERE id=$idpsa") or die(mysql_error());
	$row=mysql_fetch_array($consulta);

	if ($id==$row["id_aseguradora"])
		$correlativo=$row["n_solicitud"];

}

$lista= array();
$lista[] = array('correl'=> $correlativo);

echo json_encode($lista);





?>