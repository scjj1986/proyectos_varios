<?php
session_start();
require("conectar.php");

$idb=$_POST["idb"];
$nr=$_POST["nr"];



$consulta=mysql_query("SELECT * FROM tarjeta_credito WHERE idbanco=$idb AND numero='$nr'");

$lista= array();

while($rw=mysql_fetch_array($consulta)){

	
	$lista[] = array('tc'=> $rw["tipo"],'fven'=> $rw["fvenc"]);


}
echo json_encode($lista);

?>