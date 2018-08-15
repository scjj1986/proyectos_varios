jQuery(document).ready(function(){



jQuery("#bnc_agr").click(function() {
		
		$("#nombre").val("");
		$("#idb").val("");
		$("#myModal").modal('show');

});

jQuery(".bnc_edi").click(function() {
		
		$("#nombre").val($(this).data("nombre"));
		$("#idb").val($(this).data("id"));
		$("#myModal").modal('show');

});

jQuery("#agredi_bnc").click(function() {

	if ($("#nombre").val()=="")
		swal("¡Error!", "Campo Nombre vacío", "error");
	else {
		
		$.post("banco_codigo_agredi.php",$("#frmbnc").serialize(),function(res){

						if (res==-1){
                          
                            swal("¡Error!", "El nombre del banco debe ser irrepetible", "error");
                        }
                        else if (res==1) {
                             $("#myModal").modal('hide');       
                                      
                            swal({   
                            title: "Finalizado",   
                            text: "Datos guardados satisfactoriamente",   
                            type: "success",   
                            showCancelButton: false,   
                            confirmButtonColor: "#BBD7ED",   
                            confirmButtonText: "Aceptar",   
                            closeOnConfirm: true }, 

                            function(){

                            
                              
                              $("#capa").load('banco_interfaz_listado.php');
                              });
                                      
                          }else {
                          
                              swal("¡Error!", "Error al guardar banco", "error");
                          }

		});

		

	}

});


});