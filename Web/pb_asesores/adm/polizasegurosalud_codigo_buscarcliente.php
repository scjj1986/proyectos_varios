<?php

session_start();
require("conectar.php");

$id=$_POST["id"];


$consulta=mysql_query("SELECT * FROM cliente WHERE id=$id") or die(mysql_error());
$lista= array();

while($cli=mysql_fetch_array($consulta)){

	$ide=$cli["id_edo"];
	$idm=$cli["id_mun"];
	$idp=$cli["id_par"];



	$qr_edo=mysql_query("SELECT * FROM estado WHERE id=$ide");
	$edo= mysql_fetch_array($qr_edo);

	$qr_mun=mysql_query("SELECT * FROM municipio WHERE id=$idm");
	$mun=mysql_fetch_array($qr_mun);

	$qr_par=mysql_query("SELECT * FROM parroquia WHERE id=$idp");
	$par=mysql_fetch_array($qr_par);

	$lista[] = array('id'=> $cli["id"], 'nom'=> $cli["nombre_rs"], 'natemp'=> $cli["natemp"], 'fnac'=> $cli["fnac"], 'sx'=> $cli["sexo"], 'ec'=> $cli["ec"], 'ianu'=> $cli["inganu"], 'aeco'=> $cli["acteco"], 'ocu'=> $cli["ocup"], 'edo'=>$edo["nombre"],'ciu'=> $cli["ciudad"],'mun'=> $mun["nombre"],'par'=> $par["nombre"],'usb'=> $cli["usb"],'egcq'=> $cli["egcq"],'vp'=> $cli["vp"],'vizq'=> $cli["vizq"],'vder'=> $cli["vder"],'tsa'=> $cli["tsa"],'pn'=> $cli["pn"],'loa'=> $cli["loa"], 'ref'=>$cli["ref"],'otro'=> $cli["otro"],'cp'=> $cli["cp"],'tlfh'=> $cli["tlfh"],'tlfo'=> $cli["tlfo"],'tlfc'=> $cli["tlfc"],'email'=> $cli["email"],'fax'=> $cli["fax"],'tp'=> $cli["tipo_persona"],'cedrif'=> $cli["ced_rif"]);

}

echo json_encode($lista);





?>