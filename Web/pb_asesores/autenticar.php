<?php
session_start();
require("conectar.php");
/*var_dump($_POST);
exit;*/
$login=strtoupper($_POST['login']);
$clave=$_POST['clave'];

$consulta=mysql_query("SELECT * FROM usuario WHERE  login='$login' and clave='$clave' AND activo='SI'") or die(mysql_error());

if(!$resultado=mysql_fetch_array($consulta)){

echo -1;

}
else{
	$qr3=mysql_query("SELECT * FROM usuario WHERE login='$login'") or die(mysql_error());
	$rs=mysql_fetch_array($qr3);
	//$_SESSION['login']=$usuario;
	$_SESSION['nombrecompleto']=$nombrecompleto=$rs['nombres']." ".$rs['apellidos'];
	//$nombrecompleto=$rs['nombre']." ".$rs['apellido'];
	$_SESSION['perfil']=$perfil=$rs['perfil'];
	//$_SESSION['usuario']=$usuario;
	$_SESSION['idu']=$idus=$rs['id'];
	if($resultado['perfil']=="ADMINISTRADOR"){
		echo 1;
	}
	/*
	else{

		echo 2;

	}*/
	

}


?>
