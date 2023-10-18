/*Pega o numero antecessor e soma com o próximo que esta por vir por exemplo: 10+0=10, 10+12=22, 22+20=42 
o que altera é o numero 0 que está por ultimo na função de callback*/
const numeros = [10,12,20];

const somatorio = numeros.reduce((total, n) => {
    return total + n;
}, 0);

console.log(somatorio)


//Exemplo de produtos
const produtos = [
    {produto: "Camiseta", preco: 129.90},
    {produto: "Tênis", preco: 350.97},
    {produto: "Jaqueta de couro", preco: 700.01},
];


let totalProduto = produtos.reduce((valorInicial, oP) => {
    return valorInicial + oP.preco;
}, 0)

console.log(`Gerente, o total de vendas é: R$${totalProduto}`);


//Comissao do vendedor de 5%
const vendedor = "Gabriel";

let comissao = produtos.reduce((valorInicial, oP) => {
    return valorInicial + (oP.preco * 0.05);
}, 0);

console.log(`${vendedor} sua comissao é de ${comissao}`)