<?php
session_start();
require("conectar.php");
$ced=$_POST["ced"];
$consulta=mysql_query("SELECT * FROM beneficiario WHERE cedula='$ced'");
$lista= array();
while($rw=mysql_fetch_array($consulta)){
	$lista[] = array('nom'=> $rw["nombre"],'par'=> $rw["parentesco"],'ppar'=> $rw["porc_part"]);
}
echo json_encode($lista);
?>