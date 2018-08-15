<?php
session_start();
require("conectar.php");
$qr_pss=mysql_query("SELECT ps.id,ps.n_solicitud,asg.nombre as nomaseg,ps.fecha,cli.nombre_rs as tomador FROM poliza_salud ps INNER JOIN cliente cli ON ps.id_asegurado=cli.id INNER JOIN aseguradora asg ON ps.id_aseguradora=asg.id");

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
<?php
session_start();
require("conectar.php");
$qr_pss=mysql_query("SELECT ps.id,ps.n_solicitud,asg.nombre as nomaseg,ps.fecha,cli.nombre_rs as tomador FROM poliza_salud ps INNER JOIN cliente cli ON ps.id_asegurado=cli.id INNER JOIN aseguradora asg ON ps.id_aseguradora=asg.id");

?>

<div class="panel panel-primary">
  <div class="panel-heading">
    <h3 class="panel-title"><span align="right" class="glyphicon glyphicon-list"></span><b>&nbsp;&nbsp;SOLICITUD DE SEGURO DE SALUD</b></h3>
  </div>
  <div class="panel-body">
    <div class="container">

                        <form role="form" class="form-horizontal">
                            <div class="form-group">
                                <table id="example" class="table table-striped table-bordered" align="right" cellspacing="0" width="100%">
                                    <thead>
                                        <tr>
                                            
                                            
                                            <th>Fecha</th>
                                            <th>N° Solicitud</th>
                                            <th>Aseguradora</th>
                                            <th>Asegurado</th>
                                            <th>Opciones</th>
                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                            <th>Fecha</th>
                                            <th>N° Solicitud</th>
                                            <th>Aseguradora</th>
                                            <th>Asegurado</th>
                                            <th>Opciones</th>
                                        </tr>
                                    </tfoot>
                                    <tbody>
                                    <?php 
                                      
                                        while($pss=mysql_fetch_array($qr_pss)){

                                      ?>
                                        <tr>
                                            
                                            <td><? echo $pss["fecha"];?></td>
                                            <td><? echo $pss["n_solicitud"];?></td>
                                            <td><? echo $pss["nomaseg"];?></td>
                                            <td><? echo $pss["tomador"];?></td>
                                            <td align="center"><button disabled title="Detalles" type="button" data-id="<? echo $pss["id"]; ?>" class="pss_det btn btn-default"><span class="glyphicon glyphicon-file"></span></button> - <button title="Editar" type="button" data-id="<? echo $pss["id"]; ?>" class="pss_edi btn btn-warning"><span class="glyphicon glyphicon-pencil"></span></button></td>
                                        </tr>
                                        <?php 
                                      
                                        }

                                      ?>
                                        
                                    </tbody>
                                </table>
                            </div>
                            <div class="form-group" align="center">
                                <label><a id="pss_agr" class=" btn btn-success">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Agregar&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></label>
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
    <h3 class="panel-title"><b>SISTEMA DE ASESORES DE SEGUROS P.B. </b></h3>
  </div>
</div>

