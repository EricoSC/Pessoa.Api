$(document).ready(function () {
    loadData();
    $("#peopleTable").on('click', '#btnDel', function () {
        $(this).closest('tr').remove();
    });
    
});
$("#Cep").focusout(function () {
    //Nova variável "cep" somente com dígitos.
    var cep = $(this).val().replace(/\D/g, '');

    //Verifica se campo cep possui valor informado.
    if (cep != "") {

        //Expressão regular para validar o CEP.
        var validacep = /^[0-9]{8}$/;

        //Valida o formato do CEP.
        if (validacep.test(cep)) {

            //Preenche os campos com "..." enquanto consulta webservice.
            $("#Rua").val("...");
            $("#Bairro").val("...");
            $("#Cidade").val("...");
            $("#Estado").val("...");

            //Consulta o webservice viacep.com.br/
            $.getJSON("https://ws.apicep.com/cep.json?code="+ cep, function (dados) {

                if (!("erro" in dados)) {
                    //Atualiza os campos com os valores da consulta.
                    $("#Rua").val(dados.address);
                    $("#Bairro").val(dados.district);
                    $("#Cidade").val(dados.city);
                    $("#Estado").val(dados.state);
                } //end if.
                else {
                    //CEP pesquisado não foi encontrado.
                    limpa_formulário_cep();
                    alert("CEP não encontrado.");
                }
            });
        } //end if.
        else {
            //cep é inválido.
            limpa_formulário_cep();
            alert("Formato de CEP inválido.");
        }
    } //end if.
    else {
        //cep sem valor, limpa formulário.
        limpa_formulário_cep();
    }
});



//carregar dados  
function loadData() {
    $.ajax({
        url: "/People/getall",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                var date = new Date(item.dataNascimento)
                html += '<tr>';
                html += '<td>' + item.pessoaId + '</td>';
                html += '<td>' + item.nome + '</td>';
                html += '<td>' + item.idade + '</td>';
                html += '<td>' + date.getDay().toString() + '/' + date.getMonth() + '/' + date.getFullYear() + '</td>';
                html += '<td>' + item.telefone + '</td>';
                html += '<td>' + item.endereco.cep + '</td>';
                html += '<td>' + item.endereco.numero + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.pessoaId + ')">Edit</a> | <a href="#" id="btnDel" onclick="Delete(' + item.pessoaId + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//adicionar 
function Add() {
    
    var res = validate();
    if (res == false) {
        return false;
    }
    var peopleObjAdd = {
        nome: $('#Nome').val(),
        idade: $('#Idade').val(),
        dataNascimento: $('#DataNascimento').val(),
        telefone: $('#Telefone').val(),
        endereco: {
            cep: $('#Cep').val(),
            numero: $('#Numero').val(),
            estado: $('#Estado').val(),
            bairro: $('#Bairro').val(),
            cidade: $('#Cidade').val(),
            rua: $('#Rua').val(),
            pais: $('#Pais').val()
        }
    };
    $.ajax({
        url: "/People/",
        data: JSON.stringify(peopleObjAdd),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//função de pegar por id
function getbyID(PeopleID) {
    $('#Nome').css('border-color', 'lightgrey');
    $('#Idade').css('border-color', 'lightgrey');
    $('#DataNascimento').css('border-color', 'lightgrey');
    $('#Telefone').css('border-color', 'lightgrey');
    $.ajax({
        url: "/People/" + PeopleID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            let datas = new Date(result.dataNascimento)
            $('#PeopleID').val(result.pessoaId);
            $('#Nome').val(result.nome);
            $('#Idade').val(result.idade);
            // :(
            $('#DataNascimento').val(datas.getFullYear() + '-' + datas.getMonth() + '-' + datas.getDate());
            //$('#DataNascimento').val(datas.getFullYear() + '-' + datas.getMonth() + '-' + datas.getDate());
            $('#Telefone').val(result.telefone);
            $('#EnderecoId').val(result.endereco.enderecoId);
            $('#Cep').val(result.endereco.cep);
            $('#Numero').val(result.endereco.numero);
            $('#Estado').val(result.endereco.estado);
            $('#Bairro').val(result.endereco.bairro);
            $('#Cidade').val(result.endereco.cidade);
            $('#Rua').val(result.endereco.rua);
            $('#Pais').val(result.endereco.pais);
            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//função de atualizar
function Update() {

    var res = validate();
    if (res == false) {
        return false;
    }
    var peopleObj = {
        pessoaId: $('#PeopleID').val(),
        nome: $('#Nome').val(),
        idade: $('#Idade').val(),
        
        dataNascimento: $('#DataNascimento').val(),
        telefone: $('#Telefone').val(),
        endereco: {
            enderecoId: $('#EnderecoId').val(),
            cep: $('#Cep').val(),
            numero: $('#Numero').val(),
            estado: $('#Estado').val(),
            bairro: $('#Bairro').val(),
            cidade: $('#Cidade').val(),
            rua: $('#Rua').val(),
            pais: $('#Pais').val()
        }
    };
    $.ajax({
        url: "/People/" + peopleObj.pessoaId,
        data: JSON.stringify(peopleObj),
        type: "PUT",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            clearTextBox();
            loadData();
            
            $('#myModal').modal('hide');
            
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//função de deletar 
function Delete(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/People/" + ID,
            type: "DELETE",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                clearTextBox();
                
                loadData();
                
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

function clearTextBox() {
    $('#PeopleID').val("");
    $('#Nome').val("");
    $('#Idade').val("");
    $('#DataNascimento').val("");
    $('#Telefone').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Nome').css('border-color', 'lightgrey');
    $('#Idade').css('border-color', 'lightgrey');
    $('#DataNascimento').css('border-color', 'lightgrey');
    $('#Telefone').css('border-color', 'lightgrey');
    limpa_formulário_cep();
}
var formatData = function (d) {
    var date = d.getDay();
    var month = d.getMonth();
    var year = d.getFullYear();
    return year + "-" + (int)(month) + "-" + (int)(date);
};

function validate() {
    var isValid = true;
    if ($('#Nome').val().trim() == "") {
        $('#Nome').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Nome').css('border-color', 'lightgrey');
    }
    if ($('#Idade').val().trim() == "") {
        $('#Idade').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Idade').css('border-color', 'lightgrey');
    }
    if ($('#DataNascimento').val().trim() == "") {
        $('#DataNascimento').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#DataNascimento').css('border-color', 'lightgrey');
    }
    if ($('#Telefone').val().trim() == "") {
        $('#Telefone').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Telefone').css('border-color', 'lightgrey');
    }
    if ($('#Rua').val().trim() == "") {
        $('#Rua').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Rua').css('border-color', 'lightgrey');
    }
    if ($('#Bairro').val().trim() == "") {
        $('#Bairro').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Bairro').css('border-color', 'lightgrey');
    }
    if ($('#Cidade').val().trim() == "") {
        $('#Cidade').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Cidade').css('border-color', 'lightgrey');
    }
    if ($('#Estado').val().trim() == "") {
        $('#Estado').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Estado').css('border-color', 'lightgrey');
    }
    if ($('#Cep').val().trim() == "") {
        $('#Cep').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Cep').css('border-color', 'lightgrey');
    }
    if ($('#Numero').val().trim() == "") {
        $('#Numero').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Numero').css('border-color', 'lightgrey');
    }
    if ($('#Pais').val().trim() == "") {
        $('#Pais').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Pais').css('border-color', 'lightgrey');
    }
    return isValid;

}

function limpa_formulário_cep() {
    // Limpa valores do formulário de cep.
    $("#Rua").val("");
    $("#Bairro").val("");
    $("#Cidade").val("");
    $("#Estado").val("");
    $("#Cep").val("");
    $("#Numero").val("");
    $('#EnderecoId').val("");
    $('#Pais').val("");


}

