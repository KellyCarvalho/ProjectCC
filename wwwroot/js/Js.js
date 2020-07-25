// JavaScript source code
/* Declaração de variaveis*/

var endereco = "https://localhost:5001/Gestao/NovaOS"



$('#idcliente').click(function () {


    var a = $.("#idcliente").val();
var requestajax = $.ajax({
        method: "GET",
        url: "https://localhost:5001/Gestao/Cliente",
        data: {
            clienteid: $(':input[name:idcliente]').val()

        },


        alert(requestajax);

    });

});
console.log("ok");
  
});
