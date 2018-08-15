<?php 
include('conexion.php');

    	$user=$_POST["usua"];
		$pass=$_POST["contra"];


    	$sql=mysql_query("SELECT usuario,pass from usuario where usuario = '$user' and pass = '$pass'");

         $r=mysql_num_rows ($sql);
		 
         if ($r==0)
            {
               ?><script>
                    
                    alert("Usuario o contraseña incorrectos");
					 					</script><?php
                
            }else{
				
				    $row = mysql_fetch_array($sql);
                    $_SESSION["usu"]=$row[usuario];
					header('Location: menuprincipal.php');
                   // $_SESSION["sta"]=$row["nivel_user"];
					?><script>
                    
                    //window.location="administracion.php";
					</script>
					<?php
					
				
               // header('Location: index.php?user=invalido');
			}
    



?>