<? 
session_start();
require("conectar.php");
date_default_timezone_set('America/Caracas');
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



<?php

$qr_cli=mysql_query("SELECT cli.ced_rif,cli.nombre_rs,a.nombre,pv.n_solicitud,pv.fecha_desde,pv.fecha_hasta,pv.status,pv.tipoP FROM cliente cli INNER JOIN poliza_vehiculo pv  ON pv.id_asegurado=cli.id INNER JOIN aseguradora a  ON pv.id_aseguradora=a.id union SELECT cli.ced_rif,cli.nombre_rs,a.nombre,ps.n_solicitud,ps.fecha_desde,ps.fecha_hasta,ps.status,ps.tipoP FROM cliente cli INNER JOIN poliza_salud ps  ON ps.id_asegurado=cli.id INNER JOIN aseguradora a  ON ps.id_aseguradora=a.id");

?>

<script type='text/javascript' language='javascript' src='js/reportePoliza.js'></script>


<div class="panel panel-primary">
  <div class="panel-heading">
    <h2 class="panel-title"><span align="right" class="glyphicon glyphicon-print"></span><b>&nbsp;&nbsp;REPORTE DE PÓLIZAS</b></h2>
  </div>
  <div class="panel-body">
    <div class="container">

                        <form role="form" class="frmpss form-horizontal">

                                  

                        <div class="form-group" >

                           
                                <label for="idasg" class="col-sm-1 control-label">Estatus:</label>
                                <div class="col-sm-4">
                                <select name="idasg" id="idasg" class="form-control">
                                <option value="-1">Seleccione...</option>
                               
                                <option value="AL DIA">AL DIA</option>
                                <option value="MOROSA">MOROSA</option>
                                <option value="VENCIDA">VENCIDA</option>
                              
                                </select>
                                 </div>
                                <label for="fdes" class="col-sm-1 control-label">Desde:</label>
                                <div class="col-sm-2">
                                <input type="date" maxlength="15" class="form-control" name="fdes" id="fdes" placeholder="" />
                                </div>
                                <label for="fhas" class="col-sm-1 control-label">Hasta:</label>
                                <div class="col-sm-2">
                                <input type="date" maxlength="15" class="form-control" name="fhas" id="fhas" placeholder="" />
                                 </div>   
                                  <input type="hidden" name="hora"  id="hora" value=""/>    

                     </div>

                          

                            <div class="form-group" align="center">
                                <label><a data-opc="agregar" id="im" class="btn btn-success">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Imprimir&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></label>
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









