const urlViaCep = "https://viacep.com.br/ws/";
const urlCepProfessor = "http://172.16.35.155:3000/myceps"

async function cadastrar(e) {
    e.preventDefault();
    //Pega os valores dos campos de formulário
    const nome = document.getElementById("nome").value.trim();
    const email = document.getElementById("email").value.trim();
    const cep = document.getElementById("cep").value;
    const endereco = document.getElementById("endereco").value.trim();
    const numero = document.getElementById("numero").value;
    const cidade = document.getElementById("cidade").value.trim();
    const estado = document.getElementById("estado").value.trim();

    objCadastro = {
        nome,
        email,
        cep,
        endereco,
        numero,
        cidade,
        estado
    }

    try {
        const promise = await fetch("http://172.16.35.155:3000/myceps", {
            data: JSON.stringify(objCadastro),
            method: "post",
            headers: { "Conten-type": "application/json" }
        });

        const dados = await promise.json()
        console.log(objCadastro);
    } catch (error) {
        console.log(error);
    }




    // extra - fazer validação com if 
    if (!validaForm(nome, email, cep, endereco, numero, cidade, estado)) {
        alert("Preencher todos os campos!")
        return;
    }
}

function validaForm(nome, email, cep, endereco, numero, cidade, estado) {
    console.log(nome);
    console.log(endereco);
    console.log(cep);
    if (nome.length == 0 ||
        email.length == 0 ||
        cep.length == 0 ||
        cep.length < 8 ||
        endereco.length == 0 ||
        numero.length == 0 ||
        cidade.length == 0 ||
        estado.length == 0) {
        alert("Favor inserir os dados, o campo não pode estar vazio")
    }



}

async function buscarEndereco(cep) { //async = pois irá fazer uma busca externa
    const resource = `${cep}/json/` //Complemento de endereço da API resource = https://viacep.com.br/ws/

    try {
        //const promise = await fetch(urlViaCep + resource);
        const promise = await fetch(`${urlCepProfessor}/${cep}`);
        const endereco = await promise.json();
        console.log(endereco);


        preencherCampos({
            endereco: endereco.logradouro,
            cidade: endereco.localidade,
            estado: endereco.uf
        })


        document.getElementById("not-found").innerText = "";//Caso der certo ele limpa o CEP INVALIDO


    } catch (error) {
        console.log(error);

        document.getElementById("not-found").innerText = "CEP Inválido";
    }
}

function preencherCampos(endereco) {
    //Preenche o formulário
    document.getElementById("endereco").value = endereco.endereco
    document.getElementById("cidade").value = endereco.cidade
    document.getElementById("estado").value = endereco.estado
}

