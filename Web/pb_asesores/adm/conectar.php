<?

/*
//-------------------------- Conexión Michel ---------------------//
$dbhost="127.0.0.1";  // host del MySQL (generalmente localhost)
$dbusuario="root"; // aqui debes ingresar el nombre de usuario
$dbpassword="1903"; // password de acceso para el usuario de la
$db="pb_asesores";        // Seleccionamos la base con la cual trabajar
//---------------------------------------------------------------//*/



$dbhost="localhost";  // host del MySQL (generalmente localhost)
$dbusuario="root"; // aqui debes ingresar el nombre de usuario
$dbpassword="1234567-"; // password de acceso para el usuario de la
$db="pb_asesores";        // Seleccionamos la base con la cual trabajar







$conexion = mysql_connect($dbhost, $dbusuario, $dbpassword);
mysql_select_db($db, $conexion);
?>