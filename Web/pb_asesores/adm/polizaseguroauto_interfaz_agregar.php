<? 
session_start();
require("conectar.php");

?>

<script type="text/javascript">
       // $(document).ready(function () {
            $('#example').DataTable({
                "oLanguage": {
                    "sLengthMenu": "Mostrar _MENU_ registros por pág.",
                    "sZeroRecords": "No hubo coincidencias",
                    "sInfo": "Mostrando _START_ hasta _END_ de _TOTAL_ páginas",
                    "sInfoEmpty": "0 Registros",
                    "sInfoFiltered": "(Filtrando de _MAX_ registros)"
                }
            });

            


        //});
    </script>


<script type='text/javascript' language='javascript' src='js/polizaseguroauto.js'></script>




<div class="panel panel-primary">
  <div class="panel-heading">
    <h2 class="panel-title"><span align="right" class="glyphicon glyphicon-plus-sign"></span><b>&nbsp;&nbsp;AGREGAR SOLICITUD DE SEGURO DE VEHÍCULOS TERRESTRES</b></h2>
  </div>
  <div class="panel-body">
    <div class="container">

                        <form role="form" class="frmpsa form-horizontal">

                        <div class="form-group">
                                <label align="center" class="col-sm-9 control-label"><p align="right">Solicitud Renovación de Seguro N°:</p></label>
                                <div class="col-sm-3">
                                <input type="text" disabled class="form-control" name="nsol" id="nsol" placeholder="" />
                                <input type="hidden" class="form-control" name="nsol2" id="nsol2" placeholder="" />
                                    
                                </div>
                        </div>

                        <div class="form-group">
                        		

                                <div class="radio">
								  <label>
								    <input type="radio" name="tiposol" id="tiposol" value="CASCO" checked>
								    <b>Casco</b>
								  </label>
								</div>
								<div class="radio">
								  <label>
								    <input type="radio" name="tiposol" id="tiposol2" value="RCATP">
								    <b>Responsabilidad Civil, Accidentes Terrestres y Proviajero</b>
								  </label>
								</div>
                        </div>

                        <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="left">1) DATOS DE LA EMPRESA ASEGURADORA</p></label>
                        </div>

                        <div class="form-group">

                            <label for="idasg" class="col-sm-3 control-label">Nombre de la Aseguradora:</label>
                                <div class="col-sm-5">
                                <select name="idasg" id="idasg" class="form-control">
                                <option value="-1">Seleccione...</option>
                                <?
                                    $qr_asg=mysql_query("SELECT * FROM aseguradora");
                                    while ($asg=mysql_fetch_array($qr_asg)){ 
                                ?>
                                <option value="<? echo $asg['id']; ?>"><? echo $asg['nombre']; ?></option>
                                <? 

                                }
                                ?>
                                </select>
                                </div>
                                
                        </div>

                        <div class="form-group">
                                &nbsp;
                        </div>

                        <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="left">2) DATOS DEL TOMADOR</p></label>
                                <input type="hidden" maxlength="15" class="form-control" name="idtom" id="idtom" placeholder="" />
                            </div>
                        		

                            <div class="form-group">




                            	<label for="fnac" class="col-sm-2 control-label">Buscar Tomador:</label>
                                <div class="col-sm-6">
                                    <div class="input-group">
                                        <span class="input-group-btn">
                                            <button id="bsctom" class="btn btn-primary glyphicon glyphicon-search" type="button"></button>
                                      </span>
                                      <input disabled type="text" id="txttomador" class="form-control" placeholder="Buscar...">
                                      
                                    </div>
                                </div>
                            

                                
                            </div>

                            <div id="pj" style="display:none;" class="form-group">
                            <label for="natemp" class="col-sm-3 control-label">Naturaleza de la Empresa:</label>
                            <div class="col-sm-3">
                                <input disabled name="natemp" id="natemp" class="form-control" />
                                
                            </div>

                            </div>

                             
                            <div class="form-group">

                                <label for="fnac" class="col-sm-2 control-label">F. Nacimiento:</label>
                                <div class="col-sm-2">
                                <input disabled type="date" maxlength="15" class="form-control" name="fnac" id="fnac" placeholder="" />
                                    
                                </div>

                                <label for="sexo" class="col-sm-1 control-label">Sexo:</label>
                                
                                <div class="col-sm-1">
                                <input disabled name="sexo" id="sexo" class="form-control"/>
                                </div>

                                <label for="ec" class="col-sm-3 control-label">Estado Civil:</label>                               
                                <div class="col-sm-3">
                                <input disabled name="ec" id="ec" class="form-control"/>
                                </div>





                                
                                
                            </div>

                            <div class="form-group">


                                <label for="inganu" class="col-sm-2 control-label">Ing. An. (U.T.):</label>                               
                                <div class="col-sm-3">
                                <input disabled name="inganu" id="inganu" class="form-control"/>
                                </div>

                                <label for="acteco" class="col-sm-1 control-label">Act. Ecn.:</label>
                                <div class="col-sm-2">
                                <input disabled name="acteco" id="acteco" class="form-control"/>
                                </div>

                                <label for="ocu" class="col-sm-1 control-label">Ocup.:</label>
                                <div class="col-sm-3">
                                <input disabled type="text" maxlength="80" class="form-control" name="ocu" id="ocu" placeholder="" /> 
                                </div>
                                
                            </div>

                            <div class="form-group">


                                <label for="edo" class="col-sm-1 control-label">Estado:</label>
                                <div class="col-sm-3">
                                <input disabled name="edo" id="edo" class="form-control"/>
                                </div>

                                <label for="ciu" class="col-sm-1 control-label">Ciudad:</label>
                                <div class="col-sm-3">
                                <input disabled type="text" maxlength="80" class="form-control" name="ciu" id="ciu" placeholder="" />
                                    
                                </div>

                                <label for="mun" class="col-sm-1 control-label">Municipio:</label>
                                
                                <div class="col-sm-3">
                                <input disabled name="mun" id="mun" class="form-control"/>
                                </div>

                                

                                
                                
                                
                            </div>

                            <div class="form-group">


                                <label for="par" class="col-sm-1 control-label">Parroquia:</label>
                                
                                <div class="col-sm-3">
                                <input disabled name="par" id="par" class="form-control"/>
                                </div>

                                <label for="usb" class="col-sm-1 control-label">Urb./Sec./Bar.:</label>
                                <div class="col-sm-3">
                                <input disabled type="text" maxlength="80" class="form-control" name="usb" id="usb" placeholder="" />
                                    
                                </div>

                                <label for="egcq" class="col-sm-1 control-label">Ed./Gp./Cs./Qt.:</label>
                                <div class="col-sm-3">
                                <input disabled type="text" maxlength="80" class="form-control" name="egcq" id="egcq" placeholder="" />
                                    
                                </div>

                                

                                
                                
                                
                            </div>

                            <div class="form-group">

                                <label for="vp" class="col-sm-1 control-label">Vía Prnc.:</label>
                                <div class="col-sm-3">
                                <input  disabled type="text" maxlength="80" class="form-control" name="vp" id="vp" placeholder="" />
                                </div>

                                <label for="vizq" class="col-sm-1 control-label">Vía (Izq.):</label>
                                <div class="col-sm-3">
                                <input  disabled type="text" maxlength="80" class="form-control" name="vizq" id="vizq" placeholder="" />
                                    
                                </div>

                                <label for="vder" class="col-sm-1 control-label">Vía (Der.):</label>
                                <div class="col-sm-3">
                                <input  disabled type="text" maxlength="80" class="form-control" name="vder" id="vder" placeholder="" />
                                    
                                </div>
                                
                                
                            </div>

                            <div class="form-group">



                                <label for="tsa" class="col-sm-1 control-label">Tr/Sc./Al.:</label>
                                <div class="col-sm-3">
                                <input  disabled type="text" maxlength="80" class="form-control" name="tsa" id="tsa" placeholder="" />
                                    
                                </div>

                                <label for="pn" class="col-sm-1 control-label">Pis/Nv.:</label>
                                <div class="col-sm-3">
                                <input  disabled type="text" maxlength="80" class="form-control" name="pn" id="pn" placeholder="" />
                                    
                                </div>

                                <label for="loa" class="col-sm-1 control-label">Lc./Of./Ap:</label>
                                <div class="col-sm-3">
                                <input  disabled type="text" maxlength="80" class="form-control" name="loa" id="loa" placeholder="" />
                                    
                                </div>

                                

                                  
                                
                            </div>

                            <div class="form-group">

                                <label for="ref" class="col-sm-1 control-label">Ref.:</label>
                                <div class="col-sm-3">
                                    <textarea  disabled maxlength="100" name="ref" id="ref" class="form-control" rows="2"></textarea>
                                 </div>

                                <label for="otro" class="col-sm-1 control-label">Otro:</label>
                                <div class="col-sm-3">
                                    <textarea  disabled maxlength="100" name="otro" id="otro" class="form-control" rows="2"></textarea>
                                 </div>

                                 <label for="cp" class="col-sm-1 control-label">Cd. Ps.:</label>
                                <div class="col-sm-3">
                                <input  disabled type="text" maxlength="10" class="form-control" name="cp" id="cp" placeholder="" />
                                    
                                </div>  
                                
                            </div>

                            <div class="form-group">

                                <label for="tlfh" class="col-sm-1 control-label">Tlf. Hb.:</label>
                                <div class="col-sm-3">
                                    <input  disabled type="text" maxlength="20" class="form-control" name="tlfh" id="tlfh" placeholder="" />
                                 </div>

                                <label for="tlfo" class="col-sm-1 control-label">Tlf. Of.:</label>
                                <div class="col-sm-3">
                                    <input  disabled type="text" maxlength="20" class="form-control" name="tlfo" id="tlfo" placeholder="" />
                                 </div>

                                 <label for="tlfc" class="col-sm-1 control-label">Tlf. Cel.:</label>
                                <div class="col-sm-3">
                                    <input  disabled type="text" maxlength="20" class="form-control" name="tlfc" id="tlfc" placeholder="" />
                                 </div>
                                
                                
                            </div>


                            <div class="form-group">

                                <label for="email" class="col-sm-1 control-label">Email:</label>
                                <div class="col-sm-3">
                                    <input  disabled type="text" maxlength="50" class="form-control" name="email" id="email" placeholder="" />
                                 </div>

                                <label for="fax" class="col-sm-1 control-label">Fax:</label>
                                <div class="col-sm-3">
                                    <input  disabled type="text" maxlength="20" class="form-control" name="fax" id="fax" placeholder="" />
                                 </div>
                            </div>

                            

                            <div class="form-group">
                                &nbsp;
                            </div>

                            <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="left">3) DATOS DEL PROPUESTO ASEGURADO TITULAR</p></label>
                                <input type="hidden" maxlength="15" class="form-control" name="idat" id="idat" placeholder="" />
                            </div>
                                

                            <div class="form-group">

                                <label for="fnac" class="col-sm-2 control-label">Buscar Asegurador:</label>
                                <div class="col-sm-6">
                                    <div class="input-group">
                                        <span class="input-group-btn">
                                            <button id="bscaseg" class="btn btn-primary glyphicon glyphicon-search" type="button"></button>
                                      </span>
                                      <input disabled type="text" id="txtaseg" class="form-control" placeholder="Buscar...">
                                      
                                    </div>
                                </div>
                            

                                
                            </div>

                            <div id="pj2" style="display:none;" class="form-group">
                            <label for="natemp2" class="col-sm-3 control-label">Naturaleza de la Empresa:</label>
                            <div class="col-sm-3">
                                <input disabled name="natemp2" id="natemp2" class="form-control" />
                                
                            </div>

                            </div>

                             
                            <div class="form-group">

                                <label for="fnac2" class="col-sm-2 control-label">F. Nacimiento:</label>
                                <div class="col-sm-2">
                                <input disabled type="date" maxlength="15" class="form-control" name="fnac2" id="fnac2" placeholder="" />
                                    
                                </div>

                                <label for="sexo2" class="col-sm-1 control-label">Sexo:</label>
                                
                                <div class="col-sm-1">
                                <input disabled name="sexo2" id="sexo2" class="form-control"/>
                                </div>

                                <label for="ec2" class="col-sm-3 control-label">Estado Civil:</label>                               
                                <div class="col-sm-3">
                                <input disabled name="ec2" id="ec2" class="form-control"/>
                                </div>





                                
                                
                            </div>

                            <div class="form-group">


                                <label for="inganu2" class="col-sm-2 control-label">Ing. An. (U.T.):</label>                               
                                <div class="col-sm-3">
                                <input disabled name="inganu2" id="inganu2" class="form-control"/>
                                </div>

                                <label for="acteco2" class="col-sm-1 control-label">Act. Ecn.:</label>
                                <div class="col-sm-2">
                                <input disabled name="acteco2" id="acteco2" class="form-control"/>
                                </div>

                                <label for="ocu2" class="col-sm-1 control-label">Ocup.:</label>
                                <div class="col-sm-3">
                                <input disabled type="text" maxlength="80" class="form-control" name="ocu2" id="ocu2" placeholder="" /> 
                                </div>
                                
                            </div>

                            <div class="form-group">


                                <label for="edo2" class="col-sm-1 control-label">Estado:</label>
                                <div class="col-sm-3">
                                <input disabled name="edo2" id="edo2" class="form-control"/>
                                </div>

                                <label for="ciu2" class="col-sm-1 control-label">Ciudad:</label>
                                <div class="col-sm-3">
                                <input disabled type="text" maxlength="80" class="form-control" name="ciu2" id="ciu2" placeholder="" />
                                    
                                </div>

                                <label for="mun2" class="col-sm-1 control-label">Municipio:</label>
                                
                                <div class="col-sm-3">
                                <input disabled name="mun2" id="mun2" class="form-control"/>
                                </div>

                                

                                
                                
                                
                            </div>

                            <div class="form-group">


                                <label for="par2" class="col-sm-1 control-label">Parroquia:</label>
                                
                                <div class="col-sm-3">
                                <input disabled name="par2" id="par2" class="form-control"/>
                                </div>

                                <label for="usb2" class="col-sm-1 control-label">Urb./Sec./Bar.:</label>
                                <div class="col-sm-3">
                                <input disabled type="text" maxlength="80" class="form-control" name="usb2" id="usb2" placeholder="" />
                                    
                                </div>

                                <label for="egcq2" class="col-sm-1 control-label">Ed./Gp./Cs./Qt.:</label>
                                <div class="col-sm-3">
                                <input disabled type="text" maxlength="80" class="form-control" name="egcq2" id="egcq2" placeholder="" />
                                    
                                </div>

                                

                                
                                
                                
                            </div>

                            <div class="form-group">

                                <label for="vp2" class="col-sm-1 control-label">Vía Prnc.:</label>
                                <div class="col-sm-3">
                                <input  disabled type="text" maxlength="80" class="form-control" name="vp2" id="vp2" placeholder="" />
                                </div>

                                <label for="vizq2" class="col-sm-1 control-label">Vía (Izq.):</label>
                                <div class="col-sm-3">
                                <input  disabled type="text" maxlength="80" class="form-control" name="vizq2" id="vizq2" placeholder="" />
                                    
                                </div>

                                <label for="vder2" class="col-sm-1 control-label">Vía (Der.):</label>
                                <div class="col-sm-3">
                                <input  disabled type="text" maxlength="80" class="form-control" name="vder2" id="vder2" placeholder="" />
                                    
                                </div>
                                
                                
                            </div>

                            <div class="form-group">



                                <label for="tsa2" class="col-sm-1 control-label">Tr/Sc./Al.:</label>
                                <div class="col-sm-3">
                                <input  disabled type="text" maxlength="80" class="form-control" name="tsa2" id="tsa2" placeholder="" />
                                    
                                </div>

                                <label for="pn2" class="col-sm-1 control-label">Pis/Nv.:</label>
                                <div class="col-sm-3">
                                <input  disabled type="text" maxlength="80" class="form-control" name="pn2" id="pn2" placeholder="" />
                                    
                                </div>

                                <label for="loa2" class="col-sm-1 control-label">Lc./Of./Ap:</label>
                                <div class="col-sm-3">
                                <input  disabled type="text" maxlength="80" class="form-control" name="loa2" id="loa2" placeholder="" />
                                    
                                </div>

                                

                                  
                                
                            </div>

                            <div class="form-group">

                                <label for="ref2" class="col-sm-1 control-label">Ref.:</label>
                                <div class="col-sm-3">
                                    <textarea  disabled maxlength="100" name="ref2" id="ref2" class="form-control" rows="2"></textarea>
                                 </div>

                                <label for="otro2" class="col-sm-1 control-label">Otro:</label>
                                <div class="col-sm-3">
                                    <textarea  disabled maxlength="100" name="otro2" id="otro2" class="form-control" rows="2"></textarea>
                                 </div>

                                 <label for="cp2" class="col-sm-1 control-label">Cd. Ps.:</label>
                                <div class="col-sm-3">
                                <input  disabled type="text" maxlength="10" class="form-control" name="cp2" id="cp2" placeholder="" />
                                    
                                </div>  
                                
                            </div>

                            <div class="form-group">

                                <label for="tlfh2" class="col-sm-1 control-label">Tlf. Hb.:</label>
                                <div class="col-sm-3">
                                    <input  disabled type="text" maxlength="20" class="form-control" name="tlfh2" id="tlfh2" placeholder="" />
                                 </div>

                                <label for="tlfo2" class="col-sm-1 control-label">Tlf. Of.:</label>
                                <div class="col-sm-3">
                                    <input  disabled type="text" maxlength="20" class="form-control" name="tlfo2" id="tlfo2" placeholder="" />
                                 </div>

                                 <label for="tlfc2" class="col-sm-1 control-label">Tlf. Cel.:</label>
                                <div class="col-sm-3">
                                    <input  disabled type="text" maxlength="20" class="form-control" name="tlfc2" id="tlfc2" placeholder="" />
                                 </div>
                                
                                
                            </div>


                            <div class="form-group">

                                <label for="email2" class="col-sm-1 control-label">Email:</label>
                                <div class="col-sm-3">
                                    <input  disabled type="text" maxlength="50" class="form-control" name="email2" id="email2" placeholder="" />
                                 </div>

                                <label for="fax2" class="col-sm-1 control-label">Fax:</label>
                                <div class="col-sm-3">
                                    <input  disabled type="text" maxlength="20" class="form-control" name="fax2" id="fax2" placeholder="" />
                                 </div>
                            </div>

                            <div class="form-group">
                                &nbsp;
                            </div>

                            <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="left">4) VIGENCIA DE SEGURO</p></label>
                            </div>

                            <div class="form-group">
                                <label for="fdes" class="col-sm-1 control-label">Desde:</label>
                                <div class="col-sm-2">
                                <input type="date" maxlength="15" class="form-control" name="fdes" id="fdes" placeholder="" />
                                </div>
                                <label for="fhas" class="col-sm-1 control-label">Hasta:</label>
                                <div class="col-sm-2">
                                <input type="date" maxlength="15" class="form-control" name="fhas" id="fhas" placeholder="" />
                                </div>
                                
                            </div>

                            

                            

                            

                            <div class="form-group">

                                <label for="ande" class="col-sm-6 control-label">La factura una vez pagada la prima de la póliza, deberá salir a nombre de:</label>
                                
                                <div class="col-sm-2">
                                <select name="ande" id="ande" class="form-control">
                                    <option value="-1">Seleccione...</option>
                                    <option value="TOMADOR">TOMADOR</option>
                                    <option value="ASEGURADO">ASEGURADO</option>
                                </select>
                                </div>
                                
                            </div>

                            <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="left">5) BIEN POR ASEGURAR</p></label>
                            </div>

                            <div class="form-group">

                                <label for="placa" class="col-sm-1 control-label">Placa:</label>
                                <div class="col-sm-2">
                                    <input type="text" maxlength="50" class="form-control" name="placa" id="placa" placeholder="" />
                                 </div>

                                <label for="marca" class="col-sm-1 control-label">Marca:</label>
                                <div class="col-sm-2">
                                    <input type="text" maxlength="50" class="form-control" name="marca" id="marca" placeholder="" />
                                 </div>

                                 <label for="modelo" class="col-sm-1 control-label">Modelo:</label>
                                <div class="col-sm-2">
                                    <input type="text" maxlength="50" class="form-control" name="modelo" id="modelo" placeholder="" />
                                 </div>

                                <label for="anio" class="col-sm-1 control-label">Año:</label>
                                <div class="col-sm-2">
                                    <input type="text" maxlength="4" class="num form-control" name="anio" id="anio" placeholder="" />
                                 </div>
                            </div>

                            <div class="form-group">

                                <label for="color" class="col-sm-1 control-label">Color:</label>
                                <div class="col-sm-2">
                                    <input type="text" maxlength="50" class="form-control" name="color" id="color" placeholder="" />
                                 </div>

                                <label for="smot" class="col-sm-2 control-label">Serial del Motor:</label>
                                <div class="col-sm-2">
                                    <input type="text" maxlength="50" class="form-control" name="smot" id="smot" placeholder="" />
                                 </div>

                                 <label for="scar" class="col-sm-3 control-label">Serial de la Carrocería:</label>
                                <div class="col-sm-2">
                                    <input type="text" maxlength="50" class="form-control" name="scar" id="scar" placeholder="" />
                                 </div>
                                
                            </div>

                            <div class="form-group">

                                <label for="trans" class="col-sm-1 control-label">Transmisión:</label>
                                <div class="col-sm-2">
                                    <input type="text" maxlength="50" class="form-control" name="trans" id="trans" placeholder="" />
                                 </div>

                                <label for="uveh" class="col-sm-2 control-label">Uso del Vehículo:</label>
                                <div class="col-sm-2">
                                    <input type="text" maxlength="50" class="form-control" name="uveh" id="uveh" placeholder="" />
                                 </div>

                                 <label for="tcar" class="col-sm-3 control-label">Tipo de Carga:</label>
                                <div class="col-sm-2">
                                    <input type="text" maxlength="50" class="form-control" name="tcar" id="tcar" placeholder="" />
                                 </div>
                                
                            </div>

                            <div class="form-group">
                                <label for="npas" class="col-sm-2 control-label">N° Pasajeros:</label>
                                <div class="col-sm-1">
                                    <input type="text" maxlength="4" class="num form-control" name="npas" id="npas" placeholder="" />
                                 </div>
                                 <label for="peso" class="col-sm-2 control-label">Peso (Kgs.):</label>
                                <div class="col-sm-1">
                                    <input type="text" maxlength="4" class="dec form-control" name="peso" id="peso" placeholder="" />
                                 </div>
                                 <label for="tons" class="col-sm-1 control-label">Toneladas:</label>
                                <div class="col-sm-1">
                                    <input type="text" maxlength="4" class="dec form-control" name="tons" id="tons" placeholder="" />
                                 </div>

                                 <label for="uhveh" class="col-sm-2 control-label">Uso hab. del Vehículo:</label>
                                
                                <div class="col-sm-2">
                                <select name="uhveh" id="uhveh" class="form-control">
                                    <option value="URBANO">URBANO</option>
                                    <option value="EXTRAURBANO">EXTRAURBANO</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="upor" class="col-sm-2 control-label">Usado por:</label>
                                <div class="col-sm-2">
                                <select name="upor" id="upor" class="form-control">
                                    <option value="PROPIETARIO">PROPIETARIO</option>
                                    <option value="CONYUGE">CÓNYUGE</option>
                                    <option value="CHOFER">CHOFER</option>
                                    <option value="HIJOS">HIJOS</option>
                                    <option value="OTROS">OTROS</option>
                                </select>
                                </div>

                                <label for="glic" class="col-sm-2 control-label">Licencia:</label>
                                <div class="col-sm-2">
                                <select name="glic" id="glic" class="form-control">
                                    <option value="SEGUNDA">SEGUNDA</option>
                                    <option value="TERCERA">TERCERA</option>
                                    <option value="TITULO">TÍTULO</option>
                                    <option value="CUARTA">CUARTA</option>
                                    <option value="QUINTA">QUINTA</option>
                                </select>
                                </div>

                                <label for="aexp" class="col-sm-2 control-label">Años Exp.:</label>
                                <div class="col-sm-1">
                                    <input type="text" maxlength="2" class="num form-control" name="aexp" id="aexp" placeholder="" />
                                 </div>
                            </div>

                            <div class="form-group">
                                &nbsp;
                            </div>

                            <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="left">6) COBERTURAS SOLICITADAS</p></label>
                            </div>

                            <div class="form-group">
                               <div class="col-sm-8">
                                <table class="table table-striped table-bordered" align="center" cellspacing="0">
                                    <thead>
                                        <tr>
                                            
                                            <th width="45%">Automóvil-Casco</th>
                                            <th width="20%">Suma Asegurada (Bs.)</th>

                                        </tr>
                                    </thead>
                                    
                                    <tbody>
                                    
                                        <tr>
                                            <td>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_amp" id="ch_amp" >
                                                Amplia
                                              </label>
                                            </div>


                                            </td>
                                            
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="amp_sa" id="amp_sa" placeholder="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_aded" id="ch_aded" >
                                                Amplia con deducible (%)
                                              </label>
                                            </div>


                                            </td>
                                            
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="aded_sa" id="aded_sa" placeholder="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_apf" id="ch_apf" >
                                                Amplia Plan Familiar
                                              </label>
                                            </div>




                                            </td>
                                            
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="apf_sa" id="apf_sa" placeholder="" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_pt" id="ch_pt" >
                                                Pérdida Total
                                              </label>
                                            </div>

                                            </td>
                                            
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="pt_sa" id="pt_sa" placeholder="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>

                                                <div class="checkbox">
                                                  <label>
                                                    <input class="chk" type="checkbox" name="ch_id" id="ch_id" >
                                                    Indemnización Diaria
                                                  </label>
                                                </div>

                                            </td>
                                            
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="id_sa" id="id_sa" placeholder="" />
                                            </td>
                                        </tr>


                                        
                                        
                                    </tbody>
                                </table>
                                </div>  
                            </div>



                            <div class="form-group">
                               <div class="col-sm-8">
                                <table class="table table-striped table-bordered" align="center" cellspacing="0">
                                    <thead>
                                        <tr>
                                            
                                            <th width="45%">Accesorios</th>
                                            <th width="20%">Suma Asegurada (Bs.)</th>

                                        </tr>
                                    </thead>
                                    
                                    <tbody>
                                    
                                        <tr>
                                            <td>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_rrcd" id="ch_rrcd" >
                                                Radio/Reproductor/CD
                                              </label>
                                            </div>




                                            </td>
                                            
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="rrcd_sa" id="rrcd_sa" placeholder="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_aa" id="ch_aa" >
                                                Aire Acondicionado
                                              </label>
                                            </div>


                                            </td>
                                            
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="aa_sa" id="aa_sa" placeholder="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_otr" id="ch_otr" >
                                                Otro
                                              </label>
                                            </div>


                                            </td>
                                            
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="otr_sa" id="otr_sa" placeholder="" />
                                            </td>
                                        </tr>

                                        


                                        
                                        
                                    </tbody>
                                </table>
                                </div>  
                            </div>

                            <div class="form-group">
                               <div class="col-sm-8">
                                <table class="table table-striped table-bordered" align="center" cellspacing="0">
                                    <thead>
                                        <tr>
                                            
                                            <th width="45%">Combinado Automóvil</th>
                                            <th width="20%">Suma Asegurada (Bs.)</th>

                                        </tr>
                                    </thead>
                                    
                                    <tbody>
                                    
                                        <tr>
                                            <td>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_rcv" id="ch_rcv" >
                                                RCV Básica
                                              </label>
                                            </div>




                                            </td>
                                            
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="rcv_sa" id="rcv_sa" placeholder="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_aldp" id="ch_aldp" >
                                                Asistencia Legal y Def. Penal
                                              </label>
                                            </div>


                                            </td>
                                            
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="aldp_sa" id="aldp_sa" placeholder="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_el" id="ch_el" >
                                                Exceso de Límite
                                              </label>
                                            </div>

                                            </td>
                                            
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="el_sa" id="el_sa" placeholder="" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>Accidentes Terrestres</td>
                                            
                                            <td> <select class="form-control" name="at" id="at">
                                                    <option value="CONDUCTOR">CONDUCTOR</option>
                                                    <option value="PASAJEROS">PASAJEROS</option>
                                                    <option value="AYUDANTES">AYUDANTES</option>
                                                </select>
                                            </td>
                                        </tr>
                                        


                                        
                                        
                                    </tbody>
                                </table>
                                </div>  
                            </div>

                            <div class="form-group">
                               <div class="col-sm-8">
                                <table class="table table-striped table-bordered" align="center" cellspacing="0">
                                    <thead>
                                        <tr>
                                            
                                            <th width="45%">Cobertura</th>
                                            <th width="20%">Suma Asegurada (Bs.)</th>

                                        </tr>
                                    </thead>
                                    
                                    <tbody>
                                    
                                        <tr>
                                            <td>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_m" id="ch_m" >
                                                Muerte
                                              </label>
                                            </div>


                                            </td>
                                            
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="m_sa" id="m_sa" placeholder="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_inv" id="ch_inv" >
                                                Invalidez
                                              </label>
                                            </div>

                                            </td>
                                            
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="inv_sa" id="inv_sa" placeholder="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_gmc" id="ch_gmc" >
                                                Gastos Médicos o Curación
                                              </label>
                                            </div>


                                            </td>
                                            
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="gmc_sa" id="gmc_sa" placeholder="" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_ge" id="ch_ge" >
                                                Gastos de Entierro
                                              </label>
                                            </div>

                                            </td>
                                            
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="ge_sa" id="ge_sa" placeholder="" />
                                            </td>
                                        </tr>


                                        
                                        
                                    </tbody>
                                </table>
                                </div>  
                            </div>

                            <div class="form-group">
                                &nbsp;
                            </div>

                            <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="left">7) INTERMEDIARIOS</p></label>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-2">
                                    <input type="text" maxlength="20" class="form-control" name="cod_int" id="cod_int" placeholder="Código" />
                                </div>
                                <div class="col-sm-4">
                                    <input type="text" maxlength="100" class="let form-control" name="nom_int" id="nom_int" placeholder="Nombres y Apellidos" />
                                </div>
                                <div class="col-sm-1">
                                    <input type="text" class="dec form-control" name="ppar_int" id="ppar_int" placeholder="% Part." />
                                </div>

                                <div class="col-sm-2">
                                    <button title="Agregar Intermediario" id="agr_int" type="button" class="btn btn-primary"><span class="glyphicon glyphicon-plus-sign"></span></button>
                                </div>
                            </div>

                            <input hidden id="cont3" value="0">
                            <input hidden name="max3" id="max3"  value="0">
                            <input hidden id="evt"  value="NO"><!-- Campo oculto para evitar repeticiones de eventos-->

                            <div class="form-group">
                                <div class="col-sm-8">
                                <table class="table table-striped table-bordered" align="center" cellspacing="0">
                                    <thead>
                                        <tr>
                                            
                                            <th width="15%">Código</th>
                                            <th width="45%">Apellidos y Nombres</th>
                                            <th width="12%">% Participación</th>
                                            <th width="10%">Eliminar</th>

                                        </tr>
                                    </thead>
                                    <tbody id="tb-int">

                                    </tbody>
                                </table>
                                </div>
                            </div>

                            <div class="form-group">
                                &nbsp;
                            </div>

                            

                            <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="left">8) FECHA Y LUGAR</p></label>
                            </div>

                            <div class="form-group">
                                <label for="fecha" class="col-sm-1 control-label">Fecha:</label>
                                <div class="col-sm-2">
                                <input type="date" class="form-control" name="fecha" id="fecha" placeholder="" />
                                </div>
                                <label for="lugar" class="col-sm-1 control-label">Lugar:</label>
                                <div class="col-sm-4">
                                <input type="text" class="form-control" name="lugar" id="lugar" placeholder="" />
                                </div>
                                
                            </div>





                            <div class="form-group">
                                &nbsp;
                            </div>

                            <input hidden name="idpsa" id="idpsa" value="" />

                            <div class="form-group" align="center">
                                <label><a data-opc="agregar" class="psa_agredi btn btn-success">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Guardar&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></label>-<label><a id="psa_vlv_list" class="btn btn-danger">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Volver&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></label>
                            </div>
                            <div class="form-group">
                                &nbsp;
                            </div>
                                     
                        </form>

                    </div>

  </div>
  <div class="panel-heading">
    <h3 class="panel-title"><b>SISTEMA DE ASESORES DE SEGUROS P.B. </b></h3>
  </div>
</div>


<?php
$qr_cli=mysql_query("SELECT cli.id,cli.tipo_persona,cli.ced_rif,cli.nombre_rs FROM cliente cli");

?>
<!-- Modal N° 1 -->
<div  data-nmod="1" class="modal fade" id="myModal" tabindex="-1" width="150" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog" align="left" style="width:650px;">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Buscar Cliente</h4>
      </div>
      <div class="modal-body">
        <div class="container">

                        <form role="form" class="form-horizontal" id="">
                            <div class="form-group" align="center" style="width:500px;">

                                <table id="example" class="table table-striped table-bordered" align="center" cellspacing="0" >
                                    <thead>
                                        <tr>
                                            
                                            <th width="150">Cédula/R.I.F./Pasaporte</th>
                                            <th width="350">Nombre/Razón Social</th>
                                            <th width="20">Elegir</th>
                                        </tr>
                                    </thead>
                                    
                                    <tbody>
                                    <?php 
                                      
                                        while($cli=mysql_fetch_array($qr_cli)){

                                      ?>
                                        <tr>
                                            <td><? echo $cli["tipo_persona"]."-".$cli["ced_rif"];?></td>
                                            <td><? echo $cli["nombre_rs"];?></td>
                                            <td align="center"><button title="Detalles" type="button" data-id="<? echo $cli["id"]; ?>" class="pss_buscli btn btn-default"><span class="glyphicon glyphicon-hand-up"></span></button></td>
                                        </tr>
                                        <?php 
                                      
                                        }

                                      ?>
                                        
                                    </tbody>
                                </table>
                                
                            </div>
                                      
                        </form>

                    </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
      </div>
    </div>
  </div>
</div>







