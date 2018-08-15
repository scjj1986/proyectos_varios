<!DOCTYPE HTML>
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<title>Pregunta Nº2</title>
       
       
<script>
var tipo="";
var periodo="";
var anio="";


$(document).ready(function(){
	
	var t=0;
 // Cogemos los valores pasados por get
        var valores=getGET();
		
        if(valores)
        {
            // hacemos un bucle para pasar por cada indice del array de valores
            for(var index in valores)
            {
                if (index=='tipo')
				    tipo=valores[index];
				if (index=='periodo')
				    periodo=valores[index];
			    if (index=='anio')
				    anio=valores[index];
				 
            }
			
		}
		
		
	
    var options = {
        chart: {
            renderTo: 'container',
            type: 'column',
            margin: [ 50, 50, 120, 80]
        },
		 credits: {
      enabled: false
  },		
        title: {
			
            text:'Reporte de estadísticas de siniestros tipo '+tipo+' '+periodo+' '+anio
								  
        },
        xAxis: [],
        yAxis: {
            min: 0,
			allowDecimals: false,
            title: {
                text: 'Número de siniestros'
            }
        },
        legend: {
           floating: true,
            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
            borderColor: '#CCC',
            borderWidth: 1,
            shadow: true
        },
        tooltip: {
            formatter: function() {
                return '<b>'+ this.x +'</b><br/>' + this.series.name + ': ' + this.y + ' siniestros';
            }
        },
        plotOptions: {
           column: {
                pointPadding: 0.2,
                borderWidth: 0,
				shadow:true,
				dataLabels: {
						enabled: true,
						color: '#000000',
						connectorColor: '#000000',
						formatter: function() {
							//return Math.round((this.y*100/t) * 100) / 100  +' %';
						}
				}
            }
        },
        series: []
    }
  
	
    var url = 'codigo_grafica_estadisticas.php?caso=graficoTipo&tipo='+tipo+'&periodo='+periodo+'&anio='+anio;
    var xAxis = {
        categories: [],
        labels: {
            rotation: -45,
            align: 'right',
            style: {
                fontSize: '12px',
                fontFamily: 'Verdana, sans-serif'
            }
        },
		 title: {
                text: 'Intervalo de tiempo'
            }
    };
    var seriesTotal = {
        data: []
    };
    seriesTotal.name = 'Total';
    var series15y25 = {
        data: []
    };
    series15y25.name = 'Media';
    var series25y35 = {
        data: []
    };
    series25y35.name = 'meses';
	  var series35y45 = {
        data: []
    };
    series35y45.name = 'Desviación Estandar';
	  var series45y55 = {
        data: []
    };
    series45y55.name = 'Mediana';
	  var series55y65 = {
        data: []
    };
    series55y65.name = 'Nunca';
	 
    jQuery.getJSON(url, function(data) {
		
			  	 
       			jQuery.each(data, function(key1,val1) {
					if(periodo=='MENSUAL')           				
		       				 xAxis.categories.push(val1.mes);
					if(periodo=='TRIMESTRAL') 
						     xAxis.categories.push('Trimestre '+val1.trimestre);
				     if(periodo=='SEMESTRAL') 
						     xAxis.categories.push('Semestre '+val1.semestre);
				     if(periodo=='ANUAL') 
						     xAxis.categories.push(val1.anio);
                     		series15y25.data.push(val1.media);
							series45y55.data.push(val1.mediana);
							series35y45.data.push(val1.des);
							seriesTotal.data.push(val1.total);
							t=val1.total;
						
					
	   
	   
	   
				
               
            
       });
		
		
		//
		
        options.xAxis.push(xAxis);
        
        options.series.push(series15y25);
		options.series.push(series45y55);
		options.series.push(series35y45);
		options.series.push(seriesTotal);
        
		
		
        var chart = new Highcharts.Chart(options);
});		
    
});
</script>
		<script type="text/javascript" src="js/jquery.min.js"></script>
        <script type="text/javascript" src="js/validacion.js"></script>
		<style type="text/css">
${demo.css}
		</style>
   
        <link href="css/bootstrap.min.css" rel="stylesheet"> 
    
  
  
 
<script src="jquery.min.js" type="text/javascript"></script>   

	</head>
	<body id="destino" >
<script src="js/highcharts.js"></script>
<script src="js/modules/exporting.js"></script>

<div id="container" ></div>

	</body>
</html>
