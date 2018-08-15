<? 
session_start();
require("conectar.php");
date_default_timezone_set('America/Caracas');


$idasg=$_GET["id"];
$qr_asg=mysql_query("select * FROM notificacion  where id=$idasg");
$asg= mysql_fetch_array($qr_asg);
$dir="../Android/FotoSiniestros/";


?>




<script type='text/javascript' language='javascript' src='js/notificacion.js'></script>


<div class="panel panel-primary">
  <div class="panel-heading">
    <h2 class="panel-title"><span align="right" class="glyphicon glyphicon-pencil"></span><b>&nbsp;&nbsp;EDITAR NOTIFICACIÓN DE SINIESTRO</b></h2>
  </div>
  <div class="panel-body">
    <div class="container">

                        <form role="form" class="frmasg1 form-horizontal">

                        <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="center">1) DATOS DE LA NOTIFICACIÓN</p></label>
                            </div>
                            
                             
                            <div class="form-group">
                            <label for="codigo" class="col-sm-1 control-label">Código:</label>
                                <div class="col-sm-2">
                                <input value="<? echo $asg['codigo']; ?>" type="text" maxlength="100" class="let form-control" name="codigo" id="codigo" placeholder="" />
                                    
                                </div>

                                
                                <label for="descripcion" class="col-sm-1 control-label">Descripción:</label>
                                <div class="col-sm-3">
	                                <textarea maxlength="150" name="decripcion" id="descripcion" class="form-control" rows="1"><? echo $asg['descripcion']; ?></textarea>
						         </div>
                                  <label for="hora" class="col-sm-1 control-label">Hora:</label>
                                <div class="col-sm-1">
	                               <input value="<? echo $asg['hora']; ?>" type="text" maxlength="100" class="let form-control" name="hora" id="hora" placeholder="" />
						         </div>
                                 <label for="fecha" class="col-sm-1 control-label">Fecha:</label>
                                <div class="col-sm-2">
	                               <input value="<? echo date("d-m-Y", strtotime($asg["fecha"])); ?>" type="text" maxlength="100" class="let form-control" name="fecha" id="fecha" placeholder="" />
						         </div>
                                

						         <label for="status" class="col-sm-1 control-label">Estatus:</label>
                                <div class="col-sm-2">
                                    <select name="status" id="status" class="form-control">
                                        <option value="<? echo $asg['status']; ?>"><? echo $asg["status"]; ?></option>
                                        <option value="APROBADA">APROBADA</option>
                                        <option value="RECHAZADA">RECHAZADA</option>
                                        <option value="EN PROCESO">EN PROCESO</option>
                                        <option value="ENVIADA">ENVIADA</option>
                                    </select>
                                 </div>
                                  <label for="tipo" class="col-sm-1 control-label">Tipo:</label>
                                  <div class="col-sm-3">
                                    <select name="tipo" id="tipo" class="form-control">
                                        
                                        <option value=""></option>
                                        <option value="LEVE">LEVE</option>
                                        <option value="MODERADO">MODERADO</option>
                                        <option value="GRAVE">GRAVE</option>
                                    </select>
                                 </div>

                                
                            </div>

                            <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="center">2) FOTO</p></label>
                            </div>
                            
                             
                            <div class="form-group">                          
                               
                               
                                <div class="col-sm-2" align="center">
                                <img src="<? echo $dir.$asg['imagen']; ?>" width="800" height="600"  />
                                    
                                </div>

                               
                            </div>


                            <input hidden name="idasg" id="idasg" value="<? echo $idasg; ?>" />

                            <div class="form-group" align="center">
                                <label><a data-opc="editar" class="asg_agredi1 btn btn-success">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Guardar&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></label>-<label><a id="asg_vlv_list" class="btn btn-danger">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Volver&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></label>
                            </div>
                            <div class="form-group">
                                &nbsp;
                            </div>
                                     
                        </form>

                    </div>
  </div>
  <div class="panel-heading">
    <h3 class="panel-title"><b>SISTEMA pb ASESORES, C.A. </b></h3>
  </div>
</div>

