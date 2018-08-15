
<!-- Para agregar datos a un formulario validando los campos -->

<?php

$conn = new mysqli("localhost", "root", "", "frutlever");
if ($conn->connect_errno) {
    echo "Failed to connect to MySQL: (" . $conn->connect_errno . ") " . $conn->connect_error;
}


$nm = $_POST['nm'];
$gd = $_POST['gd'];
$pn = $_POST['pn'];
$al = $_POST['al'];
if($nm != null && $gd != null && $pn != null && $al != null){
$stmt = @$conn->prepare("INSERT INTO usuarios VALUES ('',?,?,?,?)");
$stmt->bind_param('ssss', $nm, $gd, $pn, $al);

if($stmt->execute()){
?>
<div class="alert alert-success alert-dismissible" role="alert">
  <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
  <strong>Registro Exitoso!</strong> 
</div>
<?php
} else{
?>
<div class="alert alert-danger alert-dismissible" role="alert">
  <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
  <strong>Error!</strong> Problema en el registro de usuario.
</div>
<?php
}
} else{
?> 
<div class="alert alert-warning alert-dismissible" role="alert">
  <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
  <strong>Disculpe!</strong> Rellene los campos necesarios!
<?php
}
?>