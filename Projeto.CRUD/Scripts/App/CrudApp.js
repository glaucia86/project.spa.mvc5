//Chamada da Função: "Listar" para poder adicionar a lista após o carregamento da página:
Listar();

//Função para Cadastrar com JQuery:
function Cadastrar() {
    /*O "serialize" é um método do JQuery que permite serializar todos os inputs de um determinado formulário
     em uma única string. Assim, quando queremos enviar uma série de dados por via Ajax
     fica mais fácil, uma vez que ele concatena todas as informações de todos os input's por uma única string*/
    var dadosSerializados = $('#formDados').serialize();
    $.ajax({
        type: "POST",
        url: "/App/Cadastrar",
        data: dadosSerializados,
        success: function () {
            Mensagem("success", "Produto cadastrado com Sucesso!");
            Listar();
        },
        error: function () {
            Mensagem("danger", "Erro ao cadastrar o Produto");
        }
    });
}

//Função para Listar os dados do formulário em uma tabela:
function Listar() {
    LimparFormulario();
    $.ajax({
        type: "GET",
        url: "/App/Listar",
        success: function (dadosProduto) {
            if (dadosProduto.length != null) {
                $('#tbody').children().remove();

                $(dadosProduto).each(function (i) {
                    var dataMiliSegundos = dadosProduto[i].DataCadastro.replace('/Date(', '').replace(')/', '');
                    var dataCadastro = new Date(parseInt(dataMiliSegundos)).toLocaleDateString();
                    var tbody = $('#tbody');
                    var tr = "<tr>";
                    tr += "<td>" + dadosProduto[i].ProdutoId;
                    tr += "<td>" + dadosProduto[i].Nome;
                    tr += "<td>" + dadosProduto[i].Preco;
                    tr += "<td>" + dataCadastro;
                    tr += "<td>" + dadosProduto[i].Quantidade;
                    tr += "<td>" + "<button class='btn btn-warning btn-sm' onclick=Editar(" + dadosProduto[i].ProdutoId + ")><span class='glyphicon glyphicon-pencil'>&nbspEditar</span></button>";
                    tr += "<td>" + "<button class='btn btn-danger btn-sm' onclick=Deletar(" + dadosProduto[i].ProdutoId + ")><span class='glyphicon glyphicon-trash'></span>&nbspDeletar</button>";

                    tbody.append(tr);
                });
            }
        }
    });
}

//Função Editar:
function Editar(idProduto) {
    if (idProduto != null && idProduto > 0) {
        $.ajax({
            type: "GET",
            url: "/App/Editar",
            data: { id: idProduto },
            success: function (dados) {
                var dataMilisegundos = dados.DataCadastro.replace('/Date(', '').replace(')/', '');
                var dataFormatoLocal = new Date(parseInt(dataMilisegundos)).toLocaleDateString();

                var dataFormatada = "";
                dataFormatada += dataFormatoLocal.substring(6, 10) + '-';
                dataFormatada += dataFormatoLocal.substring(3, 5) + '-';
                dataFormatada += dataFormatoLocal.substring(0, 2);

                $('#idProduto').val(dados.ProdutoId);
                $('#nome').val(dados.Nome);
                $('#preco').val(dados.Preco);
                $('#dataCadastro').val(dataFormatada);
                $('#quantidade').val(dados.Quantidade);

                $("#salvar").addClass("hidden");
                $("#atualizar").removeClass("hidden");
            }
        });
    }
}

//Função Atualizar:
function Atualizar() {
    var dadosSerializados = $('#formDados').serialize();
    $.ajax({
        type: "POST",
        url: "/App/Atualizar",
        data: dadosSerializados,
        success: function () {
            $("#salvar").removeClass("hidden");
            $("#atualizar").addClass("hidden");

            //Depois que eu atualizo.... preciso apresentar novamente os produtos... então...
            Listar();
        },
        error: function myfunction() {
            alert("Erro ao Atualizar o Produto!");
        }
    });
}

//Função Deletar:
function Deletar(idProduto) {
    var confirmar = confirm("Deseja realmente deletar o Produto?");
    if (confirmar) {
        if (idProduto != null && idProduto > 0) {
            $.ajax({
                type: "POST",
                url: "/App/Deletar",
                data: { id: idProduto },
                success: function () {
                    Listar();
                    Mensagem("success", "Produto deletado com Sucesso!");
                },
                error: function () {
                    Mensagem("error", "Erro ao deletar o Produto");
                }
            });
        }
    }
}

//Função para poder apresentar uma mensagem de sucesso ou de erro (via JQuery):
function Mensagem(stringCss, mensagem) {
    //Se existir algum tipo de mensagem, irá remover:
    $('#mensagem').remove();

    //Um método para poder limitar o tempo para aparecer uma determinada mensagem:
    setTimeout(function () {
        $('#formDados').append("<div class='alert alert-" + stringCss + "' id=mensagem role=alert>" + mensagem + "</div>");
    }, 10);
}

//Função para poder limpar o formulário:
function LimparFormulario() {
    $('#formDados').each(function () {
        this.reset();
    });
}

//Função que não permite número no campo "Nome":
function somenteLetras(e) {

    var regex = /[0-9]/;
    if (regex.test(String.fromCharCode(e.keyCode))) {
        return false;
    } else {
        return true;
    }
}
