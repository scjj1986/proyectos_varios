<?php
session_start();
require("conectar.php");

$tp=$_POST['tp'];
$doc=$_POST['doc'];



$consulta=mysql_query("SELECT * FROM persona_contacto WHERE tipo_persona =  '$tp' AND documento='$doc'");

$lista= array();

while($rw=mysql_fetch_array($consulta)){


	$nom=$rw[3];
	$ape=$rw[4];
	$dir=$rw[5];
	$tlf=$rw[6];
	$tlf2=$rw[7];



	$lista[] = array('nom'=> $nom, 'ape'=> $ape,'dir'=> $dir,'tlf'=> $tlf,'tlf2'=> $tlf2);


}
echo json_encode($lista);



?>
