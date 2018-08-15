<?php

  $nombre=$_POST["usuario"];
  $pass=$_POST["pass"]; 
  
     $con = mysql_connect("127.0.0.1","root","1903") or die("Sin conexion");
	 mysql_select_db("pb_asesores");
  
	
  $rs=mysql_query("select * from usuario where login='$nombre' and clave='$pass'");
  while($row=mysql_fetch_assoc($rs)){
       $datos[] = $row;
  }
  mysql_close($con);
    print(json_encode($datos)); 
 
 
?>