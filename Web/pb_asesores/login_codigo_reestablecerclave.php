<?php
session_start();
require("conectar.php");
/*var_dump($_POST);
exit;*/
$lg=strtoupper($_POST['lg']);
$pss=$_POST['pss'];

$consulta=mysql_query("UPDATE usuario SET clave='$pss' WHERE login='$lg'") or die(mysql_error());

echo 1;


?>
