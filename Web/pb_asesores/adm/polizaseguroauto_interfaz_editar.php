<? 
session_start();
require("conectar.php");

$idpsa=$_GET["id"];

$qr_psa=mysql_query("SELECT * FROM poliza_vehiculo WHERE id=$idpsa");
$psa=mysql_fetch_array($qr_psa);

// -------------------------- Tomador --------------------------------------------//
$idtom=$psa["id_tomador"];
$qr_tom=mysql_query("SELECT * FROM cliente WHERE id=$idtom") or die(mysql_error());
$tom=mysql_fetch_array($qr_tom);
$ide=$tom["id_edo"];
$idm=$tom["id_mun"];
$idp=$tom["id_par"];
$qr_edo=mysql_query("SELECT * FROM estado WHERE id=$ide");
$edotom= mysql_fetch_array($qr_edo);
$qr_mun=mysql_query("SELECT * FROM municipio WHERE id=$idm");
$muntom=mysql_fetch_array($qr_mun);
$qr_par=mysql_query("SELECT * FROM parroquia WHERE id=$idp");
$partom=mysql_fetch_array($qr_par);



// -------------------------- Asegurado -----------------------------------------//
$idat=$psa["id_asegurado"];
$qr_at=mysql_query("SELECT * FROM cliente WHERE id=$idat") or die(mysql_error());
$at=mysql_fetch_array($qr_at);
$ide=$at["id_edo"];
$idm=$at["id_mun"];
$idp=$at["id_par"];
$qr_edo=mysql_query("SELECT * FROM estado WHERE id=$ide");
$edoat= mysql_fetch_array($qr_edo);
$qr_mun=mysql_query("SELECT * FROM municipio WHERE id=$idm");
$munat=mysql_fetch_array($qr_mun);
$qr_par=mysql_query("SELECT * FROM parroquia WHERE id=$idp");
$parat=mysql_fetch_array($qr_par);



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
    <h2 class="panel-title"><span align="right" class="glyphicon glyphicon-pencil"></span><b>&nbsp;&nbsp;EDITAR SOLICITUD DE SEGURO DE VEHÍCULOS TERRESTRES</b></h2>
  </div>
  <div class="panel-body">
    <div class="container">

                        <form role="form" class="frmpsa form-horizontal">

                        <div class="form-group">
                                <label align="center" class="col-sm-9 control-label"><p align="right">Solicitud Renovación de Seguro N°:</p></label>
                                <div class="col-sm-3">
                                <input type="text" disabled class="form-control" name="nsol" id="nsol" value="<?php echo $psa['n_solicitud'];?>" placeholder="" />
                                <input type="hidden" class="form-control" name="nsol2" id="nsol2" value="<?php echo $psa['n_solicitud'];?>" placeholder="" />
                                    
                                </div>
                        </div>

                        <div class="form-group">
                        		

                                <div class="radio">
								  <label>
								    <input type="radio" name="tiposol" id="tiposol" value="CASCO" <? if ($psa['tipo']=="CASCO"){ ?> checked <? }?> >
								    <b>Casco</b>
								  </label>
								</div>
								<div class="radio">
								  <label>
								    <input type="radio" name="tiposol" id="tiposol2" value="RCATP" <? if ($psa['tipo']=="RCATP"){ ?> checked <? }?> >
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
                                <?
                                    $id_asegr=$psa["id_aseguradora"];

                                    $qr_asgr=mysql_query("SELECT * FROM aseguradora where id=$id_asegr");
                                    $as=mysql_fetch_array($qr_asgr);

                                    ?>
	                                <option value="<? echo $as['id']; ?>"><? echo $as['nombre']; ?></option>
	                                <?

                                    $qr_asg=mysql_query("SELECT * FROM aseguradora");
                                    while ($asg=mysql_fetch_array($qr_asg)){
                                    
                                    if ($id_asegr!=$asg['id']){
                                     
                                ?>
                                <option value="<? echo $asg['id']; ?>"><? echo $asg['nombre']; ?></option>
                                <? 
                            		}
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
                                <input type="hidden" maxlength="15" class="form-control" name="idtom" id="idtom" value="<? echo $idtom; ?>" placeholder="" />
                            </div>
                        		

                            <div class="form-group">




                            	<label for="fnac" class="col-sm-2 control-label">Buscar Tomador:</label>
                                <div class="col-sm-6">
                                    <div class="input-group">
                                        <span class="input-group-btn">
                                            <button id="bsctom" class="btn btn-primary glyphicon glyphicon-search" type="button"></button>
                                      </span>
                                      <input disabled type="text" id="txttomador" value="<? echo $tom['tipo_persona']."-".$tom['ced_rif'].", ".$tom['nombre_rs']; ?>" class="form-control" placeholder="Buscar...">
                                      
                                    </div>
                                </div>
                            

                                
                            </div>

                            <?

                            if ($tom["tipo_persona"]==J)
                            	$disp="block";
                            else
                            	$disp="none";


                            ?>



                            <div id="pj" style="display:<? echo $disp; ?>;" class="form-group">
                            <label for="natemp" class="col-sm-3 control-label">Naturaleza de la Empresa:</label>
                            <div class="col-sm-3">
                                <input disabled name="natemp" id="natemp" value="<? echo $tom['natemp'];?>" class="form-control" />
                                
                            </div>

                            </div>

                             
                            <div class="form-group">

                                <label for="fnac" class="col-sm-2 control-label">F. Nacimiento:</label>
                                <div class="col-sm-2">
                                <input disabled type="date" value="<? echo $tom['fnac'];?>" maxlength="15" class="form-control" name="fnac" id="fnac" placeholder="" />
                                    
                                </div>

                                <label for="sexo" class="col-sm-1 control-label">Sexo:</label>
                                
                                <div class="col-sm-1">
                                <input disabled name="sexo" id="sexo" value="<? echo $tom['sexo'];?>" class="form-control"/>
                                </div>

                                <label for="ec" class="col-sm-3 control-label">Estado Civil:</label>                               
                                <div class="col-sm-3">
                                <input disabled name="ec" id="ec" value="<? echo $tom['ec'];?>" class="form-control"/>
                                </div>





                                
                                
                            </div>

                            <div class="form-group">


                                <label for="inganu" class="col-sm-2 control-label">Ing. An. (U.T.):</label>                               
                                <div class="col-sm-3">
                                <input disabled name="inganu" value="<? echo $tom['inganu'];?>" id="inganu" class="form-control"/>
                                </div>

                                <label for="acteco" class="col-sm-1 control-label">Act. Ecn.:</label>
                                <div class="col-sm-2">
                                <input disabled name="acteco" value="<? echo $tom['acteco'];?>" id="acteco" class="form-control"/>
                                </div>

                                <label for="ocu" class="col-sm-1 control-label">Ocup.:</label>
                                <div class="col-sm-3">
                                <input disabled type="text" value="<? echo $tom['ocup'];?>" maxlength="80" class="form-control" name="ocu" id="ocu" placeholder="" /> 
                                </div>
                                
                            </div>

                            <div class="form-group">


                                <label for="edo" class="col-sm-1 control-label">Estado:</label>
                                <div class="col-sm-3">
                                <input disabled name="edo" value="<? echo $edotom['nombre'];?>" id="edo" class="form-control"/>
                                </div>

                                <label for="ciu" class="col-sm-1 control-label">Ciudad:</label>
                                <div class="col-sm-3">
                                <input disabled type="text" value="<? echo $tom['ciudad'];?>" maxlength="80" class="form-control" name="ciu" id="ciu" placeholder="" />
                                    
                                </div>

                                <label for="mun" class="col-sm-1 control-label">Municipio:</label>
                                
                                <div class="col-sm-3">
                                <input disabled value="<? echo $muntom['nombre'];?>" name="mun" id="mun" class="form-control"/>
                                </div>

                                

                                
                                
                                
                            </div>

                            <div class="form-group">


                                <label for="par" class="col-sm-1 control-label">Parroquia:</label>
                                
                                <div class="col-sm-3">
                                <input disabled name="par" value="<? echo $partom['nombre'];?>" id="par" class="form-control"/>
                                </div>

                                <label for="usb" class="col-sm-1 control-label">Urb./Sec./Bar.:</label>
                                <div class="col-sm-3">
                                <input disabled type="text" maxlength="80" value="<? echo $tom['usb'];?>" class="form-control" name="usb" id="usb" placeholder="" />
                                    
                                </div>

                                <label for="egcq" class="col-sm-1 control-label">Ed./Gp./Cs./Qt.:</label>
                                <div class="col-sm-3">
                                <input disabled type="text" value="<? echo $tom['egcq'];?>" maxlength="80" class="form-control" name="egcq" id="egcq" placeholder="" />
                                    
                                </div>

                                

                                
                                
                                
                            </div>

                            <div class="form-group">

                                <label for="vp" class="col-sm-1 control-label">Vía Prnc.:</label>
                                <div class="col-sm-3">
                                <input  disabled type="text" value="<? echo $tom['vp'];?>" maxlength="80" class="form-control" name="vp" id="vp" placeholder="" />
                                </div>

                                <label for="vizq" class="col-sm-1 control-label">Vía (Izq.):</label>
                                <div class="col-sm-3">
                                <input  disabled type="text" maxlength="80" value="<? echo $tom['vizq'];?>" class="form-control" name="vizq" id="vizq" placeholder="" />
                                    
                                </div>

                                <label for="vder" class="col-sm-1 control-label">Vía (Der.):</label>
                                <div class="col-sm-3">
                                <input  disabled type="text" maxlength="80" value="<? echo $tom['vder'];?>" class="form-control" name="vder" id="vder" placeholder="" />
                                    
                                </div>
                                
                                
                            </div>

                            <div class="form-group">



                                <label for="tsa" class="col-sm-1 control-label">Tr/Sc./Al.:</label>
                                <div class="col-sm-3">
                                <input  disabled type="text" maxlength="80" value="<? echo $tom['tsa'];?>" class="form-control" name="tsa" id="tsa" placeholder="" />
                                    
                                </div>

                                <label for="pn" class="col-sm-1 control-label">Pis/Nv.:</label>
                                <div class="col-sm-3">
                                <input  disabled type="text" maxlength="80" value="<? echo $tom['pn'];?>" class="form-control" name="pn" id="pn" placeholder="" />
                                    
                                </div>

                                <label for="loa" class="col-sm-1 control-label">Lc./Of./Ap:</label>
                                <div class="col-sm-3">
                                <input  disabled type="text" maxlength="80" value="<? echo $tom['loa'];?>" class="form-control" name="loa" id="loa" placeholder="" />
                                    
                                </div>

                                

                                  
                                
                            </div>

                            <div class="form-group">

                                <label for="ref" class="col-sm-1 control-label">Ref.:</label>
                                <div class="col-sm-3">
                                    <textarea  disabled maxlength="100" name="ref" id="ref" class="form-control" rows="2"><? echo $tom['ref'];?></textarea>
                                 </div>

                                <label for="otro" class="col-sm-1 control-label">Otro:</label>
                                <div class="col-sm-3">
                                    <textarea  disabled maxlength="100" name="otro" id="otro" class="form-control" rows="2"><? echo $tom['otro'];?></textarea>
                                 </div>

                                 <label for="cp" class="col-sm-1 control-label">Cd. Ps.:</label>
                                <div class="col-sm-3">
                                <input  disabled value="<? echo $tom['cp'];?>" type="text" maxlength="10" class="form-control" name="cp" id="cp" placeholder="" />
                                    
                                </div>  
                                
                            </div>

                            <div class="form-group">

                                <label for="tlfh" class="col-sm-1 control-label">Tlf. Hb.:</label>
                                <div class="col-sm-3">
                                    <input  disabled type="text" value="<? echo $tom['tlfh'];?>" maxlength="20" class="form-control" name="tlfh" id="tlfh" placeholder="" />
                                 </div>

                                <label for="tlfo" class="col-sm-1 control-label">Tlf. Of.:</label>
                                <div class="col-sm-3">
                                    <input  disabled type="text" maxlength="20" value="<? echo $tom['tlfo'];?>" class="form-control" name="tlfo" id="tlfo" placeholder="" />
                                 </div>

                                 <label for="tlfc" class="col-sm-1 control-label">Tlf. Cel.:</label>
                                <div class="col-sm-3">
                                    <input  disabled type="text" value="<? echo $tom['tlfc'];?>" maxlength="20" class="form-control" name="tlfc" id="tlfc" placeholder="" />
                                 </div>
                                
                                
                            </div>


                            <div class="form-group">

                                <label for="email" class="col-sm-1 control-label">Email:</label>
                                <div class="col-sm-3">
                                    <input  disabled type="text" value="<? echo $tom['email'];?>" maxlength="50" class="form-control" name="email" id="email" placeholder="" />
                                 </div>

                                <label for="fax" class="col-sm-1 control-label">Fax:</label>
                                <div class="col-sm-3">
                                    <input  disabled type="text" maxlength="20" value="<? echo $tom['fax'];?>" class="form-control" name="fax" id="fax" placeholder="" />
                                 </div>
                            </div>

                            <div class="form-group">

                                <label for="ande" class="col-sm-6 control-label">La factura una vez pagada la prima de la póliza, deberá salir a nombre de:</label>
                                
                                <div class="col-sm-2">
                                <select name="ande" id="ande" class="form-control">
                                    <option value="<? echo $psa['a_nombre_de']?>"><? echo $psa['a_nombre_de']?></option>
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
                                <input type="hidden" maxlength="15" class="form-control" value="<? echo $idat;?>"name="idat" id="idat" placeholder="" />
                            </div>
                                

                            <div class="form-group">

                                <label for="fnac" class="col-sm-2 control-label">Buscar Asegurado:</label>
                                <div class="col-sm-6">
                                    <div class="input-group">
                                        <span class="input-group-btn">
                                            <button id="bscaseg" class="btn btn-primary glyphicon glyphicon-search" type="button"></button>
                                      </span>
                                      <input disabled value="<? echo $at['tipo_persona']."-".$at['ced_rif'].", ".$at['nombre_rs']; ?>" type="text" id="txtaseg" class="form-control" placeholder="Buscar...">
                                      
                                    </div>
                                </div>
                            

                                
                            </div>


                            <?

                            if ($at["tipo_persona"]==J)
                            	$disp="block";
                            else
                            	$disp="none";


                            ?>

                            <div id="pj2" style="display:<? echo $disp; ?>;" class="form-group">
                            <label for="natemp2" class="col-sm-3 control-label">Naturaleza de la Empresa:</label>
                            <div class="col-sm-3">
                                <input disabled name="natemp2" id="natemp2" value="<? echo $at['natemp'];?>" class="form-control" />
                                
                            </div>

                            </div>

                             
                            <div class="form-group">

                                <label for="fnac2" class="col-sm-2 control-label">F. Nacimiento:</label>
                                <div class="col-sm-2">
                                <input disabled type="date" maxlength="15" value="<? echo $at['fnac'];?>" class="form-control" name="fnac2" id="fnac2" placeholder="" />
                                    
                                </div>

                                <label for="sexo2" class="col-sm-1 control-label">Sexo:</label>
                                
                                <div class="col-sm-1">
                                <input disabled name="sexo2" id="sexo2" value="<? echo $at['sexo'];?>" class="form-control"/>
                                </div>

                                <label for="ec2" class="col-sm-3 control-label">Estado Civil:</label>                               
                                <div class="col-sm-3">
                                <input disabled name="ec2" id="ec2" value="<? echo $at['ec'];?>" class="form-control"/>
                                </div>





                                
                                
                            </div>

                            <div class="form-group">


                                <label for="inganu2" class="col-sm-2 control-label">Ing. An. (U.T.):</label>                               
                                <div class="col-sm-3">
                                <input disabled name="inganu2" id="inganu2" value="<? echo $at['inganu'];?>" class="form-control"/>
                                </div>

                                <label for="acteco2" class="col-sm-1 control-label">Act. Ecn.:</label>
                                <div class="col-sm-2">
                                <input disabled name="acteco2" id="acteco2" value="<? echo $at['acteco'];?>" class="form-control"/>
                                </div>

                                <label for="ocu2" class="col-sm-1 control-label">Ocup.:</label>
                                <div class="col-sm-3">
                                <input disabled type="text" maxlength="80" value="<? echo $at['ocup'];?>" class="form-control" name="ocu2" id="ocu2" placeholder="" /> 
                                </div>
                                
                            </div>

                            <div class="form-group">


                                <label for="edo2" class="col-sm-1 control-label">Estado:</label>
                                <div class="col-sm-3">
                                <input disabled name="edo2" id="edo2" value="<? echo $edoat['nombre'];?>" class="form-control"/>
                                </div>

                                <label for="ciu2" class="col-sm-1 control-label">Ciudad:</label>
                                <div class="col-sm-3">
                                <input disabled type="text" value="<? echo $at['ciudad'];?>" maxlength="80" class="form-control" name="ciu2" id="ciu2" placeholder="" />
                                    
                                </div>

                                <label for="mun2" class="col-sm-1 control-label">Municipio:</label>
                                
                                <div class="col-sm-3">
                                <input disabled name="mun2" value="<? echo $munat['nombre'];?>" id="mun2" class="form-control"/>
                                </div>

                                

                                
                                
                                
                            </div>

                            <div class="form-group">


                                <label for="par2" class="col-sm-1 control-label">Parroquia:</label>
                                
                                <div class="col-sm-3">
                                <input disabled value="<? echo $parat['nombre'];?>" name="par2" id="par2" class="form-control"/>
                                </div>

                                <label for="usb2" class="col-sm-1 control-label">Urb./Sec./Bar.:</label>
                                <div class="col-sm-3">
                                <input disabled type="text" value="<? echo $at['usb'];?>" maxlength="80" class="form-control" name="usb2" id="usb2" placeholder="" />
                                    
                                </div>

                                <label for="egcq2" class="col-sm-1 control-label">Ed./Gp./Cs./Qt.:</label>
                                <div class="col-sm-3">
                                <input disabled type="text" value="<? echo $at['egcq'];?>" maxlength="80" class="form-control" name="egcq2" id="egcq2" placeholder="" />
                                    
                                </div>

                                

                                
                                
                                
                            </div>

                            <div class="form-group">

                                <label for="vp2" class="col-sm-1 control-label">Vía Prnc.:</label>
                                <div class="col-sm-3">
                                <input  disabled type="text" value="<? echo $at['vp'];?>" maxlength="80" class="form-control" name="vp2" id="vp2" placeholder="" />
                                </div>

                                <label for="vizq2" class="col-sm-1 control-label">Vía (Izq.):</label>
                                <div class="col-sm-3">
                                <input  disabled type="text" value="<? echo $at['vizq'];?>" maxlength="80" class="form-control" name="vizq2" id="vizq2" placeholder="" />
                                    
                                </div>

                                <label for="vder2" class="col-sm-1 control-label">Vía (Der.):</label>
                                <div class="col-sm-3">
                                <input  disabled type="text" value="<? echo $at['vder'];?>" maxlength="80" class="form-control" name="vder2" id="vder2" placeholder="" />
                                    
                                </div>
                                
                                
                            </div>

                            <div class="form-group">



                                <label for="tsa2" class="col-sm-1 control-label">Tr/Sc./Al.:</label>
                                <div class="col-sm-3">
                                <input  disabled type="text" value="<? echo $at['tsa'];?>" maxlength="80" class="form-control" name="tsa2" id="tsa2" placeholder="" />
                                    
                                </div>

                                <label for="pn2" class="col-sm-1 control-label">Pis/Nv.:</label>
                                <div class="col-sm-3">
                                <input  disabled type="text" value="<? echo $at['pn'];?>" maxlength="80" class="form-control" name="pn2" id="pn2" placeholder="" />
                                    
                                </div>

                                <label for="loa2" class="col-sm-1 control-label">Lc./Of./Ap:</label>
                                <div class="col-sm-3">
                                <input  disabled type="text" value="<? echo $at['loa'];?>" maxlength="80" class="form-control" name="loa2" id="loa2" placeholder="" />
                                    
                                </div>

                                

                                  
                                
                            </div>

                            <div class="form-group">

                                <label for="ref2" class="col-sm-1 control-label">Ref.:</label>
                                <div class="col-sm-3">
                                    <textarea  disabled maxlength="100" name="ref2" id="ref2" class="form-control" rows="2"><? echo $at['ref'];?></textarea>
                                 </div>

                                <label for="otro2" class="col-sm-1 control-label">Otro:</label>
                                <div class="col-sm-3">
                                    <textarea  disabled maxlength="100" name="otro2" id="otro2" class="form-control" rows="2"><? echo $at['otro'];?></textarea>
                                 </div>

                                 <label for="cp2" class="col-sm-1 control-label">Cd. Ps.:</label>
                                <div class="col-sm-3">
                                <input  disabled type="text" value="<? echo $at['cp'];?>" maxlength="10" class="form-control" name="cp2" id="cp2" placeholder="" />
                                    
                                </div>  
                                
                            </div>

                            <div class="form-group">

                                <label for="tlfh2" class="col-sm-1 control-label">Tlf. Hb.:</label>
                                <div class="col-sm-3">
                                    <input  disabled type="text" value="<? echo $at['tlfh'];?>" maxlength="20" class="form-control" name="tlfh2" id="tlfh2" placeholder="" />
                                 </div>

                                <label for="tlfo2" class="col-sm-1 control-label">Tlf. Of.:</label>
                                <div class="col-sm-3">
                                    <input  disabled type="text" value="<? echo $at['tlfo'];?>" maxlength="20" class="form-control" name="tlfo2" id="tlfo2" placeholder="" />
                                 </div>

                                 <label for="tlfc2" class="col-sm-1 control-label">Tlf. Cel.:</label>
                                <div class="col-sm-3">
                                    <input  disabled type="text" value="<? echo $at['tlfc'];?>" maxlength="20" class="form-control" name="tlfc2" id="tlfc2" placeholder="" />
                                 </div>
                                
                                
                            </div>


                            <div class="form-group">

                                <label for="email2" class="col-sm-1 control-label">Email:</label>
                                <div class="col-sm-3">
                                    <input  disabled type="text" value="<? echo $at['email'];?>" maxlength="50" class="form-control" name="email2" id="email2" placeholder="" />
                                 </div>

                                <label for="fax2" class="col-sm-1 control-label">Fax:</label>
                                <div class="col-sm-3">
                                    <input  disabled type="text" value="<? echo $at['fax'];?>" maxlength="20" class="form-control" name="fax2" id="fax2" placeholder="" />
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
                                <input type="date" value="<? echo $psa['fecha_desde'];?>" maxlength="15" class="form-control" name="fdes" id="fdes" placeholder="" />
                                </div>
                                <label for="fhas" class="col-sm-1 control-label">Hasta:</label>
                                <div class="col-sm-2">
                                <input type="date" value="<? echo $psa['fecha_hasta'];?>" maxlength="15" class="form-control" name="fhas" id="fhas" placeholder="" />
                                </div>
                                
                            </div>

                            

                            

                            

                            

                            <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="left">5) BIEN POR ASEGURAR</p></label>
                            </div>

                            <div class="form-group">

                                <label for="placa" class="col-sm-1 control-label">Placa:</label>
                                <div class="col-sm-2">
                                    <input type="text" maxlength="50" value="<? echo $psa['placa'];?>" class="form-control" name="placa" id="placa" placeholder="" />
                                 </div>

                                <label for="marca" class="col-sm-1 control-label">Marca:</label>
                                <div class="col-sm-2">
                                    <input type="text" maxlength="50" value="<? echo $psa['marca'];?>" class="form-control" name="marca" id="marca" placeholder="" />
                                 </div>

                                 <label for="modelo" class="col-sm-1 control-label">Modelo:</label>
                                <div class="col-sm-2">
                                    <input type="text" maxlength="50" value="<? echo $psa['modelo'];?>" class="form-control" name="modelo" id="modelo" placeholder="" />
                                 </div>

                                <label for="anio" class="col-sm-1 control-label">Año:</label>
                                <div class="col-sm-2">
                                    <input type="text" maxlength="4" value="<? echo $psa['anio'];?>" class="num form-control" name="anio" id="anio" placeholder="" />
                                 </div>
                            </div>

                            <div class="form-group">

                                <label for="color" class="col-sm-1 control-label">Color:</label>
                                <div class="col-sm-2">
                                    <input type="text" maxlength="50" value="<? echo $psa['color'];?>" class="form-control" name="color" id="color" placeholder="" />
                                 </div>

                                <label for="smot" class="col-sm-2 control-label">Serial del Motor:</label>
                                <div class="col-sm-2">
                                    <input type="text" maxlength="50" value="<? echo $psa['serial_motor'];?>" class="form-control" name="smot" id="smot" placeholder="" />
                                 </div>

                                 <label for="scar" class="col-sm-3 control-label">Serial de la Carrocería:</label>
                                <div class="col-sm-2">
                                    <input type="text" maxlength="50" value="<? echo $psa['serial_carroceria'];?>" class="form-control" name="scar" id="scar" placeholder="" />
                                 </div>
                                
                            </div>

                            <div class="form-group">

                                <label for="trans" class="col-sm-1 control-label">Transmisión:</label>
                                <div class="col-sm-2">
                                    <input type="text" maxlength="50" value="<? echo $psa['transmision'];?>" class="form-control" name="trans" id="trans" placeholder="" />
                                 </div>

                                <label for="uveh" class="col-sm-2 control-label">Uso del Vehículo:</label>
                                <div class="col-sm-2">
                                    <input type="text" maxlength="50" value="<? echo $psa['uso_vehiculo'];?>" class="form-control" name="uveh" id="uveh" placeholder="" />
                                 </div>

                                 <label for="tcar" class="col-sm-3 control-label">Tipo de Carga:</label>
                                <div class="col-sm-2">
                                    <input type="text" maxlength="50" value="<? echo $psa['tipo_carga'];?>" class="form-control" name="tcar" id="tcar" placeholder="" />
                                 </div>
                                
                            </div>

                            <div class="form-group">
                                <label for="npas" class="col-sm-2 control-label">N° Pasajeros:</label>
                                <div class="col-sm-1">
                                    <input type="text" maxlength="4" value="<? echo $psa['npasajeros'];?>" class="num form-control" name="npas" id="npas" placeholder="" />
                                 </div>
                                 <label for="peso" class="col-sm-2 control-label">Peso (Kgs.):</label>
                                <div class="col-sm-1">
                                    <input type="text" maxlength="4" value="<? echo $psa['kgs'];?>" class="dec form-control" name="peso" id="peso" placeholder="" />
                                 </div>
                                 <label for="tons" class="col-sm-1 control-label">Toneladas:</label>
                                <div class="col-sm-1">
                                    <input type="text" maxlength="4" value="<? echo $psa['tons'];?>" class="dec form-control" name="tons" id="tons" placeholder="" />
                                 </div>

                                 <label for="uhveh" class="col-sm-2 control-label">Uso hab. del Vehículo:</label>
                                
                                <div class="col-sm-2">
                                <select name="uhveh" id="uhveh" class="form-control">
                                	<option value="<? echo $psa['uhv'];?>"><? echo $psa['uhv'];?></option>
                                    <option value="URBANO">URBANO</option>
                                    <option value="EXTRAURBANO">EXTRAURBANO</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="upor" class="col-sm-2 control-label">Usado por:</label>
                                <div class="col-sm-2">
                                <select name="upor" id="upor" class="form-control">
                                	<option value="<? echo $psa['up'];?>"><? echo $psa['up'];?></option>
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
                                	<option value="<? echo $psa['licencia'];?>"><? echo $psa['licencia'];?></option>
                                    <option value="SEGUNDA">SEGUNDA</option>
                                    <option value="TERCERA">TERCERA</option>
                                    <option value="TITULO">TÍTULO</option>
                                    <option value="CUARTA">CUARTA</option>
                                    <option value="QUINTA">QUINTA</option>
                                </select>
                                </div>

                                <label for="aexp" class="col-sm-2 control-label">Años Exp.:</label>
                                <div class="col-sm-1">
                                    <input type="text" value="<? echo $psa['a_exp'];?>" maxlength="2" class="num form-control" name="aexp" id="aexp" placeholder="" />
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

                                            <?
                                            $checked="";
                                            if ($psa['amp_sa']>0)
                                                $checked="checked";

                                            ?>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_amp" id="ch_amp" <? echo $checked; ?>  >
                                                Amplia
                                              </label>
                                            </div>


                                            </td>
                                            
                                            <td> <input type="text" maxlength="20" value="<? echo $psa['amp_sa'];?>" class="dec form-control" name="amp_sa" id="amp_sa" placeholder="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            <?
                                            $checked="";
                                            if ($psa['amp_ded_sa']>0)
                                                $checked="checked";

                                            ?>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_aded" id="ch_aded" <? echo $checked; ?> >
                                                Amplia con deducible (%)
                                              </label>
                                            </div>

                                            </td>
                                            
                                            <td> <input type="text" value="<? echo $psa['amp_ded_sa'];?>" maxlength="20" class="dec form-control" name="aded_sa" id="aded_sa" placeholder="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>

                                            <?
                                            $checked="";
                                            if ($psa['apf_sa']>0)
                                                $checked="checked";

                                            ?>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_apf" id="ch_apf" <? echo $checked; ?> >
                                                Amplia Plan Familiar
                                              </label>
                                            </div>

                                            </td>
                                            
                                            <td> <input type="text" value="<? echo $psa['apf_sa'];?>" maxlength="20" class="dec form-control" name="apf_sa" id="apf_sa" placeholder="" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>

                                            <?
                                            $checked="";
                                            if ($psa['pt_sa']>0)
                                                $checked="checked";

                                            ?>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_pt" id="ch_pt" <? echo $checked; ?> >
                                                Pérdida Total
                                              </label>
                                            </div>


                                            </td>
                                            
                                            <td> <input type="text" maxlength="20" value="<? echo $psa['pt_sa'];?>" class="dec form-control" name="pt_sa" id="pt_sa" placeholder="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>

                                            <?
                                            $checked="";
                                            if ($psa['idd_sa']>0)
                                                $checked="checked";

                                            ?>

                                            <div class="checkbox">
                                                  <label>
                                                    <input class="chk" type="checkbox" name="ch_id" id="ch_id" <? echo $checked; ?> >
                                                    Indemnización Diaria
                                                  </label>
                                                </div>


                                            </td>
                                            
                                            <td> <input type="text" maxlength="20" value="<? echo $psa['idd_sa'];?>" class="dec form-control" name="id_sa" id="id_sa" placeholder="" />
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

                                            <?
                                            $checked="";
                                            if ($psa['rrcd_sa']>0)
                                                $checked="checked";

                                            ?>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_rrcd" id="ch_rrcd" <? echo $checked; ?> >
                                                Radio/Reproductor/CD
                                              </label>
                                            </div>



                                            </td>
                                            
                                            <td> <input type="text" maxlength="20" value="<? echo $psa['rrcd_sa'];?>" class="dec form-control" name="rrcd_sa" id="rrcd_sa" placeholder="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>

                                            <?
                                            $checked="";
                                            if ($psa['aa_sa']>0)
                                                $checked="checked";

                                            ?>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_aa" id="ch_aa" <? echo $checked; ?> >
                                                Aire Acondicionado
                                              </label>
                                            </div>



                                            </td>
                                            
                                            <td> <input type="text" maxlength="20" value="<? echo $psa['aa_sa'];?>" class="dec form-control" name="aa_sa" id="aa_sa" placeholder="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>

                                            <?
                                            $checked="";
                                            if ($psa['otro_sa']>0)
                                                $checked="checked";

                                            ?>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_otr" id="ch_otr" <? echo $checked; ?> >
                                                Otro
                                              </label>
                                            </div>


                                            </td>
                                            
                                            <td> <input type="text" maxlength="20" value="<? echo $psa['otro_sa'];?>" class="dec form-control" name="otr_sa" id="otr_sa" placeholder="" />
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

                                            <?
                                            $checked="";
                                            if ($psa['rcv_sa']>0)
                                                $checked="checked";

                                            ?>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_rcv" id="ch_rcv" <? echo $checked; ?> >
                                                RCV Básica
                                              </label>
                                            </div>


                                            </td>
                                            
                                            <td> <input type="text" value="<? echo $psa['rcv_sa'];?>" maxlength="20" value="0" class="dec form-control" name="rcv_sa" id="rcv_sa" placeholder="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>

                                            <?
                                            $checked="";
                                            if ($psa['aldp_sa']>0)
                                                $checked="checked";

                                            ?>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_aldp" id="ch_aldp" <? echo $checked; ?>  >
                                                Asistencia Legal y Def. Penal
                                              </label>
                                            </div>

                                            </td>
                                            
                                            <td> <input type="text" maxlength="20" value="<? echo $psa['aldp_sa'];?>" class="dec form-control" name="aldp_sa" id="aldp_sa" placeholder="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>

                                            <?
                                            $checked="";
                                            if ($psa['el_sa']>0)
                                                $checked="checked";

                                            ?>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_el" id="ch_el" <? echo $checked; ?> >
                                                Exceso de Límite
                                              </label>
                                            </div>

                                            </td>
                                            
                                            <td> <input type="text" maxlength="20" value="<? echo $psa['el_sa'];?>" class="dec form-control" name="el_sa" id="el_sa" placeholder="" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>Accidentes Terrestres</td>
                                            
                                            <td> <select class="form-control" name="at" id="at">
                                                    <option value="<? echo $psa['at'];?>"><? echo $psa['at'];?></option>
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

                                            <?
                                            $checked="";
                                            if ($psa['muerte_sa']>0)
                                                $checked="checked";

                                            ?>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_m" id="ch_m" <? echo $checked; ?> >
                                                Muerte
                                              </label>
                                            </div>


                                            </td>
                                            
                                            <td> <input type="text" maxlength="20" value="<? echo $psa['muerte_sa'];?>" class="dec form-control" name="m_sa" id="m_sa" placeholder="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>

                                            <?
                                            $checked="";
                                            if ($psa['invalidez_sa']>0)
                                                $checked="checked";

                                            ?>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_inv" id="ch_inv" <? echo $checked; ?> >
                                                Invalidez
                                              </label>
                                            </div>

                                            </td>
                                            
                                            <td> <input type="text" maxlength="20" value="<? echo $psa['invalidez_sa'];?>" class="dec form-control" name="inv_sa" id="inv_sa" placeholder="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>

                                            <?
                                            $checked="";
                                            if ($psa['gmc_sa']>0)
                                                $checked="checked";

                                            ?>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_gmc" id="ch_gmc" <? echo $checked; ?>  >
                                                Gastos Médicos o Curación
                                              </label>
                                            </div>



                                            </td>
                                            
                                            <td> <input type="text" maxlength="20" value="<? echo $psa['gmc_sa'];?>" class="dec form-control" name="gmc_sa" id="gmc_sa" placeholder="" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>

                                            <?
                                            $checked="";
                                            if ($psa['ge_sa']>0)
                                                $checked="checked";

                                            ?>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_ge" id="ch_ge" <? echo $checked; ?> >
                                                Gastos de Entierro
                                              </label>
                                            </div>



                                            </td>
                                            
                                            <td> <input type="text" maxlength="20" value="<? echo $psa['ge_sa'];?>" class="dec form-control" name="ge_sa" id="ge_sa" placeholder="" />
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

                                        <? 


                                        $qr_int=mysql_query("SELECT i.codigo,i.nombre,i.porc_part FROM intermediario i INNER JOIN intermediario_poliza ip ON i.id=ip.id_interm WHERE ip.id_poliza=$idpsa AND tipo_poliza='AUTOMOVIL'");?>

                                        <input hidden id="cont3" value="<?echo mysql_num_rows($qr_int);?>">
                                        <input hidden name="max3" id="max3"  value="<?echo mysql_num_rows($qr_int);?> ">
                                        <input hidden id="evt" value="NO"> <!-- Campo oculto para evitar repetición de eventos -->

                                        <?
                                        $i=0;
                                        while ($int=mysql_fetch_array($qr_int)){
                                            $i++;
                                        ?>

                                        <tr id="fint<? echo $i; ?>"><td><input class="codint" hidden  name="cod_int<? echo $i; ?>" id="cod_int<? echo $i; ?>" value="<? echo $int['codigo']; ?>" /><? echo $int['codigo']; ?></td><td><input hidden  name="nom_int<? echo $i; ?>" id="nom_int<? echo $i; ?>" value="<? echo $int['nombre']; ?>" /><? echo $int['nombre']; ?></td><td><input hidden  name="ppar_int<? echo $i; ?>" id="ppar_int<? echo $i; ?>" value="<? echo $int['porc_part']; ?>" /><? echo $int['porc_part']; ?></td><td><button title="Eliminar" data-id="fint<? echo $i; ?>" type="button" class="elm_int btn-danger"><span class="glyphicon glyphicon-remove"></span></button></td></tr>
             
                                        <? } ?>
                                    </tbody>
                                </table>
                                </div>
                            </div>

                            <div class="form-group">
                                &nbsp;
                            </div>

                            <!--

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

                            -->

                            <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="left">8) FECHA Y LUGAR</p></label>
                            </div>

                            <div class="form-group">
                                <label for="fecha"  class="col-sm-1 control-label">Fecha:</label>
                                <div class="col-sm-2">
                                <input type="date" value="<? echo $psa['fecha'];?>" class="form-control" name="fecha" id="fecha" placeholder="" />
                                </div>
                                <label for="lugar" class="col-sm-1 control-label">Lugar:</label>
                                <div class="col-sm-4">
                                <input type="text" value="<? echo $psa['lugar'];?>" class="form-control" name="lugar" id="lugar" placeholder="" />
                                </div>
                                
                            </div>





                            <div class="form-group">
                                &nbsp;
                            </div>

                            <input hidden name="idpsa" id="idpsa" value="<? echo $psa['id'];?>" />

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







