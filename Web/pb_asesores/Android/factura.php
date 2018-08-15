<?php
$cliente=$_POST["cedu"];
$num=$_POST["num"];
$rif=$_POST["rif"];
$razon=$_POST["razon"];
$fecha=$_POST["fecha"];
$monto=$_POST["monto"];
$img=$_POST["img"];


$con = mysql_connect("127.0.0.1","root","1903") or die("Sin conexion");
	 mysql_select_db("pb_asesores");
	 $rs1=mysql_query("select id from cliente where ced_rif=$cliente" );
	while($ids=mysql_fetch_assoc($rs1)){
              $id=$ids['id'];
}
 
	 
	 echo $sql="insert into facturas(id_cliente,numero,rif,razon,fecha,monto,imagen,status,logo)values
	 ('$id','$num','$rif','$razon','$fecha','$monto','$img','ENVIADA','enviada.png')";
	 $result=mysql_query($sql,$con);
mysql_close($con);	
 echo $result;

 ?>