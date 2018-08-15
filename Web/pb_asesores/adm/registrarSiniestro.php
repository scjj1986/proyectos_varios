<? 
session_start();
require("conectar.php");



$dir="../Android/FotoSiniestros/";

   ?>






<script type='text/javascript' language='javascript' src='js/Siniestro.js'></script>


<div class="panel panel-primary">
  <div class="panel-heading">
    <h2 class="panel-title"><span align="right" class="glyphicon glyphicon-pencil"></span><b>&nbsp;&nbsp;NUEVO SINIESTRO</b></h2>
  </div>
  <div class="panel-body">
    <div class="container">

                        <form role="form"   class="frmasg1 form-horizontal">

                        <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="center">1) DATOS DEL CLIENTE</p></label>
                                <input type="hidden" maxlength="15" class="form-control" name="idcli" id="idcli" placeholder="" />
                            </div>
                                

                            <div class="form-group">




                                <label for="" class="col-sm-2 control-label">Buscar Cliente:</label>
                                <div class="col-sm-6">
                                    <div class="input-group">
                                        <span class="input-group-btn">
                                            <button id="bsccli" class="btn btn-primary glyphicon glyphicon-search" type="button"></button>
                                      </span>
                                      <input disabled type="text" id="txtcli" class="form-control" placeholder="Buscar...">
                                      
                                    </div>
                                </div>
                            

                                
                            </div>

                        <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="center">2) DATOS DEL SINIESTRO</p></label>
                            </div>
                            
                             
                            <div class="form-group">
                                <label for="codigo" class="col-sm-1 control-label">Código:</label>
                                <div class="col-sm-2">
                                <input value="<? echo $asg['codigo']; ?>" type="text" maxlength="100" class="let form-control" name="codigo" id="codigo" placeholder="" />
                                    
                                </div>

                                
                                <label for="descripcion" class="col-sm-1 control-label">Descripción:</label>
                                <div class="col-sm-2">
	                                <textarea maxlength="150" name="decripcion" id="descripcion" class="form-control" rows="3"><? echo $asg['descripcion']; ?></textarea>
						         </div>
                                  <label for="hora" class="col-sm-1 control-label">Hora:</label>
                                <div class="col-sm-2">
	                               <input value="<? echo $asg['hora']; ?>" type="text" maxlength="100" class="let form-control" name="hora" id="hora" placeholder="" />
						         </div>
                                 <label for="fecha" class="col-sm-1 control-label">Fecha:</label>
                                <div class="col-sm-2">
	                               <input value="<? echo $asg['fecha']; ?>" type="date" class="let form-control" name="fecha" id="fecha" placeholder="" />
						         </div>
                                

						         

                                
                            </div>

                            <div class="form-group">
                                <label for="status" class="col-sm-1 control-label">Estatus:</label>
                                <div class="col-sm-2">
                                    <select name="status" id="status" class="form-control">
                                        <option value="<? echo $asg['status']; ?>"><? echo $asg["status"]; ?></option>
                                        <option value="APROBADA">APROBADA</option>
                                        <option value="RECHAZADA">RECHAZADA</option>
                                        <option value="EN PROCESO">EN PROCESO</option>
                                        <option value="ENVIADA">ENVIADA</option>
                                    </select>
                                 </div>
                            </div>

                            <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="center">3) FOTOS</p></label>
                            </div>
                            
                             
                            <div class="form-group">                          
                               
                               
                                <div class="col-sm-4" align="center">
                                  <input id="file" type="file" name="file[]" multiple="multiple" >
        						
                                   
                                </div>
                                 <div id="vista-previa" ></div>
 							 <div id="respuesta"></div>
<?php

if (isset($_FILES["file"]))
{
   $reporte = null;
     for($x=0; $x<count($_FILES["file"]["name"]); $x++)
    {
    $file = $_FILES["file"];
    $nombre = $file["name"][$x];
    $tipo = $file["type"][$x];
    $ruta_provisional = $file["tmp_name"][$x];
    $size = $file["size"][$x];
    $dimensiones = getimagesize($ruta_provisional);
    $width = $dimensiones[0];
    $height = $dimensiones[1];
    $carpeta = "imagenes/";
    
    if ($tipo != 'image/jpeg' && $tipo != 'image/jpg' && $tipo != 'image/png' && $tipo != 'image/gif')
    {
        $reporte .= "<p style='color: red'>Error $nombre, el archivo no es una imagen.</p>";
    }
    else if($size > 1024*1024)
    {
        $reporte .= "<p style='color: red'>Error $nombre, el tamaño máximo permitido es 1mb</p>";
    }
    else if($width > 500 || $height > 500)
    {
        $reporte .= "<p style='color: red'>Error $nombre, la anchura y la altura máxima permitida es de 500px</p>";
    }
    else if($width < 60 || $height < 60)
    {
        $reporte .= "<p style='color: red'>Error $nombre, la anchura y la altura mínima permitida es de 60px</p>";
    }
    else
    {
        $src = $carpeta.$nombre;
        move_uploaded_file($ruta_provisional, $src);
        echo "<p style='color: blue'>La imagen $nombre ha sido subida con éxito</p>";
    }
    }
        echo $reporte;
}
                               
           ?>                 </div>

                                <div class="form-group">
                                &nbsp;
                            </div>


                            <input hidden name="idasg" id="idasg" value="<? echo $idasg; ?>" />

                            <div class="form-group" align="center">
                                <label><a data-opc="editar" class="asg_agredi1 btn btn-success">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Guardar&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></label>-<label><a id="asg_vlv_list" class="btn btn-danger">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Volver&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></label>
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
$qr_cli=mysql_query("SELECT cli.id,cli.tipo_persona,cli.ced_rif,cli.nombre_rs FROM cliente cli");

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
                                            <td align="center"><button title="Detalles" type="button" data-id="<? echo $cli["id"]; ?>" class="sin_buscli btn btn-default"><span class="glyphicon glyphicon-hand-up"></span></button></td>
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

