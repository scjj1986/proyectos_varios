<?php

session_start();
require("conectar.php");
//var_dump($_POST);
//exit;

$idcli=$_POST['idcli'];

$tp=$_POST['tp'];
$cedrif=$_POST['cedrif'];
$nomrs=strtoupper($_POST['nomrs']);
$natemp=$_POST['natemp'];
$fnac=$_POST['fnac'];
$sexo=$_POST['sexo'];
$ec=$_POST['ec'];
$inganu=$_POST['inganu'];
$acteco=$_POST['acteco'];
$ocu=strtoupper($_POST['ocu']);
$idedo=$_POST['edo'];
$ciu=strtoupper($_POST['ciu']);
$idmun=$_POST['mun'];
$idpar=$_POST['par'];
$usb=strtoupper($_POST['usb']);
$egcq=strtoupper($_POST['egcq']);
$vp=strtoupper($_POST['vp']);
$vizq=strtoupper($_POST['vizq']);
$vder=strtoupper($_POST['vder']);
$tsa=strtoupper($_POST['tsa']);
$pn=strtoupper($_POST['pn']);
$loa=strtoupper($_POST['loa']);
$ref=strtoupper($_POST['ref']);
$otro=strtoupper($_POST['otro']);
$cp=$_POST['cp'];
$tlfh=$_POST['tlfh'];
$tlfo=$_POST['tlfo'];
$tlfc=$_POST['tlfc'];
$email=$_POST['email'];
$fax=$_POST['fax'];

if ($tp!="J"){
	
	$natemp="N/A";
}
else {
	
	$ec="OTRO";
}

if ($idcli==""){
	
	$consulta=mysql_query("SELECT * FROM cliente WHERE tipo_persona='$tp' AND ced_rif='$cedrif'") or die(mysql_error());

}
else {
	
	$consulta=mysql_query("SELECT * FROM cliente WHERE id<>$idcli AND tipo_persona='$tp' AND ced_rif='$cedrif'") or die(mysql_error());
}

if (mysql_num_rows($consulta)>0){
	
	echo -1;
}
else if ($idcli=="") {


	$query=mysql_query("INSERT INTO cliente (tipo_persona,ced_rif,nombre_rs,fnac,sexo,inganu,acteco,ocup,id_edo,ciudad,id_mun,id_par,usb,egcq,vp,vizq,vder,tsa,pn,loa,ref,otro,cp,tlfh,tlfo,tlfc,email,fax,natemp,ec) VALUES ('$tp','$cedrif','$nomrs','$fnac','$sexo','$inganu','$acteco','$ocu',$idedo,'$ciu',$idmun,$idpar,'$usb','$egcq','$vp','$vizq','$vder','$tsa','$pn','$loa','$ref','$otro','$cp','$tlfh','$tlfo','$tlfc','$email','$fax','$natemp','$ec')") or die(mysql_error());


	echo 1;
}
else {
	
	$consulta=mysql_query("UPDATE cliente SET  tipo_persona='$tp',ced_rif='$cedrif',nombre_rs='$nomrs',fnac='$fnac',sexo='$sexo',inganu='$inganu',acteco='$acteco',ocup='$ocu',id_edo=$idedo,ciudad='$ciu',id_mun=$idmun,id_par=$idpar,usb='$usb',egcq='$egcq',vp='$vp',vizq='$vizq',vder='$vder',tsa='$tsa',pn='$pn',loa='$loa',ref='$ref',otro='$otro',cp='$cp',tlfh='$tlfh',tlfo='$tlfo',tlfc='$tlfc',email='$email',fax='$fax',natemp='$natemp',ec='$ec' WHERE id=$idcli") or die(mysql_error());

	echo 2;
}





?>