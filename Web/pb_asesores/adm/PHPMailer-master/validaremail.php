<?php
/**
 * This example shows how to handle a simple contact form.
 */
$msg = '';
//Don't run this unless we're handling a form submission
/*
function generarLinkTemporal($idusuario, $username){
   // Se genera una cadena para validar el cambio de contraseña
   $cadena = $idusuario.$username.rand(1,9999999).date('Y-m-d');
   $token = sha1($cadena);

   $conexion = new mysqli('localhost', 'jomi', '1234', 'prueba');
   // Se inserta el registro en la tabla tblreseteopass
   $sql = "INSERT INTO tblreseteopass (idusuario, username, token, creado) VALUES($idusuario,'$username','$token',NOW());";
   $resultado = $conexion->query($sql);
   if($resultado){
      // Se devuelve el link que se enviara al usuario
      $enlace = $_SERVER["SERVER_NAME"].'/pass/restablecer.php?idusuario='.sha1($idusuario).'&token='.$token;
      return $enlace;
   }
   else
      return FALSE;
}

$email = $_POST['email'];

if( $email != "" ){
   $conexion = new mysqli('localhost', 'jomi', '1234', 'prueba');
   $sql = " SELECT * FROM users WHERE user_email = '$email' ";
   $resultado = $conexion->query($sql);
   if($resultado->num_rows > 0){
      $usuario = $resultado->fetch_assoc();

  $idusuario= $usuario['user_id'];
  $username= $usuario['user_name'];
    $cadena = $idusuario.$username.rand(1,9999999).date('Y-m-d');
    $token = sha1($cadena);
    $enlace = $_SERVER["SERVER_NAME"].'/pass/restablecer.php?idusuario='.sha1($idusuario).'&token='.$token;

} */
         date_default_timezone_set('Etc/UTC');
        require 'PHPMailerAutoload.php';
        //Create a new PHPMailer instance
        $mail = new PHPMailer;
        //Tell PHPMailer to use SMTP - requires a local mail server
        //Faster and safer than using mail()
        $mail->isSMTP();
        $mail->Mailer = 'smtp';
        $mail->SMTPAuth = true;
        $mail->Host = "ssl://smtp.gmail.com";
        $mail->Port = 465;
        $mail->SMTPSecure = 'ssl';

        $mail->Username = "soportearawak@gmail.com";
        $mail->Password = "kelyn1234";
        //$mail->Port = 25;
        //Use a fixed address in your own domain as the from address
        //**DO NOT** use the submitter's address here as it will be forgery
        //and will cause your messages to fail SPF checks
        $mail->setFrom('soportearawak@gmail.com', 'Soporte Arawak');
        //Send the message to yourself, or whoever should receive contact for submissions
        $mail->addAddress('jomimorillo.93@gmail.com', 'John Doe');
        //Put the submitter's address in a reply-to header
        //This will fail if the address provided is invalid,
        //in which case we should ignore the whole request
        if ($mail->addReplyTo('jomimorillo.93@gmail.com', 'Jomi')) {
            $mail->Subject = 'PHPMailer contact form';
            //Keep it simple - don't use HTML
            $mail->isHTML(false);
            //Build a simple message body
            $mail->Body = <<<EOT
          Email: {'jomimorillo.93@gmail.com'}
          Name: {'Morillo'}
          Message: {'ALGO POR ACA'}
          Link: {$enlace}
    EOT;
            //Send the message, check for errors
            if (!$mail->send()) {
                //The reason for failing to send will be in $mail->ErrorInfo
                //but you shouldn't display errors to users - process the error, log it on your server.
                $msg = 'Sorry, something went wrong. Please try again later.';
            } else {
                $msg = 'Message sent! Thanks for contacting us.';
            }
        } /*else {
            $msg = 'Invalid email address, message ignored.';
        }
    //    print_R($mail->ErrorInfo);
  //  exit();

*/

 //echo json_encode( $respuesta );


?>
