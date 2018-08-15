jQuery(document).ready(function(){

			

            jQuery(".asg_edi").click(function() {
              $("#capa").load('factura_interfaz_editar.php?id='+$(this).data("id"));
            });

            jQuery("#asg_vlv_list").click(function() {

              $("#capa").load('factura_interfaz_listado.php');
            });

           
            jQuery(".asg_agredi1").click(function() {            	
	            	$.post("factura_codigo_cambiaStts.php",$(".frmasg1").serialize(),function(res){

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
										
										$("#capa").load('factura_interfaz_listado.php');
								});
		                        
		                 

						}


	                });


	            


            });




});