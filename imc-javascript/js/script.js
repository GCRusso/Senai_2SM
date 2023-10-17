const arrPessoas = []; // Array vazio no escopo GLOBAL para todas as funções ter acesso a este array

function calcular(e) {
    e.preventDefault()// Capturar o evento de submit do formulário (Parar)

    //pegar os dados do form e validar se estão preenchidos
    const nome = document.getElementById("nome").value.trim(); // trim = retira os espaços que o usuário pode deixar
    const altura = Number.parseFloat(document.getElementById("altura").value);
    const peso = Number.parseFloat(document.getElementById("peso").value);


    if (isNaN(altura) || isNaN(peso) || nome.length == 0) {
        alert("É necessário preencher os campos corretamente!")
        return; //Para a função e entrega o resultado
    }

    //Calcular IMC, para mostra no log
    const imc = calcularImc(altura, peso);
    //Gera o texto da situação
    const situacao = retornaSituacao(imc);

    //Gera um objeto com os dados da pessoa, Objeto literal.
    const pessoa = {
        nome: nome,
        altura: altura,
        peso: peso,
        imc: imc,
        situacao: situacao
    }

    //Adicionando um objeto pessoa dentro do array que está no escopo GLOBAL
    arrPessoas.push(pessoa);

    /*const pessoa = {nome, altura, peso, imc, situacao : txtSituacao}; 
    Esta forma é conhecida como escrita curta, quando o nome do parametro é igual ao nome da variável você pode encurtar desta forma
    em situação esta exemplificando quando os nomes são diferentes assim:  const txtSituacao = retornaSituacao(imc);*/

    //console.log(pessoa); Exibe apenas a pessoa cadastrada no momento
    //console.log(arrPessoas); Exibe direto no console

    listarPessoas(); //Exibindo o array no CONSOLE chamando uma função
    listarNomes(); //Exibindo apenas os nomes da lista do array

};

function calcularImc(altura, peso) {

    // return peso / altura ^ 2;  OBS : ASSIM É ARREDONDADO O VALOR // Chapeuzinho ^ é elevado
    //return peso / Math.pow(altura, 2);
    return peso / altura ** altura;

}

/*
Resultado           Situação
Menor que 18.5      Magreza Severa
Entre 18.5 e 24.99  Peso Normal
Entre 25 e 29.99    Acima do peso
Entre 30 e 34.99    Obesidade I
Entre 35 e 39.99    Obesidade II Severa
Acima de 40         CUIDADO!!!
*/

function retornaSituacao(imc) {
    // validar o imc
    if (imc < 18.5) {
        return 'Magreza SEVERA!'
    }
    else if (imc >= 18.5 && imc <= 24.99) {
        return 'Peso normal'
    }
    else if (imc >= 25 && imc <= 29.99) {
        return 'Acima do peso'
    }
    else if (imc >= 30 && imc <= 34.99) {
        return 'Obesidade Nivel 1'
    }
    else if (imc >= 35 && imc <= 39.99) {
        return 'Obesidade Nivel 2 SEVERA'
    }
    else (imc >= 40)
    {
        return 'CUIDADO!!!'
    }

}

//Listando array completo com todas as informações
function listarPessoas() {
    let template = '';
    
    arrPessoas.forEach(p => {//+= para acumular valores, nao sobrescrever
        template += ` 
                <tr>
                    <th>${p.nome}</th>
                    <th>${p.altura}</th>
                    <th>${p.peso}</th>
                    <th>${p.imc}</th>
                    <th>${p.situacao}</th>
                </tr >`;
    });
    document.getElementById('cadastro').innerHTML = template;

    //console.log(arrPessoas);
    //arrPessoas.forEach(pessoa1 => console.log(pessoa1.nome, pessoa1.imc.toFixed(2), pessoa1.situacao)); Outra forma de exibir um array
}

//Listando apenas os nomes das pessoas no array
function listarNomes() {
    arrPessoas.forEach(pessoa1 => {
        console.log(pessoa1.nome)
    });



}