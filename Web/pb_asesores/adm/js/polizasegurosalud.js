jQuery(document).ready(function(){

    
    $('.dec').numeric("."); 

	jQuery("#pss_agr").click(function() {

              $("#capa").load('polizasegurosalud_interfaz_agregar.php');
    });

    jQuery(".pss_edi").click(function() {

              $("#capa").load('polizasegurosalud_interfaz_editar.php?id='+$(this).data("id"));
    });

    jQuery("#pss_vlv_list").click(function() {

              $("#capa").load('polizasegurosalud_interfaz_listado.php');
    });

    jQuery("#tip_cob_prim").change(function() {

            

            if ($("#tip_cob_prim").val()=="DOMICILIACION BANCARIA"){
                $("#dombanc").show();
                $("#tarjcred").hide();
            }
            else {
                $("#dombanc").hide();
                $("#tarjcred").show();

            }
    });
    

    jQuery("#reemb_bco").change(function() {

            

            if ($("#reemb_bco").val()=="COBRO DE PRIMA"){
                $("#otracta").hide();
            }
            else {
                $("#otracta").show();

            }
    }); 




    jQuery("#ced_ben").blur(function() {//Pérdida de foco cédula beneficiario (búsqueda en base de datos)

        if ($(this).val()!=""){

                //------  Consulta a la base de datos para buscar beneficiario
                $.ajax({
                    url: "polizasegurosalud_codigo_buscarbeneficiario.php",
                    data: {ced:$(this).val()}, 
                    type: "POST",
                    contentType: "application/x-www-form-urlencoded",
                    dataType: "json",  
                    success: function(data){
                        if(data != null && $.isArray(data)){
                            
                            $.each(data, function(index, value){

                                $("#nom_ben").val(value.nom);
                                $("#par_ben").val(value.par);
                                $("#ppar_ben").val(value.ppar);

                            });
                        }
                    }
                });
            }
    });

    function benf_repetido(){//Verificación de cédula repetida al agregar un beneficiario en la tabla
        var resp=false;
        $(".cedben").each(function (index) 
        {
            
            if ($(this).val()==$("#ced_ben").val()) {

                resp = true;
            }
        })
        return resp;
    }

    jQuery("#agr_ben").click(function() {//Click para agregar beneficiario en la fila de su tabla

        if ($("#cont").val()=="2")
            swal("¡Error!", "Item N° 7 (Beneficiario): No se pueden agregar beneficiarios", "error");
        else if (  $("#ced_ben").val()=="" || $("#nom_ben").val()=="" || $("#par_ben").val()=="" || $("#ppar_ben").val()=="")
            swal("¡Error!", "Item N° 7 (Beneficiario): Al agregar un beneficiario, debe completar todos los campos", "error");
        else if (benf_repetido())
            swal("¡Error!", "Item N° 7 (Beneficiario): Ya existe un beneficiario con la misma cédula", "error");
        else {

            agregar_fila_benf();
            $("#ced_ben").val("");
            $("#nom_ben").val("");
            $("#par_ben").val("");
            $("#ppar_ben").val("");
        } 
    
    }); 

    function agregar_fila_benf(){

        var cont = parseInt($("#cont").val());
        var max = parseInt($("#max").val());
        cont++;
        max++;
        $("#cont").val(cont.toString());
        $("#max").val(max.toString());
        
        if ($('#tb-ben tr').length == 0){

            $("#tb-ben").append('<tr id="fben'+max.toString()+'"><td><input class="cedben" hidden  name="ced_ben'+max.toString()+'" id="ced_ben'+max.toString()+'" value="'+$("#ced_ben").val()+'" />'+$("#ced_ben").val()+'</td><td><input hidden  name="nom_ben'+max.toString()+'" id="nom_ben'+max.toString()+'" value="'+$("#nom_ben").val().toUpperCase()+'" />'+$("#nom_ben").val().toUpperCase()+'</td><td><input hidden  name="par_ben'+max.toString()+'" id="par_ben'+max.toString()+'" value="'+$("#par_ben").val().toUpperCase()+'" />'+$("#par_ben").val().toUpperCase()+'</td><td><input hidden  name="ppar_ben'+max.toString()+'" id="ppar_ben'+max.toString()+'" value="'+$("#ppar_ben").val()+'" />'+$("#ppar_ben").val()+'</td><td><button title="Eliminar" data-id="fben'+max.toString()+'" type="button" class="elm_ben btn-danger"><span class="glyphicon glyphicon-remove"></span></button></td></tr>');
                       
        
        }
        else {

            $("#tb-ben tr:last").after('<tr id="fben'+max.toString()+'"><td><input class="cedben" hidden  name="ced_ben'+max.toString()+'" id="ced_ben'+max.toString()+'" value="'+$("#ced_ben").val()+'" />'+$("#ced_ben").val()+'</td><td><input hidden  name="nom_ben'+max.toString()+'" id="nom_ben'+max.toString()+'" value="'+$("#nom_ben").val().toUpperCase()+'" />'+$("#nom_ben").val().toUpperCase()+'</td><td><input hidden  name="par_ben'+max.toString()+'" id="par_ben'+max.toString()+'" value="'+$("#par_ben").val().toUpperCase()+'" />'+$("#par_ben").val().toUpperCase()+'</td><td><input hidden  name="ppar_ben'+max.toString()+'" id="ppar_ben'+max.toString()+'" value="'+$("#ppar_ben").val()+'" />'+$("#ppar_ben").val()+'</td><td><button title="Eliminar" data-id="fben'+max.toString()+'" type="button" class="elm_ben btn-danger"><span class="glyphicon glyphicon-remove"></span></button></td></tr>');
             
            

        }


    } 

    

    //Eliminar un beneficiario de la lista
    $(document).on('click','.elm_ben',function (e){
        
        
        if ($("#evt").val()=="NO"){

            var cont = parseInt($("#cont").val());
            var max = parseInt($("#max").val());


            if (cont==1)
                max=0;
            
            cont--;
            $("#cont").val(cont.toString());
            $("#max").val(max.toString());

            var id=$(this).data("id");
            $("#"+id).remove();
            $("#evt").val("SI");
                
        }
        else {
            
            $("#evt").val("NO");
        } 

    }); 







    jQuery("#ced_gru").blur(function() {//Pérdida de foco cédula grupo (búsqueda en base de datos)

        if ($(this).val()!=""){

                //------  Consulta a la base de datos para buscar beneficiario
                $.ajax({
                    url: "polizasegurosalud_codigo_buscargrupo.php", 
                    data: {ced:$(this).val()}, 
                    type: "POST",
                    contentType: "application/x-www-form-urlencoded",
                    dataType: "json",  
                    success: function(data){
                        if(data != null && $.isArray(data)){
                            
                            $.each(data, function(index, value){

                                $("#nom_gru").val(value.nom);
                                $("#fnac_gru").val(value.fnac);
                                $("#kgs_gru").val(value.kgs);
                                $("#sex_gru").val(value.sex);
                                $("#par_gru").val(value.par);
                                $("#mat_gru").val(value.mat);

                            });
                        }
                    }
                });
            }



    }); 

    function gru_repetido(){//Verifica si una cédula está repetida en tabla grupos
        var resp=false;
        $(".cedgru").each(function (index) 
        {
            
            if ($(this).val()==$("#ced_gru").val()) {

                resp = true;
            }
        })
        return resp;
    }



    jQuery("#agr_gru").click(function() {//Click botón agregar grupo (Llenado de fila en la respectiva tabla)

        if ($("#cont2").val()=="5")
            swal("¡Error!", "Item N° 8 (Grupo a Asegurar): No se puede agregar más grupo", "error");
        else if (  $("#ced_gru").val()=="" || $("#nom_gru").val()=="" || $("#fnac_gru").val()=="" || $("#kgs_gru").val()=="" ||  $("#par_gru").val()=="" )
            swal("¡Error!", "Item N° 8 (Grupo a Asegurar): Al agregar un grupo, debe completar todos los campos", "error");
        else if ($("#fnac_gru").val()>fact())
            swal("¡Error!", "Item N° 8 (Grupo a Asegurar): Fecha de Nacimiento incorrecta", "error");
        else if (gru_repetido())
            swal("¡Error!", "Item N° 8 (Grupo a Asegurar): Ya existe un grupo con la misma cédula", "error");
        else {

            agregar_fila_gru();
            $("#ced_gru").val("");
            $("#nom_gru").val("");
            $("#fnac_gru").val("");
            $("#kgs_gru").val("");
            $("#par_gru").val("");
        } 
    
    });


    function agregar_fila_gru(){

        var cont = parseInt($("#cont2").val());
        var max = parseInt($("#max2").val());
        cont++;
        max++;
        $("#cont2").val(cont.toString());
        $("#max2").val(max.toString());
        
        if ($('#tb-gru tr').length == 0){

            $("#tb-gru").append('<tr id="fgru'+max.toString()+'"><td><input class="cedgru" hidden  name="ced_gru'+max.toString()+'" id="ced_gru'+max.toString()+'" value="'+$("#ced_gru").val()+'" />'+$("#ced_gru").val()+'</td><td><input hidden  name="nom_gru'+max.toString()+'" id="nom_gru'+max.toString()+'" value="'+$("#nom_gru").val().toUpperCase()+'" />'+$("#nom_gru").val().toUpperCase()+'</td>  <td><input hidden name="fnac_gru'+max.toString()+'" id="fnac_gru'+max.toString()+'" value="'+$("#fnac_gru").val()+'" /> '+$("#fnac_gru").val()+'</td> <td><input hidden name="kgs_gru'+max.toString()+'" id="kgs_gru'+max.toString()+'" value="'+$("#kgs_gru").val()+'" /> '+$("#kgs_gru").val()+'</td> <td><input hidden name="sex_gru'+max.toString()+'" id="sex_gru'+max.toString()+'" value="'+$("#sex_gru").val()+'" /> '+$("#sex_gru").val()+'</td>            <td><input hidden  name="par_gru'+max.toString()+'" id="par_gru'+max.toString()+'" value="'+$("#par_gru").val().toUpperCase()+'" />'+$("#par_gru").val()+'</td><td><input hidden  name="mat_gru'+max.toString()+'" id="mat_gru'+max.toString()+'" value="'+$("#mat_gru").val()+'" />'+$("#mat_gru").val()+'</td><td><button title="Eliminar" data-id="fgru'+max.toString()+'" type="button" class="elm_gru btn-danger"><span class="glyphicon glyphicon-remove"></span></button></td></tr>');
                     
        
        }
        else {

            $("#tb-gru tr:last").after('<tr id="fgru'+max.toString()+'"><td><input class="cedgru" hidden  name="ced_gru'+max.toString()+'" id="ced_gru'+max.toString()+'" value="'+$("#ced_gru").val()+'" />'+$("#ced_gru").val()+'</td><td><input hidden  name="nom_gru'+max.toString()+'" id="nom_gru'+max.toString()+'" value="'+$("#nom_gru").val().toUpperCase()+'" />'+$("#nom_gru").val().toUpperCase()+'</td>  <td><input hidden name="fnac_gru'+max.toString()+'" id="fnac_gru'+max.toString()+'" value="'+$("#fnac_gru").val()+'" /> '+$("#fnac_gru").val()+'</td> <td><input hidden name="kgs_gru'+max.toString()+'" id="kgs_gru'+max.toString()+'" value="'+$("#kgs_gru").val()+'" /> '+$("#kgs_gru").val()+'</td> <td><input hidden name="sex_gru'+max.toString()+'" id="sex_gru'+max.toString()+'" value="'+$("#sex_gru").val()+'" /> '+$("#sex_gru").val()+'</td>            <td><input hidden  name="par_gru'+max.toString()+'" id="par_gru'+max.toString()+'" value="'+$("#par_gru").val().toUpperCase()+'" />'+$("#par_gru").val()+'</td><td><input hidden  name="mat_gru'+max.toString()+'" id="mat_gru'+max.toString()+'" value="'+$("#mat_gru").val()+'" />'+$("#mat_gru").val()+'</td><td><button title="Eliminar" data-id="fgru'+max.toString()+'" type="button" class="elm_gru btn-danger"><span class="glyphicon glyphicon-remove"></span></button></td></tr>');
             
        }
    }



    //Eliminar un grupo de la lista
    $(document).on('click','.elm_gru',function (e){
        
        
        if ($("#evt").val()=="NO"){

            var cont = parseInt($("#cont2").val());
            var max = parseInt($("#max2").val());


            if (cont==1)
                max=0;
            
            cont--;
            $("#cont2").val(cont.toString());
            $("#max2").val(max.toString());

            var id=$(this).data("id");
            $("#"+id).remove();
            $("#evt").val("SI");
                
        }
        else {
            
            $("#evt").val("NO");
        } 

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
            swal("¡Error!", "Item N° 10 (Intermediarios): No se pueden agregar intermediarios", "error");
        else if (  $("#cod_int").val()=="" || $("#nom_int").val()=="" || $("#ppar_int").val()=="")
            swal("¡Error!", "Item N° 10 (Intermediarios): Al agregar un intermediario, debe completar todos los campos", "error");
        else if (int_repetido())
            swal("¡Error!", "Item N° 10 (Intermediarios): Ya existe un intermediario con el mismo código", "error");
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

    

    function si_cuestionario (){
        
        var resp=false;
        $(".slc").each(function (index) 
        {
            
            if ($(this).val()=="SI") {

                resp = true;
            }
        })
        return resp;
    }



    

    

    


    jQuery(".pss_agredi").click(function() {
        
        
        if ( $("#idasg").val()=="-1")
            swal("¡Error!", "Item N° 1(Datos de la Empresa Aseguradora): Debe elegir una aseguradora", "error");
        else if ( $("#idtom").val()=="")
            swal("¡Error!", "Item N° 2(Datos del Tomador): Debe elegir un cliente", "error");
        else if ($("#ande").val()=="-1")
             swal("¡Error!", "Item N° 2(Datos del Tomador): Debe elegir a nombre de quién saldrá en la factura para cobro de prima", "error");
        else if ( $("#idat").val()=="")
            swal("¡Error!", "Item N° 3(Datos del propuesto Asegurado Natural): Debe elegir un cliente", "error");
        else if ($("#fdes").val()=="")
             swal("¡Error!", "Item N° 4(Vigencia del seguro): Campo Fecha Desde Vacío", "error");
        else if ($("#fhas").val()=="")
             swal("¡Error!", "Item N° 4(Vigencia del seguro): Campo Fecha Hasta Vacío", "error");
        else if ($("#fdes").val()>=$("#fhas").val())
             swal("¡Error!", "Item N° 4(Vigencia del seguro): Campo Fecha Desde no debe ser mayor o igual que el campo Fecha Hasta", "error");
        else if ($("#fhas").val()<=fact())
             swal("¡Error!", "Item N° 4(Vigencia del seguro): Campo Fecha Hasta debe ser mayor que la fecha actual", "error");
        else if ($("#frpag").val()=="-1")
             swal("¡Error!", "Item N° 5(Frecuencia de Pago): Elija Opción de pago", "error");
        else  if (!$(".chk").is(":checked"))
            swal("¡Error!", "Item N° 6(Coberturas Solicitadas): Debe elegir una cobertura", "error");
        else if (coberturas_vacias())
              swal("¡Error!", "Item N° 6(Coberturas Solicitadas): Debe especificar un monto mayor a 0 en alguna de las coberturas seleccionadas", "error");
        else if (si_cuestionario () && $("#det_enf").val()=="")
            swal("¡Error!", "Item N° 9(Cuestionario): Al seleccionar 'Sí' en alguna de las opciones, debe llenar el campo descripción", "error");
        else if ($("#tip_cob_prim").val()=="DOMICILIACION BANCARIA" && ( $("#tcta_cob").val()=="" || $("#ncta_cob").val()==""))
             swal("¡Error!", "Item N° 11(Datos bancarios para cobro de prima): No debe dejar campos vacíos", "error");
        else if ($("#tip_cob_prim").val()=="TARJETA DE CREDITO" && ( $("#nr_tc").val()=="" || $("#tipo_tc").val()=="" || $("#venc_tc").val()=="" ))
             swal("¡Error!", "Item N° 11(Datos bancarios para cobro de prima): No debe dejar campos vacíos", "error");
        else if ($("#tip_cob_prim").val()=="TARJETA DE CREDITO" && ( $("#nr_tc").val()!="" && $("#tipo_tc").val()!="" && $("#venc_tc").val()!="" && $("#venc_tc").val()<=fact()))
             swal("¡Error!", "Item N° 11(Datos bancarios para cobro de prima): Tarjeta de crédito se encuentra vencida. Intente con otra", "error");
        else if ($("#reemb_bco").val()=="OTRA CUENTA" && ( $("#tcta_reemb").val()=="" || $("#ncta_reemb").val()==""))
             swal("¡Error!", "Item N° 12(Datos bancarios para pagos a propuesto asegurado titular): No debe dejar campos vacíos", "error");
        else if ( $("#fecha").val()=="")
            swal("¡Error!", "Item N° 13(Fecha y Lugar): Campo Fecha vacío", "error");
        else if ( $("#fecha").val()>fact())
            swal("¡Error!", "Item N° 13(Fecha y Lugar): La Fecha no debe ser mayor que la fecha actual", "error");
        else if ( $("#lugar").val()=="")
            swal("¡Error!", "Item N° 13(Fecha y Lugar): Campo Lugar vacío", "error");

        else{

            preparar_coberturas();
            
            $.post("polizasegurosalud_codigo_agredi.php",$(".frmpss").serialize(),function(res){

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
                                        
                                        $("#capa").load('polizasegurosalud_interfaz_listado.php');
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
                                        
                                        $("#capa").load('polizasegurosalud_interfaz_listado.php');
                                });
                                
                }



                else {
                    
                    swal("¡Error!", "No se pudo guardar la póliza", "error");
                }

            
            });
        }

    });





    jQuery("#idasg").change(function() {

            
            $("#nsol").val("");
            $("#nsol2").val("");
            if ($(this).val()!="-1"){

                //------  Consulta a la base de datos para generar correlativo, dependiendo de la aseguradora
                $.ajax({
                    url: "polizasegurosalud_codigo_generarnumsol.php", /* Llamamos a tu archivo */
                    data: {id:$(this).val(),idpss:$("#idpss").val()}, /* Ponemos los parametros de ser necesarios */
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

    
    //----------------- Eventos para Buscar Cliente (Tomador) ------------//

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


    
    //----------------------------------------------------------------------//



    //---------------- Eventos de búsqueda para cuenta bancaria (cobro de prima)------------------//

    jQuery("#banc_cob").change(function() {

        
        $("#tcta_cob").val("");
        buscar_banco_cobro();
    });

    jQuery("#ncta_cob").blur(function() {
        
        $("#tcta_cob").val("");
        buscar_banco_cobro();
        
    });

    //---------------- Eventos de búsqueda para tarjeta de crédito (cobro de prima)------------------//

    jQuery("#banc_tc").change(function() {

        
        $("#tipo_tc").val("");
        $("#venc_tc").val("");
        buscar_tarj_cred();
    });

    jQuery("#nr_tc").blur(function() {
        
        $("#tipo_tc").val("");
        $("#venc_tc").val("");
        buscar_tarj_cred();
        
    });
    //---------------- Eventos de búsqueda para cuenta bancaria (reembolso)------------------//

    jQuery("#banc_reemb").change(function() {

        
        $("#tcta_reemb").val("");
        buscar_banco_reemb();
    });

    jQuery("#ncta_reemb").blur(function() {
        
        $("#tcta_reemb").val("");
        buscar_banco_reemb();
        
    });

    //----------------------------------//



//---------------------------- Métodos ------------------------------------------//



function buscar_banco_reemb(){


        var idbc=$("#banc_reemb").val();
        var nrc=$("#ncta_reemb").val();

        
         
        $.ajax({
                    url: "polizasegurosalud_codigo_buscarbanco.php", 
                    data: {idb:idbc,nr:nrc}, // Ponemos los parametros de ser necesarios 
                    type: "POST",
                    contentType: "application/x-www-form-urlencoded",
                    dataType: "json",  // Esto es lo que indica que la respuesta será un objeto JSon 
                    success: function(data){
                        if(data != null && $.isArray(data)){
                            // Recorremos tu respuesta con each 
                            $.each(data, function(index, value){

                                    $("#tcta_reemb").val(value.tc);

                            });
                        }
                    }
                });
    }

function buscar_banco_cobro(){


        var idbc=$("#banc_cob").val();
        var nrc=$("#ncta_cob").val();

        
         
        $.ajax({
                    url: "polizasegurosalud_codigo_buscarbanco.php", 
                    data: {idb:idbc,nr:nrc}, // Ponemos los parametros de ser necesarios 
                    type: "POST",
                    contentType: "application/x-www-form-urlencoded",
                    dataType: "json",  // Esto es lo que indica que la respuesta será un objeto JSon 
                    success: function(data){
                        if(data != null && $.isArray(data)){
                            // Recorremos tu respuesta con each 
                            $.each(data, function(index, value){

                                    $("#tcta_cob").val(value.tc);

                            });
                        }
                    }
                });
    }

    function buscar_tarj_cred(){


        var idbc=$("#banc_tc").val();
        var nrc=$("#nr_tc").val();

        
         
        $.ajax({
                    url: "polizasegurosalud_codigo_buscartarjetacredito.php", 
                    data: {idb:idbc,nr:nrc}, // Ponemos los parametros de ser necesarios 
                    type: "POST",
                    contentType: "application/x-www-form-urlencoded",
                    dataType: "json",  // Esto es lo que indica que la respuesta será un objeto JSon 
                    success: function(data){
                        if(data != null && $.isArray(data)){
                            // Recorremos tu respuesta con each 
                            $.each(data, function(index, value){

                                    $("#tipo_tc").val(value.tc);
                                    $("#venc_tc").val(value.fven);

                            });
                        }
                    }
                });
    }

    function preparar_coberturas(){// Cada checkbox de cobertura que no esté tildado, su monto deducible y suma asegurada se le asigna 0
        
        if (!$("#ch_bhcm").is(":checked")){
            
            $("#bhcm_ded").val("0");
            $("#bhcm_sa").val("0")
        }

        if (!$("#ch_anx").is(":checked")){
            
            $("#anx_ded").val("0");
            $("#anx_sa").val("0");

        }

        if (!$("#ch_mat").is(":checked")){
            
            $("#mat_ded").val("0");
            $("#mat_sa").val("0");
        }

        if (!$("#ch_ap").is(":checked")){
            $("#ap_ded").val("0");
            $("#ap_sa").val("0");

        }
        if (!$("#ch_fun").is(":checked")){
            
            $("#fun_ded").val("0");
            $("#fun_sa").val("0");
        }

        if (!$("#ch_epe").is(":checked")){
            
            $("#epe_ded").val("0");
            $("#epe_sa").val("0");
        }

        if (!$("#ch_eep").is(":checked")){
            
            $("#eep_ded").val("0");
            $("#eep_sa").val("0");
        }

        if (!$("#ch_otr").is(":checked")){
            
            $("#otr_ded").val("0");
            $("#otr_sa").val("0");
        }
        

    }


    function coberturas_vacias(){//Validación de las coberturas
        
        if (  $("#bhcm_ded").val()!="" && $("#bhcm_ded").val()!="." && $("#bhcm_sa").val()!="" && $("#bhcm_sa").val()!="." && $("#ch_bhcm").is(":checked")){
            
            if (parseFloat($("#bhcm_ded").val()).toFixed(2)==0 && parseFloat($("#bhcm_sa").val()).toFixed(2)==0)
                return true;
        }
        else if ($("#ch_bhcm").is(":checked")) {
            return true;
        }

        
        if ($("#anx_ded").val()!="" && $("#anx_ded").val()!="." && $("#anx_sa").val()!="" && $("#anx_sa").val()!="." && $("#ch_anx").is(":checked")){
            
            if (parseFloat($("#anx_ded").val()).toFixed(2)==0 && parseFloat($("#anx_sa").val()).toFixed(2)==0)
                return true;
        }
        else if ($("#ch_anx").is(":checked")) {
            return true;
        }
        


        if ($("#mat_ded").val()!="" && $("#mat_ded").val()!="." && $("#mat_sa").val()!="" && $("#mat_sa").val()!="." && $("#ch_mat").is(":checked")){
            
            if (parseFloat($("#mat_ded").val()).toFixed(2)==0 && parseFloat($("#mat_sa").val()).toFixed(2)==0)
                return true;
        }
        else if ($("#ch_mat").is(":checked")) {
            return true;
        }
        


        if ($("#ap_ded").val()!="" && $("#ap_ded").val()!="." && $("#ap_sa").val()!="" && $("#ap_sa").val()!="." && $("#ch_ap").is(":checked")){
            
            if (parseFloat($("#ap_ded").val()).toFixed(2)==0 && parseFloat($("#ap_sa").val()).toFixed(2)==0)
                return true;
        }
        else if ($("#ch_ap").is(":checked")) {
            return true;
        }
        

        if ($("#fun_ded").val()!="" && $("#fun_ded").val()!="." && $("#fun_sa").val()!="" && $("#fun_sa").val()!="." && $("#ch_fun").is(":checked")){
            
            if (parseFloat($("#fun_ded").val()).toFixed(2)==0 && parseFloat($("#fun_sa").val()).toFixed(2)==0)
                return true;
        }
        else if ($("#ch_fun").is(":checked")) {
            return true;
        }
        
        if ($("#epe_ded").val()!="" && $("#epe_ded").val()!="." && $("#epe_sa").val()!="" && $("#epe_sa").val()!="." && $("#ch_epe").is(":checked")){
            
            if (parseFloat($("#epe_ded").val()).toFixed(2)==0 && parseFloat($("#epe_sa").val()).toFixed(2)==0)
                return true;
        }
        else if ($("#ch_epe").is(":checked")) {
            return true;
        }
        

        if ($("#eep_ded").val()!="" && $("#eep_ded").val()!="." && $("#eep_sa").val()!="" && $("#eep_sa").val()!="." && $("#ch_eep").is(":checked")){
            
            if (parseFloat($("#eep_ded").val()).toFixed(2)==0  && parseFloat($("#eep_sa").val()).toFixed(2)==0)
                return true;
        }
        else if ($("#ch_eep").is(":checked")) {
            return true;
        }
        

        if ($("#otr_ded").val()!="" && $("#otr_ded").val()!="." && $("#otr_sa").val()!="" && $("#otr_sa").val()!="." && $("#ch_otr").is(":checked")){
            
            if (parseFloat($("#otr_ded").val()).toFixed(2)==0 && parseFloat($("#otr_sa").val()).toFixed(2)==0)
                return true;
        }
        else if ($("#ch_otr").is(":checked")) {
            return true;
        }
        

        return false;
        


    }
    

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
//-------------------------------------------------------------------------------------------------//



});