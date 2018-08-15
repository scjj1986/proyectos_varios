<? 
session_start();
require("conectar.php");
date_default_timezone_set('America/Caracas');

?>

<script type="text/javascript">
       // $(document).ready(function () {
            $('#example1').DataTable({
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


<script type='text/javascript' language='javascript' src='js/reporteSiniestro1.js'></script>




<div class="panel panel-primary">
  <div class="panel-heading">
    <h2 class="panel-title"><span align="right" class="glyphicon glyphicon-print"></span><b>&nbsp;&nbsp;REPORTE DE SINIESTROS</b></h2>
  </div>
  <div class="panel-body">
    <div class="container">

                        <form role="form" class="frmps4 form-horizontal" >
                            <label for="idasg" class="col-sm-2 control-label">Aseguradora:</label>
                                <div class="col-sm-4">
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
                                <label for="idasg" class="col-sm-2 control-label">Asegurado:</label>
                                <div class="col-sm-4">
                                <select name="idasg1" id="idasg1" class="form-control">
                                <option value="-1">Seleccione...</option>
                                <?
                                    $qr_asg=mysql_query("SELECT * FROM cliente inner join poliza_vehiculo on cliente.id=poliza_vehiculo.id_asegurado order by cliente.nombre_rs");
                                    while ($asg=mysql_fetch_array($qr_asg)){ 
                                ?>
                                <option value="<? echo $asg['id']; ?>"><? echo $asg['nombre_rs']; ?></option>
                                <? 

                                }
                                ?>
                                </select>
                                
                                <input type="hidden" name="hora"  id="hora" value=""/>
                                </div>
                                
                                  

                       

                           
                                 <label for="fdes" class="col-sm-2 control-label">Desde:</label>
                                <div class="col-sm-2">
                                <input type="date" maxlength="15" class="form-control" name="fdes" id="fdes" placeholder="" />
                                </div>
                                <label for="fhas" class="col-sm-4 control-label">Hasta:</label>
                                <div class="col-sm-2">
                                <input type="date" maxlength="15" class="form-control" name="fhas" id="fhas" placeholder="" />
                                 </div>   
                         

                            <div class="form-group" align="center">
                                <label><a data-opc="agregar" id="im" class="btn btn-success">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Imprimir&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></label>
                            </div>
                            <div class="form-group">
                                &nbsp;
                            </div>
                                     
                        </form>

                    </div>

  </div>
  <div class="panel-heading">
    <h3 class="panel-title"><b>SISTEMA pb ASESORES, C.A.</b></h3>
  </div>
</div>









