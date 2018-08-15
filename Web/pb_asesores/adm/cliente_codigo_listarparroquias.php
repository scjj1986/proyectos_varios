<?php
session_start();
require("conectar.php");

$idmun=$_POST["idmun"];

$consulta=mysql_query("SELECT * FROM parroquia where id_municipio=$idmun");

$lista= array();

while($rw=mysql_fetch_array($consulta)){


	$nom=$rw[2];
	$id=$rw[0];
	$lista[] = array('nombre'=> $nom, 'id'=> $id);


}
echo json_encode($lista);



?>
