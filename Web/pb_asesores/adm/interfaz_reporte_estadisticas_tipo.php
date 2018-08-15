<? 
session_start();
require("conectar.php");
date_default_timezone_set('America/Caracas');
?>
 <link rel="stylesheet" href="css/datepicker.css">
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

 <script type="text/javascript" src="js/validacion.js"></script>
<script type='text/javascript' language='javascript' src='js/reporteEstadisticasTipo.js'></script>
<?php


?>
<div class="panel panel-primary">
  <div class="panel-heading">
    <h2 class="panel-title"><span align="right" class="glyphicon glyphicon-print"></span><b>&nbsp;&nbsp;ESTADISTICAS DE SINIESTROS</b></h2>
  </div>
  <div class="panel-body">
    <div class="container">
                        <form role="form" class="frmpss form-horizontal">               
                                 <div class="form-group" >  
                                <label for="fdes" class="col-sm-1 control-label">Tipo:</label>
                                <div class="col-sm-2">
                                <select name="datepicker" id="datepicker" class="form-control">                                	
					                <option value="LEVE">LEVE</option>
					                <option value="MODERADO">MODERADO</option>
					                <option value="GRAVE">GRAVE</option>  
                                                                      
					            </select>
                                </div>
                                <label for="fhas" class="col-sm-1 control-label">Periodo:</label>
                                <div class="col-sm-2">
                                 <select name="tp" id="tp" class="form-control">                                	
					                <option value="MENSUAL">MENSUAL</option>
					                <option value="TRIMESTRAL">TRIMESTRAL</option>
					                <option value="SEMESTRAL">SEMESTRAL</option>  
                                    <option value="ANUAL">ANUAL</option>                                     
					            </select>
                                 </div>   
                                  <label for="fdes" class="col-sm-1 control-label">Año:</label>
                                <div class="col-sm-2">
                                <input type="text" class="form-control" id="aaa" placeholder="" required onkeyup="mascara(this,'',patron,true)">
                                </div>
                                <div class="col-sm-2">
                                <label><a data-opc="agregar" id="imprimir1" class="btn btn-success">Mostrar</a></label>
                            </div>

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









