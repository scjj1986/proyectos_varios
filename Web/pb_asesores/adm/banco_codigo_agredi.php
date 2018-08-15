<?
session_start();
require("conectar.php");

$idb=$_POST['idb'];
$nom=strtoupper($_POST['nombre']);

if ($idb=="")
	$consulta=mysql_query("SELECT * FROM banco WHERE nombre='$nom'") or die(mysql_error());
else 
	$consulta=mysql_query("SELECT * FROM banco WHERE nombre='$nom' AND id<>$idb") or die(mysql_error());

if (mysql_num_rows($consulta)>0){
	echo -1;
	exit;
}

if ($idb=="")
	$consulta3=mysql_query("INSERT INTO banco (nombre) VALUES ('$nom')") or die(mysql_error());
else 
	$consulta3=mysql_query("UPDATE banco SET nombre='$nom' WHERE id=$idb") or die(mysql_error());


echo 1;	
?>