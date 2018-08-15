jQuery(document).ready(function(){

			
        
            jQuery("#usu_agr").click(function() {

              $("#capa").load('usuario_interfaz_agregar.php');
            });

            jQuery(".usu_edi").click(function() {

            

              $("#capa").load('usuario_interfaz_editar.php?id='+$(this).data("id"));



            });

            jQuery("#usu_vlv_list").click(function() {

              $("#capa").load('usuario_interfaz_listado.php');
            });

            jQuery("#doc").blur(function() {


            	$("#perfil").empty();
            	$("#perfil").append('<option value="ADMINISTRADOR">ADMINISTRADOR</option>');
                $("#perfil").append('<option value="ASESOR">ASESOR</option>');
                $("#nombre").val("");
            	$.ajax({
                    url: "usuario_codigo_buscarcliente.php", 
                    data: {tp:$("#tp").val(),doc:$("#doc").val()}, // Ponemos los parametros de ser necesarios 
                    type: "POST",
                    contentType: "application/x-www-form-urlencoded",
                    dataType: "json",  // Esto es lo que indica que la respuesta será un objeto JSon 
                    success: function(data){
                        if(data != null && $.isArray(data)){
                            // Recorremos tu respuesta con each 
                            $.each(data, function(index, value){
                            		$("#perfil").empty();
                                    $("#perfil").append('<option value="ANDROID">ANDROID</option>');

                                    $("#nombre").val(value.nom);
                               

                            });
                        }
                        
                    }
                });

              //$("#capa").load('usuario_interfaz_listado.php');
            });


            function logout(){
            	$.post("logout.php", {}, function(resp){
										   
				  if (resp==1){
					  window.location.replace('/../pb_asesores/index.php');
					  
					  }
												
				
					}, "json");

            }




            jQuery(".usu_agredi").click(function() {
            	
	              var nom=$("#nombre").val().toUpperCase();
	              var ape=$("#apellido").val().toUpperCase();


	              if ($("#doc").val()=="" || $("#nombre").val()=="" || $("#rs").val()=="" || $("#pss").val()=="" || $("#pss2").val()==""  ){
	              	
	              	swal("¡Error!", "No debe dejar campos vacíos", "error");
	              }
	              else if ($("#pss").val()!=$("#pss2").val()){

	              	swal("¡Error!", "Las contraseñas no coinciden", "error");
	              	

	              }
	              else if ($("#pss").val().length < 8){
						
						swal("¡Error!", "La contraseña debe tener mínimo 8 caracteres", "error");
				  }else {

				  	$.post("usuario_codigo_agredi.php",$(".frmusu").serialize(),function(res){


				  		if (res==-1){
				  			
				  				swal("¡Error!", "La Cédula/Pasp./RIF coincide con un usuario registrado en la base de datos", "error");
				  		}
				  		else if (res==-2){
				  			
				  				swal({   
									title: "Finalizado",   
									text: "Datos guardados satisfactoriamente. Acaba de desactivar su cuenta de usuario. Presione 'Aceptar' para cerrar la sesión",   
									type: "warning",   
									showCancelButton: false,   
									confirmButtonColor: "#BBD7ED",   
									confirmButtonText: "Aceptar",   
									closeOnConfirm: true }, 

									function(){   
										logout();
								});
				  		}
				  		else if (res==-3){
				  			
				  				swal({   
									title: "Finalizado",   
									text: "Datos guardados satisfactoriamente. Acaba de cambiar su perfil de usuario. Presione 'Aceptar' para cerrar la sesión",   
									type: "warning",   
									showCancelButton: false,   
									confirmButtonColor: "#BBD7ED",   
									confirmButtonText: "Aceptar",   
									closeOnConfirm: true }, 

									function(){   
										logout();
								});
				  		}
				
						else if (res==1) {
		                    	
		                        
		                        swal({   
									title: "Finalizado",   
									text: "Datos guardados satisfactoriamente",   
									type: "success",   
									showCancelButton: false,   
									confirmButtonColor: "#BBD7ED",   
									confirmButtonText: "Aceptar",   
									closeOnConfirm: true }, 

									function(){
										$("#nomusu").html(nom+" "+ape);
										$("#capa").load('usuario_interfaz_listado.php');
								});
		                        
		                 }
		                 else {
		                    	
		                        
		                        swal({   
									title: "Finalizado",   
									text: "Datos guardados satisfactoriamente",   
									type: "success",   
									showCancelButton: false,   
									confirmButtonColor: "#BBD7ED",   
									confirmButtonText: "Aceptar",   
									closeOnConfirm: true }, 

									function(){
										
										$("#capa").load('usuario_interfaz_listado.php');
								});
		                        
		                 }
						
						
		            });
				  	
				  	
				  }
              	

         
            });



            



});