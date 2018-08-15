




<script type='text/javascript' language='javascript' src='js/usuario.js'></script>


<div class="panel panel-primary">
  <div class="panel-heading">
    <h2 class="panel-title"><span align="right" class="glyphicon glyphicon-plus-sign"></span><b>&nbsp;&nbsp;AGREGAR USUARIO</b></h2>
  </div>
  <div class="panel-body">
    <div class="container">

                        <form role="form" class="frmusu form-horizontal">
                            
                             
                            <div class="form-group">
                                <label for="tp" class="col-sm-2 control-label">Tipo Persona:</label>
                                <div class="col-sm-1">
                                <select name="tp" id="tp" class="form-control">
					                <option value="V">V</option>
					                <option value="E">E</option>
					                <option value="J">J</option>
					            </select>
                                    
                                </div>
                                <label for="doc" class="col-sm-1 control-label">Céd/Pas./RIF:</label>
                                <div class="col-sm-2">
                                <input type="text" maxlength="15" class="form-control" name="doc" id="doc" placeholder="" />
                                    
                                </div>

                                <label for="nombre" class="col-sm-1 control-label">Nombres:</label>
                                <div class="col-sm-5">
                                <input type="text" maxlength="50" class="let form-control" name="nombre" id="nombre" placeholder="" />
                                    
                                </div>
                            </div>


                            <div class="form-group">
                                <label for="apellido" class="col-sm-2 control-label">Apellidos (Opcional):</label>
                                <div class="col-sm-4 has-warning">
                                <input type="text" class="let form-control" maxlength="50" name="apellido" id="apellido" placeholder="" />
                                </div>
                                <label for="perfil" class="col-sm-1 control-label">Perfil:</label>
                                <div class="col-sm-3">
	                                <select name="perfil" id="perfil" class="form-control">
						                <option value="ADMINISTRADOR">ADMINISTRADOR</option>
						                <option value="ASESOR">ASESOR</option>
						            </select>
						         </div>
						         <label for="tp" class="col-sm-2 control-label">&nbsp;</label>

                                
                            </div>
                            <div class="form-group">
                                <label for="ps" class="col-sm-2 control-label">Pregunta Secreta:</label>
                                <div class="col-sm-3">
	                                <select name="ps" id="ps" class="form-control">
						                <option value="¿COMIDA FAVORITA?">¿COMIDA FAVORITA?</option>
						                <option value="¿PELICULA FAVORITA?">¿PELÍCULA FAVORITA?</option>
						                <option value="¿ARTISTA FAVORITO?">¿ARTISTA FAVORITO?</option>
						                <option value="¿CANCION FAVORITA?">¿CANCIÓN FAVORITA?</option>
						                <option value="¿COLOR FAVORITO?">¿COLOR FAVORITO?</option>
						                <option value="¿NOMBRE DE MASCOTA?">¿NOMBRE DE MASCOTA?</option>
						                <option value="¿2DO APELLIDO DEL PADRE?">¿2DO APELLIDO DEL PADRE?</option>
						                <option value="¿2DO APELLIDO DE LA MADRE?">¿2DO APELLIDO DE LA MADRE?</option>
						            </select>
						         </div>
						         <label class="col-sm-1 control-label">&nbsp;</label>


						         <label for="rs" class="col-sm-1 control-label">Respuesta:</label>
                                <div class="col-sm-3">
	                                <input type="password" maxlength="30" class="form-control" name="rs" id="rs" placeholder="" />
						         </div>
						         <label class="col-sm-2 control-label">&nbsp;</label>
                            </div>
                            <div class="form-group">
                                <label for="pss" class="col-sm-2 control-label">Contraseña:</label>
                                <div class="col-sm-3">
	                                <input type="password" maxlength="20" class="form-control" name="pss" id="pss" placeholder="" />
						         </div>
						         


						         <label for="pss2" class="col-sm-2 control-label">Repetir Contraseña:</label>
                                <div class="col-sm-3">
	                                <input type="password" maxlength="20" class="form-control" name="pss2" id="pss2" placeholder="" />
						         </div>
						         <label class="col-sm-2 control-label">&nbsp;</label>
                            </div>

                            <div class="form-group">
                                &nbsp;
                            </div>

                            <input hidden name="idu" id="idu" value="" />

                            <div class="form-group" align="center">
                                <label><a data-opc="agregar" class="usu_agredi btn btn-success">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Guardar&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></label>-<label><a id="usu_vlv_list" class="btn btn-danger">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Volver&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></label>
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

