//FILTER = FILTRAR A LISTA DE ARRAY PASSANDO UMA CONDIÇÃO

const numeros = [1,2,200,10,7,12,15,8];
console.log(numeros);

const nMenor10 = numeros.filter((n) => {
    return n < 10;
})
console.log(nMenor10);

/* Estritamente igual com 3 iguais ===
pois se caso voce tenha um 2 ou 200 como string e voce estiver usando apenas o == ele puxa a string como se fosse numero 
entao basicamente utilizar o estritamente igual ele ira puxar apenas o formato que pesquisou*/
const doisDuzentos = numeros.filter((p) => {
    return p === 2 || p === 200;
})
console.log(doisDuzentos);

//Exemplo de comentarios
const comentarios = [
    {comentario: "sadasdsadsadsaasd", exibe: true},
    {comentario: "$%$#^%$^$%^%$", exibe: false},
    {comentario: "sluiluiliuliunh", exibe: true},
    {comentario: "asdsadsatytruytjyty", exibe: true},
    {comentario: "$%$#%#%#$%$#", exibe: false}
];

const comentariosOk = comentarios.filter((c) => {
    return c.exibe === true;
})

console.log(comentariosOk);