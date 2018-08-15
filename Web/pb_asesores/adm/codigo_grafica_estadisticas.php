<?php

 date_default_timezone_set('America/Caracas');
extract($_GET);
 if (!($cn = mysql_connect("127.0.0.1", "root", "1903"))) {
            echo "Error conectando a la base de datos.";
            exit();
        }
        if (!mysql_select_db("pb_asesores", $cn)) {
            echo "Error seleccionando la base de datos.";
            exit();
        }
        mysql_query("SET NAMES 'utf8'");
switch ($caso) {
	
    
 
 case 'grafico5':
        
      
		$a=$anio;
		$per=$periodo;
		
		if($per=='MENSUAL'){
 
        $sql = "select avg(siniestro) as media,sum(siniestro) as t, mes,(MAX(siniestro) + MIN(siniestro))/2 as mediana, std(siniestro) as desviacion from estadistica where anio='$a' group by mes";
		
		//fecha BETWEEN  '$fi' AND  '$ff'
        $res = mysql_query($sql, $cn);
       
	
		 $arrayX = array();
		 
		 $resulT=array();
		 
		  while($dep_rows = mysql_fetch_array($res)){
           
			  $arrayX['mes'][] =  ($dep_rows["mes"]);
			  $arrayX['media'] []= (float) ($dep_rows["media"]);
			   $arrayX['mediana'] []= (float) ($dep_rows["mediana"]);
			    $arrayX['des'] []= (float) ($dep_rows["desviacion"]);
			  $arrayX['total'] []= (int) ($dep_rows["t"]);			
			  array_push($resulT,$arrayX);
              unset($arrayX);
			
		  }
			

        echo json_encode($resulT);}
		if($per=='TRIMESTRAL'){
		   $sql = "select avg(siniestro) as media,sum(siniestro) as t, trimestre,(MAX(siniestro) + MIN(siniestro))/2 as mediana, std(siniestro) as desviacion from estadistica where anio='$a' group by trimestre";
		    $res = mysql_query($sql, $cn);
       
	
		 $arrayX = array();
		 
		 $resulT=array();
		 
		  while($dep_rows = mysql_fetch_array($res)){
           
			  $arrayX['trimestre'][] =  ($dep_rows["trimestre"]);
			  $arrayX['media'] []= (float) ($dep_rows["media"]);
			   $arrayX['mediana'] []= (float) ($dep_rows["mediana"]);
			    $arrayX['des'] []= (float) ($dep_rows["desviacion"]);
			  $arrayX['total'] []= (int) ($dep_rows["t"]);			
			  array_push($resulT,$arrayX);
              unset($arrayX);
			
		  }
			

        echo json_encode($resulT);
		   
		   
		   }
		   if($per=='SEMESTRAL'){
		   $sql = "select avg(siniestro) as media,sum(siniestro) as t, semestre,(MAX(siniestro) + MIN(siniestro))/2 as mediana, std(siniestro) as desviacion from estadistica where anio='$a' group by semestre";
		    $res = mysql_query($sql, $cn);
       
	
		 $arrayX = array();
		 
		 $resulT=array();
		 
		  while($dep_rows = mysql_fetch_array($res)){
           
			  $arrayX['semestre'][] =  ($dep_rows["semestre"]);
			  $arrayX['media'] []= (float) ($dep_rows["media"]);
			   $arrayX['mediana'] []= (float) ($dep_rows["mediana"]);
			    $arrayX['des'] []= (float) ($dep_rows["desviacion"]);
			  $arrayX['total'] []= (int) ($dep_rows["t"]);			
			  array_push($resulT,$arrayX);
              unset($arrayX);
			
		  }
			

        echo json_encode($resulT);
		   
		   
		   }
		   if($per=='ANUAL'){
		   $sql = "select avg(siniestro) as media,sum(siniestro) as t, anio,(MAX(siniestro) + MIN(siniestro))/2 as mediana, std(siniestro) as desviacion from estadistica group by anio";
		    $res = mysql_query($sql, $cn);
       
	
		 $arrayX = array();
		 
		 $resulT=array();
		 
		  while($dep_rows = mysql_fetch_array($res)){
           
			  $arrayX['anio'][] =  ($dep_rows["anio"]);
			  $arrayX['media'] []= (float) ($dep_rows["media"]);
			   $arrayX['mediana'] []= (float) ($dep_rows["mediana"]);
			    $arrayX['des'] []= (float) ($dep_rows["desviacion"]);
			  $arrayX['total'] []= (int) ($dep_rows["t"]);			
			  array_push($resulT,$arrayX);
              unset($arrayX);
			
		  }
			

        echo json_encode($resulT);
		   
		   
		   }
        break;
		
	 case 'graficoTipo':	
	 $tp=$tipo;	
	 $per=$periodo;	
	 $a=$anio;
	 	if($per=='MENSUAL'){
 
        $sql = "select avg(siniestro) as media,sum(siniestro) as t, mes,(MAX(siniestro) + MIN(siniestro))/2 as mediana, std(siniestro) as desviacion from estadistica where tipo='$tp' and anio='$a' group by mes";
		
		//fecha BETWEEN  '$fi' AND  '$ff'
        $res = mysql_query($sql, $cn);
       
	
		 $arrayX = array();
		 
		 $resulT=array();
		 
		  while($dep_rows = mysql_fetch_array($res)){
           
			  $arrayX['mes'][] =  ($dep_rows["mes"]);
			  $arrayX['media'] []= (float) ($dep_rows["media"]);
			   $arrayX['mediana'] []= (float) ($dep_rows["mediana"]);
			    $arrayX['des'] []= (float) ($dep_rows["desviacion"]);
			  $arrayX['total'] []= (int) ($dep_rows["t"]);			
			  array_push($resulT,$arrayX);
              unset($arrayX);
			
		  }
			

        echo json_encode($resulT);}
		if($per=='TRIMESTRAL'){
		   $sql = "select avg(siniestro) as media,sum(siniestro) as t, trimestre,(MAX(siniestro) + MIN(siniestro))/2 as mediana, std(siniestro) as desviacion from estadistica where tipo='$tp'  and anio='$a' group by trimestre";
		    $res = mysql_query($sql, $cn);
       
	
		 $arrayX = array();
		 
		 $resulT=array();
		 
		  while($dep_rows = mysql_fetch_array($res)){
           
			  $arrayX['trimestre'][] =  ($dep_rows["trimestre"]);
			  $arrayX['media'] []= (float) ($dep_rows["media"]);
			   $arrayX['mediana'] []= (float) ($dep_rows["mediana"]);
			    $arrayX['des'] []= (float) ($dep_rows["desviacion"]);
			  $arrayX['total'] []= (int) ($dep_rows["t"]);			
			  array_push($resulT,$arrayX);
              unset($arrayX);
			
		  }
			

        echo json_encode($resulT);
		   
		   
		   }
		   if($per=='SEMESTRAL'){
		   $sql = "select avg(siniestro) as media,sum(siniestro) as t, semestre,(MAX(siniestro) + MIN(siniestro))/2 as mediana, std(siniestro) as desviacion from estadistica where tipo='$tp' and anio='$a' group by semestre";
		    $res = mysql_query($sql, $cn);
       
	
		 $arrayX = array();
		 
		 $resulT=array();
		 
		  while($dep_rows = mysql_fetch_array($res)){
           
			  $arrayX['semestre'][] =  ($dep_rows["semestre"]);
			  $arrayX['media'] []= (float) ($dep_rows["media"]);
			   $arrayX['mediana'] []= (float) ($dep_rows["mediana"]);
			    $arrayX['des'] []= (float) ($dep_rows["desviacion"]);
			  $arrayX['total'] []= (int) ($dep_rows["t"]);			
			  array_push($resulT,$arrayX);
              unset($arrayX);
			
		  }
			

        echo json_encode($resulT);
		   
		   
		   }
		   if($per=='ANUAL'){
		   $sql = "select avg(siniestro) as media,sum(siniestro) as t, anio,(MAX(siniestro) + MIN(siniestro))/2 as mediana, std(siniestro) as desviacion from estadistica where tipo='$tp' group by anio";
		    $res = mysql_query($sql, $cn);
       
	
		 $arrayX = array();
		 
		 $resulT=array();
		 
		  while($dep_rows = mysql_fetch_array($res)){
           
			  $arrayX['anio'][] =  ($dep_rows["anio"]);
			  $arrayX['media'] []= (float) ($dep_rows["media"]);
			   $arrayX['mediana'] []= (float) ($dep_rows["mediana"]);
			    $arrayX['des'] []= (float) ($dep_rows["desviacion"]);
			  $arrayX['total'] []= (int) ($dep_rows["t"]);			
			  array_push($resulT,$arrayX);
              unset($arrayX);
			
		  }
			

        echo json_encode($resulT);
		   
		   
		   }
		   break;
 
		
}

  


mysql_close($cn);
?>