<?php
  $cd=$_GET["cd"];
 // $pass=$_POST["pass"]; 
  
     $con = mysql_connect("127.0.0.1","root","1903") or die("Sin conexion");
	 mysql_select_db("pb_asesores");

	$rs1=mysql_query("select id from cliente where ced_rif=$cd" );
	while($ids=mysql_fetch_assoc($rs1)){
              $id=$ids['id'];
}
   
       
    $rs=mysql_query("select n_solicitud,date_format(fecha_desde,'%d-%m-%Y') AS fecha_desde,date_format(fecha_hasta,'%d-%m-%Y') AS fecha_hasta,imagen,nombre_rs from poliza_salud inner join cliente on poliza_salud.id_asegurado=cliente.id
	where poliza_salud.id_asegurado=$id union select numero,date_format(fecha_desde,'%d-%m-%Y') AS fecha_desde,date_format(fecha_hasta,'%d-%m-%Y') AS fecha_hasta,imagen,nombre_rs from poliza_vehiculo inner join cliente on poliza_vehiculo.id_asegurado=cliente.id
	where poliza_vehiculo.id_asegurado=$id ");
  while($row=mysql_fetch_assoc($rs)){
       $datos[] = $row;
  }
    mysql_close($con);
    print(json_encode($datos)); 
 
 
?>