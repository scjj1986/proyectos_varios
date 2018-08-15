function validando(){
	// alert("Validando con JavaScript");
	var form = document.form;

	if (form.nombre.value==0) {
		alert("El campo del Nombre no se ingreso.");
	}
	
	form.submit();
}