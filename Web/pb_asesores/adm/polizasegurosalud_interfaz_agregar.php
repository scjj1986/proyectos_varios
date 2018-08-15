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




<script type='text/javascript' language='javascript' src='js/polizasegurosalud.js'></script>




<div class="panel panel-primary">
  <div class="panel-heading">
    <h2 class="panel-title"><span align="right" class="glyphicon glyphicon-plus-sign"></span><b>&nbsp;&nbsp;AGREGAR SOLICITUD DE SEGURO DE SALUD</b></h2>
  </div>
  <div class="panel-body">
    <div class="container">

                        <form role="form" class="frmpss form-horizontal">

                        <div class="form-group">
                                <label align="center" class="col-sm-9 control-label"><p align="right">Solicitud Renovación de Seguro N°:</p></label>
                                <div class="col-sm-3">
                                <input type="text" disabled class="form-control" name="nsol" id="nsol" placeholder="" />
                                <input type="hidden" class="form-control" name="nsol2" id="nsol2" placeholder="" />
                                    
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
                                &nbsp;
                            </div>

                            <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="left">5) FRECUENCIA DE PAGO</p></label>
                            </div>

                            <div class="form-group">
                                <label for="frpag" class="col-sm-2 control-label">Opciones de pago:</label>
                                
                                <div class="col-sm-3">
                                <select name="frpag" id="frpag" class="form-control">
                                    <option value="-1">Seleccione...</option>
                                    <option value="MENSUAL">MENSUAL</option>
                                    <option value="TRIMESTRAL">TRIMESTRAL</option>
                                    <option value="ANUAL">ANUAL</option>
                                </select>
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
                                            
                                            <th width="45%">Coberturas</th>
                                            <th width="20%">Deducible (Bs.)</th>
                                            <th width="20%">Suma Asegurada (Bs.)</th>

                                        </tr>
                                    </thead>
                                    
                                    <tbody>
                                    
                                        <tr>
                                            <td>
                                            
                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_bhcm" id="ch_bhcm" value="NO">
                                                Básica de Hospitalización, Cirugía y Maternidad
                                              </label>
                                            </div>




                                            </td>
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="bhcm_ded" id="bhcm_ded" placeholder="" />
                                            </td>
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="bhcm_sa" id="bhcm_sa" placeholder="" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>
                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_anx" id="ch_anx" value="NO">
                                                Anexos
                                              </label>
                                            </div>



                                            </td>
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="anx_ded" id="anx_ded" placeholder="" />
                                            </td>
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="anx_sa" id="anx_sa" placeholder="" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td><div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_mat" id="ch_mat" value="SI">
                                                Maternidad
                                              </label>
                                            </div>
                                            </td>
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="mat_ded" id="mat_ded" placeholder="" />
                                            </td>
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="mat_sa" id="mat_sa" placeholder="" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td><div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_ap" id="ch_ap" value="SI">
                                                Accidentes Personales
                                              </label>
                                            </div></td>
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="ap_ded" id="ap_ded" placeholder="" />
                                            </td>
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="ap_sa" id="ap_sa" placeholder="" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td><div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_fun" id="ch_fun" value="SI">
                                                Funerarios
                                              </label>
                                            </div></td>
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="fun_ded" id="fun_ded" placeholder="" />
                                            </td>
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="fun_sa" id="fun_sa" placeholder="" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>
                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_epe" id="ch_epe" value="SI">
                                                Eliminación de plazos de espera
                                              </label>
                                            </div></td>
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="epe_ded" id="epe_ded" placeholder="" />
                                            </td>
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="epe_sa" id="epe_sa" placeholder="" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td><div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_eep" id="ch_eep" value="SI">
                                                Eliminacion de enfermedades preexistentes
                                              </label>
                                            </div></td>
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="eep_ded" id="eep_ded" placeholder="" />
                                            </td>
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="eep_sa" id="eep_sa" placeholder="" />
                                            </td>
                                        </tr>

                                        

                                        <tr>
                                            <td><div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_otr" id="ch_otr" value="SI">
                                                Otros
                                              </label>
                                            </div></td>
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="otr_ded" id="otr_ded" placeholder="" />
                                            </td>
                                            <td> <input type="text" maxlength="20" value="0" class="dec form-control" name="otr_sa" id="otr_sa" placeholder="" />
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
                                <label align="center" class="col-sm-12 control-label"><p align="left">7) BENEFICIARIO(S) EN CASO DE FALLECIMIENTO DEL PROPUESTO ASEGURADO TITULAR (Opcional)</p></label>
                            </div>

                            <div class="form-group">
                                <div class="col-sm-2">
                                <input type="text" maxlength="20" class="num form-control" name="ced_ben" id="ced_ben" placeholder="Céd. Int." />
                                </div>

                                <div class="col-sm-3">
                                <input type="text" maxlength="20" class="let form-control" name="nom_ben" id="nom_ben" placeholder="Nombre y Apellido" />
                                </div>

                                <div class="col-sm-2">
                                    <input type="text" maxlength="20" class="let form-control" name="par_ben" id="par_ben" placeholder="Parentesco" />
                                </div>

                                <div class="col-sm-2">
                                    <input type="text" maxlength="4" class="dec form-control" name="ppar_ben" id="ppar_ben" placeholder="% Part." />
                                </div>
                                <div class="col-sm-2">
                                    <button title="Agregar Beneficiario" id="agr_ben" type="button" class="btn btn-primary"><span class="glyphicon glyphicon-plus-sign"></span></button>
                                </div>

                            </div>

                            <input hidden id="cont" value="0">
                            <input hidden name="max" id="max"  value="0">
                            <input hidden id="evt"  value="NO"><!-- Campo oculto para evitar repeticiones de eventos-->



                            <div class="form-group">
                                <div class="col-sm-10">
                                <table class="table table-striped table-bordered" align="center" cellspacing="0">
                                    <thead>
                                        <tr>
                                            
                                            <th width="20%">Nro. C.I.</th>
                                            <th width="45%">Apellidos y Nombres</th>
                                            <th width="20%">Parentesco</th>
                                            <th width="10%">% Part.</th>
                                            <th width="10%">Eliminar</th>

                                        </tr>
                                    </thead>
                                    <tbody id="tb-ben">
                                        

                                    </tbody>
                                </table>
                                </div>
                            </div>

                            <div class="form-group">
                                &nbsp;
                            </div>

                            <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="left">8) GRUPO A ASEGURAR       (Nota: Indicar de primero al titular; Opcional)</p></label>
                            </div>

                            <div class="form-group">
                                <label for="ced_gru" class="col-sm-1 control-label">C.I.:</label>
                                <div class="col-sm-2">
                                <input type="text" maxlength="20" class="num form-control" name="ced_gru" id="ced_gru" placeholder="" />
                                </div>
                                <label for="nom_gru" class="col-sm-2 control-label">Apellidos y Nombres:</label>
                                <div class="col-sm-3">
                                <input type="text" maxlength="50" class="let form-control" name="nom_gru" id="nom_gru" placeholder="" />
                                </div>
                                 <label for="fnac_gru" class="col-sm-2 control-label">Fecha Nac.:</label>
                                 <div class="col-sm-2">
                                 <input type="date" maxlength="20" class="form-control" name="fnac_gru" id="fnac_gru" placeholder="" />

                                 </div>
                            </div>
                            <div class="form-group">
                                <label for="kgs_gru" class="col-sm-1 control-label">Kgs.:</label>
                                <div class="col-sm-1">
                                    <input type="text" maxlength="5" class="dec form-control" name="kgs_gru" id="kgs_gru" placeholder="" />
                                </div>
                                <label for="sex_gru" class="col-sm-1 control-label">Sexo:</label>
                                <div class="col-sm-1">
                                    <select class="form-control" name="sex_gru" id="sex_gru">
                                                    <option value="M">M</option>
                                                    <option value="F">F</option>
                                                </select>
                                </div>
                                <label for="par_gru" class="col-sm-2 control-label">Parentesco:</label>
                                <div class="col-sm-2">
                                    <input type="text" maxlength="20" class="let form-control" name="par_gru" id="par_gru" placeholder="" />
                                </div>
                                <label for="mat_gru" class="col-sm-2 control-label">Maternidad:</label>
                                <div class="col-sm-1">
                                    <select class="form-control" name="mat_gru" id="mat_gru">
                                                    <option value="SI">Sí</option>
                                                    <option value="NO">NO</option>
                                                </select>

                                </div>
                            </div>



                            <div align="center" class="form-group">
                                <div class="col-sm-12">
                                    <button title="Agregar Grupo" id="agr_gru" type="button" class="btn btn-primary"><span class="glyphicon glyphicon-plus-sign"></span></button>
                                </div>
                            </div>

                            <div class="form-group">
                                &nbsp;
                            </div>



                            <input hidden id="cont2" value="0">
                            <input hidden name="max2" id="max2"  value="0">




                            <div class="form-group">
                                <div class="col-sm-12">
                                <table class="table table-striped table-bordered" align="center" cellspacing="0">
                                    <thead>
                                        <tr>
                                            
                                            <th width="10%">Nro. C.I.</th>
                                            <th width="20%">Apellidos y Nombres</th>
                                            <th width="10%">F. Nac.</th>
                                            <th width="5%">Kgs.</th>
                                            <th width="5%">Sexo</th>
                                            <th width="10%">Parentesco</th>
                                            <th width="10%">¿Maternidad?</th>
                                            <th align="center" width="10%">Eliminar</th>

                                        </tr>
                                    </thead>
                                    <tbody id="tb-gru">
                                    
                                    </tbody>
                                </table>
                                </div>
                                
                            </div>

                            

                            <div class="form-group">
                                &nbsp;
                            </div>

                            <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="left">9) CUESTIONARIO (DECLARACIÓN DE SALUD)</p></label>
                            </div>

                            <div class="form-group">
                                <label for="goz_sal" class="col-sm-8 control-label">¿Usted y las demás personas incluidas en esta solicitud gozan de buena salud?:</label>
                                
                                <div class="col-sm-2">
                                <select class="slc form-control" name="goz_sal" id="goz_sal">
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                                    
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="oper_quir" class="col-sm-8 control-label">¿Se le ha practicado alguna operación quirúrgica?:</label>
                                
                                <div class="col-sm-2">
                                <select class="slc form-control" name="oper_quir" id="oper_quir">
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="prev_alg" class="col-sm-8 control-label">¿Tiene prevista alguna?:</label>
                                
                                <div class="col-sm-2">
                                <select class="slc form-control" name="prev_alg" id="prev_alg">
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="trat_enf_trans" class="col-sm-8 control-label">¿Han consultado o estado en tratamiento médico por algún síntoma o enfermedad transitoria o defecto?:</label>
                                
                                <div class="col-sm-2">
                                <select class="slc form-control" name="trat_enf_trans" id="trat_enf_trans">
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="pad_enf_trans" class="col-sm-8 control-label">¿Padecen ustedes actualmente de alguna enfermedad transitoria, crónica o defecto?:</label>
                                
                                <div class="col-sm-2">
                                <select class="slc form-control" name="pad_enf_trans" id="pad_enf_trans">
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="edo_grav" class="col-sm-8 control-label">¿Alguno de los solicitantes ha estado o está en estado de gravidez?:</label>
                                
                                <div class="col-sm-2">
                                <select class="slc form-control" name="edo_grav" id="edo_grav">
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="left">&nbsp;&nbsp;&nbsp;&nbsp;*Padece o ha padecido usted o alguna de las personas incluidas en esta solicitud de seguro de:</p></label>
                            </div>

                            <div class="form-group">
                                <label for="enf_sis_dig" class="col-sm-8 control-label">Enfermedades del sistema digestivo (Gastritis, Úlceras, Colon, Recto, Cálculos, entre otros)</label>
                                
                                <div class="col-sm-2">
                                <select class="slc form-control" name="enf_sis_dig" id="enf_sis_dig">
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="enf_card" class="col-sm-8 control-label">Enfermedades Cardiovasculares ( Tensión Alta, Infarto, Insuficiencia Cardiaca o Coronaria)</label>
                                
                                <div class="col-sm-2">
                                <select class="slc form-control" name="enf_card" id="enf_card">
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="enf_resp" class="col-sm-8 control-label">Enfermedades Respiratorias ( Tos Crónica, Asma, Bronquitis, Insuficiencia Respiratoria)</label>
                                
                                <div class="col-sm-2">
                                <select class="slc form-control" name="enf_resp" id="enf_resp">
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="enf_piel" class="col-sm-8 control-label">Enfermedades de la piel, ojos, nariz, oídos y garganta (Sinusitis, Amigdalitis, Rinitis)</label>
                                
                                <div class="col-sm-2">
                                <select class="slc form-control" name="enf_piel" id="enf_piel">
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="enf_ven" class="col-sm-8 control-label">Enfermedades Venéreas, contagiosas o infecciosas, Sida.</label>
                                
                                <div class="col-sm-2">
                                <select class="slc form-control" name="enf_ven" id="enf_ven">
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="tras_end" class="col-sm-8 control-label">Trastornos Endocrinos (Diabetes, Obesidad, Hipófisis,Tiroides, Metabolismo)</label>
                                
                                <div class="col-sm-2">
                                <select class="slc form-control" name="tras_end" id="tras_end">
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="tras_neu" class="col-sm-8 control-label">Trastornos Neurosiquiátricos ( Epilepsias, Convulsiones, parálisis, Retardo Mental, Vértigo)</label>
                                
                                <div class="col-sm-2">
                                <select class="slc form-control" name="tras_neu" id="tras_neu">
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="tras_ren" class="col-sm-8 control-label">Trastornos Renales o del Sietema Urinario ( Cálculos, Tumores de Próstata, Riñones)</label>
                                
                                <div class="col-sm-2">
                                <select class="slc form-control" name="tras_ren" id="tras_ren">
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="enf_osea_musc" class="col-sm-8 control-label">Efermedades Ósea Musculares ( Escolitis, Hernias, Artritis, Reumatismo)</label>
                                
                                <div class="col-sm-2">
                                <select class="slc form-control" name="enf_osea_musc" id="enf_osea_musc">
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="enf_muj" class="col-sm-8 control-label">Enfermedades Propias de la Mujer ( Fibroma, Nódulos o Quistes Mamarios, Ovarios)</label>
                                
                                <div class="col-sm-2">
                                <select class="slc form-control" name="enf_muj" id="enf_muj">
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label align="right" class="col-sm-12 control-label">En caso de ser afirmativa alguna de las respuestas: Nomb. persona, fecha, tipo tratamiento o intervención , médico, informe médico y resultados de exámenes:</label>
                            </div>

                            
                            
                            
                            <div class="form-group">
                                <div class="col-sm-12">
                                    <textarea maxlength="300" name="det_enf" id="det_enf" class="form-control" rows="4"></textarea>
                                 </div>
                            </div>

                            <div class="form-group">
                                &nbsp;
                            </div>

                            <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="left">10) INTERMEDIARIOS</p></label>
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
                                <label align="center" class="col-sm-12 control-label"><p align="left">11) DATOS BANCARIOS PARA COBRO DE PRIMA </p></label>
                            </div>

                            <div class="form-group">
                                <label for="tip_cob_prim" class="col-sm-3 control-label">Tipo de Cobro de Prima:</label>
                                
                                <div class="col-sm-4">
                                <select class="form-control" name="tip_cob_prim" id="tip_cob_prim">
                                                    <option value="DOMICILIACION BANCARIA">DOMICILIACION BANCARIA</option>
                                                    <option value="TARJETA DE CREDITO">TARJETA DE CREDITO</option>
                                </select>
                                </div>
                            </div>

                            <div id="dombanc" class="form-group">
                                <div class="col-sm-8">
                                <table class="table table-striped table-bordered" align="center" cellspacing="0">
                                    <thead>
                                        <tr>
                                            
                                            <th width="30%">Banco</th>
                                            <th width="30%">N.Cuenta</th>
                                            <th width="20%">Tipo Cuenta</th>

                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>
                                                
                                                            <select class="form-control" name="banc_cob" id="banc_cob">

                                                            <?
                                                                $qr_bco=mysql_query("SELECT * FROM banco");
                                                                while ($bco=mysql_fetch_array($qr_bco)){ 
                                                            ?>
                                                            <option value="<? echo $bco['id']; ?>"><? echo $bco['nombre']; ?></option>
                                                            <? 

                                                            }
                                                            ?>
                                                            </select>
                                            </td>
                                            <td>
                                                <input type="text" class="form-control" name="ncta_cob" id="ncta_cob" placeholder="" />
                                            </td>
                                           
                                            <td>
                                                <input type="text" maxlength="20" class="form-control" name="tcta_cob" id="tcta_cob" placeholder="" />
                                            </td>
                                        </tr>   

                                    </tbody>
                                </table>
                                </div>
                            </div>

                            <div id="tarjcred" style="display:none;" class="form-group">
                                <div class="col-sm-8">
                                <table class="table table-striped table-bordered" align="center" cellspacing="0">
                                    <thead>
                                        <tr>
                                            
                                            <th width="45%">Banco</th>
                                            <th width="30%">N.Tarj. Cred.</th>
                                            <th width="20%">Tipo</th>
                                            <th width="5%">Vence</th>

                                        </tr>
                                    </thead>
                                    <tbody>


                                        <tr>
                                            <td>
                                                
                                                <select class="form-control" name="banc_tc" id="banc_tc">

                                                            <?
                                                                $qr_bco=mysql_query("SELECT * FROM banco");
                                                                while ($bco=mysql_fetch_array($qr_bco)){ 
                                                            ?>
                                                            <option value="<? echo $bco['id']; ?>"><? echo $bco['nombre']; ?></option>
                                                            <? 

                                                            }
                                                            ?>
                                                            </select>
                                            </td>
                                            <td>
                                                <input type="text" class="form-control" name="nr_tc" id="nr_tc" placeholder="" />
                                            </td>
                                           
                                            <td>
                                                <input type="text" class="form-control" name="tipo_tc" id="tipo_tc" placeholder="" />
                                            </td>
                                            <td>
                                                <input type="date" class="form-control" name="venc_tc" id="venc_tc" placeholder="" />
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
                                <label align="center" class="col-sm-12 control-label"><p align="left">12) DATOS BANCARIOS PARA PAGOS A PROPUESTO ASEGURADO TITULAR</p></label>
                            </div>

                            <div class="form-group">
                                <label for="enf_muj" class="col-sm-6 control-label">Deseo que el reembolso o pago me sea efectuado mediante:</label>
                                
                                <div class="col-sm-3">
                                <select class="form-control" name="reemb_bco" id="reemb_bco">
                                                    <option value="COBRO DE PRIMA">COBRO DE PRIMA</option>
                                                    <option value="OTRA CUENTA">OTRA CUENTA</option>
                                </select>
                                </div>
                            </div>

                            <div id="otracta" style="display:none;" class="form-group">
                                <div class="col-sm-8">
                                <table class="table table-striped table-bordered" align="center" cellspacing="0">
                                    <thead>
                                        <tr>
                                            
                                            <th width="30%">Banco</th>
                                            <th width="30%">N.Cuenta</th>
                                            <th width="20%">Tipo Cuenta</th>

                                        </tr>
                                    </thead>
                                    <tbody>


                                        <tr>
                                            <td>
                                                <select type="text" class="form-control" name="banc_reemb" id="banc_reemb">
                                                <?
                                                                $qr_bco=mysql_query("SELECT * FROM banco");
                                                                while ($bco=mysql_fetch_array($qr_bco)){ 
                                                            ?>
                                                            <option value="<? echo $bco['id']; ?>"><? echo $bco['nombre']; ?></option>
                                                            <? 

                                                            }
                                                            ?>
                                                </select>


                                            </td>
                                            <td>
                                                <input type="text" class="form-control" name="ncta_reemb" id="ncta_reemb" placeholder="" />
                                            </td>
                                           
                                            <td>
                                                <input type="text" maxlength="20" class="form-control" name="tcta_reemb" id="tcta_reemb" placeholder="" />
                                            </td>
                                        </tr>   

                                    </tbody>
                                </table>
                                </div>
                            </div>

                            <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="left">13) FECHA Y LUGAR</p></label>
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

                            <input hidden name="idpss" id="idpss" value="" />

                            <div class="form-group" align="center">
                                <label><a data-opc="agregar" class="pss_agredi btn btn-success">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Guardar&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></label>-<label><a id="pss_vlv_list" class="btn btn-danger">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Volver&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></label>
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