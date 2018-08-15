<?php
  $cd=$_GET["num"];
  $tip=$_GET["tp"];
 // $pass=$_POST["pass"]; 
  
     $con = mysql_connect("127.0.0.1","root","1903") or die("Sin conexion");
	 mysql_select_db("pb_asesores");
if($tip=='VEHICULO'){
	$rs1=mysql_query("select id from poliza_vehiculo  where n_solicitud='$cd'" );
	
	
	
	while($ids=mysql_fetch_assoc($rs1)){
              $id=$ids['id'];
	}
   
       
    $rs=mysql_query("SELECT pv.n_solicitud, DATE_FORMAT( pv.fecha_desde,  '%d-%m-%Y' ) AS fecha_desde, DATE_FORMAT( pv.fecha_hasta,  '%d-%m-%Y' ) AS fecha_hasta, pv.imagen, c.nombre_rs, c.tipo_persona, c.ced_rif, a.nombre, a.direccion, pv.placa, pv.marca, pv.modelo, pv.anio, pv.color, pv.serial_motor, pv.serial_carroceria, pv.amp_sa, pv.apf_sa, pv.idd_sa, pv.rrcd_sa, pv.aa_sa, pv.otro_sa, pv.rcv_sa, pv.aldp_sa, pv.el_sa, pv.muerte_sa, pv.invalidez_sa, pv.ge_sa,pv.amp_ded_sa,pv.pt_sa,pv.gmc_sa
FROM poliza_vehiculo pv
INNER JOIN cliente c ON pv.id_asegurado = c.id
INNER JOIN aseguradora a ON a.id = pv.id_aseguradora
WHERE pv.id =  '$id'");
  while($row=mysql_fetch_assoc($rs)){
       $datos[] = $row;
  }
    mysql_close($con);
    print(json_encode($datos)); 
 
}else{
	
	$rs1=mysql_query("select id from poliza_salud  where n_solicitud='$cd'" );
	
	
	
	while($ids=mysql_fetch_assoc($rs1)){
              $id=$ids['id'];
	}
   
       
    $rs=mysql_query("select ps.n_solicitud,date_format(ps.fecha_desde,'%d-%m-%Y') AS fecha_desde,date_format(ps.fecha_hasta,'%d-%m-%Y') AS fecha_hasta,ps.imagen,c.nombre_rs,c.tipo_persona,c.ced_rif,a.nombre,a.direccion,ps.frec_pago,ps.bhcm_sa,ps.anx_sa,ps.mat_sa,ps.ap_sa,ps.fun_sa,ps.epe_sa,ps.eep_sa,otr_sa from poliza_salud ps inner join cliente c on ps.id_asegurado=c.id inner join aseguradora a on a.id=ps.id_aseguradora where ps.id='$id' ");
  while($row=mysql_fetch_assoc($rs)){
       $datos[] = $row;
  }
    mysql_close($con);
    print(json_encode($datos)); 
	
	
	
	
	
	}
?>