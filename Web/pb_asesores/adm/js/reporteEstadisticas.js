$(document).ready(function(){
 
	   var f1="";
	         var f2="";
    $("#imprimir1").click(function(evento) {

              
			f1=document.getElementById('datepicker').value;
	         f2=document.getElementById('tp').value;
			if (f2!='ANUAL'& f1==""){
				alert("Debe de colocar el año para el reporte");
				return;
			}
			if(f2=='ANUAL')
			   f1="";
			 			
		
			
			 document.getElementById("imprimir1").href = '#interfaz_grafica.php?anio='+f1+'&periodo='+f2;	
			 //$("#capa").html('');
			$("#capa").load('interfaz_grafica.php');
            
					

            });   
    
   
	         
});