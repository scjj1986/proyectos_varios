<?php
session_start();
require("conectar.php");

$ced=$_POST["ced"];



$consulta=mysql_query("SELECT * FROM grupo WHERE cedula='$ced'");

$lista= array();

while($rw=mysql_fetch_array($consulta)){

	
	$lista[] = array('nom'=> $rw["nombre"],'fnac'=> $rw["fnac"],'kgs'=> $rw["kgs"],'sex'=> $rw["sexo"],'par'=> $rw["parentesco"],'mat'=> $rw["maternidad"]);


}
echo json_encode($lista);

?>