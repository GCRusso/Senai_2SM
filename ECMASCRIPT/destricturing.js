const camisaLacoste = {
    descricao: "Camisa Lacoste",
    preco: 589.97,
    tamanho: "m",
    cor: "Amarela",
    presente: true
}

const {descricao, preco} = camisaLacoste;
const {presente} = camisaLacoste;

console.log(`"
PRODUTO
    Descrição: ${descricao}
    Preço: ${preco}
    Presente: ${presente ? "sim" : "não"} 
`);""

const evento = {
        dataEvento: new Date(),
        descricaoEvento: "evento de Java Script",
        titulo: "Programação WEB",
        presencaEvento: true,
        comentario: "Este evento foi top com o Edu!"
}

const {dataEvento, descricaoEvento, titulo, presencaEvento, comentario} = evento;

//const eventoCopia = {...evento}; //Assim ele puxa todas as propriedades do objeto evento sem precisar escrever todos como o exempl acima

console.log(`
Evento
    Data do Evento: ${dataEvento}
    Descrição: ${descricaoEvento}
    Titulo: ${titulo}
    Presença: ${presencaEvento}
    Comentario: ${comentario}
`)