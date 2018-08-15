jQuery(document).ready(function(){


	

    function resetear_select(valor){
    	
    	$("#"+valor).empty();
        $("#"+valor).append('<option value="-1">Seleccione...</option>');
    }

    function fact(){
		
			var f = new Date();
			var mm;
			var dd;
			if(f.getMonth() +1<10){ mm="0"+(f.getMonth()+1);
				}else{mm=f.getMonth()+1}

			if(f.getDate()<10){ dd="0"+(f.getDate());
				}else{dd=f.getDate()}
			
			return f.getFullYear() + "-" + mm + "-" + dd;
		
		}


	jQuery("#cli_agr").click(function() {

              $("#capa").load('cliente_interfaz_agregar.php');    
    });

    jQuery(".cli_det").click(function() {
              $("#capa").load('cliente_interfaz_detalles.php?id='+$(this).data("id"));
    });
    jQuery(".cli_edi").click(function() {
              $("#capa").load('cliente_interfaz_editar.php?id='+$(this).data("id"));
    });





    jQuery("#cli_vlv_list").click(function() {

              $("#capa").load('cliente_interfaz_listado.php');
    });

    jQuery(".cli_agredi").click(function() {

              if ( $("#cedrif").val()==""){
              	swal("¡Error!", "Campo Cédula/RIF/Pas. vacío", "error");
              }
              else if ( $("#nomrs").val()=="" ){
              	swal("¡Error!", "Campo Nombre/Razón Social vacío", "error");
              }
              else if ($("#fnac").val()==""  ){
              	swal("¡Error!", "Campo Fecha de Nacimiento vacío", "error");
              }
              else if ( fact()<$("#fnac").val() ) {
              	swal("¡Error!", "Fecha de nacimiento no debe ser mayor que la fecha actual", "error");
              }
              else if ( $("#edo").val()=="-1"  ) {
              	swal("¡Error!", "Debe seleccionar el Estado", "error");
              }
              else if ( $("#ciu").val()==""  ) {
              	swal("¡Error!", "Campo Ciudad vacío", "error");
              }
              else if ( $("#mun").val()=="-1"  ) {
              	swal("¡Error!", "Debe seleccionar el Municipio", "error");
              }
              else if ( $("#par").val()=="-1"  ) {
              	swal("¡Error!", "Debe seleccionar la Parroquia", "error");
              }
              else if ( $("#usb").val()==""  ) {
              	swal("¡Error!", "Campo Urb./Sect./Bar. vacío", "error");
              }
              else if ( $("#egcq").val()==""  ) {
              	swal("¡Error!", "Campo Edif./Gal./Cas./Qta. vacío", "error");
              }
              else if ( $("#vp").val()==""  ) {
              	swal("¡Error!", "Campo Vía Pincipal vacío", "error");
              }
              else if ( $("#ref").val()==""  ) {
              	swal("¡Error!", "Campo Referencia vacío", "error");
              }
              else if ( $("#cp").val()==""  ) {
              	swal("¡Error!", "Campo Código Postal vacío", "error");
              }
              else if ( $("#tlfh").val()=="" && $("#tlfo").val()=="" && $("#tlfc").val()==""  ) {
              	swal("¡Error!", "Debe ingresar por lo menos un número de teléfono", "error");
              }
              else {

              	$.post("cliente_codigo_agredi.php",$(".frmcli").serialize(),function(res){

              		if (res==-1){
				  			
				  				swal("¡Error!", "Ya exsite otro cliente con la misma Céd./R.I.F./Pas.", "error");
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
										
										$("#capa").load('cliente_interfaz_listado.php');
								});
		                        
		                 }
		                 else if (res==2) {
		                    	
		                        
		                        swal({   
									title: "Finalizado",   
									text: "Datos modificados satisfactoriamente",   
									type: "success",   
									showCancelButton: false,   
									confirmButtonColor: "#BBD7ED",   
									confirmButtonText: "Aceptar",   
									closeOnConfirm: true }, 

									function(){
										
										$("#capa").load('cliente_interfaz_listado.php');
								});
		                        
		                 }
		                 else {
		                 	
		                 	swal("¡Error!", "Hubo un error en la base de datos", "error");
		                 }


              	});
              }


    });



    jQuery("#tp").change(function() {

			

            if ($("#tp").val()=="J"){
            	$("#pj").show();
            }
            else {
            	$("#pj").hide();

            }
    });


    jQuery("#edo").change(function() {

			resetear_select("mun");
            resetear_select("par");

            if ($("#edo").val()!="-1"){
            	cargar_select_municipio();

            }
    });

    jQuery("#mun").change(function() {

			resetear_select("par");

            if ($("#mun").val()!="-1"){
            	cargar_select_parroquia();

            }
    });



    // Método para cargar select de estados//
    
    function cargar_select_estado(){
    	$.ajax({
				    url: "cliente_codigo_listarestados.php", /* Llamamos a tu archivo */
				    type: "POST",
				    contentType: "application/x-www-form-urlencoded",
				    dataType: "json",  /* Esto es lo que indica que la respuesta será un objeto JSon */
				    success: function(data){
				        
				        if(data != null && $.isArray(data)){
				            /* Recorremos tu respuesta con each */



				            $.each(data, function(index, value){

								$("#edo").append('<option value="'+value.id+'">'+value.nombre+'</option>');

				            });
				        }
				    }
				});


    }
    //------------------------------------------------------------//






    function cargar_select_municipio(){
    	$.ajax({
				    url: "cliente_codigo_listarmunicipios.php", /* Llamamos a tu archivo */
				    data: "idedo="+$("#edo").val(), /* Ponemos los parametros de ser necesarios */
				    type: "POST",
				    contentType: "application/x-www-form-urlencoded",
				    dataType: "json",  /* Esto es lo que indica que la respuesta será un objeto JSon */
				    success: function(data){
				        
				        if(data != null && $.isArray(data)){
				            /* Recorremos tu respuesta con each */



				            $.each(data, function(index, value){

								$("#mun").append('<option value="'+value.id+'">'+value.nombre+'</option>');

				            });
				        }
				    }
				});

    }

    function cargar_select_parroquia(){
    	$.ajax({
				    url: "cliente_codigo_listarparroquias.php", /* Llamamos a tu archivo */
				    data: "idmun="+$("#mun").val(), /* Ponemos los parametros de ser necesarios */
				    type: "POST",
				    contentType: "application/x-www-form-urlencoded",
				    dataType: "json",  /* Esto es lo que indica que la respuesta será un objeto JSon */
				    success: function(data){
				        
				        if(data != null && $.isArray(data)){
				            /* Recorremos tu respuesta con each */



				            $.each(data, function(index, value){

								$("#par").append('<option value="'+value.id+'">'+value.nombre+'</option>');

				            });
				        }
				    }
				});

    }






    




});