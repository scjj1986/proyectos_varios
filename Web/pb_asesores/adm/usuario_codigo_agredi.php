<?php
session_start();
require("conectar.php");
/*var_dump($_POST);
exit;*/

$idu=$_POST['idu'];
$tp=$_POST['tp'];
$doc=$_POST['doc'];
$nom=strtoupper($_POST['nombre']);
$ape=strtoupper($_POST['apellido']);
$perf=$_POST['perfil'];
$ps=$_POST['ps'];
$rs=$_POST['rs'];
$pss=$_POST['pss'];
$act=$_POST['act'];


$lg=strtoupper($_POST['lg']);
$pss=$_POST['pss'];

if ($idu==""){
	
	$consulta=mysql_query("SELECT * FROM usuario WHERE login='$doc'") or die(mysql_error());

}
else {
	
	$consulta=mysql_query("SELECT * FROM usuario WHERE login='$doc' and id<>$idu ") or die(mysql_error());
}


if (mysql_num_rows($consulta)>0){
	
	echo -1;
}
else {

	if ($idu==""){
	
		$consulta=mysql_query("INSERT INTO usuario (tipo_persona,documento,nombres,apellidos,perfil,login,clave,pregunta,respuesta,activo) VALUES ('$tp','$doc','$nom','$ape','$perf','$doc','$pss','$ps','$rs','SI')") or die(mysql_error());
	}
	else {

		$consulta=mysql_query("UPDATE usuario SET tipo_persona='$tp',documento='$doc',nombres='$nom',apellidos='$ape',perfil='$perf',login='$doc',clave='$pss',pregunta='$ps',respuesta='$rs',activo='$act' WHERE id=$idu") or die(mysql_error());


		if ($idu==$_SESSION['idu']){

			$qr=mysql_query("SELECT * FROM usuario WHERE id=$idu AND activo='NO'") or die(mysql_error());
			$qr2=mysql_query("SELECT * FROM usuario WHERE id=$idu AND perfil<>'ADMINISTRADOR'") or die(mysql_error());
			//echo mysql_num_rows($qr);
			
			if (mysql_num_rows($qr)>0){
				echo -2;

			}


			else if(mysql_num_rows($qr2)>0){
				echo -3;

			}
			else {
				$_SESSION['nombrecompleto']=$nom." ".$ape;
				echo 1;
			}
			

		}
		else {
			
			echo 2;
		}


	}

	
	

}






?>
