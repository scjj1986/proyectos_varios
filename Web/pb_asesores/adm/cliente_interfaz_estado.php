<?php 
session_start();
require("conectar.php");
$idcli=$_GET["id"];
$cli=mysql_query("select * from cliente where id='$idcli'");
$rr=mysql_fetch_array($cli);

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

<script type='text/javascript' language='javascript' src='js/cliente.js'></script>
<?php

$qr_cli=mysql_query("SELECT pv.n_solicitud,pv.tipoP,f.numero,f.fecha,f.monto,f.status from poliza_vehiculo pv inner join financiamiento f on f.id_poliza=pv.id where f.id_cliente='$idcli'");

?>

<div class="panel panel-primary">
  <div class="panel-heading">
    <h3 class="panel-title"><span align="right" class="glyphicon glyphicon-list"></span><b>&nbsp;&nbsp;ESTADO DE CUENTA CLIENTE <?php echo $rr["tipo_persona"]." ".$rr["ced_rif"]." ".$rr['nombre_rs'] ?></b></h3>
  </div>
  <div class="panel-body">
    <div class="container">

                        <form role="form" class="form-horizontal">
                            <div class="form-group">
                                <table id="example" class="table table-striped table-bordered" align="right" cellspacing="0" width="100%">
                                    <thead>
                                        <tr>
                                            
                                            <th>N° póliza</th>
                                            <th>Tipo</th>
                                            <th>N° cuota</th>
                                            <th>Fecha Vencimiento</th>
                                            <th>Monto Bs.</th>
                                            <th>Estatus</th>
                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                            
                                            <th>N° póliza</th>
                                            <th>Tipo</th>
                                            <th>N° cuota</th>
                                            <th>Fecha Vencimiento</th>
                                            <th>Monto Bs.</th>
                                            <th>Estatus</th>
                                        </tr>
                                    </tfoot>
                                    <tbody>
                                    <?php 
                                      
                                        while($cli=mysql_fetch_array($qr_cli)){

                                      ?>
                                        <tr>
                                            <td><? echo $cli["n_solicitud"]?></td>
                                            <td><? echo $cli["tipoP"];?></td>
                                            <td><? echo $cli["numero"];?></td>
                                            <td><? echo $cli["fecha"];?></td>
                                            <td><? echo $cli["monto"];?></td>
                                            <td ><? echo $cli["status"];?></td>
                                        </tr>
                                        <?php 
                                      
                                        }

                                      ?>
                                        
                                    </tbody>
                                </table>
                            </div>
                           
                            <div class="form-group">
                                &nbsp;
                            </div>
                            <div class="form-group">
                                &nbsp;
                            </div>
                                    
                        </form>

                    </div>
  </div>
  <div class="panel-heading">
    <h3 class="panel-title"><b>SISTEMA PB ASESORES </b></h3>
  </div>
</div>

