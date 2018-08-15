$(document).ready(function(){
 
	   var f1="";
	         var f2="";
			 var aa="";
    $("#imprimir1").click(function(evento) {

              
			f1=document.getElementById('datepicker').value;
	         f2=document.getElementById('tp').value;
			 aa=document.getElementById('aaa').value;
			
			 			
		
			
			 document.getElementById("imprimir1").href = '#interfaz_grafica_tipo.php?tipo='+f1+'&periodo='+f2+'&anio='+aa;	
			 //$("#capa").html('');
			$("#capa").load('interfaz_grafica_tipo.php');
            
					

            });   
    
   
	         
});