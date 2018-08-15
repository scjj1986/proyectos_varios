<?
require("conectar.php");
session_start();

set_time_limit(3000);

$ban=false;
if (@mysql_select_db("pb_asesores")){
  $ban=true;
} else {
   $ban=false;
}  

if($ban==false){
$sql = 'CREATE DATABASE dge';
	mysql_query($sql);
    }


//------------------------------------------------------------------------------------------
//  Definiciones

	/*/------------------------------------- Conexión Michel --------------------//
	//  Conexión con la Base de Datos.
	$db_server			= "127.0.0.1"; 
	$db_name				= "pb_asesores"; 
	$db_username		= "root"; 
	$db_password		= "1903"; 
	//  Acceso al script.
	$auth_user			= "root";
	$auth_password 	= "1903";
	// ------------------------------------------------------------------------/*/

	//-------------------------------------------------------------------------//
	//  Conexión con la Base de Datos.
	$db_server			= "localhost"; 
	$db_name				= "pb_asesores"; 
	$db_username		= "root"; 
	$db_password		= "1234567-"; 
	//  Acceso al script.
	$auth_user			= "root";
	$auth_password 	= "1234567-";
	// ------------------------------------------------------------------------//

	//  Nombre del archivo.

	$filename 			= "Backups\pb_asesores.sql.gz";


//------------------------------------------------------------------------------------------
//  No tocar
	error_reporting( E_ALL & ~E_NOTICE );
	define( 'Str_VERS', "1.1.1" );
	define( 'Str_DATE', "15 de Junio del 2017" );
//------------------------------------------------------------------------------------------



 ?>

 <div class="panel panel-primary">
  <div class="panel-heading">
    <h3 class="panel-title"><span align="right" class="glyphicon glyphicon-floppy-open"></span><b>&nbsp;&nbsp;RESTURACIÓN DE BASE DE DATOS</b></h3>
  </div>
  <div class="panel-body">
    <div class="container">

                        <form role="form" class="form-horizontal">
                            <div class="form-group">
                            <p align="left"><?php
	@set_time_limit( 0 );

		echo( "- Base de Datos: '$db_name' en '$db_server'.<br>" );
	$error = false;

	if ( !@function_exists( 'gzopen' ) ) {
		$hay_Zlib = false;
		echo( "- Ya que no está disponible Zlib, se usará el BackUp de la Base de Datos: '$filename'<br>" );
	}
	else {
		$hay_Zlib = true;
		$filename = $filename ;
		echo( "- Ya que está disponible Zlib, se usará el BackUp de la Base de Datos: '$filename'<br>" );
	}

	if( !$file = @fopen( $filename,"r" ) ) { 
	    echo ("<br>- No se puede abrir: '$filename'.<br>");
	    $error = true;
	}
	else { 
	    if( fseek($file, 0, SEEK_END)==0 )
	        $filesize_comprimido = ftell( $file );
	    else { 
	       echo ("<br>- No se pueden obtener las dimensiones de '$filename'.<br>");
	       $error = true;
	    }
	 	  fclose( $file );
	}

	if ( !$error ) {
		if( $hay_Zlib ) {
			if ( !$file = @gzopen( $filename, "rb" ) ) { 
				echo( "<br>- No se puede abrir: '$filename'.<br>" );
				$error = true;
			}
			else {
				gzrewind( $file );
			}
		}
		else {
			if ( !$file = @fopen( $filename, "rb" ) ) { 
				echo( "<br>- No se puede abrir: '$filename'.<br>" );
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
	        echo( "- La conexion con la Base de datos ha fallado: ".mysql_error()."<br>" );
	        $error = true;
	    }
	    else {
	        echo( "<br>" );
	        echo( "- Se ha establecido conexion con la Base de datos.<br>" );
	    }
	}

	if (!$error) { 
	   $result = mysql_query("show tables");//mysql_list_tables( $db_name );
			if (!$result) {
					print "<br>- Error, no se puede obtener la lista de las tablas.<br>";
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
											print "- Error al borrar la tabla $row[0].<br>";
											$error = true;
											break;
									}
							}
							echo "- Se ha borrado la estructura de la Base de Datos.<br>";
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
	        if( mb_ereg( ";$", $statement ) ) { 
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
	    echo( "- Consultas procesadas........................ $total_queries<br>" );
	  //  echo( "- Último Query procesado.................... '$last_query'<br>" );
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
			echo( "- Se ha completado la resturación de la Base de Datos en $t_delta<br>" );
	}

	if ( $dbconnection )
	    mysql_close();
	if ( $file )
		if( $hay_Zlib )
			gzclose($file);
	   else
	    fclose($file);

	echo( "</strong><br><br><hr><center><small>" );
date_default_timezone_set('America/Caracas'); //fecha del sistema
	//setlocale(LC_TIME, "C");//setlocale( LC_TIME,"spanish" );
	echo strftime( "%A %d %B %Y&nbsp;-&nbsp;%H:%M:%S", time() );
	echo( "<br>&copy;2005 <a href=\"mailto:insidephp@gmail.com\">Inside PHP</a><br>" );
	echo( "vers." . Str_VERS . "<br>" );
	echo( "</small></center>" );
	echo( "</BODY>" );
	echo( "</HTML>" );
//------------------------------------------------------------------------------------------
//  END

?></p>

</div>         
                        </form>

                    </div>
  </div>
  <div class="panel-heading">
    <h3 class="panel-title"><b>SISTEMA pb ASESORES, C.A.</b></h3>
  </div>
</div>


