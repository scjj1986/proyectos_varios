<?php session_start();
//crear con abuelo padre e hijo
//------------------------------------------------------------------------------------------
$db_server			= "127.0.0.1"; 
	$db_name				= "pb_asesores" ; 
	$db_username		= "root";  
	$db_password		= "1903";  


	//  Acceso al script.
	
	$auth_user			= $_SESSION['user']; 
	$auth_password 	= $_SESSION['pass'];
$arch=$_POST['archi'];


	//  Nombre del archivo.

	$filename = 'Backups\\pb';

//------------------------------------------------------------------------------------------
//  No tocar
	error_reporting( E_ALL & ~E_NOTICE );
	define( 'Str_VERS', "1.1.1" );
	define( 'Str_DATE', "18 de Marzo de 2005" );
//------------------------------------------------------------------------------------------
?>
<?php 
	// Check to see if $PHP_AUTH_USER already contains info
	if (!isset($_SERVER['PHP_AUTH_USER'])) {
		// If empty, send header causing dialog box to appear
		header('WWW-Authenticate: Basic realm="Acceso al Restore la Base de Datos"');
		header('HTTP/1.0 401 Unauthorized');
    // Defines the charset to be used
    header('Content-Type: text/html; charset=iso-8859-1');
?>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 3.2 Final//EN">
<HTML>
 <HEAD>
	<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
	<title>Acceso Denegado</title>
	<!-- no cache headers -->
	<meta http-equiv="Pragma" content="no-cache">
	<meta http-equiv="no-cache">
	<meta http-equiv="Expires" content="-1">
	<meta http-equiv="Cache-Control" content="no-store">
	<meta http-equiv="Cache-Control" content="no-cache">
	<meta http-equiv="Cache-Control" content="must-revalidate">
	<!-- end no cache headers --> 
    <link href="estilo.css" rel="stylesheet" type="text/css">
    <link href="hoja_estilo.css" rel="stylesheet" type="text/css">
    <link href="EvaluacionCadete/hoja_estilo.css" rel="stylesheet" type="text/css">
 </HEAD>
<BODY 
	>
	<center><h1>Restore la Base de Datos</h1></center><br>
	<strong><center><p>Usuario/contraseña equivocado. Acceso denegado.</p></center>
<?php
		echo( "</strong><br><br><hr><center><small>" );
		
		
		echo( "</BODY>" );
		echo( "</HTML>" );
    exit();
	}
	else {
		if (($_SERVER['PHP_AUTH_USER'] != $auth_user ) || ($_SERVER['PHP_AUTH_PW'] != $auth_password )) {
			header('WWW-Authenticate: Basic realm="Acceso al Restore la Base de Datos"');
			header('HTTP/1.0 401 Unauthorized');
    	// Defines the charset to be used
    	header('Content-Type: text/html; charset=iso-8859-1');
?>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 3.2 Final//EN">
<HTML>
 <HEAD>
	<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
	<title>Acceso Denegado</title>
	<!-- no cache headers -->
	<meta http-equiv="Pragma" content="no-cache">
	<meta http-equiv="no-cache">
	<meta http-equiv="Expires" content="-1">
	<meta http-equiv="Cache-Control" content="no-store">
	<meta http-equiv="Cache-Control" content="no-cache">
	<meta http-equiv="Cache-Control" content="must-revalidate">
	<!-- end no cache headers --> 
 </HEAD>
<BODY 
	>
	<center><h1>Restore la Base de Datos</h1></center><br>
	<strong><center><p>Usuario/contraseña equivocado. Acceso denegado.</p></center>
<?php
			echo( "</strong><br><br><hr><center><small>" );
			
			echo( "</BODY>" );
			echo( "</HTML>" );
    	exit();
		}
		else {
///////  El área protegida empieza DESPUÉS de la SIGUIENTE línea  /////
?>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 3.2 Final//EN">
<HTML>
 <HEAD>
	<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
	<title>Restore la Base de Datos</title>
	<!-- no cache headers -->
	<meta http-equiv="Pragma" content="no-cache">
	<meta http-equiv="no-cache">
	<meta http-equiv="Expires" content="-1">
	<meta http-equiv="Cache-Control" content="no-store">
	<meta http-equiv="Cache-Control" content="no-cache">
	<meta http-equiv="Cache-Control" content="must-revalidate">
	<link href="hoja_estilo.css" rel="stylesheet" type="text/css">
	<!-- end no cache headers --> 
 </HEAD>
<BODY bgcolor="#CCCCCC" >
	<center>
	  <table width="803" border="0" cellpadding="0" cellspacing="0" align="center" >
        <tr>
          <td width="208" height="0" bordercolor="#FFFFFF" bgcolor="#FFFFFF">&nbsp;</td>
          <td height="8" colspan="6" bgcolor="#FFFFFF">&nbsp;</td>
        </tr>
        <tr>
          <td height="8" colspan="7"  align="center" bordercolor="#FFFFFF" bgcolor="#FFFFFF" class="button-flat-action">RESTAURAR BASE DE DATOS</td>
        </tr>
        <tr>
          <td height="46" colspan="3" bordercolor="#FFFFFF" bgcolor="#FFFFFF"><div align="right" class="cajatexto"><a href="menu.php"/><img src="imagenes/home1.png" alt="sd" width="24" height="24" />MEN&Uacute; PRINCIPAL</div></td>
          <td height="46" colspan="3" bgcolor="#FFFFFF">&nbsp;</td>
          <td width="116" height="46" bgcolor="#FFFFFF"><span class="etiqueta"><img src="imagenes/correcto-thumb6623123.jpg" alt="SDF" width="37" height="40" /><?php echo $_SESSION['us'];?></span></td>
        </tr>
        <tr>
          <td height="19" colspan="7" bordercolor="#FFFFFF" bgcolor="#999999">&nbsp;</td>
        </tr>
        <tr>
          <td height="0" bordercolor="#FFFFFF" bgcolor="#FFFFFF"><div align="center"><a href="nuevasolicitud.php"/></div></td>
          <td width="23" height="19" bordercolor="#FFFFFF" bgcolor="#FFFFFF">&nbsp;</td>
          <td width="363" height="19" bordercolor="#FFFFFF" bgcolor="#FFFFFF" class="etiquetas_nomodi">RESULTADO DE RESTAURAR </td>
          <td width="13" height="0" bordercolor="#FFFFFF" bgcolor="#FFFFFF"><div align="center"></div></td>
          <td height="19" colspan="3" bordercolor="#FFFFFF" bgcolor="#FFFFFF">&nbsp;</td>
        </tr>
        <tr>
          <td height="45" colspan="2" bordercolor="#FFFFFF" bgcolor="#FFFFFF"><div align="center"><img src="imagenes/database_up.png" width="128" height="128"></div></td>
          <td height="0" colspan="2" bordercolor="#FFFFFF" bgcolor="#FFFFFF"><div align="left" class="etiquetas_nomodi">
            <?php
	@set_time_limit( 0 );

	echo( "- Base de Datos: '$db_name' en '$db_server'.<br>" );
	$error = false;

	if ( !@function_exists( 'gzopen' ) ) {
		$hay_Zlib = false;
		echo( "- Ya que no está disponible Zlib, usaré el BackUp de la Base de Datos: '$filename'<br>" );
	}
	else {
		$hay_Zlib = true;
		$filename = $filename;
		echo( "- disponible respaldo comprimido, BackUp de la Base de Datos a utilizar: '$filename'<br>" );
	}

	if( !$file = @fopen( $filename,"r" ) ) { 
	    echo ("<br>- Lo siento, no encuentro o no puedo abrir: '$filename'.<br>");
	    $error = true;
	}
	else { 
	    if( fseek($file, 0, SEEK_END)==0 )
	        $filesize_comprimido = ftell( $file );
	    else { 
	       echo ("<br>- Lo siento, no puedo obtener las dimensiones de '$filename'.<br>");
	       $error = true;
	    }
	 	  fclose( $file );
	}

	if ( !$error ) {
		if( $hay_Zlib ) {
			if ( !$file = @gzopen( $filename, "rb" ) ) { 
				echo( "<br>- Lo siento, no encuentro o no puedo abrir: '$filename'.<br>" );
				$error = true;
			}
			else {
				gzrewind( $file );
			}
		}
		else {
			if ( !$file = @fopen( $filename, "rb" ) ) { 
				echo( "<br>- Lo siento, no encuentro o no puedo abrir: '$filename'.<br>" );
				$error = true;
			}
			else {
				rewind( $file );
			}
		}
	}

	if (!$error) { 
	    $dbconnection = @mysql_connect( $db_server, $db_username, $db_password ); 
	    if ($dbconnection) 
	        $db = mysql_select_db( $db_name );
	    if ( !$dbconnection || !$db ) { 
	        echo( "<br>" );
	        echo( "- Lo siento, la conexion con la Base de datos ha fallado: ".mysql_error()."<br>" );
	        $error = true;
	    }
	    else {
	        echo( "<br>" );
	        echo( "- Conexion establecida con la Base de datos.<br>" );
	    }
	}

	if (!$error) { 
	    $result = mysql_list_tables( $db_name );
			if (!$result) {
					print "<br>- Error, no puedo obtener la lista de las tablas.<br>";
					print '<br>- MySQL Error: ' . mysql_error(). '<br>';
					$error = true;
			}
			else {
					// $count es el número de tablas en la base de datos
					$count = mysql_num_rows($result);
					if( !$count ) {
							echo "- No ha sido necesario borrar la estructura de la Base de datos, estaba vacía.<br>";
					}
					else {
							while ($row = mysql_fetch_row($result)) {
									$deleteIt = mysql_query("DROP TABLE $row[0]");
									if( !$deleteIt ) {
	        						echo( "<br>" );
											print "- Lo siento, error al borrar la tabla $row[0].<br>";
											$error = true;
											break;
									}
							}
							echo "- Borrada estructura de la Base de Datos.<br>";
					}
					mysql_free_result($result);
			}
	}

	if( !$error ) { 
	    $query = "";
	    $last_query = "";
	    $total_queries = 0;
	    $total_lineas = 0;
	
			$t_start = time();

			while( 1 ) {
				if( $hay_Zlib )
					$seacabo = gzeof( $file ) OR $error;
				else
					$seacabo = feof( $file ) OR $error;
				if( $seacabo )
					break;
				if( $hay_Zlib )
					$statement = gzgets( $file );
				else
					$statement = fgets( $file );
					
	        $statement = trim( $statement );
	        $total_lineas++;
	        // no se procesan comentarios ni lineas en blanco
	        if ( $statement=="--" || $statement=="" || strpos ($statement, "#") === 0) { 
	            continue;
	        }
	        // pasa a query
	        $query .= $statement;
	        // ejecuta query si esta completo
	        if( ereg( ";$", $statement ) ) { 
	            if ( !mysql_query( $query, $dbconnection) ) { 
	                echo(" <br>" );
	                echo("- Error en statement: $statement<br>" );
	                echo("- Query: $query<br>");
	                echo("- MySQL: ".mysql_error()."<br>" );
	                $error = true;
	                break;
	            }
	            $last_query = $query;
	            $query = "";
	            $total_queries++;
	        }
	    }

			if( $hay_Zlib )
				$file_offset = gztell($file);
	    else
	    	$file_offset = ftell($file);
	
	    echo( "<pre>" );
	    echo( "- Líneas procesadas......................... $total_lineas<br>" );
	    echo( "- Queries procesadas........................ $total_queries<br>" );
	    echo( "- Último Query procesado.................... '$last_query'<br>" );
			if( $hay_Zlib ) {
	    	echo( "- Base de Datos comprimida.................. $filesize_comprimido bytes<br>");
	    	echo( "- Base de Datos descomprimida y procesada... $file_offset bytes<br>" );
	  	}
	  	else {
	    	echo( "- Base de Datos procesada................... $file_offset bytes<br>" );
	  	}
	    echo( "</pre>" );
			$t_now = time();
			$t_delta = $t_now - $t_start;
			if( !$t_delta )
				$t_delta = 1;
			$t_delta = floor(($t_delta-(floor($t_delta/3600)*3600))/60)." minutos y "
			.floor($t_delta-(floor($t_delta/60))*60)." segundos.";
			echo( "- Base de Datos restaurada en $t_delta<br>" );
			$_SESSION['transaccion']="Restore";
				include('guardarlog.php');
	}

	if ( $dbconnection )
	    mysql_close();
	if ( $file )
		if( $hay_Zlib )
			gzclose($file);
	   else
	    fclose($file);

	echo( "</strong><br><br><hr><center><small>" );

	echo( "</BODY>" );
	echo( "</HTML>" );

//------------------------------------------------------------------------------------------
//  END
?>
            <?php
///////  El área protegida acaba ANTES de la ANTERIOR línea  /////
		}
	}
?>
          </div></td>
          <td height="0" colspan="3" bordercolor="#FFFFFF" bgcolor="#FFFFFF" class="etiquetas_nomodi">&nbsp;</td>
        </tr>
        <tr>
          <td height="21" bgcolor="#FFFFFF">&nbsp;</td>
          <td height="21" bgcolor="#FFFFFF">&nbsp;</td>
          <td width="363" height="21" bgcolor="#FFFFFF">&nbsp;</td>
          <td width="13" height="21" bgcolor="#FFFFFF">&nbsp;</td>
          <td height="21" colspan="3" bgcolor="#FFFFFF">&nbsp;</td>
        </tr>
        <tr>
          <td height="21" colspan="7" bgcolor="#999999">&nbsp;</td>
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
	  <h1>&nbsp;</h1>
	</center><br>
	<strong>