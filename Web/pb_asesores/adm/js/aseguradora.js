jQuery(document).ready(function(){

			jQuery("#asg_agr").click(function() {

              $("#capa").load('aseguradora_interfaz_agregar.php');
            });

            jQuery(".asg_edi").click(function() {
              $("#capa").load('aseguradora_interfaz_editar.php?id='+$(this).data("id"));
            });

            jQuery("#asg_vlv_list").click(function() {

              $("#capa").load('aseguradora_interfaz_listado.php');
            });

            jQuery("#docpc").blur(function() {
		    		$.ajax({
				    url: "aseguradora_codigo_buscarpersonacontacto.php", /* Llamamos a tu archivo */
				    data: "tp="+$("#tppc").val()+"&doc="+$("#docpc").val(), /* Ponemos los parametros de ser necesarios */
				    type: "POST",
				    contentType: "application/x-www-form-urlencoded",
				    dataType: "json",  /* Esto es lo que indica que la respuesta será un objeto JSon */
				    success: function(data){
				        
				        if(data != null && $.isArray(data)){
				            /* Recorremos tu respuesta con each */
				            $.each(data, function(index, value){

				            	$("#nompc").val(value.nom);
				            	$("#apepc").val(value.ape);
				            	$("#dirpc").val(value.dir);
				            	$("#tlf1pc").val(value.tlf);
				            	$("#tlf2pc").val(value.tlf2);

				            });
				        }
				    }
				});
			});













            jQuery(".asg_agredi").click(function() {

            	if ($("#nombre").val()=="" || $("#direccion").val()=="" || $("#docpc").val()=="" || $("#nompc").val()=="" || $("#dirpc").val()=="" || ($("#tlf1pc").val()=="" && $("#tlf2pc").val()=="")){
	              	
	              	swal("¡Error!", "Campos obligatorios vacíos", "error");
	            }
	            else {
	            	
	            	$.post("aseguradora_codigo_agredi.php",$(".frmasg").serialize(),function(res){

	            		if (res==-1){
				  			
				  				swal("¡Error!", "Ya exsite otra aseguradora con ese nombre", "error");
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
										
										$("#capa").load('aseguradora_interfaz_listado.php');
								});
		                        
		                 }




	                });


	            }


            });




});