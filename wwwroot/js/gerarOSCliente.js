
var enderecoCliente ="https://localhost:5001/Gestao/Cliente/Clientes/1"



$('#pegarIDCliente').click(function () {
 
    $.post(enderecoCliente, function (dados, status) {
        alert("Dados: " + dados + " Status: " + status);
    });
});