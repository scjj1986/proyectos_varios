<?php
require_once("dompdf/dompdf_config.inc.php");
//$dompdf = new DOMPDF();
/*
$html = '<html><body><h1>Generar un PDF con PHP</h1><p>Desde un documentoHTML.</p></body></html>'; 

//$html = file_get_contents("index.php");

$dompdf->load_html($html);
$dompdf->render();
//$dompdf->stream("resultado.pdf");

$dompdf->render();
$output = $dompdf->output();
file_put_contents("salida.pdf", $output);*/


// Introducimos HTML de prueba
$html = '<h1>Hola mundo!</h1>';
 
// Instanciamos un objeto de la clase DOMPDF.
$pdf = new DOMPDF();
 
// Definimos el tamaño y orientación del papel que queremos.
//$pdf->set_paper("A4", "portrait");
 
// Cargamos el contenido HTML.
$pdf->load_html(utf8_decode($html));
 
// Renderizamos el documento PDF.
$pdf->render();
 
// Enviamos el fichero PDF al navegador.
$pdf->stream('FicheroEjemplo.pdf');


?>