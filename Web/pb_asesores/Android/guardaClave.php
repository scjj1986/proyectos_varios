<?php
  $id=$_POST["user"];
  $clave=$_POST["clave"];
 // $pass=$_POST["pass"]; 
  
     $con = mysql_connect("127.0.0.1","root","1903") or die("Sin conexion");
	 mysql_select_db("pb_asesores");

	
	echo $sql="update usuario set clave='$clave' where id='$id'";
       
    $rs=mysql_query($sql,$con);

 mysql_close($con);
 echo $rs;
?>