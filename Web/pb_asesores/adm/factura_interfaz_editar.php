<?
session_start();
require("conectar.php");

$idf=$_GET["id"];
$qr_fac=mysql_query("select * FROM facturas  where id=$idf");
$fac= mysql_fetch_array($qr_fac);

$idc=$fac["id_cliente"];
$qr_cli=mysql_query("select * FROM cliente  where id=$idc");
$cli= mysql_fetch_array($qr_cli);


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
<script type='text/javascript' language='javascript' src='js/factura.js'></script>

<div class="panel panel-primary">
  <div class="panel-heading">
    <h2 class="panel-title"><span align="right" class="glyphicon glyphicon-pencil"></span><b>&nbsp;&nbsp;EDITAR FACTURA</b></h2>
  </div>
  <div class="panel-body">
    <div class="container">

                        <form role="form"   class="frmsin form-horizontal">

                        <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="left">1) DATOS DEL CLIENTE</p></label>
                                <input value="<? echo $cli['id']; ?>" type="hidden" maxlength="15" class="frm form-control" name="idcli" id="idcli" placeholder="" />
                            </div>
                                

                            <div class="form-group">

                                <label for="codigo" class="col-sm-2 control-label">Buscar Cliente:</label>
                                <div class="col-sm-6">
                                    <div class="input-group">
                                        <span class="input-group-btn">
                                            <button id="bsccli" class="btn btn-primary glyphicon glyphicon-search" type="button"></button>
                                      </span>
                                      <input disabled value="<? echo $cli['tipo_persona'].'-'.$cli['ced_rif'].', '.$cli['nombre_rs'];?>" type="text" id="txtcli" class="form-control" placeholder="Buscar...">
                                      
                                    </div>

                                </div>

                                
                            </div>

                        <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="left">2) DATOS DE LA FACTURA</p></label>
                            </div>
                            
                             
                            <div class="form-group">

                            	<label for="fecha" class="col-sm-1 control-label">Fecha:</label>
                                <div class="col-sm-2">
	                               <input value="<? echo $fac['fecha']?>" type="date" class="frm form-control" name="fecha" id="fecha" placeholder="" />
						         </div>


                                <label for="codigo" class="col-sm-1 control-label">Número:</label>
                                <div class="col-sm-2">
                                <input type="text" value="<? echo $fac['numero']?>" maxlength="20" class="frm form-control" name="nr" id="nr" placeholder="" />
                                    
                                </div>

                                <label class="col-sm-2 control-label">Céd./R.I.F./Pas.:</label>
                                <div class="col-sm-2">
                                <input type="text" value="<? echo $fac['ced_rif']?>" maxlength="20" class="frm form-control" name="cedrif" id="cedrif" placeholder="" />
                                    
                                </div>

                                
                                
                                
                            </div>

                            <div class="form-group">

                                <label class="col-sm-2 control-label">Nombre/Razón Social:</label>
                                <div class="col-sm-2">
                                <input type="text" value="<? echo $fac['nombre_rs']?>" maxlength="60" class="frm form-control" name="nomrs" id="nomrs" placeholder="" />
                                    
                                </div>

                                <label for="lugar" class="col-sm-1 control-label">Monto:</label>
                                <div class="col-sm-2">
                                <input type="text" value="<? echo $fac['monto']?>" maxlength="40" class="frm form-control" name="monto" id="monto" placeholder="" />
                                    
                                </div>

                                <label for="status" class="col-sm-1 control-label">Estatus:</label>
                                <div class="col-sm-2">
                                    <select name="status" id="status" class="frm form-control">
                                        <option value="<? echo $fac['status']?>"><? echo $fac['status']?></option>
                                        <option value="APROBADA">APROBADA</option>
                                        <option value="RECHAZADA">RECHAZADA</option>
                                        <option value="EN PROCESO">EN PROCESO</option>
                                        <option value="ENVIADA">ENVIADA</option>
                                    </select>
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
                                    <div id="vista-previa" >
                                    <img src="data:image/jpg;base64,<? echo base64_encode($fac['imagen']); ?>" width="300" height="300"  />

                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                &nbsp;
                            </div>


                            <input hidden class="frm" name="idf" id="idf" value="<? echo $idf; ?>" />

                            <div class="form-group" align="center">
                                <label><a class="fac_agredi btn btn-success">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Guardar&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></label>-<label><a id="fac_vlv_list" class="btn btn-danger">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Volver&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></label>
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
$qr_cli=mysql_query("SELECT cli.id,cli.tipo_persona,cli.ced_rif,cli.nombre_rs FROM cliente cli, poliza_salud, poliza_vehiculo WHERE cli.id = poliza_salud.id_asegurado OR cli.id = poliza_vehiculo.id_asegurado group by cli.id,cli.tipo_persona,cli.ced_rif,cli.nombre_rs");

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
                                            <td align="center"><button title="Detalles" type="button" data-id="<? echo $cli["id"]; ?>" class="fac_buscli btn btn-default"><span class="glyphicon glyphicon-hand-up"></span></button></td>
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