<?php
session_start();
require("conectar.php");
$qr_asg=mysql_query("SELECT asg.id, asg.nombre, asg.direccion, asg.activo, pc.nombre as nompc, pc.apellido as apepc FROM aseguradora asg INNER JOIN persona_contacto pc ON asg.idpc=pc.id");

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

<script type='text/javascript' language='javascript' src='js/aseguradora.js'></script>

<div class="panel panel-primary">
  <div class="panel-heading">
    <h3 class="panel-title"><span align="right" class="glyphicon glyphicon-list"></span><b>&nbsp;&nbsp;ASEGURADORAS</b></h3>
  </div>
  <div class="panel-body">
    <div class="container">

                        <form role="form" class="form-horizontal">
                            <div class="form-group">
                                <table id="example" class="table table-striped table-bordered" align="right" cellspacing="0" width="100%">
                                    <thead>
                                        <tr>
                                            
                                            <th>Nombre</th>
                                            <th>Dirección</th>
                                            <th>Persona Contacto</th>
                                            <th>Activo</th>
                                            <th>Opciones</th>
                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                            <th>Nombre</th>
                                            <th>Dirección</th>
                                            <th>Persona Contacto</th>
                                            <th>Activo</th>
                                            <th>Opciones</th>
                                        </tr>
                                    </tfoot>
                                    <tbody>
                                    <?php 
                                      
                                        while($asg=mysql_fetch_array($qr_asg)){

                                      ?>
                                        <tr>
                                            <td><? echo $asg["nombre"];?></td>
                                            <td><? echo $asg["direccion"];?></td>
                                            <td><? echo $asg["nompc"]." ".$asg["apepc"];?></td>
                                            <td><? echo $asg["activo"];?></td>
                                            <td><button title="Editar" type="button" data-id="<? echo $asg["id"]; ?>" class="asg_edi btn btn-warning"><span class="glyphicon glyphicon-pencil"></span></button></td>
                                        </tr>
                                        <?php 
                                      
                                        }

                                      ?>
                                        
                                    </tbody>
                                </table>
                            </div>
                            <div class="form-group" align="center">
                                <label><a id="asg_agr" class=" btn btn-success">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Agregar&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></label>
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

