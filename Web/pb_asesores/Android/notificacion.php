<?php
$cliente=$_POST["cedu"];
$des=$_POST["des"];
$hora=$_POST["hora"];
$fecha=$_POST["fecha"];
$donde=$_POST["donde"];
$img=$_POST["img"];
$prio=$_POST["prio"];

$con = mysql_connect("127.0.0.1","root","1903") or die("Sin conexion");
	 mysql_select_db("pb_asesores");
	 $rs1=mysql_query("select id from cliente where ced_rif=$cliente" );
	while($ids=mysql_fetch_assoc($rs1)){
              $id=$ids['id'];
}
 $rs2=mysql_query("select max(id) as num from notificacion");
	while($ids1=mysql_fetch_assoc($rs2)){
              $num=$ids1['num']+1;
}
$cod="SNST".$num."-".$cliente;
	 
	 echo $sql="insert into notificacion(id_cliente,descripcion,hora,fecha,donde,imagen,status,codigo,logo,prioridad)values
	 ('$id','$des','$hora','$fecha','$donde','$img','ENVIADA','$cod','enviada.png','$prio')";
	 $result=mysql_query($sql,$con);
mysql_close($con);	
 echo $result;

 ?>