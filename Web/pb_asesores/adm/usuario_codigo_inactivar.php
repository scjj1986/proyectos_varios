<?php
session_start();
require("conectar.php");
/*var_dump($_POST);
exit;*/

$idu=$_POST['id'];





	
$consulta=mysql_query("SELECT * FROM usuario WHERE id='$idu'") or die(mysql_error());

$r=mysql_fetch_array($consulta);

if($r['activo']=='SI')
	$consulta=mysql_query("UPDATE usuario SET activo='NO' WHERE id=$idu") or die(mysql_error());
else
    
	$consulta=mysql_query("UPDATE usuario SET activo='SI' WHERE id=$idu") or die(mysql_error());

		


	
	
	








?>
