<?
session_start();
require("conectar.php");
//$ruta = './ImgApp/siniestros/'; //Decalaramos una variable con la ruta en donde almacenaremos los archivos

 //------------- Métodos --------------------------//
function id_max(){
    
    
    $qr=mysql_query("SELECT MAX(id) AS id FROM siniestro") or die(mysql_error());
    $rw=mysql_fetch_array($qr);
    return $rw["id"];
}

//-------------------------------------------------//
//var_dump($_POST);
//exit;

$ids=$_POST["ids"];
$idp=$_POST["idpol"];
$cod=strtoupper($_POST["codigo"]);
$descr=strtoupper($_POST["descripcion"]);
$fch=$_POST["fecha"];
$lug=strtoupper($_POST["lugar"]);
$hra=$_POST["hra"];
$stat=$_POST["status"];
$narch=$_POST["narch"];

if ($ids=="")
    $consulta=mysql_query("SELECT * FROM siniestro WHERE codigo='$cod'") or die(mysql_error());
else
    $consulta=mysql_query("SELECT * FROM siniestro WHERE codigo='$cod' AND id<>$ids") or die(mysql_error());

if (mysql_num_rows($consulta)>0){
    echo -1;
    exit;
}
    
if ($ids=="") {
    
    $consulta2=mysql_query("INSERT INTO siniestro (codigo,id_poliza,descripcion,hora,fecha,lugar,status,logo,prioridad) VALUES ('$cod',$idp,'$descr','$hra','$fch','$lug','EN PROCESO','enproceso.png','BAJA')") or die(mysql_error());

    $ids=id_max();
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


    $consulta2=mysql_query("UPDATE siniestro SET codigo='$cod',id_poliza=$idp,descripcion='$descr',hora='$hra',fecha='$fch',lugar='$lug',status='$stat',logo='$imglogo' WHERE id=$ids") or die(mysql_error());

    if ($narch==0){
        
        echo 1;
        exit;
    }
    else {
        //echo $ids;
            $qr=mysql_query("DELETE FROM siniestro_imagen where id_siniestro=$ids") or die(mysql_error());
        

    }

}



$exitoso = true;
$i=0;
foreach ($_FILES as $key) //Iteramos el arreglo de archivos
{
    if($key['error'] == UPLOAD_ERR_OK )//Si el archivo se paso correctamente Ccontinuamos 
        {
            //$NombreOriginal = $key['name'];//Obtenemos el nombre original del archivo
            $i++;
            $NombreOriginal = $cod."_00".$i.".jpg";
            $temporal = $key['tmp_name']; //Obtenemos la ruta Original del archivo
            $Destino = $ruta.$NombreOriginal;   //Creamos una ruta de destino con la variable ruta y el nombre original del archivo 

            $imagen=addslashes(file_get_contents($key['tmp_name']));
            


            //move_uploaded_file($temporal, $Destino); //Movemos el archivo temporal a la ruta especificada       
        }
 
    if ($key['error']=='') //Si no existio ningun error, retornamos un mensaje por cada archivo subido
        {
            
            $consulta2=mysql_query("INSERT INTO siniestro_imagen (id_siniestro,img_nombre,img_archivo) VALUES ($ids,'$NombreOriginal','$imagen')") or die(mysql_error());

            //$mensage .= '-> Archivo <b>'.$NombreOriginal.'</b> Subido correctamente. <br>';
        }
    if ($key['error']!='')//Si existio algún error retornamos un el error por cada archivo.
        {
            //$mensage .= '-> No se pudo subir el archivo <b>'.$NombreOriginal.'</b> debido al siguiente Error: n'.$key['error'];
            $exitoso = false; 
        }
    
}

if (!$exitoso)
    echo -2;
else
    echo 1;



?>