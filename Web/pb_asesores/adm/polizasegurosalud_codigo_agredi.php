<?php


session_start();
require("conectar.php");
//var_dump($_POST);
//exit;

//set_time_limit(300);

function id_max($tabla){
	
	
	$strsql="SELECT MAX(id) AS id FROM ".$tabla;
	$qr=mysql_query($strsql) or die(mysql_error());
	$rw=mysql_fetch_array($qr);
	return $rw["id"];
}

$idpss=$_POST['idpss'];
$nsol=$_POST['nsol2'];
$idasg=$_POST['idasg'];
$idtom=$_POST['idtom'];
$idat=$_POST['idat'];
$ande=$_POST['ande'];
$fdes=$_POST['fdes'];
$fhas=$_POST['fhas'];
$frpag=$_POST['frpag'];
$bhcm_ded=$_POST['bhcm_ded'];
$bhcm_sa=$_POST['bhcm_sa'];
$anx_ded=$_POST['anx_ded'];
$anx_sa=$_POST['anx_sa'];
$mat_ded=$_POST['mat_ded'];
$mat_sa=$_POST['mat_sa'];
$ap_ded=$_POST['ap_ded'];
$ap_sa=$_POST['ap_sa'];
$fun_ded=$_POST['fun_ded'];
$fun_sa=$_POST['fun_sa'];
$epe_ded=$_POST['epe_ded'];
$epe_sa=$_POST['epe_sa'];
$eep_ded=$_POST['eep_ded'];
$eep_sa=$_POST['eep_sa'];
$otr_ded=$_POST['otr_ded'];
$otr_sa=$_POST['otr_sa'];
$gz=$_POST['goz_sal'];
$oq=$_POST['oper_quir'];
$pa=$_POST['prev_alg'];
$tet=$_POST['trat_enf_trans'];
$pet=$_POST['pad_enf_trans'];
$eg=$_POST['edo_grav'];
$esg=$_POST['enf_sis_dig'];
$ec=$_POST['enf_card'];
$er=$_POST['enf_resp'];
$ep=$_POST['enf_piel'];
$ev=$_POST['enf_ven'];
$te=$_POST['tras_end'];
$tn=$_POST['tras_neu'];
$tr=$_POST['tras_ren'];
$eom=$_POST['enf_osea_musc'];
$te=$_POST['tras_end'];
$epm=$_POST['enf_muj'];
$de=$_POST['det_enf'];




$tcp=$_POST['tip_cob_prim'];

$banc_cob=$_POST['banc_cob'];
$ncta_cob=$_POST['ncta_cob'];
$tcta_cob=strtoupper($_POST['tcta_cob']);

$idbtc=$_POST['banc_tc'];
$nrtc=$_POST['nr_tc'];
$ttc=strtoupper($_POST['tipo_tc']);
$fvtc=$_POST['venc_tc'];





$reemb_bco=$_POST['reemb_bco'];
$banc_reemb=$_POST['banc_reemb'];
$ncta_reemb=$_POST['ncta_reemb'];
$tcta_reemb=strtoupper($_POST['tcta_reemb']);
$fecha=$_POST['fecha'];
$lugar=strtoupper($_POST['lugar']);





if ($tcp=="TARJETA DE CREDITO"){//Modo de cobro de prima (tarjeta de crédito o cuenta bancaria)

	//echo "SELECT * FROM tarjeta_credito WHERE idbanco=$idbtc AND numero='$nrtc'";
	$query=mysql_query("SELECT * FROM tarjeta_credito WHERE idbanco=$idbtc AND numero='$nrtc'") or die(mysql_error());
	if (mysql_num_rows($query)>0){
		$cta=mysql_fetch_array($query);
		$idctacob=$cta["id"];
		//echo "UPDATE tarjeta_credito SET tipo='$ttc',fvenc='$fvtc' WHERE id=$idctacob";
		$query=mysql_query("UPDATE tarjeta_credito SET tipo='$ttc',fvenc='$fvtc' WHERE id=$idctacob") or die(mysql_error());

	}
	else {
	$query=mysql_query("INSERT INTO tarjeta_credito (idbanco,numero,tipo,fvenc)
	 VALUES ($idbtc,'$nrtc','$ttc','$fvtc')") or die(mysql_error());

	 $idctacob=id_max("tarjeta_credito");
	}

}
else {//Cobro de prima (Cuenta bancaria)

	$query=mysql_query("SELECT * FROM cuenta_bancaria_poliza WHERE idbanco=$banc_cob AND ncuenta='$ncta_cob'") or die(mysql_error());
	if (mysql_num_rows($query)>0){
		$cta=mysql_fetch_array($query);
		$idctacob=$cta["id"];
		$query=mysql_query("UPDATE cuenta_bancaria_poliza SET tipo_cuenta='$tcta_cob' WHERE id=$idctacob") or die(mysql_error());

	}
	else {
	$query=mysql_query("INSERT INTO cuenta_bancaria_poliza (idbanco,ncuenta,tipo_cuenta)
	 VALUES ($banc_cob,'$ncta_cob','$tcta_cob')") or die(mysql_error());

	 $idctacob=id_max("cuenta_bancaria_poliza");
	}
}

//Cuenta para reembolso (la del cobro de prima)
if ($reemb_bco=="COBRO DE PRIMA"){
	
	$idctareem=$idctacob;
}
else {//Otra cuenta
	
	$query=mysql_query("SELECT * FROM cuenta_bancaria_poliza WHERE idbanco=$banc_reemb AND ncuenta='$ncta_reemb'") or die(mysql_error());
	if (mysql_num_rows($query)>0){
		$cta=mysql_fetch_array($query);
		$idctareem=$cta["id"];
		$query=mysql_query("UPDATE cuenta_bancaria_poliza SET tipo_cuenta='$tcta_reemb' WHERE id=$idctareem") or die(mysql_error());

	}
	else {
	$query=mysql_query("INSERT INTO cuenta_bancaria_poliza (idbanco,ncuenta,tipo_cuenta)
	 VALUES ($banc_reemb,'$ncta_reemb','$tcta_reemb')") or die(mysql_error());


	 $idctareem=id_max("cuenta_bancaria_poliza");
	}

}
        
 



if ($idpss==""){//Inserción


	$query=mysql_query("INSERT INTO poliza_salud (id_aseguradora,id_tomador,id_asegurado,fecha,lugar,n_solicitud,a_nombre_de,fecha_desde,fecha_hasta,frec_pago,bhcm_ded,bhcm_sa,anx_ded,anx_sa,mat_ded,mat_sa,ap_ded,ap_sa,fun_ded,fun_sa,epe_ded,epe_sa,eep_ded,eep_sa,otr_ded,otr_sa,gozan_salud,oper_quir,prev_alg,trat_enf_trans,pad_enf_trans,edo_grav,enf_sist_dig,enf_cardvasc,enf_resp,enf_piel,enf_ven,tras_end,tras_neu,tras_ren,enf_os_musc,enf_prop_muj,detalle_enf,tipo_cobro_prim,id_cta_cobro,id_cta_reemb,descr_cta_reemb,imagen)
	
	 VALUES ($idasg,$idtom,$idat,'$fecha','$lugar','$nsol','$ande','$fdes','$fhas','$frpag','$bhcm_ded','$bhcm_sa','$anx_ded','$anx_sa','$mat_ded','$mat_sa','$ap_ded','$ap_sa','$fun_ded','$fun_sa','$epe_ded','$epe_sa','$eep_ded','$eep_sa','$otr_ded','$otr_sa','$gz','$oq','$pa','$tet','$pet','$eg','$esg','$ec','$er','$ep','$ev','$te','$tn','$tr','$eom','$epm','$de','$tcp',$idctacob,$idctareem,'$reemb_bco','hcm.jpg')") or die(mysql_error());

	 $idpss=id_max("poliza_salud");

	 $resp = 1;
}
else {//Modificación

	
	$query=mysql_query("UPDATE poliza_salud SET id_aseguradora=$idasg,id_tomador=$idtom,id_asegurado=$idat,fecha='$fecha',lugar='$lugar',n_solicitud='$nsol',a_nombre_de='$ande',fecha_desde='$fdes',fecha_hasta='$fhas',frec_pago='$frpag',bhcm_ded='$bhcm_ded',bhcm_sa='$bhcm_sa',anx_ded='$anx_ded',anx_sa='$anx_sa',mat_ded='$mat_ded',mat_sa='$mat_sa',ap_ded='$ap_ded',ap_sa='$ap_sa',fun_ded='$fun_ded',fun_sa='$fun_sa',epe_ded='$epe_ded',epe_sa='$epe_sa',eep_ded='$eep_ded',eep_sa='$eep_sa',otr_ded='$otr_ded',otr_sa='$otr_sa',gozan_salud='$gz',oper_quir='$oq',prev_alg='$pa',trat_enf_trans='$tet',pad_enf_trans='$pet',edo_grav='$eg',enf_sist_dig='$esg',enf_cardvasc='$ec',enf_resp='$er',enf_piel='$ep',enf_ven='$ev',tras_end='$te',tras_neu='$tn',tras_ren='$tr',enf_os_musc='$eom',enf_prop_muj='$epm',detalle_enf='$de',tipo_cobro_prim='$tcp',id_cta_cobro=$idctacob,id_cta_reemb=$idctareem,descr_cta_reemb='$reemb_bco' WHERE id=$idpss") or die(mysql_error());

	$resp = 2;

	$query=mysql_query("DELETE FROM beneficiario_poliza WHERE id_poliza=$idpss") or die(mysql_error());
	$query=mysql_query("DELETE FROM grupo_poliza WHERE id_poliza=$idpss") or die(mysql_error());
	$query=mysql_query("DELETE FROM intermediario_poliza WHERE id_poliza=$idpss AND tipo_poliza='SALUD'") or die(mysql_error());
}


$max=(int)$_POST['max'];





for ($i=1;$i<=$max; $i++){//Recorrido de Beneficiarios

	if (isset($_POST['ced_ben'.(string)$i])){

		$ced=$_POST['ced_ben'.(string)$i];
		$nom=$_POST['nom_ben'.(string)$i];
		$par=$_POST['par_ben'.(string)$i];
		$ppar=$_POST['ppar_ben'.(string)$i];

		$query=mysql_query("SELECT * FROM beneficiario WHERE cedula='$ced'") or die(mysql_error());
		if (mysql_num_rows($query)>0){
			$fl=mysql_fetch_array($query);
			$idbn=$fl["id"];

			//echo "UPDATE beneficiario SET cedula='$ced',nombre='$nom',parentesco='$par',porc_part='$ppar' WHERE id=$idbn";

			$query2=mysql_query("UPDATE beneficiario SET cedula='$ced',nombre='$nom',parentesco='$par',porc_part='$ppar' WHERE id=$idbn") or die(mysql_error());
			
		}
		else {

			
			
			$query2=mysql_query("INSERT INTO beneficiario (cedula,nombre,parentesco,porc_part) VALUES ('$ced','$nom','$par','$ppar')") or die(mysql_error());

			$idbn=id_max("beneficiario");
		}

		$query3=mysql_query("INSERT INTO beneficiario_poliza (id_poliza,id_benf) VALUES ($idpss,$idbn)") or die(mysql_error());

	}
}





$max=(int)$_POST['max2'];

for ($i=1;$i<=$max; $i++){//Recorrido de Grupos

	if (isset($_POST['ced_gru'.(string)$i])){

		$ced=$_POST['ced_gru'.(string)$i];
		$nom=$_POST['nom_gru'.(string)$i];
		$fnac=$_POST['fnac_gru'.(string)$i];
		$sex=$_POST['sex_gru'.(string)$i];
		$kgs=$_POST['kgs_gru'.(string)$i];
		$par=$_POST['par_gru'.(string)$i];
		$mat=$_POST['mat_gru'.(string)$i];

		

		$query=mysql_query("SELECT * FROM grupo WHERE cedula='$ced'") or die(mysql_error());
		if (mysql_num_rows($query)>0){
			$fl=mysql_fetch_array($query);
			$idgr=$fl["id"];

			$query2=mysql_query("UPDATE grupo SET cedula='$ced',nombre='$nom',fnac='$fnac',sexo='$sex',kgs='$kgs',parentesco='$par',maternidad='$mat' WHERE id=$idgr") or die(mysql_error());
			
		}
		else {
			
			//echo "INSERT INTO grupo (cedula,nombre,fnac,sexo,kgs,parentesco,maternidad) VALUES ('$ced','$nom','$fnac','$sex','$kgs','$par','$mat')";

			$query2=mysql_query("INSERT INTO grupo (cedula,nombre,fnac,sexo,kgs,parentesco,maternidad) VALUES ('$ced','$nom','$fnac','$sex','$kgs','$par','$mat')") or die(mysql_error());

			$idgr=id_max("grupo");
		}

		$query3=mysql_query("INSERT INTO grupo_poliza (id_poliza,id_grupo) VALUES ($idpss,$idgr)") or die(mysql_error());

	}
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

		$query3=mysql_query("INSERT INTO intermediario_poliza (id_poliza,id_interm,tipo_poliza) VALUES ($idpss,$idin,'SALUD')") or die(mysql_error());

	}
}



echo $resp;
?>