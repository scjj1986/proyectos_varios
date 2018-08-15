jQuery(document).ready(function(){



	$('.dec').numeric("."); 

	jQuery("#psa_agr").click(function() {

              $("#capa").load('polizaseguroauto_interfaz_agregar.php');
    });

    jQuery(".psa_edi").click(function() {

              $("#capa").load('polizaseguroauto_interfaz_editar.php?id='+$(this).data("id"));
    });

    jQuery(".psa_pdf").click(function() {

              

              $.ajax({
                    url:'polizaseguroauto_codigo_pdfsol.php', //Url a donde la enviaremos
                    type:'POST', //Metodo que usaremos
                    contentType:false, //Debe estar en false para que pase el objeto sin procesar
                    processData:false, //Debe estar en false para que JQuery no procese los datos a enviar
                    data: {id:$(this).data("id")},
                    cache:false //Para que el formulario no guarde cache
                  }).done(function(res){//Escuchamos la respuesta y capturamos el mensaje msg
                    if (res==1) {
                           
                                console.log("Se creó el PDF");
                                          
                    }else {
                              
                          console.log("No se creó el PDF");
                    }
                  });
    });

    jQuery("#psa_vlv_list").click(function() {

              $("#capa").load('polizaseguroauto_interfaz_listado.php');
    });

    jQuery("#idasg").change(function() {

            
            $("#nsol").val("");
            $("#nsol2").val("");
            if ($(this).val()!="-1"){

                //------  Consulta a la base de datos para generar correltivo, dependiendo de la aseguradora
                $.ajax({
                    url: "polizaseguroauto_codigo_generarnumsol.php", /* Llamamos a tu archivo */
                    data: {id:$(this).val(),idpsa:$("#idpsa").val()}, /* Ponemos los parametros de ser necesarios */
                    type: "POST",
                    contentType: "application/x-www-form-urlencoded",
                    dataType: "json",  /* Esto es lo que indica que la respuesta será un objeto JSon */
                    success: function(data){
                        if(data != null && $.isArray(data)){
                            /* Recorremos tu respuesta con each */
                            $.each(data, function(index, value){

                                $("#nsol").val(value.correl);
                                $("#nsol2").val(value.correl);

                            });
                        }
                    }
                });
            }  
    });

    var tipocli="";

    jQuery("#bsctom").click(function() {
        tipocli="TOMADOR";
        $("#myModal").modal('show');
    });

    jQuery("#bscaseg").click(function() {
        tipocli="ASEGURADO";
        $("#myModal").modal('show');
    });

    jQuery(".pss_buscli").click(function() {

        
        if (tipocli=="TOMADOR")
            limpiar_datos_tomador();
        else
            limpiar_datos_asegurado();


        buscar_cliente($(this).data("id"));
    });

    jQuery("#cod_int").blur(function() {//Pérdida de foco código intermediario (búsqueda en base de datos)

        if ($(this).val()!=""){

                //------  Consulta a la base de datos para buscar beneficiario
                $.ajax({
                    url: "polizasegurosalud_codigo_buscarintermediario.php",
                    data: {cod:$(this).val()}, 
                    type: "POST",
                    contentType: "application/x-www-form-urlencoded",
                    dataType: "json",  
                    success: function(data){
                        if(data != null && $.isArray(data)){
                            $.each(data, function(index, value){

                                $("#nom_int").val(value.nom);
                                $("#ppar_int").val(value.ppar);

                            });
                        }
                    }
                });
            }
    });

    

    function int_repetido(){//Verificación de cédula repetida al agregar un beneficiario en la tabla
        var resp=false;
        $(".codint").each(function (index) 
        {
            
            if ($(this).val()==$("#cod_int").val()) {

                resp = true;
            }
        })
        return resp;
    }



    

    jQuery("#agr_int").click(function() {//Click para agregar beneficiario en la fila de su tabla

        if ($("#cont3").val()=="3")
            swal("¡Error!", "Item N° 7 (Intermediarios): No se pueden agregar intermediarios", "error");
        else if (  $("#cod_int").val()=="" || $("#nom_int").val()=="" || $("#ppar_int").val()=="")
            swal("¡Error!", "Item N° 7 (Intermediarios): Al agregar un intermediario, debe completar todos los campos", "error");
        else if (int_repetido())
            swal("¡Error!", "Item N° 7 (Intermediarios): Ya existe un intermediario con el mismo código", "error");
        else {

            agregar_fila_int();
            $("#cod_int").val("");
            $("#nom_int").val("");
            $("#ppar_int").val("");
        } 
    
    });



    function agregar_fila_int(){

        var cont = parseInt($("#cont3").val());
        var max = parseInt($("#max3").val());
        cont++;
        max++;
        $("#cont3").val(cont.toString());
        $("#max3").val(max.toString());
        
        if ($('#tb-int tr').length == 0){

            $("#tb-int").append('<tr id="fint'+max.toString()+'"><td><input class="codint" hidden  name="cod_int'+max.toString()+'" id="cod_int'+max.toString()+'" value="'+$("#cod_int").val().toUpperCase()+'" />'+$("#cod_int").val().toUpperCase()+'</td><td><input hidden  name="nom_int'+max.toString()+'" id="nom_int'+max.toString()+'" value="'+$("#nom_int").val().toUpperCase()+'" />'+$("#nom_int").val().toUpperCase()+'</td><td><input hidden  name="ppar_int'+max.toString()+'" id="ppar_int'+max.toString()+'" value="'+$("#ppar_int").val().toUpperCase()+'" />'+$("#ppar_int").val().toUpperCase()+'</td><td><button title="Eliminar" data-id="fint'+max.toString()+'" type="button" class="elm_int btn-danger"><span class="glyphicon glyphicon-remove"></span></button></td></tr>');
                       
        
        }
        else {

            $("#tb-int tr:last").after('<tr id="fint'+max.toString()+'"><td><input class="codint" hidden  name="cod_int'+max.toString()+'" id="cod_int'+max.toString()+'" value="'+$("#cod_int").val().toUpperCase()+'" />'+$("#cod_int").val().toUpperCase()+'</td><td><input hidden  name="nom_int'+max.toString()+'" id="nom_int'+max.toString()+'" value="'+$("#nom_int").val().toUpperCase()+'" />'+$("#nom_int").val().toUpperCase()+'</td><td><input hidden  name="ppar_int'+max.toString()+'" id="ppar_int'+max.toString()+'" value="'+$("#ppar_int").val().toUpperCase()+'" />'+$("#ppar_int").val().toUpperCase()+'</td><td><button title="Eliminar" data-id="fint'+max.toString()+'" type="button" class="elm_int btn-danger"><span class="glyphicon glyphicon-remove"></span></button></td></tr>');
             
            

        }


    }
    
    
    // Eliminar un intermediario de la lista
    $(document).on('click','.elm_int',function (e){
        
        
        if ($("#evt").val()=="NO"){

            var cont = parseInt($("#cont3").val());
            var max = parseInt($("#max3").val());


            if (cont==1)
                max=0;
            
            cont--;
            $("#cont3").val(cont.toString());
            $("#max3").val(max.toString());

            var id=$(this).data("id");
            $("#"+id).remove();
            $("#evt").val("SI");
                
        }
        else {
            
            $("#evt").val("NO");
        } 

    }); 

    function coberturas_sin_seleccionar(){//Coberturas sin seleccionar
        var resp=true;
        $(".chk").each(function (index) 
        {
            
            if ($(this).is(":checked")) {

                resp = false;
            }
        })
        return resp;
    }

    function validar_coberturas (){
        
        if ($("#ch_amp").is(":checked")){
            if ($("#amp_sa").val()==".")
                return false;
            else if ($("#amp_sa").val()=="0")
                return false;
            else if (parseFloat($("#amp_sa").val()).toFixed(2)==0)
                return false;
        }
        if ($("#ch_aded").is(":checked")){
            if ($("#aded_sa").val()==".")
                return false;
            else if ($("#aded_sa").val()=="0")
                return false;
            else if (parseFloat($("#aded_sa").val()).toFixed(2)==0)
                return false;
        }
        if ($("#ch_apf").is(":checked")){
            if ($("#apf_sa").val()==".")
                return false;
            else if ($("#apf_sa").val()=="0")
                return false;
            else if (parseFloat($("#apf_sa").val()).toFixed(2)==0)
                return false;
        }

        if ($("#ch_pt").is(":checked")){
            if ($("#pt_sa").val()==".")
                return false;
            else if ($("#pt_sa").val()=="0")
                return false;
            else if (parseFloat($("#pt_sa").val()).toFixed(2)==0)
                return false;
        }
        if ($("#ch_id").is(":checked")){
            if ($("#amp_id").val()==".")
                return false;
            else if ($("#amp_id").val()=="0")
                return false;
            else if (parseFloat($("#amp_id").val()).toFixed(2)==0)
                return false;
        }
        if ($("#ch_rrcd").is(":checked")){
            if ($("#rrcd_sa").val()==".")
                return false;
            else if ($("#rrcd_sa").val()=="0")
                return false;
            else if (parseFloat($("#rrcd_sa").val()).toFixed(2)==0)
                return false;
        }
        if ($("#ch_aa").is(":checked")){
            if ($("#aa_sa").val()==".")
                return false;
            else if ($("#aa_sa").val()=="0")
                return false;
            else if (parseFloat($("#aa_sa").val()).toFixed(2)==0)
                return false;
        }
        if ($("#ch_otr").is(":checked")){
            if ($("#otr_sa").val()==".")
                return false;
            else if ($("#otr_sa").val()=="0")
                return false;
            else if (parseFloat($("#otr_sa").val()).toFixed(2)==0)
                return false;
        }
        if ($("#ch_rcv").is(":checked")){
            if ($("#rcv_sa").val()==".")
                return false;
            else if ($("#rcv_sa").val()=="0")
                return false;
            else if (parseFloat($("#otr_sa").val()).toFixed(2)==0)
                return false;
        }
        if ($("#ch_aldp").is(":checked")){
            if ($("#aldp_sa").val()==".")
                return false;
            else if ($("#aldp_sa").val()=="0")
                return false;
            else if (parseFloat($("#aldp_sa").val()).toFixed(2)==0)
                return false;
        }
        if ($("#ch_el").is(":checked")){
            if ($("#el_sa").val()==".")
                return false;
            else if ($("#el_sa").val()=="0")
                return false;
            else if (parseFloat($("#el_sa").val()).toFixed(2)==0)
                return false;
        }
        if ($("#ch_m").is(":checked")){
            if ($("#m_sa").val()==".")
                return false;
            else if ($("#m_sa").val()=="0")
                return false;
            else if (parseFloat($("#m_sa").val()).toFixed(2)==0)
                return false;
        }
        if ($("#ch_inv").is(":checked")){
            if ($("#inv_sa").val()==".")
                return false;
            else if ($("#inv_sa").val()=="0")
                return false;
            else if (parseFloat($("#inv_sa").val()).toFixed(2)==0)
                return false;
        }
        if ($("#ch_gmc").is(":checked")){
            if ($("#gmc_sa").val()==".")
                return false;
            else if ($("#gmc_sa").val()=="0")
                return false;
            else if (parseFloat($("#gmc_sa").val()).toFixed(2)==0)
                return false;
        }
        if ($("#ch_ge").is(":checked")){
            if ($("#ge_sa").val()==".")
                return false;
            else if ($("#ge_sa").val()=="0")
                return false;
            else if (parseFloat($("#ge_sa").val()).toFixed(2)==0)
                return false;
        }

        return true;
    }

    function preparar_coberturas (){
        
        if (!$("#ch_amp").is(":checked")){
            $("#amp_sa").val("0");
        }
        if (!$("#ch_aded").is(":checked")){
            $("#aded_sa").val("0")
        }
        if (!$("#ch_apf").is(":checked")){
            $("#apf_sa").val("0");
        }

        if (!$("#ch_pt").is(":checked")){
            $("#pt_sa").val("0")
        }
        if (!$("#ch_id").is(":checked")){
            $("#amp_id").val("0");
        }
        if (!$("#ch_rrcd").is(":checked")){
            $("#rrcd_sa").val("0");
        }
        if (!$("#ch_aa").is(":checked")){
            $("#aa_sa").val("0");
        }
        if (!$("#ch_otr").is(":checked")){
            $("#otr_sa").val("0");
        }
        if (!$("#ch_rcv").is(":checked")){
            $("#rcv_sa").val("0");
        }
        if (!$("#ch_aldp").is(":checked")){
            $("#aldp_sa").val("0");
        }
        if (!$("#ch_el").is(":checked")){
            $("#el_sa").val("0");
        }
        if (!$("#ch_m").is(":checked")){
            $("#m_sa").val("0");
        }
        if (!$("#ch_inv").is(":checked")){
            $("#inv_sa").val("0");
        }
        if (!$("#ch_gmc").is(":checked")){
            $("#gmc_sa").val("0");
        }
        if (!$("#ch_ge").is(":checked")){
            $("#ge_sa").val("0");
        }
    }





    jQuery(".psa_agredi").click(function() {

    	
        
    	if ( $("#idasg").val()=="-1")
            swal("¡Error!", "Item N° 1(Datos de la Empresa Aseguradora): Debe elegir una aseguradora", "error");
        else if ( $("#idtom").val()=="")
            swal("¡Error!", "Item N° 2(Datos del Tomador): Debe elegir un cliente", "error");
        else if ( $("#idat").val()=="")
            swal("¡Error!", "Item N° 3(Datos del propuesto Asegurado Natural): Debe elegir un cliente", "error");
        else if ($("#fdes").val()=="")
             swal("¡Error!", "Item N° 4(Vigencia del seguro): Campo Fecha Desde vacío", "error");
        else if ($("#fhas").val()=="")
             swal("¡Error!", "Item N° 4(Vigencia del seguro): Campo Fecha Hasta vacío", "error");
        else if ($("#fdes").val()>=$("#fhas").val())
             swal("¡Error!", "Item N° 4(Vigencia del seguro): Campo Fecha Desde no debe ser mayor o igual que el campo Fecha Hasta", "error");
        else if ($("#fhas").val()<=fact())
             swal("¡Error!", "Item N° 4(Vigencia del seguro): Campo Fecha Hasta debe ser mayor que la fecha actual", "error");
        else if ($("#ande").val()=="-1")
             swal("¡Error!", "Item N° 4(Vigencia del seguro): Debe elegir a nombre de quién saldrá en la factura para cobro de prima", "error"); 
        else if ($("#placa").val()=="")
             swal("¡Error!", "Item N° 5(Bien por Asegurar): Campo Placa vacío", "error");
        else if ($("#marca").val()=="")
             swal("¡Error!", "Item N° 5(Bien por Asegurar): Campo Marca vacío", "error");
        else if ($("#modelo").val()=="")
             swal("¡Error!", "Item N° 5(Bien por Asegurar): Campo Modelo vacío", "error");
        else if ($("#anio").val()=="")
             swal("¡Error!", "Item N° 5(Bien por Asegurar): Campo Año vacío", "error");
        else if ($("#color").val()=="")
             swal("¡Error!", "Item N° 5(Bien por Asegurar): Campo Color vacío", "error");
        else if ($("#smot").val()=="")
             swal("¡Error!", "Item N° 5(Bien por Asegurar): Campo Serial del Motor vacío", "error");
        else if ($("#scar").val()=="")
             swal("¡Error!", "Item N° 5(Bien por Asegurar): Campo Serial de la Carrocería vacío", "error");
        else if ($("#trans").val()=="")
             swal("¡Error!", "Item N° 5(Bien por Asegurar): Campo Transmisión vacío", "error");
        else if ($("#uveh").val()=="")
             swal("¡Error!", "Item N° 5(Bien por Asegurar): Campo Uso del Vehículo vacío", "error");
        else if ($("#tcar").val()=="")
             swal("¡Error!", "Item N° 5(Bien por Asegurar): Campo Tipo de Carga vacío", "error");
        else if ($("#npas").val()=="")
             swal("¡Error!", "Item N° 5(Bien por Asegurar): Campo N° Pasajeros vacío", "error");
        else if ($("#peso").val()=="")
             swal("¡Error!", "Item N° 5(Bien por Asegurar): Campo Peso (Kgs.) vacío", "error");
        else if ($("#tons").val()=="")
             swal("¡Error!", "Item N° 5(Bien por Asegurar): Campo Toneladas vacío", "error");
        else if ($("#aexp").val()=="")
             swal("¡Error!", "Item N° 5(Bien por Asegurar): Campo Años de Experiencia vacío", "error");
        else if (coberturas_sin_seleccionar()) 
            swal("¡Error!", "Item N° 6(Coberturas Solicitadas): Debe seleccionar al menos una cobertura", "error");
        else if (!validar_coberturas())
            swal("¡Error!", "Item N° 6(Coberturas Solicitadas): Por cada cobertura seleccionada, la suma asegurada debe ser mayor que 0", "error");
        else if ( $("#fecha").val()=="")
            swal("¡Error!", "Item N° 8(Fecha y Lugar): Campo Fecha vacío", "error");
        else if ( $("#fecha").val()>fact())
            swal("¡Error!", "Item N° 8(Fecha y Lugar): La Fecha no debe ser mayor que la fecha actual", "error");
        else if ( $("#lugar").val()=="")
            swal("¡Error!", "Item N° 8(Fecha y Lugar): Campo Lugar vacío", "error");
        else{ 
            preparar_coberturas ();
            $.post("polizaseguroauto_codigo_agredi.php",$(".frmpsa").serialize(),function(res){

                if (res==1) {
                                
                                
                                swal({   
                                    title: "Finalizado",   
                                    text: "Datos guardados satisfactoriamente",   
                                    type: "success",   
                                    showCancelButton: false,   
                                    confirmButtonColor: "#BBD7ED",   
                                    confirmButtonText: "Aceptar",   
                                    closeOnConfirm: true }, 

                                    function(){
                                        
                                        $("#capa").load('polizaseguroauto_interfaz_listado.php');
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
                                        
                                        $("#capa").load('polizaseguroauto_interfaz_listado.php');
                                });
                                
                }



                else {
                    
                    swal("¡Error!", "No se pudo guardar la póliza", "error");
                }

            
            });


        } 

    

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


    function limpiar_datos_tomador(){

                                    $("#idtom").val("");
                                    $("#txttomador").val("");
                                    $("#pj").hide();
                                    $("#natemp").val("");
                                    $("#fnac").val("");
                                    $("#sexo").val("");
                                    $("#ec").val("");
                                    $("#inganu").val("");
                                    $("#acteco").val("");
                                    $("#ocu").val("");
                                    $("#edo").val("");
                                    $("#ciu").val("");
                                    $("#mun").val("");
                                    $("#par").val("");
                                    $("#usb").val("");
                                    $("#egcq").val("");
                                    $("#vp").val("");
                                    $("#vder").val("");
                                    $("#vizq").val("");
                                    $("#tsa").val("");
                                    $("#pn").val("");
                                    $("#loa").val("");
                                    $("#ref").val("");
                                    $("#otro").val("");
                                    $("#cp").val("");
                                    $("#tlfh").val("");
                                    $("#tlfo").val("");
                                    $("#tlfc").val("");
                                    $("#fax").val("");
                                    $("#email").val("");

    }

    function limpiar_datos_asegurado(){

                                    $("#idat").val("");
                                    $("#txtaseg").val("");
                                    $("#pj2").hide();
                                    $("#natemp2").val("");
                                    $("#fnac2").val("");
                                    $("#sexo2").val("");
                                    $("#ec2").val("");
                                    $("#inganu2").val("");
                                    $("#acteco2").val("");
                                    $("#ocu2").val("");
                                    $("#edo2").val("");
                                    $("#ciu2").val("");
                                    $("#mun2").val("");
                                    $("#par2").val("");
                                    $("#usb2").val("");
                                    $("#egcq2").val("");
                                    $("#vp2").val("");
                                    $("#vder2").val("");
                                    $("#vizq2").val("");
                                    $("#tsa2").val("");
                                    $("#pn2").val("");
                                    $("#loa2").val("");
                                    $("#ref2").val("");
                                    $("#otro2").val("");
                                    $("#cp2").val("");
                                    $("#tlfh2").val("");
                                    $("#tlfo2").val("");
                                    $("#tlfc2").val("");
                                    $("#fax2").val("");
                                    $("#email2").val("");

    }



    function buscar_cliente(idt){
        
         
        $.ajax({
                    url: "polizasegurosalud_codigo_buscarcliente.php", 
                    data: {id:idt}, // Ponemos los parametros de ser necesarios 
                    type: "POST",
                    contentType: "application/x-www-form-urlencoded",
                    dataType: "json",  // Esto es lo que indica que la respuesta será un objeto JSon 
                    success: function(data){
                        if(data != null && $.isArray(data)){
                            // Recorremos tu respuesta con each 
                            $.each(data, function(index, value){

                                if (tipocli=="TOMADOR"){
                                    $("#idtom").val(value.id);
                                    $("#txttomador").val(value.tp+"-"+value.cedrif+", "+value.nom);


                                    if (value.tp=="J"){
                                        $("#natemp").val(value.natemp);
                                        $("#pj").show();
                                    }
                                    else {
                                        $("#pj").hide();

                                    }

                                    $("#fnac").val(value.fnac);
                                    $("#sexo").val(value.sx);
                                    $("#ec").val(value.ec);
                                    $("#inganu").val(value.ianu);
                                    $("#acteco").val(value.aeco);
                                    $("#ocu").val(value.ocu);
                                    $("#edo").val(value.edo);
                                    $("#ciu").val(value.ciu);
                                    $("#mun").val(value.mun);
                                    $("#par").val(value.par);
                                    $("#usb").val(value.usb);
                                    $("#egcq").val(value.egcq);
                                    $("#vp").val(value.vp);
                                    $("#vder").val(value.vder);
                                    $("#vizq").val(value.vizq);
                                    $("#tsa").val(value.tsa);
                                    $("#pn").val(value.pn);
                                    $("#loa").val(value.loa);
                                    $("#ref").val(value.ref);
                                    $("#otro").val(value.otro);
                                    $("#cp").val(value.cp);
                                    $("#tlfh").val(value.tlfh);
                                    $("#tlfo").val(value.tlfo);
                                    $("#tlfc").val(value.tlfc);
                                    $("#fax").val(value.fax);
                                    $("#email").val(value.email);



                                }
                                else {

                                    $("#idat").val(value.id);
                                    $("#txtaseg").val(value.tp+"-"+value.cedrif+", "+value.nom);

                                    if (value.tp=="J"){
                                        $("#natemp2").val(value.natemp);
                                        $("#pj2").show();
                                    }
                                    else {
                                        $("#pj2").hide();

                                    }

                                    $("#fnac2").val(value.fnac);
                                    $("#sexo2").val(value.sx);
                                    $("#ec2").val(value.ec);
                                    $("#inganu2").val(value.ianu);
                                    $("#acteco2").val(value.aeco);
                                    $("#ocu2").val(value.ocu);
                                    $("#edo2").val(value.edo);
                                    $("#ciu2").val(value.ciu);
                                    $("#mun2").val(value.mun);
                                    $("#par2").val(value.par);
                                    $("#usb2").val(value.usb);
                                    $("#egcq2").val(value.egcq);
                                    $("#vp2").val(value.vp);
                                    $("#vder2").val(value.vder);
                                    $("#vizq2").val(value.vizq);
                                    $("#tsa2").val(value.tsa);
                                    $("#pn2").val(value.pn);
                                    $("#loa2").val(value.loa);
                                    $("#ref2").val(value.ref);
                                    $("#otro2").val(value.otro);
                                    $("#cp2").val(value.cp);
                                    $("#tlfh2").val(value.tlfh);
                                    $("#tlfo2").val(value.tlfo);
                                    $("#tlfc2").val(value.tlfc);
                                    $("#fax2").val(value.fax);
                                    $("#email2").val(value.email);
                                    
                                    
                                }

                                $("#myModal").modal('hide');

                            });
                        }
                    }
                });
    }


});