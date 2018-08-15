<?php
session_start();
require("conectar.php");
$qr_sin=mysql_query("SELECT sn.id,sn.fecha,sn.codigo,pv.n_solicitud as nsol, cli.nombre_rs as nomaseg, sn.descripcion,sn.status FROM siniestro sn inner join poliza_vehiculo pv on sn.id_poliza=pv.id inner join cliente cli on pv.id_asegurado=cli.id 
order by sn.fecha desc");

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

<script type='text/javascript' language='javascript' src='js/siniestro.js'></script>


<div class="panel panel-primary">
  <div class="panel-heading">
    <h3 class="panel-title"><span align="right" class="glyphicon glyphicon-list"></span><b>&nbsp;&nbsp;SINIESTROS</b></h3>
  </div>
  <div class="panel-body">
    <div class="container">

                        <form role="form" class="form-horizontal">
                            <div class="form-group">
                                <table id="example" class="table table-striped table-bordered" align="right" cellspacing="0" width="100%">
                                    <thead>
                                        <tr>
                                            
                                            <th>Fecha</th>
                                            <th>Código</th>
                                            <th>N° Póliza</th>
                                            <th>Asegurado</th>
                                            <th>Descripción</th>                            
                                            <th>Estatus</th>                                            
                                            <th>Opciones</th>
                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                             <th>Fecha</th>
                                            <th>Código</th>
                                            <th>N° Póliza</th>
                                            <th>Asegurado</th>
                                            <th>Descripción</th>                            
                                            <th>Estatus</th>                                            
                                            <th>Opciones</th>
                                        </tr>
                                    </tfoot>
                                    <tbody>
                                    <?php 
                                      
                                        while($sin=mysql_fetch_array($qr_sin)){

                                      ?>
                                        <tr>
                                            <td><? echo $sin["fecha"];?></td>
                                            <td><? echo $sin["codigo"];?></td>
                                            <td><? echo $sin["nsol"];?></td>
                                            <td><? echo $sin["nomaseg"];?></td>
                                            <td><? echo $sin["descripcion"];?></td>                                         
                                            <td><? echo $sin["status"];?></td>                                           
                                            <td><button title="Editar" type="button" data-id="<? echo $sin["id"]; ?>" class="sin_edi btn btn-warning"><span class="glyphicon glyphicon-pencil"></span></button></td>
                                        </tr>
                                        <?php 
                                      
                                        }

                                      ?>
                                        
                                    </tbody>
                                </table>
                            </div>
                            <div class="form-group" align="center">
                                <label><a id="sin_agr" class=" btn btn-success">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Agregar&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></label>
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
    <h3 class="panel-title"><b>SISTEMA pb ASESORES, C.A. </b></h3>
  </div>
</div>

