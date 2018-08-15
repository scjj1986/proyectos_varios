<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>INICIO DE SESIÓN</title>

    
    
    <link rel="stylesheet" href="css/bootstrap.css">
    <link rel="stylesheet" href="css/font-awesome.min.css">
    <link href="css/sweetalert.css" rel="stylesheet">
    
    <script src="js/jquery-3.1.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/login.js"></script>


    <script src="js/sweetalert.min.js"></script>



</head>
<body style="background-color:#A9D0F5;">

<!-- Contenido del Formulario  -->
        <div class="modal-dialog">
            

            <div class="panel panel-primary">
  <div class="panel-heading">
    <h2 class="panel-title"><span align="right" class="glyphicon glyphicon-user"></span> <b>INICIO DE SESIÓN</b></h2>
  </div>
  <div class="panel-body">
    <div class="container">

                        <form role="form" class="form-horizontal" id="frmlogin">
                            <div class="form-group">

                                <label for="login" class="col-sm-2 control-label">Login</label>
                                  <div class="col-sm-3">
                                    <input type="text" class="enter form-control" name="login" id="login" placeholder="Ej: 17897657" />
                                  </div>
                                
                            </div>
                            <div class="form-group">
                                <label for="clave" class="col-sm-2 control-label">Clave</label>
                                <div class="col-sm-3">
                                    <input type="password" class="enter form-control" name="clave" id="clave" placeholder="Contaseña" />
                                </div>
                            </div>          
                        </form>

                    </div>
              </div>
              <div class="modal-footer">
                <button type="button" id="iniciar" class="btn btn-success">
                        Acceder
                    </button>
                    <button type="button" class="btn btn-warning" id="rc">
                        Recuperar contraseña
                    </button>
                    
                </div>
          </div>



</div>






<!-- Modal N° 1 -->
<div data-nmod="1" class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Recuperar Contraseña (Paso N° 1)</h4>
      </div>
      <div class="modal-body">
        <div class="container">

                        <form role="form" class="form-horizontal" id="frmrc">
                            <div class="form-group">

                                <label for="login2" class="col-sm-2 control-label">Login</label>
                                  <div class="col-sm-3">
                                    <input type="text" class="form-control" value="" name="login2" id="login2" placeholder="Ej: 17897657" />
                                  </div>
                                
                            </div>
                                      
                        </form>

                    </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-primary" id="sig">Sig.</button>
        <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
      </div>
    </div>
  </div>
</div>




<!-- Modal -->
<div class="modal fade" id="myModal2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Recuperar Contraseña (Paso N° 2)</h4>
      </div>
      <div class="modal-body">
                    <div class="container">

                        <form role="form" class="form-horizontal" id="frmmmmm">
                            <div class="form-group">

                                <label for=ps class="col-sm-2 control-label">Pregunta Secreta</label>
                                  <div class="col-sm-4">
                                    <input disabled type="text" class="form-control" name="ps" id="ps" placeholder="" />
                                  </div>
                                
                            </div>
                            <div class="form-group">
                                <label for="rs" class="col-sm-2 control-label">Respuesta</label>
                                <div class="col-sm-3">
                                    <input type="password" class="form-control" data-rs="" name="rs" id="rs" placeholder="Respuesta" />
                                </div>
                            </div>          
                        </form>

                    </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" id="prev2">Prev.</button>
        <button type="button" class="btn btn-primary" id="sig2">Sig.</button>
        <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
      </div>
    </div>
  </div>
</div>




<!-- Modal -->
<div class="modal fade" id="myModal3" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Recuperar Contraseña (Paso N° 3)</h4>
      </div>
      <div class="modal-body">
        <div class="container">

                        <form role="form" class="form-horizontal" id="frmrc2">
                            <div class="form-group">
                                <label for="rs" class="col-sm-3 control-label">Nueva Contraseña (Mín. 8 caracteres)</label>
                                <div class="col-sm-3">
                                    <input type="hidden" name="lg" id="lg" />
                                    <input type="password" class="form-control" name="pss" id="pss" placeholder="Contaseña" />
                                </div>
                            </div> 

                            <div class="form-group">
                                <label for="rs" class="col-sm-3 control-label">Repetir Contraseña</label>
                                <div class="col-sm-3">
                                    <input type="password" class="form-control" name="pss2" id="pss2" placeholder="Contaseña" />
                                </div>
                            </div>          
                        </form>

                    </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" id="prev3">Prev.</button>
        <button type="button" class="btn btn-success" id="finrc">Guardar</button>
        <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
      </div>
    </div>
  </div>
</div>

<!--  <script src="js/index.js"></script>      -->




</body>