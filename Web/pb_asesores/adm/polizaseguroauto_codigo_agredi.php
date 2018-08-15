<?php

session_start();
require("conectar.php");
//var_dump($_POST);
//exit;

function id_max($tabla){
	
	
	$strsql="SELECT MAX(id) AS id FROM ".$tabla;
	$qr=mysql_query($strsql) or die(mysql_error());
	$rw=mysql_fetch_array($qr);
	return $rw["id"];
}

$idpsa=$_POST['idpsa'];
$tipo=$_POST['tiposol'];
$nsol=$_POST['nsol2'];
$idasg=$_POST['idasg'];
$idtom=$_POST['idtom'];
$idat=$_POST['idat'];
$ande=$_POST['ande'];
$fdes=$_POST['fdes'];
$fhas=$_POST['fhas'];


$placa=strtoupper($_POST['placa']);
$marca=strtoupper($_POST['marca']);
$modelo=strtoupper($_POST['modelo']);
$anio=$_POST['anio'];

$color=strtoupper($_POST['color']);
$smot=strtoupper($_POST['smot']);
$scar=strtoupper($_POST['scar']);

$trans=strtoupper($_POST['trans']);
$uveh=strtoupper($_POST['uveh']);
$tcar=strtoupper($_POST['tcar']);

$npas=$_POST['npas'];
$peso=$_POST['peso'];
$tons=$_POST['tons'];

$uhveh=$_POST['uhveh'];

$upor=$_POST['upor'];
$glic=$_POST['glic'];
$aexp=$_POST['aexp'];

$amp_sa=$_POST['amp_sa'];
$aded_sa=$_POST['aded_sa'];
$apf_sa=$_POST['apf_sa'];
$pt_sa=$_POST['pt_sa'];
$id_sa=$_POST['id_sa'];

$rrcd_sa=$_POST['rrcd_sa'];
$aa_sa=$_POST['aa_sa'];
$otr_sa=$_POST['otr_sa'];


$rcv_sa=$_POST['rcv_sa'];
$aldp_sa=$_POST['aldp_sa'];
$el_sa=$_POST['el_sa'];

$at=$_POST['at'];
$m_sa=$_POST['m_sa'];
$inv_sa=$_POST['inv_sa'];
$gmc_sa=$_POST['gmc_sa'];
$ge_sa=$_POST['ge_sa'];
$fecha=$_POST['fecha'];
$lugar=strtoupper($_POST['lugar']);









if ($idpsa==""){

	
	 
	$query=mysql_query("INSERT INTO poliza_vehiculo (id_aseguradora,id_tomador,id_asegurado,n_solicitud,fecha,lugar,a_nombre_de,tipo,fecha_desde,fecha_hasta,bien,placa,marca,modelo,anio,color,serial_motor,serial_carroceria,uso_vehiculo,tipo_carga,transmision,npasajeros,kgs,tons,uhv,up,a_exp,licencia,amp_sa,amp_ded_sa,apf_sa,pt_sa,idd_sa,rrcd_sa,aa_sa,descr_otro,otro_sa,rcv_sa,aldp_sa,el_sa,at,muerte_sa,invalidez_sa,gmc_sa,ge_sa,imagen)
	
	 VALUES ($idasg,$idtom,$idat,'$nsol','$fecha','$lugar','$ande','$tipo','$fdes','$fhas',' ','$placa','$marca','$modelo',$anio,'$color','$smot','$scar','$uveh','$tcar','$trans',$npas,'$peso','$tons','$uhveh','$upor',$aexp,'$glic','$amp_sa','$aded_sa','$apf_sa','$pt_sa','$id_sa','$rrcd_sa','$aa_sa',' ','$otr_sa','$rcv_sa','$aldp_sa','$el_sa','$at','$m_sa','$inv_sa','$gmc_sa','$ge_sa','automovil.jpg')") or die(mysql_error());

	 $idpsa = id_max("poliza_vehiculo");


	$resp= 1;
}
else {

	

	
	
	$query=mysql_query("UPDATE poliza_vehiculo SET id_aseguradora=$idasg,id_tomador=$idtom,id_asegurado=$idat,fecha='$fecha',lugar='$lugar',n_solicitud='$nsol',a_nombre_de='$ande',fecha_desde='$fdes',fecha_hasta='$fhas',bien=' ',placa='$placa',marca='$marca',modelo='$modelo',anio=$anio,color='$color',serial_motor='$smot',serial_carroceria='$scar',uso_vehiculo='$uveh',tipo_carga='$tcar',transmision='$trans',npasajeros=$npas,kgs='$peso',tons='$tons',uhv='$uhveh',up='$upor',a_exp=$aexp,licencia='$glic',amp_sa='$amp_sa',amp_ded_sa='$aded_sa',apf_sa='$apf_sa',pt_sa='$pt_sa',idd_sa='$id_sa',rrcd_sa='$rrcd_sa',aa_sa='$aa_sa',descr_otro=' ',otro_sa='$otr_sa',rcv_sa='$rcv_sa',aldp_sa='$aldp_sa',el_sa='$el_sa',at='$at',muerte_sa='$m_sa',invalidez_sa='$inv_sa',gmc_sa='$gmc_sa',ge_sa='$ge_sa' WHERE id=$idpsa") or die(mysql_error());

	$query=mysql_query("DELETE FROM intermediario_poliza WHERE id_poliza=$idpsa AND tipo_poliza='AUTOMOVIL'") or die(mysql_error());


	

	$resp = 2;
}



$max=(int)$_POST['max3'];

for ($i=1;$i<=$max; $i++){//Recorrido de Intermediarios

	if (isset($_POST['cod_int'.(string)$i])){

		$cod=$_POST['cod_int'.(string)$i];
		$nom=$_POST['nom_int'.(string)$i];
		$ppar=$_POST['ppar_int'.(string)$i];

		$query=mysql_query("SELECT * FROM intermediario WHERE codigo='$ced'") or die(mysql_error());
		if (mysql_num_rows($query)>0){
			$fl=mysql_fetch_array($query);
			$idin=$fl["id"];

			//echo "UPDATE intermediario SET codigo='$cod',nombre='$nom',porc_part='$ppar' WHERE id=$idin";

			$query2=mysql_query("UPDATE intermediario SET codigo='$cod',nombre='$nom',porc_part='$ppar' WHERE id=$idin") or die(mysql_error());
			
		}
		else {
			
			$query2=mysql_query("INSERT INTO intermediario (codigo,nombre,porc_part) VALUES ('$cod','$nom','$ppar')") or die(mysql_error());

			$idin=id_max("intermediario");
		}

		$query3=mysql_query("INSERT INTO intermediario_poliza (id_poliza,id_interm,tipo_poliza) VALUES ($idpsa,$idin,'AUTOMOVIL')") or die(mysql_error());

	}
}




echo $resp;
?>