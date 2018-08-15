<?php
  $cd=$_GET["cd"];
 // $pass=$_POST["pass"]; 
  
     $con = mysql_connect("127.0.0.1","root","1903") or die("Sin conexion");
	 mysql_select_db("pb_asesores");

	$rs1=mysql_query("select id from cliente where ced_rif=$cd" );
	while($ids=mysql_fetch_assoc($rs1)){
              $id=$ids['id'];
}
   
       
    $rs=mysql_query("select codigo,date_format(fecha,'%d-%m-%Y') AS fecha,descripcion,status,logo,nombre_rs from notificacion inner join cliente on notificacion.id_cliente=cliente.id where notificacion.id_cliente=$id");
  while($row=mysql_fetch_assoc($rs)){
       $datos[] = $row;
  }
    mysql_close($con);
    print(json_encode($datos)); 
 
 
?>