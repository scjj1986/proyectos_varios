<?php
session_start();
require("conectar.php");

$idedo=$_POST["idedo"];

$consulta=mysql_query("SELECT * FROM municipio where id_estado=$idedo");

$lista= array();

while($rw=mysql_fetch_array($consulta)){


	$nom=$rw[2];
	$id=$rw[0];
	$lista[] = array('nombre'=> $nom, 'id'=> $id);


}
echo json_encode($lista);



?>
