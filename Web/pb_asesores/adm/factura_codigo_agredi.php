<?

session_start();
require("conectar.php");

 //------------- Métodos --------------------------//
function id_max(){
    
    
    $qr=mysql_query("SELECT MAX(id) AS id FROM facturas") or die(mysql_error());
    $rw=mysql_fetch_array($qr);
    return $rw["id"];
}

//-------------------------------------------------//
//var_dump($_FILES);
//exit;

$idf=$_POST["idf"];
$idc=$_POST["idcli"];
$fch=$_POST["fecha"];
$nr=strtoupper($_POST["nr"]);
$monto=$_POST["monto"];
$stat=$_POST["status"];
$cedrif=strtoupper($_POST["cedrif"]);
$nomrs=strtoupper($_POST["nomrs"]);

if ($idf=="")

    $consulta=mysql_query("SELECT * FROM facturas WHERE numero='$nr'") or die(mysql_error()); 
else
    $consulta=mysql_query("SELECT * FROM facturas WHERE numero='$nr' AND id<>$idf") or die(mysql_error());

if (mysql_num_rows($consulta)>0){
    echo -1;
    exit;
}

if ($idf=="") {
    
    $consulta2=mysql_query("INSERT INTO facturas (numero,fecha,monto,logo,status,id_cliente,nombre_rs,ced_rif) VALUES ('$nr','$fch','$monto','enproceso.png','EN PROCESO',$idc,'$nomrs','$cedrif')") or die(mysql_error());

    $idf=id_max();
}
else {

	if ($stat=='APROBADA')
        $imglogo="aprobada.png";
    else if ($stat=='RECHAZADA')
        $imglogo="rechazada.png";
    else if($stat=='ENVIADA')
        $imglogo="enviada.png";
    else
        $imglogo="enproceso.png";


    $consulta2=mysql_query("UPDATE facturas SET numero='$nr',fecha='$fch',monto='$monto',logo='$imglogo',status='$stat',id_cliente=$idc,nombre_rs='$nomrs',ced_rif='$cedrif' WHERE id=$idf") or die(mysql_error());
	
}

foreach ($_FILES as $key){

	$imagen=addslashes(file_get_contents($key['tmp_name']));
	
    if ($key['error']=='')
    	$consulta2=mysql_query("UPDATE facturas SET imagen='$imagen' WHERE id=$idf") or die(mysql_error());
		
}

echo 1;


?>