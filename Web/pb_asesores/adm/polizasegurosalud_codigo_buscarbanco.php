<?php
session_start();
require("conectar.php");

$idb=$_POST["idb"];
$nr=$_POST["nr"];



$consulta=mysql_query("SELECT * FROM cuenta_bancaria_poliza WHERE idbanco=$idb AND ncuenta='$nr'");

$lista= array();

while($rw=mysql_fetch_array($consulta)){

	
	$lista[] = array('tc'=> $rw["tipo_cuenta"]);


}
echo json_encode($lista);

?>