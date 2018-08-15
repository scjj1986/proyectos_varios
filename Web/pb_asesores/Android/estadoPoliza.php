<?php
  $cd=$_GET["num"];
  $ced=$_GET["cedu"];
  $tp=$_GET["tp"];
 // $pass=$_POST["pass"]; 
  
     $con = mysql_connect("127.0.0.1","root","1903") or die("Sin conexion");
	 mysql_select_db("pb_asesores");

	$rs1=mysql_query("select id from cliente  where ced_rif='$ced'" );
	
	
	
	while($ids=mysql_fetch_assoc($rs1)){
              $id=$ids['id'];
	}
	
	if($tp=='VEHICULO')
		$rs2=mysql_query("select id from poliza_vehiculo  where n_solicitud='$cd'" );
	else
	    $rs2=mysql_query("select id from poliza_salud  where n_solicitud='$cd'" );
	
	
	
	while($idsP=mysql_fetch_assoc($rs2)){
              $idp=$idsP['id'];
	}
  
       
    $rs=mysql_query("select numero,DATE_FORMAT(fecha,'%d-%m-%Y' )as fecha,monto,status from financiamiento where id_cliente='$id' and id_poliza='$idp'");
  while($row=mysql_fetch_assoc($rs)){
       $datos[] = $row;
  }
    mysql_close($con);
    print(json_encode($datos)); 
 

	
	
?>