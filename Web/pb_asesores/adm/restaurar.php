<?php session_start();
if (!isset($_SESSION['us'])){
echo '<script languaje="javascript"> location.href="index.php"; </script>';
}
$arch=$_POST['archi'];
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Restaurar Bases de Datos</title>
<link href="hoja_estilo.css" rel="stylesheet" type="text/css" />
<script>
function enviar(){
	var ar = document.getElementById("archivo");
	var sep=ar.value.split('_');
	if(ar.value!=""){
	 			if(confirm("seguro desea restaurar la base de datos a la fecha "+sep[1] +" y a "+sep[2]+" horas")){
					var arc=ar.value.split('\\');
					
					document.form2.archi.value=arc[2];
					document.form2.action="restore.php";
					document.form2.submit();
					
				}
	}else alert ("debe seleccionar un archivo para restaurar");
} 
</script>
</head>

<body  onload="if(history.length>0) history.go(+1);" bgcolor="#CCCCCC">
<form id="form2" name="form2" method="post">
<table width="738" border="0" cellpadding="0" cellspacing="0" align="center" >
  <tr>
    <td width="208" height="0" bordercolor="#FFFFFF" bgcolor="#FFFFFF">&nbsp;</td>
    <td height="8" colspan="6" bgcolor="#FFFFFF">&nbsp;</td>
  </tr>
  <tr>
    <td height="8"  align="center" colspan="7" bordercolor="#FFFFFF" bgcolor="#FFFFFF" class="button-flat-action">RESTAURAR BASE DE DATOS</td>
    </tr>
  <tr>
    <td height="46" colspan="3" bordercolor="#FFFFFF" bgcolor="#FFFFFF" class="cajatexto"><a href="menu.php"/><img src="imagenes/home1.png" alt="fv" width="32" height="32" />MENÚ PRINCIPAL</td>
    <td height="46" colspan="4" bgcolor="#FFFFFF"><span class="etiqueta"><img src="imagenes/correcto-thumb6623123.jpg" alt="SDF" width="37" height="40" /><?php echo $_SESSION['us'];?></span></td>
    </tr>
  <tr>
    <td height="19" colspan="7" bordercolor="#FFFFFF" bgcolor="#999999" class="separador1">&nbsp;</td>
  </tr>
  <tr>
    <td height="0" bordercolor="#FFFFFF" bgcolor="#FFFFFF"><div align="center"><a href="nuevasolicitud.php"/></a></div></td>
    <td width="44" height="19" bordercolor="#FFFFFF" bgcolor="#FFFFFF">&nbsp;</td>
    <td width="342" height="19" bordercolor="#FFFFFF" bgcolor="#FFFFFF" class="etiquetas_nomodi">ELEGIR UN ARCHIVO</td>
    <td width="119" height="0" bordercolor="#FFFFFF" bgcolor="#FFFFFF"><div align="center"></div></td>
    <td width="25" height="19" colspan="3" bordercolor="#FFFFFF" bgcolor="#FFFFFF">&nbsp;</td>
  </tr>
  <tr>
    <td height="45" colspan="2" bordercolor="#FFFFFF" bgcolor="#FFFFFF"><div align="center"><img src="imagenes/database_up.png" alt="sdfg" width="128" height="128" /></div></td>
    <td height="0" colspan="2" bordercolor="#FFFFFF" bgcolor="#FFFFFF"><div align="left" class="etiquetas_nomodi"><input name="archivo" type="file" class="cajatexto" id="archivo"  />
  
    </div></td>
    <td height="0" colspan="3" bordercolor="#FFFFFF" bgcolor="#FFFFFF" class="etiquetas_nomodi">&nbsp;</td>
  </tr>
  <tr>
    <td height="21" bgcolor="#FFFFFF">&nbsp;</td>
    <td height="21" bgcolor="#FFFFFF"><input type="hidden" name="archi"  id="archi" value=""/></td>
    <td width="342" height="21" bgcolor="#FFFFFF">&nbsp;</td>
    <td width="119" height="21" bgcolor="#FFFFFF"><input name="modificar" type="button" id="modificar" value="RESTAURAR" onclick="enviar()" class="button-tiny button-primary button-pill button-action"/></td>
    <td height="21" colspan="3" bgcolor="#FFFFFF">&nbsp;</td>
  </tr>
  <tr>
    <td height="21" colspan="7" bgcolor="#999999" class="separador">&nbsp;</td>
  </tr>
  <tr>
    <td colspan="7" bgcolor="#CCCCCC"></td>
  </tr>
  <tr>
    <td colspan="7" bgcolor="#FFFFFF">&nbsp;</td>
  </tr>
  <tr>
    <td colspan="7" bgcolor="#FFFFFF">&nbsp;</td>
  </tr>
  <tr>
    <td colspan="7" bgcolor="#FFFFFF"></td>
  </tr>
</table>
</form>
</body>
</html>