jQuery(document).ready(function(){


    //Preparación del input text en formato hora (formato 12)
		$('#hora').timepicker({
		    showPeriod: true,
		    showLeadingZero: true
		});

			
        
            

            jQuery("#sin_agr").click(function() {

              //$("#capa").html('');
              $("#capa").load('siniestro_interfaz_agregar.php');

            });

            jQuery(".sin_edi").click(function() {

            

              $("#capa").load('siniestro_interfaz_editar.php?id='+$(this).data("id"));



            });

            //Preparación del campo tipo archivo (file)
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
       
       

           jQuery("#bscpol").click(function() {
		        
		        $("#myModal").modal('show');
		    });

		    jQuery(".sin_buspol").click(function() {

		        buscar_poliza($(this).data("id"));
		    });

		    function buscar_poliza(idp){
        	$("#txtcli").val("");
         
        $.ajax({
                    url: "siniestro_codigo_buscarpoliza.php", 
                    data: {id:idp}, // Ponemos los parametros de ser necesarios 
                    type: "POST",
                    contentType: "application/x-www-form-urlencoded",
                    dataType: "json",  // Esto es lo que indica que la respuesta será un objeto JSon 
                    success: function(data){
                        if(data != null && $.isArray(data)){
                            // Recorremos tu respuesta con each 
                            $.each(data, function(index, value){

                                
                                    $("#idpol").val(value.id);
                                    $("#txtnsol").val(value.nsol);
                                    $("#txtnomaseg").val(value.nomaseg);
                                    $("#txtaseg").val(value.aseg);



                                
                                

                                $("#myModal").modal('hide');

                            });
                        }
                    }
                });
    }
       
     

            jQuery("#sin_vlv_list").click(function() {

              $("#capa").load('siniestro_interfaz_listado.php');
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


            
            function agregar_editar(){
    
              var archivos = document.getElementById("file").files;//Creamos un objeto con el elemento que contiene los archivos
              //Creamos una instancia del Objeto FormDara.
              var frmdat = new FormData();
              
              for(i=0; i<archivos.length; i++){
              frmdat.append('archivo'+i,archivos[i]); //Añadimos cada archivo a el arreglo con un indice direfente
              }

              frmdat.append("narch",archivos.length);
              frmdat.append("ids",$("#ids").val());
              frmdat.append("hra",$("#hra").val());
              frmdat.append("idpol",$("#idpol").val());
              frmdat.append("codigo",$("#codigo").val());
              frmdat.append("descripcion",$("#descripcion").val());
              frmdat.append("fecha",$("#fecha").val());
              frmdat.append("lugar",$("#lugar").val());
              frmdat.append("status",$("#status").val());


              
           
              /*Ejecutamos la función ajax de jQuery*/    
              $.ajax({
                url:'siniestro_codigo_agredi.php', //Url a donde la enviaremos
                type:'POST', //Metodo que usaremos
                contentType:false, //Debe estar en false para que pase el objeto sin procesar
                data:frmdat, //Le pasamos el objeto que creamos con los archivos
                processData:false, //Debe estar en false para que JQuery no procese los datos a enviar
                cache:false //Para que el formulario no guarde cache
              }).done(function(res){//Escuchamos la respuesta y capturamos el mensaje msg
                if (res==-1){
                          
                            swal("¡Error!", "El código debe ser irrepetible", "error");
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
                              
                              $("#capa").load('siniestro_interfaz_listado.php');
                              });
                                      
                          }else{
                          
                              swal("¡Error!", "No se pudieron guardar las imágenes en el siniestro", "error");
                          }
              });
            }



            jQuery(".sin_agredi").click(function() {

	              $("#hra").val($("#hora").val());

	              if ($("#idpol").val()=="")
	              		swal("¡Error!", "Item N° 1 (Datos del Cliente): Debe seleccionar un cliente", "error");
	              else if ($("#codigo").val()=="")
	              		swal("¡Error!", "Item N° 2 (Datos del Siniestro): Campo Código vacío", "error");
	              else if ($("#descripcion").val()=="")
	              		swal("¡Error!", "Item N° 2 (Datos del Siniestro): Campo Descripción vacío", "error");
	              else if ($("#hra").val()=="")
	              		swal("¡Error!", "Item N° 2 (Datos del Siniestro): Campo Hora vacío", "error");
	              else if ($("#fecha").val()=="")
	              		swal("¡Error!", "Item N° 2 (Datos del Siniestro): Campo Fecha vacío", "error");
	              else if ($("#fecha").val()>fact())
	              		swal("¡Error!", "Item N° 2 (Datos del Siniestro): Campo Fecha no debe ser mayor que la fecha actual", "error");
                else if ($("#lugar").val()=="")
                    swal("¡Error!", "Item N° 2 (Datos del Siniestro): Campo Lugar vacío", "error");
                else if (document.getElementById('file').files.length==0 && $("#ids").val()=="")
                    swal("¡Error!", "Item N° 3(Fotos): Debe subir al menos una imagen", "error");
	              else 
                    agregar_editar();
         
            });



            



});