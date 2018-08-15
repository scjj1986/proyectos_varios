<?php


        /*if ($_POST['email']){
          $email = $_POST['email'];

          /* Conectar con la base de datos*/
          
        require 'PHPMailerAutoload.php';
        //Create a new PHPMailer instance
        $mail = new PHPMailer;
        $mail->SMTPDebug  = 2;
        //Tell PHPMailer to use SMTP - requires a local mail server
        //Faster and safer than using mail()
        $mail->isSMTP();
        $mail->Mailer = 'smtp';
        $mail->SMTPAuth = true;
        $mail->Host = "smtp.gmail.com";
        $mail->Port = 587;
        $mail->SMTPSecure = 'tls';

        $mail->SMTPOptions = array(
                'ssl' => array(
                'verify_peer' => false,
                'verify_peer_name' => false,
                'allow_self_signed' => true
                )
            );


        $mail->Username = "elimarcano.18@gmail.com";
        $mail->Password = "24695926eli";

        $mail->setFrom('elimarcano.18@gmail.com', 'Soporte pb Asesores');
        //Send the message to yourself, or whoever should receive contact for submissions
        $mail->addAddress('michelparra1802@gmail.com', 'adasd');

       // $mail->addReplyTo('kelyncamacho@gmail.com', 'kelyn');
        $mail->Subject = 'PHPMailer contact form';
        //Keep it simple - don't use HTML
        $mail->isHTML(true);
        //Build a simple message body
        $mensaje = '<p>Hemos recibido una petición para restablecer la contraseña de tu cuenta.</p>
            <p>Si hiciste esta petición, haz clic en el siguiente enlace, si no hiciste esta petición puedes ignorar este correo.</p>
            <p>
              <strong>Enlace para restablecer tu contraseña</strong><br>
              
            </p>';

        $mail->Body = $mensaje;
        //Send the message, check for errors
        if (!$mail->send()) {
            //The reason for failing to send will be in $mail->ErrorInfo
            //but you shouldn't display errors to users - process the error, log it on your server.
          $respuesta->mensaje = '<div class="alert alert-warning"> El correo no pudo ser enviado, por favor intente nuevamente. </div>';
          //echo json_encode( $respuesta );
          exit();
        } else {
         // $respuesta->mensaje = '<div class="alert alert-info"> Un correo ha sido enviado a su cuenta de email con las instrucciones para reestablecer la contraseña </div>';
         echo 'enviado';
          exit();
        }

       // echo json_encode( $respuesta );
        //exit();
//}else{
  echo "UN MENSAJE";
//}
?>
