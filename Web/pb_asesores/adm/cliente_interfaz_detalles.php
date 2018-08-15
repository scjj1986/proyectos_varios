
<script type='text/javascript' language='javascript' src='js/cliente.js'></script>

<? 
session_start();
require("conectar.php");


$idcli=$_GET["id"];
$qr_cli=mysql_query("SELECT * FROM cliente WHERE id=$idcli");
$cli= mysql_fetch_array($qr_cli);

$ide=$cli["id_edo"];
$idm=$cli["id_mun"];
$idp=$cli["id_par"];



$qr_edo=mysql_query("SELECT * FROM estado WHERE id=$ide");
$edo= mysql_fetch_array($qr_edo);

$qr_mun=mysql_query("SELECT * FROM municipio WHERE id=$idm");
$mun=mysql_fetch_array($qr_mun);

$qr_par=mysql_query("SELECT * FROM parroquia WHERE id=$idp");
$par=mysql_fetch_array($qr_par);



?>


<div class="panel panel-primary">
  <div class="panel-heading">
    <h2 class="panel-title"><span align="right" class="glyphicon glyphicon-file"></span><b>&nbsp;&nbsp;DETALLES CLIENTE</b></h2>
  </div>
  <div class="panel-body">
    <div class="container">

                        <form role="form" class="frmcli form-horizontal">
                        		

                            <div class="form-group">

                            	<label for="tp" class="col-sm-2 control-label">Tipo Persona:</label>
                                
                                <div class="col-sm-1">
                                <select disabled name="tp" id="tp" class="form-control">
                                	<option value="<? echo $cli['tipo_persona']; ?>"><? echo $cli['tipo_persona']; ?></option>
					            </select>
                                </div>

                                <label for="cedrif" class="col-sm-1 control-label">Céd/Pas./RIF:</label>
                                <div class="col-sm-2">
                                <input disabled type="text" maxlength="15" class="form-control" name="cedrif" id="cedrif" value="<? echo $cli['ced_rif']; ?>" placeholder="" />
                                    
                                </div>

                                <label for="nomrs" class="col-sm-2 control-label">Nombre/Raz.Soc.:</label>
                                <div class="col-sm-4">
                                <input disabled type="text" maxlength="50" class="let form-control" name="nomrs" id="nomrs" value="<? echo $cli['nombre_rs']; ?>" placeholder="" />
                                    
                                </div>
                                
                            </div>


                            <?
                            
                            if ($cli['tipo_persona']=="J"){
                                
                                $mostrar="block";
                            }
                            else {
                                $mostrar="none";
                            }
                            
                             ?>




                            <div id="pj" style="display:<? echo $mostrar; ?>;" class="form-group">
                            <label for="natemp" class="col-sm-3 control-label">Naturaleza de la Empresa:</label>
                            <div class="col-sm-3">
                                <select disabled name="natemp" id="natemp" class="form-control">
                                    <option value="<? echo $cli['natemp']; ?>"><? echo $cli['natemp']; ?></option>
                                </select>
                                </div>

                            </div>






                             
                            <div class="form-group">

                                <label for="fnac" class="col-sm-2 control-label">F. Nacimiento:</label>
                                <div class="col-sm-2">
                                <input disabled type="date" maxlength="15" class="form-control" name="fnac" id="fnac" value="<? echo $cli['fnac']; ?>" placeholder="" />
                                    
                                </div>

                                <label for="sexo" class="col-sm-1 control-label">Sexo:</label>
                                
                                <div class="col-sm-1">
                                <select disabled name="sexo" id="sexo" class="form-control">
                                <option value="<? echo $cli['sexo']; ?>"><? echo $cli['sexo']; ?></option>
					            </select>
                                </div>

                                <label for="ec" class="col-sm-3 control-label">Estado Civil:</label>                               
                                <div class="col-sm-3">
                                <select disabled name="ec" id="ec" class="form-control">
                                    <option value="<? echo $cli['ec']; ?>"><? echo $cli['ec']; ?></option>
                                </select>
                                </div>






                                
                                
                            </div>

                            <div class="form-group">

                                <label for="inganu" class="col-sm-2 control-label">Ing. An. (U.T.):</label>                               
                                <div class="col-sm-3">
                                <select disabled name="inganu" id="inganu" class="form-control">
                                    <option value="<? echo $cli['inganu']; ?>"><? echo $cli['inganu']; ?></option>
                                </select>
                                </div>

                                <label for="acteco" class="col-sm-1 control-label">Act. Ecn.:</label>
                                <div class="col-sm-2">
                                <select disabled name="acteco" id="acteco" class="form-control">
                                <option value="<? echo $cli['acteco']; ?>"><? echo $cli['acteco']; ?></option>
                                </select>
                                </div>

                                <label for="ocu" class="col-sm-1 control-label">Ocup.:</label>
                                <div class="col-sm-3 has-warning">
                                <input disabled type="text" maxlength="80" class="form-control" name="ocu" id="ocu" value="<? echo $cli['ocup']; ?>" placeholder="" />
                                    
                                </div>

                                

                                

                                
                                
                            </div>

                            <div class="form-group">


                                <label for="edo" class="col-sm-1 control-label">Estado:</label>
                                <div class="col-sm-3">
                                <select disabled name="edo" id="edo" class="form-control">
                                <option value="<? echo $edo['id']; ?>"><? echo $edo['nombre']; ?></option>
                                </select>
                                </div>

                                <label for="ciu" class="col-sm-1 control-label">Ciudad:</label>
                                <div class="col-sm-3">
                                <input disabled type="text" maxlength="80" class="form-control" name="ciu" id="ciu" value="<? echo $cli['ciudad']; ?>" placeholder="" />
                                    
                                </div>

                                <label for="mun" class="col-sm-1 control-label">Municipio:</label>
                                
                                <div class="col-sm-3">
                                <select disabled name="mun" id="mun" class="form-control">

                                <option value="<? echo $mun['id']; ?>"><? echo $mun['nombre']; ?></option>
                                

                                </select>
                                </div>

                                

                                
                                
                                
                            </div>

                            <div class="form-group">

                                <label for="par" class="col-sm-1 control-label">Parroquia:</label>
                                
                                <div class="col-sm-3">
                                <select disabled name="par" id="par" class="form-control">

                                <option value="<? echo $par['id']; ?>"><? echo $par['nombre']; ?></option>
                                

                                </select>
                                </div>

                                <label for="usb" class="col-sm-1 control-label">Urb./Sec./Bar.:</label>
                                <div class="col-sm-3">
                                <input disabled type="text" maxlength="80" class="form-control" name="usb" id="usb" value="<? echo $cli['usb']; ?>" placeholder="" />
                                    
                                </div>

                                <label for="egcq" class="col-sm-1 control-label">Ed./Gp./Cs./Qt.:</label>
                                <div class="col-sm-3">
                                <input disabled type="text" maxlength="80" class="form-control" name="egcq" id="egcq" value="<? echo $cli['egcq']; ?>" placeholder="" />
                                    
                                </div>

                                
                            </div>

                            <div class="form-group">

                                <label for="vp" class="col-sm-1 control-label">Vía Prnc.:</label>
                                <div class="col-sm-3">
                                <input disabled type="text" maxlength="80" class="form-control" name="vp" id="vp" value="<? echo $cli['vp']; ?>" placeholder="" />
                                    
                                </div>

                                <label for="vizq" class="col-sm-1 control-label">Vía (Izq.):</label>
                                <div class="col-sm-3 has-warning">
                                <input disabled type="text" maxlength="80" class="form-control" name="vizq" id="vizq" value="<? echo $cli['vizq']; ?>" placeholder="" />
                                    
                                </div>

                                <label for="vder" class="col-sm-1 control-label">Vía (Der.):</label>
                                <div class="col-sm-3 has-warning">
                                <input disabled type="text" maxlength="80" class="form-control" name="vder" id="vder" value="<? echo $cli['vder']; ?>" placeholder="" />
                                    
                                </div>

                                

                                
                                
                                
                            </div>

                            <div class="form-group">

                                <label for="tsa" class="col-sm-1 control-label">Tr/Sc./Al.:</label>
                                <div class="col-sm-3 has-warning">
                                <input disabled type="text" maxlength="80" class="form-control" name="tsa" id="tsa" value="<? echo $cli['tsa']; ?>" placeholder="" />
                                    
                                </div>

                                <label for="pn" class="col-sm-1 control-label">Pis/Nv.:</label>
                                <div class="col-sm-3 has-warning">
                                <input disabled type="text" maxlength="80" class="form-control" name="pn" id="pn" value="<? echo $cli['pn']; ?>" placeholder="" />
                                    
                                </div>

                                <label for="loa" class="col-sm-1 control-label">Lc./Of./Ap:</label>
                                <div class="col-sm-3 has-warning">
                                <input disabled type="text" maxlength="80" class="form-control" name="loa" id="loa" value="<? echo $cli['loa']; ?>" placeholder="" />
                                    
                                </div>

                                

                                  
                                
                            </div>

                            <div class="form-group">

                                <label for="ref" class="col-sm-1 control-label">Ref.:</label>
                                <div class="col-sm-3">
                                    <textarea disabled maxlength="100" name="ref" id="ref" class="form-control" rows="2"><? echo $cli['ref']; ?></textarea>
                                 </div>

                                <label for="otro" class="col-sm-1 control-label">Otro:</label>
                                <div class="col-sm-3 has-warning">
                                    <textarea disabled maxlength="100" name="otro" id="otro" class="form-control" rows="2"><? echo $cli['otro']; ?></textarea>
                                 </div>

                                 <label for="cp" class="col-sm-1 control-label">Cd. Ps.:</label>
                                <div class="col-sm-3">
                                <input disabled type="text" maxlength="10" class="form-control" name="cp" id="cp" value="<? echo $cli['cp']; ?>" placeholder="" />
                                    
                                </div> 

                                

                                 
                                
                                
                            </div>

                            <div class="form-group">

                                <label for="tlfh" class="col-sm-1 control-label">Tlf. Hb.:</label>
                                <div class="col-sm-3">
                                    <input disabled type="text" maxlength="20" class="form-control" name="tlfh" id="tlfh" value="<? echo $cli['tlfh']; ?>" placeholder="" />
                                 </div>

                                <label for="tlfo" class="col-sm-1 control-label">Tlf. Of.:</label>
                                <div class="col-sm-3">
                                    <input disabled type="text" maxlength="20" class="form-control" name="tlfo" id="tlfo" value="<? echo $cli['tlfo']; ?>" placeholder="" />
                                 </div>

                                 <label for="tlfc" class="col-sm-1 control-label">Tlf. Cel.:</label>
                                <div class="col-sm-3">
                                    <input disabled type="text" maxlength="20" class="form-control" name="tlfc" id="tlfc" value="<? echo $cli['tlfc']; ?>" placeholder="" />
                                 </div>

                                

                                 
                                
                                
                            </div>


                            <div class="form-group">

                                <label for="email" class="col-sm-1 control-label">Email:</label>
                                <div class="col-sm-3 has-warning">
                                    <input disabled type="text" maxlength="50" class="form-control" name="email" id="email" value="<? echo $cli['email']; ?>" placeholder="" />
                                 </div>

                                <label for="fax" class="col-sm-1 control-label">Fax:</label>
                                <div class="col-sm-3 has-warning">
                                    <input disabled type="text" maxlength="20" class="form-control" name="fax" id="fax" value="<? echo $cli['fax']; ?>" placeholder="" />
                                 </div>
                            </div>
                            
                            
                            
                            <div class="form-group">
                                &nbsp;
                            </div>


                            <div class="form-group" align="center">
                                <label><a id="cli_vlv_list" class="btn btn-danger">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Volver&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></label>
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

