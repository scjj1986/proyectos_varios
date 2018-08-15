<?php
session_start();
require("conectar.php");
/*var_dump($_POST);
exit;*/

$idasg=$_POST['idasg'];
$nom=strtoupper($_POST['nombre']);
$dir=strtoupper($_POST['direccion']);
$act=$_POST['act'];
$tppc=$_POST['tppc'];
$docpc=$_POST['docpc'];
$nompc=strtoupper($_POST['nompc']);
$apepc=strtoupper($_POST['apepc']);
$dirpc=strtoupper($_POST['dirpc']);

$tlf1pc=$_POST['tlf1pc'];
$tlf2pc=$_POST['tlf2pc'];

if ($idasg==""){
	
	$consulta=mysql_query("SELECT * FROM aseguradora WHERE nombre='$nom'") or die(mysql_error());

}
else {
	
	$consulta=mysql_query("SELECT * FROM aseguradora WHERE nombre='$nom' AND id<>$idasg") or die(mysql_error());
}


if (mysql_num_rows($consulta)>0){
	
	echo -1;
}
else {

	$consulta2=mysql_query("SELECT * FROM persona_contacto WHERE tipo_persona='$tppc' AND documento='$docpc'") or die(mysql_error());
	if (mysql_num_rows($consulta2)>0){//Si la persona_contacto existe en la base de datos, se copia el id y se modifica
	
			$rw=mysql_fetch_array($consulta2);
			$idpc=$rw["id"];
			$consulta3=mysql_query("UPDATE persona_contacto SET tipo_persona='$tppc',documento='$docpc',nombre='$nompc',apellido='$apepc',direccion='$dirpc',tlf1='$tlf1pc',tlf2='$tlf2pc' WHERE id=$idpc") or die(mysql_error());
			
		}
		else {//Si no está, se inserta y se copia el id
			$consulta3=mysql_query("INSERT INTO persona_contacto (tipo_persona,documento,nombre,apellido,direccion,tlf1,tlf2) VALUES ('$tppc','$docpc','$nompc','$apepc','$dirpc','$tlf1pc','$tlf2pc')") or die(mysql_error());

			$consulta3=mysql_query("SELECT * FROM persona_contacto WHERE tipo_persona='$tppc' AND documento='$docpc'") or die(mysql_error());

			$rw=mysql_fetch_array($consulta3);
			$idpc=$rw["id"];
		}

	if ($idasg==""){//Ingresar

		$consulta3=mysql_query("INSERT INTO aseguradora (nombre,direccion,idpc,activo) VALUES ('$nom','$dir',$idpc,'SI')") or die(mysql_error());
	}
	else {//Editar

		$consulta3=mysql_query("UPDATE aseguradora SET nombre='$nom',direccion='$dir',idpc=$idpc,activo='$act' WHERE id=$idasg") or die(mysql_error());
	}

	echo 1;

}






?>
