




<script type='text/javascript' language='javascript' src='js/aseguradora.js'></script>


<div class="panel panel-primary">
  <div class="panel-heading">
    <h2 class="panel-title"><span align="right" class="glyphicon glyphicon-plus-sign"></span><b>&nbsp;&nbsp;AGREGAR ASEGURADORA</b></h2>
  </div>
  <div class="panel-body">
    <div class="container">

                        <form role="form" class="frmasg form-horizontal">

                        <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="center">1) DATOS DE LA ASEGURADORA</p></label>
                            </div>
                            
                             
                            <div class="form-group">
                            <label for="nombre" class="col-sm-1 control-label">Nombre:</label>
                                <div class="col-sm-5">
                                <input type="text" maxlength="100" class="form-control" name="nombre" id="nombre" placeholder="" />
                                    
                                </div>

                                
                                <label for="direccion" class="col-sm-1 control-label">Dirección:</label>
                                <div class="col-sm-5">
	                                <textarea maxlength="150" name="direccion" id="direccion" class="form-control" rows="3"></textarea>
						         </div>

                                
                            </div>

                            <div class="form-group">
                                <label align="center" class="col-sm-12 control-label"><p align="center">2) DATOS DE LA PERSONA CONTACTO</p></label>
                            </div>
                            
                             
                            <div class="form-group">
                                <label for="tppc" class="col-sm-2 control-label">Tipo Persona:</label>
                                <div class="col-sm-1">
                                <select name="tppc" id="tppc" class="form-control">
					                <option value="V">V</option>
					                <option value="E">E</option>
					                <option value="J">J</option>
					            </select>
                                    
                                </div>
                                <label for="docpc" class="col-sm-1 control-label">Céd/Pas./RIF:</label>
                                <div class="col-sm-2">
                                <input type="text" maxlength="15" class="form-control" name="docpc" id="docpc" placeholder="" />
                                    
                                </div>

                                <label for="nombre" class="col-sm-1 control-label">Nombre:</label>
                                <div class="col-sm-5">
                                <input type="text" maxlength="50" class="let form-control" name="nompc" id="nompc" placeholder="" />
                                    
                                </div>
                            </div>



                            <div class="form-group">
                                <label for="apepc" class="col-sm-2 control-label">Apellido:</label>
                                <div class="col-sm-4 has-warning">
                                <input type="text" class="let form-control" maxlength="50" name="apepc" id="apepc" placeholder="" />
                                </div>

                                <label for="dirpc" class="col-sm-1 control-label">Dirección:</label>
                                <div class="col-sm-5">
	                                <textarea maxlength="150" name="dirpc" id="dirpc" class="form-control" rows="3"></textarea>
						         </div>

                                
                            </div>
                            
                            

                            <div class="form-group">
                                <label for="tlf1pc" class="col-sm-1 control-label">Tlf. 1:</label>
                                <div class="col-sm-2">
                                <input type="text" maxlength="15" class="form-control" name="tlf1pc" id="tlf1pc" placeholder="" />
                                    
                                </div>
                                <label for="tlf2pc" class="col-sm-1 control-label">Tlf. 2:</label>
                                <div class="col-sm-2 has-warning">
                                <input type="text" maxlength="15" class="form-control" name="tlf2pc" id="tlf2pc" placeholder="" />
                                    
                                </div>
                                <div class="col-sm-6">
                                &nbsp;
                                </div>
                            </div>
                            <div class="form-group">
                                &nbsp;
                            </div>

                            <input hidden name="idasg" id="idasg" value="" /><input hidden name="act" id="act" value="" />

                            <div class="form-group" align="center">
                                <label><a data-opc="agregar" class="asg_agredi btn btn-success">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Guardar&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></label>-<label><a id="asg_vlv_list" class="btn btn-danger">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Volver&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></label>
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

