const urlViaCep = "https://viacep.com.br/ws/";

function cadastrar(e)
{
    e.preventDefault();
    alert("Cadastrar...");
}

async function buscarEndereco(cep) { //async = pois irá fazer uma busca externa
    const resource = `${cep}/json/` //Complemento de endereço da API resource = https://viacep.com.br/ws/
    
    try {
        const promise = await fetch(urlViaCep + resource);
        const endereco = await promise.json();
        console.log(endereco);

        preencherCampos({
            endereco: endereco.logradouro,
            cidade: endereco.localidade,
            bairro: endereco.bairro,
            estado: endereco.uf
        })


        document.getElementById("not-found").innerText = "";//Caso der certo ele limpa o CEP INVALIDO


    } catch (error) {
        console.log(error);

        document.getElementById("not-found").innerText = "CEP Inválido";
    }
}

function preencherCampos(endereco){
        //Preenche o formulário
        document.getElementById("endereco").value = endereco.logradouro
        document.getElementById("bairro").value = endereco.bairro
        document.getElementById("cidade").value = endereco.localidade
        document.getElementById("estado").value = endereco.uf
}

