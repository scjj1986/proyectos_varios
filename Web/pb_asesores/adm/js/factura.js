jQuery(document).ready(function(){

			$("#monto").numeric(".");

			$(":file").filestyle( {
              buttonName: "btn-primary",
               buttonText: "Buscar Archivo",
               uploadAsync: false,
                minFileCount: 1,
                maxFileCount: 5,
              showUpload: false, 
              showRemove: false,

             });


             jQuery("#file").change(function(){
	           /* Limpiar vista previa */
	           $("#vista-previa").html('');
	           var archivos = document.getElementById('file').files;

	           if (archivos.length>1){
	           		swal("¡Error!", "Debe elegir sólo una imagen", "error");
	           		return false;

	           }

	           var navegador = window.URL || window.webkitURL;
	           /* Recorrer los archivos */
	           for(x=0; x<archivos.length; x++)
	           {
	               /* Validar tamaño y tipo de archivo */
	               var size = archivos[x].size;
	               var type = archivos[x].type;
	               var name = archivos[x].name;
	               if (size > 3024*3024)
	               {
	                   $("#vista-previa").append("<p style='color: red'>El archivo "+name+" supera el máximo permitido 3MB</p>");
	               }
	               else if(type != 'image/jpeg' && type != 'image/jpg' && type != 'image/png' && type != 'image/gif')
	               {
	                   $("#vista-previa").append("<p style='color: red'>El archivo "+name+" no es del tipo de imagen permitida.</p>");
	               }
	               else
	               {
	                 var objeto_url = navegador.createObjectURL(archivos[x]);
	                 $("#vista-previa").append("<img src="+objeto_url+" width='300' height='300'>&nbsp;");
	               }
	           }
	       });
        
            jQuery("#fac_agr").click(function() {

              $("#capa").load('factura_interfaz_agregar.php');
            });

            jQuery(".fac_edi").click(function() {

            

              $("#capa").load('factura_interfaz_editar.php?id='+$(this).data("id"));



            });

            jQuery("#fac_vlv_list").click(function() {

              $("#capa").load('factura_interfaz_listado.php');
            });

            jQuery("#bsccli").click(function() {
		        $("#myModal").modal('show');
		    });
		    jQuery(".fac_buscli").click(function() {


		        var idc=$(this).data("id");
		        $.ajax({
                    url: "polizasegurosalud_codigo_buscarcliente.php", 
                    data: {id:idc}, // Ponemos los parametros de ser necesarios 
                    type: "POST",
                    contentType: "application/x-www-form-urlencoded",
                    dataType: "json",  // Esto es lo que indica que la respuesta será un objeto JSon 
                    success: function(data){
                        if(data != null && $.isArray(data)){
                            // Recorremos tu respuesta con each 
                            $.each(data, function(index, value){
                                    $("#idcli").val(value.id);
                                    $("#txtcli").val(value.tp+"-"+value.cedrif+", "+value.nom);

                                $("#myModal").modal('hide');

                            });
                        }
                    }
                });
		    });

		    function fact(){//Fecha actual en formato string
        
	            var f = new Date();
	            var mm;
	            var dd;
	            if(f.getMonth() +1<10){ mm="0"+(f.getMonth()+1);
	                }else{mm=f.getMonth()+1}

	            if(f.getDate()<10){ dd="0"+(f.getDate());
	                }else{dd=f.getDate()}
	            
	            return f.getFullYear() + "-" + mm + "-" + dd;
	        
	        }


            




            jQuery(".fac_agredi").click(function() {

	              if ($("#idcli").val()=="")
	              	swal("¡Error!", "Item N° 1 (Datos del Cliente): Debe elegir un cliente asegurado", "error");
	              else if ( $("#fecha").val()=="")
			          swal("¡Error!", "Item N° 2(Datos de la Factura): Campo Fecha vacío", "error");
			      else if ( $("#fecha").val()>fact())
			          swal("¡Error!", "Item N° 2(Datos de la Factura): La Fecha no debe ser mayor que la fecha actual", "error");
			      else if ($("#monto").val().substr(0,1)==".")
			      	  swal("¡Error!", "Item N° 2(Datos de la Factura): El monto debe ser numérico", "error");
			      else if (parseInt($("#monto").val())==0 )
			      	  swal("¡Error!", "Item N° 2(Datos de la Factura): El monto debe ser mayor que 0", "error");
			      else if (document.getElementById('file').files.length==0 && $("#idf").val()=="")
			      	  swal("¡Error!", "Item N° 3(Fotos): Debe subir al menos una imagen", "error");
			      else {

			      	var archivos = document.getElementById("file").files;
			      	var frmdat = new FormData();
			      	for(i=0; i<archivos.length; i++)
              			frmdat.append('archivo'+i,archivos[i]);


			      	$(".frm").each(function (index) 
			        {
			            frmdat.append($(this).attr("id"),$(this).val());
			            
			        })

			        $.ajax({
		                url:'factura_codigo_agredi.php', //Url a donde la enviaremos
		                type:'POST', //Metodo que usaremos
		                contentType:false, //Debe estar en false para que pase el objeto sin procesar
		                data:frmdat, //Le pasamos el objeto que creamos con los archivos
		                processData:false, //Debe estar en false para que JQuery no procese los datos a enviar
		                cache:false //Para que el formulario no guarde cache
		              }).done(function(res){//Escuchamos la respuesta y capturamos el mensaje msg
		                if (res==-1){
		                          
		                            swal("¡Error!", "El número debe ser irrepetible", "error");
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
		                              
		                              $("#capa").load('factura_interfaz_listado.php');
		                              });
		                                      
		                          }else {
		                          
		                              swal("¡Error!", "No se pudo guardar la imagen en la factura", "error");
		                          }
		              });

			      	
				  	
				  	
				  }
              	

         
            });



            



});