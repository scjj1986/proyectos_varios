$(document).ready(function(){
 jQuery("#im").click(function() {
              hora();
			  var res = encodeURI($("#idasg").val()+'&hora='+$("#hora").val()+'&fi='+$("#fdes").val()+'&ff='+$("#fhas").val()+'&idc='+$("#idasg1").val());
			  
               window.location='pdfSiniestro.php?id='+ res;
			
				 
				 
    });
	
 

});

function hora(){
			momentoActual = new Date() 
   	hora = momentoActual.getHours() 
   	minuto = momentoActual.getMinutes() 
   	segundo = momentoActual.getSeconds() 
	if (minuto<10)
		minuto="0"+minuto;
	if (segundo<10)
		segundo="0"+segundo;	
	
	if (hora>12){
		hora=hora-12;
		horaImprimible = hora + ":" + minuto + ":" + segundo + "p.m."
	}else{
		if (hora==12)
   			horaImprimible = hora + ":" + minuto + ":" + segundo + "m"
		else
			horaImprimible = hora + ":" + minuto + ":" + segundo + "a.m."
	 }
	

   	document.getElementById("hora").value = horaImprimible ;
	 
	 
	 
} 