<? 
session_start();
require("conectar.php");

$idpss=$_GET["id"];

$qr_pss=mysql_query("SELECT * FROM poliza_salud WHERE id=$idpss");
$pss=mysql_fetch_array($qr_pss);



// -------------------------- Tomador --------------------------------------------//
$idtom=$pss["id_tomador"];
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
$idat=$pss["id_asegurado"];
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


<script type='text/javascript' language='javascript' src='js/polizasegurosalud.js'></script>




<div class="panel panel-primary">
  <div class="panel-heading">
    <h2 class="panel-title"><span align="right" class="glyphicon glyphicon-pencil"></span><b>&nbsp;&nbsp;EDITAR SOLICITUD DE SEGURO DE SALUD</b></h2>
  </div>
  <div class="panel-body">
    <div class="container">

                        <form role="form" class="frmpss form-horizontal">

                        <div class="form-group">
                                <label align="center" class="col-sm-9 control-label"><p align="right">Solicitud Renovación de Seguro N°:</p></label>
                                <div class="col-sm-3">
                                <input type="text" disabled class="form-control" name="nsol" id="nsol" value="<?php echo $pss['n_solicitud'];?>" placeholder="" />
                                <input type="hidden" class="form-control" name="nsol2" id="nsol2" value="<?php echo $pss['n_solicitud'];?>" placeholder="" />
                                    
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
                                    $id_asegr=$pss["id_aseguradora"];

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

                                <label for="ande" class="col-sm-6 control-label">La factura una vez pagada la prima de la póliza, deberá salir a nombre de:</label>
                                
                                <div class="col-sm-2">
                                <select name="ande" id="ande" class="form-control">
                                    <option value="<? echo $pss['a_nombre_de']?>"><? echo $pss['a_nombre_de']?></option>
                                    <option value="TOMADOR">TOMADOR</option>
                                    <option value="ASEGURADO">ASEGURADO</option>
                                </select>
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
                                <input type="date" value="<? echo $pss['fecha_desde'];?>" maxlength="15" class="form-control" name="fdes" id="fdes" placeholder="" />
                                </div>
                                <label for="fhas" class="col-sm-1 control-label">Hasta:</label>
                                <div class="col-sm-2">
                                <input type="date" value="<? echo $pss['fecha_hasta'];?>" maxlength="15" class="form-control" name="fhas" id="fhas" placeholder="" />
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
                                    <option value="<? echo $pss['frec_pago'];?>"><? echo $pss['frec_pago'];?></option>
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


                                            <?

                                            $checked="";
                                            if ($pss['bhcm_ded']>0  || $pss['bhcm_sa']>0)
                                                $checked="checked";
                                                

                                            ?>
                                            
                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_bhcm" id="ch_bhcm"   <? echo $checked; ?> >
                                                Básica de Hospitalización, Cirugía y Maternidad
                                              </label>
                                            </div>

                                            </td>
                                            <td> <input type="text" maxlength="20" value="<? echo $pss['bhcm_ded']; ?>" class="dec form-control" name="bhcm_ded" id="bhcm_ded" placeholder="" />
                                            </td>
                                            <td> <input type="text" maxlength="20" value="<? echo $pss['bhcm_sa']; ?>" class="dec form-control" name="bhcm_sa" id="bhcm_sa" placeholder="" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>

                                            <?
                                            $checked="";
                                            if ($pss['anx_ded']>0  || $pss['anx_sa']>0)
                                                $checked="checked";
                                            ?>


                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_anx" id="ch_anx" <? echo $checked; ?> >
                                                Anexos
                                              </label>
                                            </div>



                                            </td>
                                            <td> <input type="text" maxlength="20" value="<? echo $pss['anx_ded']; ?>" class="dec form-control" name="anx_ded" id="anx_ded" placeholder="" />
                                            </td>
                                            <td> <input type="text" maxlength="20" value="<? echo $pss['anx_sa']; ?>" class="dec form-control" name="anx_sa" id="anx_sa" placeholder="" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>
                                            <?
                                            $checked="";
                                            if ($pss['mat_ded']>0  || $pss['mat_sa']>0)
                                                $checked="checked";
                                            ?>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_mat" id="ch_mat" <? echo $checked; ?> >
                                                Maternidad
                                              </label>
                                            </div>
                                            </td>
                                            <td> <input type="text" maxlength="20" value="<? echo $pss['mat_ded']; ?>" class="dec form-control" name="mat_ded" id="mat_ded" placeholder="" />
                                            </td>
                                            <td> <input type="text" maxlength="20" value="<? echo $pss['mat_sa']; ?>" class="dec form-control" name="mat_sa" id="mat_sa" placeholder="" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>
                                            <?
                                            $checked="";
                                            if ($pss['ap_ded']>0  || $pss['ap_sa']>0)
                                                $checked="checked";
                                            ?>



                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_ap" id="ch_ap" <? echo $checked; ?> >
                                                Accidentes Personales
                                              </label>
                                            </div></td>
                                            <td> <input type="text" maxlength="20" value="<? echo $pss['ap_ded']; ?>" class="dec form-control" name="ap_ded" id="ap_ded" placeholder="" />
                                            </td>
                                            <td> <input type="text" maxlength="20" value="<? echo $pss['ap_sa']; ?>" class="dec form-control" name="ap_sa" id="ap_sa" placeholder="" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>
                                            <?
                                            $checked="";
                                            if ($pss['fun_ded']>0  || $pss['fun_sa']>0)
                                                $checked="checked";
                                            ?>

                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_fun" id="ch_fun" <? echo $checked; ?> >
                                                Funerarios
                                              </label>
                                            </div></td>
                                            <td> <input type="text" maxlength="20" value="<? echo $pss['fun_ded']; ?>" class="dec form-control" name="fun_ded" id="fun_ded" placeholder="" />
                                            </td>
                                            <td> <input type="text" maxlength="20" value="<? echo $pss['fun_sa']; ?>" class="dec form-control" name="fun_sa" id="fun_sa" placeholder="" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>
                                            <?
                                            $checked="";
                                            if ($pss['epe_ded']>0  || $pss['epe_sa']>0)
                                                $checked="checked";
                                            ?>
                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_epe" id="ch_epe"  <? echo $checked; ?> >
                                                Eliminación de plazos de espera
                                              </label>
                                            </div></td>
                                            <td> <input type="text" maxlength="20" value="<? echo $pss['epe_ded']; ?>" class="dec form-control" name="epe_ded" id="epe_ded" placeholder="" />
                                            </td>
                                            <td> <input type="text" maxlength="20" value="<? echo $pss['epe_sa']; ?>" class="dec form-control" name="epe_sa" id="epe_sa" placeholder="" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>
                                            <?
                                            $checked="";
                                            if ($pss['eep_ded']>0  || $pss['eep_sa']>0)
                                                $checked="checked";
                                            ?>


                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_eep" id="ch_eep" <? echo $checked; ?> >
                                                Eliminacion de enfermedades preexistentes
                                              </label>
                                            </div></td>
                                            <td> <input type="text" maxlength="20" value="<? echo $pss['eep_ded']; ?>" class="dec form-control" name="eep_ded" id="eep_ded" placeholder="" />
                                            </td>
                                            <td> <input type="text" maxlength="20" value="<? echo $pss['eep_sa']; ?>" class="dec form-control" name="eep_sa" id="eep_sa" placeholder="" />
                                            </td>
                                        </tr>

                                        

                                        <tr>
                                            <td>

                                            <?
                                            $checked="";
                                            if ($pss['otr_ded']>0  || $pss['otr_sa']>0)
                                                $checked="checked";
                                            ?>


                                            <div class="checkbox">
                                              <label>
                                                <input class="chk" type="checkbox" name="ch_otr" id="ch_otr" <? echo $checked; ?> >
                                                Otros
                                              </label>
                                            </div></td>
                                            <td> <input type="text" maxlength="20" value="<? echo $pss['otr_ded']; ?>" class="dec form-control" name="otr_ded" id="otr_ded" placeholder="" />
                                            </td>
                                            <td> <input type="text" maxlength="20" value="<? echo $pss['otr_sa']; ?>" class="dec form-control" name="otr_sa" id="otr_sa" placeholder="" />
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
                                <label align="center" class="col-sm-12 control-label"><p align="left">7) BENEFICIARIO(S) EN CASO DE FALLECIMIENTO DEL PROPUESTO ASEGURADO TITULAR</p></label>
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

                                    
                                    

                                    <? 

                                    

                                    $qr_ben=mysql_query("SELECT b.cedula,b.nombre,b.parentesco,b.porc_part FROM beneficiario b INNER JOIN beneficiario_poliza bp ON b.id=bp.id_benf WHERE bp.id_poliza=$idpss");?>

                                    <input hidden id="cont" value="<?echo mysql_num_rows($qr_ben);?>">
                                    <input hidden name="max" id="max"  value="<?echo mysql_num_rows($qr_ben);?> ">

                                    <?
                                    $i=0;
                                    while ($ben=mysql_fetch_array($qr_ben)){
                                        $i++;
                                    ?>

                                    <tr id="fben<? echo $i;?>"><td><input class="cedben" hidden  name="ced_ben<? echo $i;?>" id="ced_ben<? echo $i;?>" value="<? echo $ben['cedula'];?>" /><? echo $ben['cedula'];?></td><td><input hidden  name="nom_ben<? echo $i;?>" id="nom_ben<? echo $i;?>" value="<? echo $ben['nombre'];?>" /><? echo $ben['nombre'];?></td><td><input hidden  name="par_ben<? echo $i;?>" id="par_ben<? echo $i;?>" value="<? echo $ben['parentesco'];?>" /><? echo $ben['parentesco'];?></td><td><input hidden  name="ppar_ben<? echo $i;?>" id="ppar_ben<? echo $i;?>" value="<? echo $ben['porc_part'];?>" /><? echo $ben['porc_part'];?></td><td><button title="Eliminar" data-id="fben<? echo $i;?>" type="button" class="elm_ben btn-danger"><span class="glyphicon glyphicon-remove"></span></button></td></tr>    
                                    <? }?>
                                    </tbody>
                                </table>
                                </div>
                            </div>





                            <div class="form-group">
                                &nbsp;
                            </div>

                            <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="left">8) GRUPO A ASEGURAR       (Nota: Indicar de primero al titular)</p></label>
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

                                        <? 

                                    

                                        $qr_gru=mysql_query("SELECT g.cedula,g.nombre,g.fnac,g.kgs,g.sexo,g.parentesco,g.maternidad FROM grupo g INNER JOIN grupo_poliza gp ON g.id=gp.id_grupo WHERE gp.id_poliza=$idpss");?>

                                        <input hidden id="cont2" value="<?echo mysql_num_rows($qr_gru);?>">
                                        <input hidden name="max2" id="max2"  value="<?echo mysql_num_rows($qr_gru);?> ">

                                        <?
                                        $i=0;
                                        while ($gru=mysql_fetch_array($qr_gru)){
                                            $i++;
                                        ?>

                                        <tr id="fgru<? echo $i; ?>"><td><input class="cedgru" hidden  name="ced_gru<? echo $i; ?>" id="ced_gru<? echo $i; ?>" value="<? echo $gru['cedula']; ?>" /><? echo $gru['cedula']; ?></td><td><input hidden  name="nom_gru<? echo $i; ?>" id="nom_gru<? echo $i; ?>" value="<? echo $gru['nombre']; ?>" /><? echo $gru['nombre']; ?></td>  <td><input hidden name="fnac_gru<? echo $i; ?>" id="fnac_gru'+max.toString()+'" value="<? echo $gru['fnac']; ?>" /> <? echo $gru['fnac']; ?></td> <td><input hidden name="kgs_gru<? echo $i; ?>" id="kgs_gru<? echo $i; ?>" value="<? echo $gru['kgs']; ?>" /> <? echo $gru['kgs']; ?></td> <td><input hidden name="sex_gru<? echo $i; ?>" id="sex_gru<? echo $i; ?>" value="<? echo $gru['sexo']; ?>" /> <? echo $gru['sexo']; ?></td>            <td><input hidden  name="par_gru<? echo $i; ?>" id="par_gru<? echo $i; ?>" value="<? echo $gru['parentesco']; ?>" /><? echo $gru['parentesco']; ?></td><td><input hidden  name="mat_gru<? echo $i; ?>" id="mat_gru<? echo $i; ?>" value="<? echo $gru['maternidad']; ?>" /><? echo $gru['maternidad']; ?></td><td><button title="Eliminar" data-id="fgru<? echo $i; ?>" type="button" class="elm_gru btn-danger"><span class="glyphicon glyphicon-remove"></span></button></td></tr>
            

                                        <? } ?>
                                    
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
                                <select class="form-control" name="goz_sal" id="goz_sal">
                                					<option value="<?echo $pss['gozan_salud'];?>"><?echo $pss['gozan_salud'];?></option>
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                                    
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="oper_quir" class="col-sm-8 control-label">¿Se le ha practicado alguna operación quirúrgica?:</label>
                                
                                <div class="col-sm-2">
                                <select class="form-control" name="oper_quir" id="oper_quir">
                                					<option value="<?echo $pss['oper_quir'];?>"><?echo $pss['oper_quir'];?></option>
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="prev_alg" class="col-sm-8 control-label">¿Tiene prevista alguna?:</label>
                                
                                <div class="col-sm-2">
                                <select class="form-control" name="prev_alg" id="prev_alg">
                                					<option value="<?echo $pss['prev_alg'];?>"><?echo $pss['prev_alg'];?></option>
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="trat_enf_trans" class="col-sm-8 control-label">¿Han consultado o estado en tratamiento médico por algún síntoma o enfermedad transitoria o defecto?:</label>
                                
                                <div class="col-sm-2">
                                <select class="form-control" name="trat_enf_trans" id="trat_enf_trans">
                                					<option value="<?echo $pss['trat_enf_trans'];?>"><?echo $pss['trat_enf_trans'];?></option>
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="pad_enf_trans" class="col-sm-8 control-label">¿Padecen ustedes actualmente de alguna enfermedad transitoria, crónica o defecto?:</label>
                                
                                <div class="col-sm-2">
                                <select class="form-control" name="pad_enf_trans" id="pad_enf_trans">
                                					<option value="<?echo $pss['pad_enf_trans'];?>"><?echo $pss['pad_enf_trans'];?></option>
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="edo_grav" class="col-sm-8 control-label">¿Alguno de los solicitantes ha estado o está en estado de gravidez?:</label>
                                
                                <div class="col-sm-2">
                                <select class="form-control" name="edo_grav" id="edo_grav">
                                					<option value="<?echo $pss['edo_grav'];?>"><?echo $pss['edo_grav'];?></option>
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
                                <select class="form-control" name="enf_sis_dig" id="enf_sis_dig">
                                					<option value="<?echo $pss['enf_sist_dig'];?>"><?echo $pss['enf_sist_dig'];?></option>
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="enf_card" class="col-sm-8 control-label">Enfermedades Cardiovasculares ( Tensión Alta, Infarto, Insuficiencia Cardiaca o Coronaria)</label>
                                
                                <div class="col-sm-2">
                                <select class="form-control" name="enf_card" id="enf_card">
                                					<option value="<?echo $pss['enf_cardvasc'];?>"><?echo $pss['enf_cardvasc'];?></option>
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="enf_resp" class="col-sm-8 control-label">Enfermedades Respiratorias ( Tos Crónica, Asma, Bronquitis, Insuficiencia Respiratoria)</label>
                                
                                <div class="col-sm-2">
                                <select class="form-control" name="enf_resp" id="enf_resp">
                                					<option value="<?echo $pss['enf_resp'];?>"><?echo $pss['enf_resp'];?></option>
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="enf_piel" class="col-sm-8 control-label">Enfermedades de la piel, ojos, nariz, oídos y garganta (Sinusitis, Amigdalitis, Rinitis)</label>
                                
                                <div class="col-sm-2">
                                <select class="form-control" name="enf_piel" id="enf_piel">
                                					<option value="<?echo $pss['enf_piel'];?>"><?echo $pss['enf_piel'];?></option>
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="enf_ven" class="col-sm-8 control-label">Enfermedades Venéreas, contagiosas o infecciosas, Sida.</label>
                                
                                <div class="col-sm-2">
                                <select class="form-control" name="enf_ven" id="enf_ven">
                                					<option value="<?echo $pss['enf_ven'];?>"><?echo $pss['enf_ven'];?></option>
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="tras_end" class="col-sm-8 control-label">Trastornos Endocrinos (Diabetes, Obesidad, Hipófisis,Tiroides, Metabolismo)</label>
                                
                                <div class="col-sm-2">
                                <select class="form-control" name="tras_end" id="tras_end">
                                					<option value="<?echo $pss['tras_end'];?>"><?echo $pss['tras_end'];?></option>
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="tras_neu" class="col-sm-8 control-label">Trastornos Neurosiquiátricos ( Epilepsias, Convulsiones, parálisis, Retardo Mental, Vértigo)</label>
                                
                                <div class="col-sm-2">
                                <select class="form-control" name="tras_neu" id="tras_neu">
                                					<option value="<?echo $pss['tras_neu'];?>"><?echo $pss['tras_neu'];?></option>
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="tras_ren" class="col-sm-8 control-label">Trastornos Renales o del Sietema Urinario ( Cálculos, Tumores de Próstata, Riñones)</label>
                                
                                <div class="col-sm-2">
                                <select class="form-control" name="tras_ren" id="tras_ren">
                                					<option value="<?echo $pss['tras_ren'];?>"><?echo $pss['tras_ren'];?></option>
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="enf_osea_musc" class="col-sm-8 control-label">Efermedades Ósea Musculares ( Escolitis, Hernias, Artritis, Reumatismo)</label>
                                
                                <div class="col-sm-2">
                                <select class="form-control" name="enf_osea_musc" id="enf_osea_musc">
                                					<option value="<?echo $pss['enf_os_musc'];?>"><?echo $pss['enf_os_musc'];?></option>
                                                    <option value="NO">NO</option>
                                                    <option value="SI">Sí</option>
                                </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="enf_muj" class="col-sm-8 control-label">Enfermedades Propias de la Mujer ( Fibroma, Nódulos o Quistes Mamarios, Ovarios)</label>
                                
                                <div class="col-sm-2">
                                <select class="form-control" name="enf_muj" id="enf_muj">
                                					<option value="<?echo $pss['enf_prop_muj'];?>"><?echo $pss['enf_prop_muj'];?></option>
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


                                        $qr_int=mysql_query("SELECT i.codigo,i.nombre,i.porc_part FROM intermediario i INNER JOIN intermediario_poliza ip ON i.id=ip.id_interm WHERE ip.id_poliza=$idpss AND tipo_poliza='SALUD'");?>

                                        <input hidden id="cont3" value="<?echo mysql_num_rows($qr_int);?>">
                                        <input hidden name="max3" id="max3"  value="<?echo mysql_num_rows($qr_int);?> ">

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

                           

                            <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="left">11) DATOS BANCARIOS PARA COBRO DE PRIMA </p></label>
                            </div>

                            <div class="form-group">
                                <label for="tip_cob_prim" class="col-sm-3 control-label">Tipo de Cobro de Prima:</label>
                                
                                <div class="col-sm-4">
                                <select class="form-control" name="tip_cob_prim" id="tip_cob_prim">
                                					<option value="<?echo $pss['tipo_cobro_prim'];?>"><?echo $pss['tipo_cobro_prim'];?></option>
                                                    <option value="DOMICILIACION BANCARIA">DOMICILIACION BANCARIA</option>
                                                    <option value="TARJETA DE CREDITO">TARJETA DE CREDITO</option>
                                </select>
                                </div>
                            </div>

                            <?

                            	if ($pss['tipo_cobro_prim']=="DOMICILIACION BANCARIA"){
                            		//echo $pss["id_cta_cobro"];
                            		$disp="block";
                            	}else{
                            		$disp="none";}

                                //echo $disp;


                            ?>

                            <div id="dombanc" style="display:<? echo $disp;?>;" class="form-group">
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
                                                                if ($pss['tipo_cobro_prim']=="DOMICILIACION BANCARIA"){

                                                                	$idbnc=$pss["id_cta_cobro"];
                                                                	//echo "SELECT bc.id,bc.nombre FROM cuenta_bancaria_poliza cbp INNER JOIN banco bc ON bc.id=cbp.idbanco WHERE cbp.id=$idbnc";
                                                                	$qr_bco2=mysql_query("SELECT bc.id,bc.nombre,cbp.ncuenta,cbp.tipo_cuenta FROM cuenta_bancaria_poliza cbp INNER JOIN banco bc ON bc.id=cbp.idbanco WHERE cbp.id=$idbnc");
                                                                	$bc=mysql_fetch_array($qr_bco2);
                                                            ?>
                                                                	<option value="<? echo $bc['id']; ?>"><? echo $bc['nombre']; ?></option>
                                                                <?

                                                            }


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
                                                <input type="text" value="<? echo $bc['ncuenta']; ?>" class="form-control" name="ncta_cob" id="ncta_cob" placeholder="" />
                                            </td>
                                           
                                            <td>
                                                <input type="text" maxlength="20" value="<? echo $bc['tipo_cuenta']; ?>" class="form-control" name="tcta_cob" id="tcta_cob" placeholder="" />
                                            </td>
                                        </tr>   

                                    </tbody>
                                </table>
                                </div>
                            </div>

                            <?

                            	if ($pss['tipo_cobro_prim']!="DOMICILIACION BANCARIA")
                            		$disp="block";
                            	else
                            		$disp="none";


                            ?>

                            <div id="tarjcred" style="display:<? echo $disp; ?>;" class="form-group">
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
                                                                if ($pss['tipo_cobro_prim']!="DOMICILIACION BANCARIA"){

                                                                    $idbnc=$pss["id_cta_cobro"];
                                                                    //echo "SELECT bc.id,bc.nombre FROM cuenta_bancaria_poliza cbp INNER JOIN banco bc ON bc.id=cbp.idbanco WHERE cbp.id=$idbnc";
                                                                    $qr_bco2=mysql_query("SELECT bc.id,bc.nombre,tc.numero,tc.tipo,tc.fvenc FROM tarjeta_credito tc INNER JOIN banco bc ON bc.id=tc.idbanco WHERE tc.id=$idbnc");
                                                                    $bc=mysql_fetch_array($qr_bco2);
                                                            ?>
                                                                    <option value="<? echo $bc['id']; ?>"><? echo $bc['nombre']; ?></option>
                                                                <?

                                                            }


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
                                                <input type="text" value="<? echo $bc['numero']; ?>" class="form-control" name="nr_tc" id="nr_tc" placeholder="" />
                                            </td>
                                           
                                            <td>
                                                <input type="text" class="form-control" value="<? echo $bc['tipo']; ?>" name="tipo_tc" id="tipo_tc" placeholder="" />
                                            </td>
                                            <td>
                                                <input type="date" class="form-control" value="<? echo $bc['fvenc']; ?>" name="venc_tc" id="venc_tc" placeholder="" />
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
                                                    <option value="<? echo $pss['descr_cta_reemb']; ?>"><? echo $pss['descr_cta_reemb']; ?></option>
                                                    <option value="COBRO DE PRIMA">COBRO DE PRIMA</option>
                                                    <option value="OTRA CUENTA">OTRA CUENTA</option>
                                </select>
                                </div>
                            </div>


                            <?

                                if ($pss['descr_cta_reemb']!="COBRO DE PRIMA")
                                    $disp="block";
                                else
                                    $disp="none";


                            ?>


                            <div id="otracta" style="display:<? echo $disp; ?>;" class="form-group">
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
                                                                if ($pss['descr_cta_reemb']!="COBRO DE PRIMA"){

                                                                    $idbnc=$pss["id_cta_reemb"];
                                                                    //echo "SELECT bc.id,bc.nombre FROM cuenta_bancaria_poliza cbp INNER JOIN banco bc ON bc.id=cbp.idbanco WHERE cbp.id=$idbnc";
                                                                    $qr_bco2=mysql_query("SELECT bc.id,bc.nombre,cbp.ncuenta,cbp.tipo_cuenta FROM cuenta_bancaria_poliza cbp INNER JOIN banco bc ON bc.id=cbp.idbanco WHERE cbp.id=$idbnc");
                                                                    $bc=mysql_fetch_array($qr_bco2);
                                                            ?>
                                                                    <option value="<? echo $bc['id']; ?>"><? echo $bc['nombre']; ?></option>
                                                                <?

                                                            }
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
                                                <input type="text" value="<? echo $bc['ncuenta']; ?>" class="form-control" name="ncta_reemb" id="ncta_reemb" placeholder="" />
                                            </td>
                                           
                                            <td>
                                                <input type="text" maxlength="20" value="<? echo $bc['tipo_cuenta']; ?>" class="form-control" name="tcta_reemb" id="tcta_reemb" placeholder="" />
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
                                <input type="date" value="<? echo $pss['fecha']; ?>" class="form-control" name="fecha" id="fecha" placeholder="" />
                                </div>
                                <label for="lugar" class="col-sm-1 control-label">Lugar:</label>
                                <div class="col-sm-4">
                                <input type="text" class="form-control" value="<? echo $pss['lugar']; ?>" name="lugar" id="lugar" placeholder="" />
                                </div>
                                
                            </div>





                            <div class="form-group">
                                &nbsp;
                            </div>

                            <input hidden name="idpss" id="idpss" value="<? echo $idpss; ?>" />

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