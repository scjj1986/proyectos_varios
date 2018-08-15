<?php
session_start();
require("conectar.php");
$qr_fac=mysql_query("SELECT fc.id,fc.numero,cl.tipo_persona,cl.ced_rif,cl.nombre_rs, fc.fecha,fc.monto,fc.status,fc.nombre_rs as nomrs,fc.ced_rif as cedrif FROM facturas fc inner join cliente cl on fc.id_cliente=cl.id 
order by fecha desc");

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
    <h3 class="panel-title"><span align="right" class="glyphicon glyphicon-list"></span><b>&nbsp;&nbsp;FACTURAS PARA REEMBOLSO</b></h3>
  </div>
  <div class="panel-body">
    <div class="container">

                        <form role="form" class="form-horizontal">
                            <div class="form-group">
                                <table id="example" class="table table-striped table-bordered" align="right" cellspacing="0" width="100%">
                                    <thead>
                                        <tr>
                                            
                                            <th>N° Factura</th>
                                            <th>Fecha</th>
                                            <th>Nombre/Razón Social</th>
                                            <th>Cliente</th>
                                            <th>Monto Bs.</th>                                           
                                            <th>Estatus</th>                                            
                                            <th>Opciones</th>
                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                            <th>N° Factura</th>
                                            <th>Fecha</th>
                                            <th>Nombre/Razón Social</th>
                                            <th>Cliente</th>
                                            <th>Monto Bs.</th>                                           
                                            <th>Estatus</th>                                            
                                            <th>Opciones</th>
                                        </tr>
                                    </tfoot>
                                    <tbody>
                                    <?php 
                                      
                                        while($fac=mysql_fetch_array($qr_fac)){

                                      ?>
                                        <tr>
                                            <td><? echo $fac["numero"];?></td>
                                            <td><? echo $fac["fecha"];?></td>
                                            <td><? echo $fac["cedrif"]."; ".$fac["nomrs"];?></td>
                                            <td><? echo $fac["tipo_persona"]."-".$fac["ced_rif"]."; ".$fac["nombre_rs"];?></td>
                                             <td><?echo $fac["monto"];?></td>                                         
                                            <td><? echo $fac["status"];?></td>                                           
                                            <td><button title="Editar" type="button" data-id="<? echo $fac["id"]; ?>" class="fac_edi btn btn-warning"><span class="glyphicon glyphicon-pencil"></span></button></td>
                                        </tr>
                                        <?php 
                                      
                                        }

                                      ?>
                                        
                                    </tbody>
                                </table>
                            </div>
                            <div class="form-group" align="center">
                                <label><a id="fac_agr" class=" btn btn-success">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Agregar&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></label>
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

