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
session_start();
require("conectar.php");
$qr_cli=mysql_query("SELECT cli.id,cli.tipo_persona,cli.ced_rif,cli.nombre_rs,edo.nombre as edo,mun.nombre as mun,par.nombre as par FROM cliente cli INNER JOIN estado edo ON cli.id_edo=edo.id INNER JOIN municipio mun ON cli.id_mun=mun.id INNER JOIN parroquia par ON cli.id_par=par.id");

?>

<div class="panel panel-primary">
  <div class="panel-heading">
    <h3 class="panel-title"><span align="right" class="glyphicon glyphicon-list"></span><b>&nbsp;&nbsp;CLIENTES</b></h3>
  </div>
  <div class="panel-body">
    <div class="container">

                        <form role="form" class="form-horizontal">
                            <div class="form-group">
                                <table id="example" class="table table-striped table-bordered" align="right" cellspacing="0" width="100%">
                                    <thead>
                                        <tr>
                                            
                                            <th>Céd/Pas./R.I.F.</th>
                                            <th>Nombre/Razón Social</th>
                                            <th>Estado</th>
                                            <th>Municipio</th>
                                            <th>Parroquia</th>
                                            <th>Opciones</th>
                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                            
                                            <th>Céd/Pas./R.I.F.</th>
                                            <th>Nombre/Razón Social</th>
                                            <th>Estado</th>
                                            <th>Municipio</th>
                                            <th>Parroquia</th>
                                            <th>Opciones</th>
                                        </tr>
                                    </tfoot>
                                    <tbody>
                                    <?php 
                                      
                                        while($cli=mysql_fetch_array($qr_cli)){

                                      ?>
                                        <tr>
                                            <td><? echo $cli["tipo_persona"]."-".$cli["ced_rif"];?></td>
                                            <td><? echo $cli["nombre_rs"];?></td>
                                            <td><? echo $cli["edo"];?></td>
                                            <td><? echo $cli["mun"];?></td>
                                            <td><? echo $cli["par"];?></td>
                                            <td align="center"><button title="Detalles" type="button" data-id="<? echo $cli["id"]; ?>" class="cli_det btn btn-default"><span class="glyphicon glyphicon-file"></span></button> - <button title="Editar" type="button" data-id="<? echo $cli["id"]; ?>" class="cli_edi btn btn-warning"><span class="glyphicon glyphicon-pencil"></span></button></td>
                                        </tr>
                                        <?php 
                                      
                                        }

                                      ?>
                                        
                                    </tbody>
                                </table>
                            </div>
                            <div class="form-group" align="center">
                                <label><a id="cli_agr" class=" btn btn-success">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Agregar&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></label>
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

