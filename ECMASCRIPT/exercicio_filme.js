/*
let filme = [
    filme1 = {
        titulo: "Golpe Baixo",
        genero: "Comédia",
        duracao: 120,
        visto: 1
    },

    filme2 = {
        titulo: "Carros",
        genero: "Comédia/Ação",
        duracao: 150,
        visto: 2
    }
]

const {titulo, genero, duracao, visto} = filme1;

console.log(`
FILME
    Titulo: ${titulo}
    Genero: ${genero}
    Duração em minutos: ${duracao}
    Viu este filme?: ${visto ? "sim" : "não"}
`);
*/

//************CORREÇÃO DO PROFESSOR*****************
const filmes = [
    {
        titulo: "A Bela e a fera",
        genero: ["Fantasia", "Romance", "Infantil"],
        descricao: "Descrição do filme",
        anoLancamento: 1980,
    },
    {
        titulo: "A Fuga das galinhas",
        genero: ["Fantasia", "Comedia", "Infantil"],
        descricao: "Descrição do filme",
        anoLancamento: 2005,
    },
    {
        titulo: "John Wick",
        genero: ["Ação", "Vingança"],
        descricao: "Descrição do filme",
        anoLancamento: 2015,
    },
];

filmes.forEach( ( {titulo, genero, descricao, anoLancamento}, i ) => {
    //const {titulo, genero, descricao, anoLancamento}

    console.log(`
        Filme: ${i+1}: ${titulo.toUpperCase()}
        Gênero: ${genero.toString()}
        Descrição: ${descricao}
        Ano de Lançamento: ${anoLancamento}
    `)
});