<?php
session_start();
require("conectar.php");
/*var_dump($_POST);
exit;*/

$idu=$_POST['idasg'];
$stts=$_POST['status'];
$logo="askaskask";

switch($stts){
	case "ENVIADA":
	      $logo="enviada.png";
		  break;
		  case "EN PROCESO":
		  $logo="enproceso.png";
		  break;
		  case "APROBADA":
		  $logo="aprobada.png";
		  break;
		  case "RECHAZADA":
		  $logo="rechazada.png";
	
	}




mysql_query("UPDATE facturas SET status='$stts',logo='$logo' WHERE id='$idu'") or die(mysql_error());

	
	





?>
