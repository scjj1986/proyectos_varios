<?php
session_start();
require("conectar.php");

$consulta=mysql_query("SELECT * FROM estado");

$lista= array();

while($rw=mysql_fetch_array($consulta)){

	$nom=$rw[1];
	$id=$rw[0];
	$lista[] = array('nombre'=> $nom, 'id'=> $id);


}
echo json_encode($lista);

?>