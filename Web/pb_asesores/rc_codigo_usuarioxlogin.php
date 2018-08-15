<?php
session_start();
require("conectar.php");

$log=$_POST['log'];



$consulta=mysql_query("SELECT * FROM usuario WHERE login =  '$log' AND activo='SI'");

$lista= array();

while($rw=mysql_fetch_array($consulta)){


	$prg=$rw[8];
	$rsp=$rw[9];



	$lista[] = array('pregunta'=> $prg, 'respuesta'=> $rsp);


}
echo json_encode($lista);



?>
