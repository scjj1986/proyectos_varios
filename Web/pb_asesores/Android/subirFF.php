<?php 

$file_path = "FotoFacturas/";
$file_path = $file_path . basename( $_FILES['imagen']['name']);
@move_uploaded_file($_FILES['imagen']['tmp_name'], $file_path);

@chmod($file_path,0777);
$n="FotoFacturas/2.jpg";
$v=$file_path;
copy($file_path,$n);
unlink($v);
rename($n,$v);




?>