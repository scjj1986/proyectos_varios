<?php
$conn = new mysqli("localhost", "root", "", "frutlever");
if ($conn->connect_errno) {
    echo "Failed to connect to MySQL: (" . $conn->connect_errno . ") " . $conn->connect_error;
}

?>


<table class="table table-bordered table-hover">
	<thead>
	  <tr>
	    <th>Codigo</th>
	    <th>Nombre de Usuario</th>
	    <th>Contrasena</th>
	    <th>Estado</th>
	    <th>Nivel de Usuario</th>
	  </tr>
	</thead>
	<tbody>

	<!-- Sentencia o consultas para mostrar datos de una tabla -->
<?php

$res = $conn->query("select * from usuarios");

while ($row = $res->fetch_assoc()) {
?>
    
	  <tr>
	    <td><?php echo $row['id_usuario']; ?></td>
	    <td><?php echo $row['nom_user']; ?></td>
	    <td><?php echo $row['pass_user']; ?></td>
	    <td><?php echo $row['estado_user']; ?></td>
	   	<td><?php echo $row['nivel_user']; ?></td>
	  </tr>
<?php
}
?>
	</tbody>
      </table>

     