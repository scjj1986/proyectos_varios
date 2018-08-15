<? 
session_start();
require("conectar.php");



$dir="../Android/FotoSiniestros/";

   ?>






<script type='text/javascript' language='javascript' src='js/siniestro.js'></script>

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




<div class="panel panel-primary">
  <div class="panel-heading">
    <h2 class="panel-title"><span align="right" class="glyphicon glyphicon-plus-sign"></span><b>&nbsp;&nbsp;NUEVO SINIESTRO</b></h2>
  </div>
  <div class="panel-body">
    <div class="container">

                        <form role="form"   class="frmsin form-horizontal" enctype="multipart/form-data">

                        <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="left">1) DATOS DE LA PÓLIZA</p></label>
                                <input type="hidden" maxlength="15" class="form-control" name="idpol" id="idpol" placeholder="" />
                            </div>
                                

                            <div class="form-group">

                                
                                <div class="col-sm-3">
                                    <div class="input-group">
                                        <span class="input-group-btn">
                                            <button id="bscpol" class="btn btn-primary glyphicon glyphicon-search" type="button"></button>
                                      </span>
                                      <input disabled type="text" id="txtnsol" class="form-control" placeholder="Buscar...">
                                      
                                    </div>

                                </div>

                                <label for="codigo" class="col-sm-1 control-label">Aseguradora:</label>
                                <div class="col-sm-3">
                                <input readonly type="text" maxlength="100" class="let form-control" name="txtnomaseg" id="txtnomaseg" placeholder="" />
                                        
                                </div>
                                <label for="codigo" class="col-sm-1 control-label">Asegurado:</label>
                                <div class="col-sm-3">
                                <input readonly type="text" maxlength="100" class="let form-control" name="txtaseg" id="txtaseg" placeholder="" />
                                        
                                </div>
                            

                                
                            </div>

                        <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="left">2) DATOS DEL SINIESTRO</p></label>
                            </div>
                            
                             
                            <div class="form-group">
                                <label for="codigo" class="col-sm-1 control-label">Código:</label>
                                <div class="col-sm-2">
                                <input type="text" maxlength="100" class="form-control" name="codigo" id="codigo" placeholder="" />
                                    
                                </div>

                                
                                <label for="descripcion" class="col-sm-1 control-label">Descripción:</label>
                                <div class="col-sm-2">
	                                <textarea maxlength="150" name="descripcion" id="descripcion" class="form-control" rows="3"></textarea>
						         </div>
                                  <label for="hora" class="col-sm-1 control-label">Hora:</label>
                                <div class="col-sm-2">
	                               <input style="cursor:pointer;" readonly type="text" maxlength="100" class="form-control" name="hora" id="hora" placeholder="" />

                                   <input hidden name="hra" id="hra" placeholder="" />
						         </div>
                                 <label for="fecha" class="col-sm-1 control-label">Fecha:</label>
                                <div class="col-sm-2">
	                               <input type="date" class="form-control" name="fecha" id="fecha" placeholder="" />
						         </div>
                                

						         

                                
                            </div>

                            <div class="form-group">

                            <label for="lugar" class="col-sm-1 control-label">Lugar:</label>
                                <div class="col-sm-2">
                                <input type="text" maxlength="100" class="form-control" name="lugar" id="lugar" placeholder="" />
                                    
                                </div>

                                
                            </div>

                            <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="left">3) FOTOS</p></label>
                            </div>
                            
                             
                            <div class="form-group">                          
                               
                               
                                <div class="col-sm-6" align="left">

                                
                                        <input id="file" type="file" name="file[]" multiple="multiple"  class="filestyle" data-buttonName="btn-primary" accept="image/*">
                                   
                                </div> 

                                 
                            </div>

                            <div class="form-group">
                                <div class="col-sm-12" align="center">
                                    <div id="vista-previa" ></div>
                                </div>
                            </div>

                            <div class="form-group">
                                &nbsp;
                            </div>


                            <input hidden name="ids" id="ids" value="" />

                            <div class="form-group" align="center">
                                <label><a class="sin_agredi btn btn-success">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Guardar&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></label>-<label><a id="sin_vlv_list" class="btn btn-danger">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Volver&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></label>
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


<?php
$qr_psa=mysql_query("SELECT ps.id,ps.n_solicitud,asg.nombre as nomaseg,cli.nombre_rs as aseg FROM poliza_vehiculo ps INNER JOIN cliente cli ON ps.id_asegurado=cli.id INNER JOIN aseguradora asg ON ps.id_aseguradora=asg.id");

?>
<!-- Modal N° 1 -->
<div  data-nmod="1" class="modal fade" id="myModal" tabindex="-1" width="750" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog" align="left" style="width:800px;">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Buscar Póliza</h4>
      </div>
      <div class="modal-body">
        <div class="container">

                        <form role="form" class="form-horizontal" id="">
                            <div class="form-group" align="center" style="width:750px;">

                                <table id="example" class="table table-striped table-bordered" align="right" cellspacing="0" width="100%" >
                                    <thead>
                                        <tr>
                                            
                                            <th width="250">N° Solicitud</th>
                                            <th width="250">Aseguradora</th>
                                            <th width="230">Asegurado</th>
                                            <th width="20">Elegir</th>
                                        </tr>
                                    </thead>
                                    
                                    <tbody>
                                    <?php 
                                      
                                        while($psa=mysql_fetch_array($qr_psa)){

                                      ?>
                                        <tr>
                                            <td><? echo $psa["n_solicitud"];?></td>
                                            <td><? echo $psa["nomaseg"];?></td>
                                            <td><? echo $psa["aseg"];?></td>
                                            <td align="center"><button title="Detalles" type="button" data-id="<? echo $psa["id"]; ?>" class="sin_buspol btn btn-default"><span class="glyphicon glyphicon-hand-up"></span></button></td>
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

