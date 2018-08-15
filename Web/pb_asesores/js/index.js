
function validar_forms(nmod){
  var resp=-2;
  if (nmod=="1"){
    
//alert("epa");
    if ($("#login2").val()==""){
      resp = -1;

    }
  }
  return resp;
  


}








$("div[id^='myModal']").each(function(){
  
      var currentModal = $(this);

      var res = validar_forms($(this).data("nmod"));

      console.log(res);
      
      //click next
      currentModal.find('.btn-next').click(function(){

        if (res==-1){
          
          swal("¡Error!", "No puede dejar campos vacíos", "error");
        }
        else {
          currentModal.modal('hide');
        currentModal.closest("div[id^='myModal']").nextAll("div[id^='myModal']").first().modal('show'); 

        }
      

        
      });
      
      //click prev
      currentModal.find('.btn-prev').click(function(){
        currentModal.modal('hide');
        currentModal.closest("div[id^='myModal']").prevAll("div[id^='myModal']").first().modal('show'); 
      });

    });


