<?php
session_start();
require("conectar.php");

$cod=$_POST["cod"];



$consulta=mysql_query("SELECT * FROM intermediario WHERE codigo='$cod'");

$lista= array();

while($rw=mysql_fetch_array($consulta)){

	
	$lista[] = array('nom'=> $rw["nombre"],'ppar'=> $rw["porc_part"]);


}
echo json_encode($lista);

?>