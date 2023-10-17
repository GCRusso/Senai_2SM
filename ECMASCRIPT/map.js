//MAP =  MODIFICA UMA LISTA DE ARRAY, MAS ELE NAO ALTERNA A ORDEM E NEM ALTERA OS DADOS DELA ELE CRIA UMA NOVA LISTA MODIFICADA EXEMPLOS A BAIXO.

/*
const numeros = [1,2,5,10,300];
const arrDobro = numeros.map( (n) => {
    return n * 2;
})

console.log(numeros);
console.log(arrDobro);*/

const nome = ["Gabriel", "Pedro", "Rubens", "Andre", "Julia"];
const sobrenome = ["Coral", "Silva","Moura", "Souza", "Rocha"];

const nomeCompleto = nome.map( (nome,i) => {
    return `${nome} ${sobrenome[i]}`;
});

nomeCompleto.forEach(nc => {console.log(nomeCompleto)});

