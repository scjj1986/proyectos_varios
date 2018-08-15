jQuery(document).ready(function(){


	jQuery(".enter").keypress(function(e) {
		if(e.which == 13)
			loguear();

	});

	function loguear (){

		if ($("#login").val()=="" || $("#clave").val()==""){
			
			swal("¡Error!", "No puede dejar campos vacíos", "error");
		}
		else{
			
			$.post("autenticar.php",$("#frmlogin").serialize(),function(res){
				
				if(res < 0){
                        swal("¡Error!", "Login y/o Clave incorrectos", "error");


                    }else if (res = 1){
                    	
                        window.location.replace('adm/index.php');

                    }
					else{
						
						//window.location.replace('cest/index.php');

						swal("¡Error!", "Error con la Base de Datos", "error");
					}
				
				
            });
		}
		

	}

	

	//Click acceder
	jQuery("#iniciar").click(function() {

		loguear();

	});

	//Click Recuperar contraseña
	jQuery("#rc").click(function() {

		
		$("#login2").val("");
		$("#myModal").modal('show');
		


	});


	//click Sig (1er modal)
	jQuery("#sig").click(function() {

		
		if ($("#login2").val()==""){
			
			swal("¡Error!", "Campo Login vacío", "error");
		}
		else{	
			$.ajax({
			    url: "rc_codigo_usuarioxlogin.php", /* Llamamos a tu archivo */
			    data: "log="+$("#login2").val(), /* Ponemos los parametros de ser necesarios */
			    type: "POST",
			    contentType: "application/x-www-form-urlencoded",
			    dataType: "json",  /* Esto es lo que indica que la respuesta será un objeto JSon */
			    success: function(data){


			    	if (data.length==0){
			    		
			    		swal("¡Error!", "Login no encontrado en la base de datos", "error");
			    	}
			    	else {

			    		$.each(data, function(index, value){

			            	$('#mp').append(new Option(value.nombre, value.id, false, true));

			            	$('#ps').val(value.pregunta);
			            	$('#rs').attr('data-rs',value.respuesta);
			            	
			                });

			                $("#rs").val("");

			                $("#myModal").modal('hide');

			                $("#myModal2").modal('show');
			    		
			    	}
			    }
			});
			
			
		}


	});

	//Click prev. 2do modal
	jQuery("#prev2").click(function() {

		$("#myModal2").modal('hide');
		$("#myModal").modal('show');


	});

	//Click sig. 2do modal
	jQuery("#sig2").click(function() {

		if ($("#rs").val()==""){

			swal("¡Error!", "Campo Respuesta vacío", "error");
			
		}
		else if ($("#rs").val() != $('#rs').attr('data-rs')){
			
			swal("¡Error!", "Respuesta incorrecta", "error");
		}
		else {
			
			$("#myModal2").modal('hide');
			$("#lg").val($("#login2").val());
			$("#pss").val("");
			$("#pss2").val("");
			$("#myModal3").modal('show');
		}

	});

	//Click prev. 3er. modal
	jQuery("#prev3").click(function() {

		$("#myModal3").modal('hide');
		$("#myModal2").modal('show');


	});

	//Click guardar (3er. modal)
	jQuery("#finrc").click(function() {

		if ($("#pss").val()=="" || $("#pss2").val()==""){
			
			swal("¡Error!", "No puede dejar campos vacíos", "error");
		}
		else if ($("#pss").val()!= $("#pss2").val()){
			
			swal("¡Error!", "No coinciden las contraseñas", "error");
		}
		else if ($("#pss").val().length < 8){
			
			swal("¡Error!", "La nueva contraseña debe tener mínimo 8 caracteres", "error");
		}
		else{
			
			$.post("login_codigo_reestablecerclave.php",$("#frmrc2").serialize(),function(res){
				
				if (res = 1){
                    	
                        
                        swal({   
							title: "Finalizado",   
							text: "Contraseña reestablecida satisfactoriamente",   
							type: "success",   
							showCancelButton: false,   
							confirmButtonColor: "#BBD7ED",   
							confirmButtonText: "Aceptar",   
							closeOnConfirm: false }, 

							function(){   
								window.location.replace('index.php'); 
						});


                        

                 }
					
						
					
				
				
            });
		}

	});






});