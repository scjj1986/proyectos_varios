jQuery(document).ready(function(){

			 var Letras=' ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzàáÀÁéèÈÉíìÍÌïÏóòÓÒúùÚÙüÜ,. ' 
			 var Numeros='1234567890.' 
			 var NumerosYLetras=' ABCÇDEFGHIJKLMNOPQRSTUVWXYZabcçdefghijklmnopqrstuvwxyz1234567890,.:;@-\''
			 var SimbolosEspeciales=',.:;@-\'' 
			 var SignosMatematicos='+-=()*/' 
			 var Otros='<>#$%&?¿' 
			 var Sexo='FMfm'
			 var NumeroYLetra=' NSns1234567890/ '
			 var Nick='ABCÇDEFGHIJKLMNOPQRSTUVWXYZabcçdefghijklmnopqrstuvwxyz1234567890'
			 //Validar La entrada de datos
			 function ValidarEntrada(e,allow) { 
			  var k; 
			  k=document.all?parseInt(e.keyCode): parseInt(e.which); 
			  return (allow.indexOf(String.fromCharCode(k))!=-1); 
			 }// JavaScript Document

			 $(document).on('keypress','.num',function (e){
					return ValidarEntrada(e, Numeros);
		        
		    });
		    
			$(document).on('keypress','.let',function (e){
					return ValidarEntrada(e, Letras);
			});



            $("#capa").load('home.php');

            

            jQuery("#inicio").click(function() {

              $("#capa").html('');
              $("#capa").load('home.php');

            });

            jQuery("#asg").click(function() {

              $("#capa").html('');
              $("#capa").load('aseguradora_interfaz_listado.php');

            });

            jQuery("#bnc").click(function() {

              $("#capa").html('');
              $("#capa").load('banco_interfaz_listado.php');

            });


            jQuery("#cli").click(function() {

              $("#capa").html('');
              $("#capa").load('cliente_interfaz_listado.php');

            });

            jQuery("#sss").click(function() {

              $("#capa").html('');
              $("#capa").load('polizasegurosalud_interfaz_listado.php');

            });

            jQuery("#ssv").click(function() {

              $("#capa").html('');
              $("#capa").load('polizaseguroauto_interfaz_listado.php');

            });


            jQuery("#rsp").click(function() {

              $("#capa").html('');
              $("#capa").load('bd_interfaz_respaldar.php');

            });

            jQuery("#rst").click(function() {

			       $("#mainmenu").hide();
             $("#capa").hide();

             $.ajax({
                    url:'bd_codigo_restore.php', //Url a donde la enviaremos
                    type:'POST', //Metodo que usaremos
                    contentType:false, //Debe estar en false para que pase el objeto sin procesar
                    processData:false, //Debe estar en false para que JQuery no procese los datos a enviar
                    cache:false //Para que el formulario no guarde cache
                  }).done(function(res){//Escuchamos la respuesta y capturamos el mensaje msg
                    if (res==1) {
                           
                                swal({   
                                title: "Finalizado",   
                                text: "Restauración realizada satisfactoriamente",   
                                type: "success",   
                                showCancelButton: false,   
                                confirmButtonColor: "#BBD7ED",   
                                confirmButtonText: "Aceptar",   
                                closeOnConfirm: true }, 

                                function(){
                                  
                                  $("#mainmenu").show();
                                  $("#capa").show();

                                  });
                                          
                    }else {
                              
                          swal("¡Error!", "No se pudo realizar la restauración", "error");
                    }
                  });

            });

            jQuery("#usuario_listado").click(function() {

              $("#capa").html('');
              $("#capa").load('usuario_interfaz_listado.php');

            });
			  jQuery("#siniestro_listado").click(function() {

              $("#capa").html('');
              $("#capa").load('siniestro_interfaz_listado.php');

            });
			 jQuery("#factura_listado").click(function() {

              $("#capa").html('');
              $("#capa").load('factura_interfaz_listado.php');

            });

            jQuery("#logout").click(function() {

              	 $.post("sesion_codigo_logout.php", {}, function(resp){
												   
				  if (resp==1){
					  window.location.replace('/../pb_asesores/index.php');
					  
					  }
												
				
					}, "json");

            });



});