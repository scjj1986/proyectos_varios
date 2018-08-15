<?php
session_start();
require("conectar.php");

$id=$_POST["id"];



$consulta=mysql_query("SELECT ps.id,ps.n_solicitud,asg.nombre as nomaseg,cli.nombre_rs as aseg FROM poliza_vehiculo ps INNER JOIN cliente cli ON ps.id_asegurado=cli.id INNER JOIN aseguradora asg ON ps.id_aseguradora=asg.id WHERE ps.id=$id");

$lista= array();

while($rw=mysql_fetch_array($consulta)){

	
	$lista[] = array('id'=> $rw["id"],'nsol'=> $rw["n_solicitud"],'nomaseg'=> $rw["nomaseg"],'aseg'=> $rw["aseg"]);


}
echo json_encode($lista);

?>