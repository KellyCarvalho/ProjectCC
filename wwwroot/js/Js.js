// JavaScript source code
/* Declaração de variaveis*/
var enderecoCliente = "https://localhost:5001/Clientes/Cliente/";
/* Ajax */
$("#pesquisar").click(function () {
    var codCliente = $("#codCliente").val();
    var enderecoTemporario = enderecoCliente + codCliente;
    $.post(enderecoTemporario, function (dados, status) {
        cliente = dados;


    };


        preencherFormulario(cliente);
    }).fail(function () {
        alert("Produto inválido!");
    });
});