<?php 
session_start();
$conexion = mysql_connect ("127.0.0.1", "root" , "1903") or trigger_error (mysql_error() ,E_USER_ERROR);
mysql_select_db("encuestac");

?>