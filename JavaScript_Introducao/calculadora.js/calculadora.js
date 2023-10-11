function calcular(){

    //Para parar o submit do formulário, pois ele apenas pisca mostrando o resultado
    event.preventDefault();
    
    //Criamos uma variável para cada item
    let n1 = Number.parseFloat(document.getElementById("n1").value);
    let n2 = Number.parseFloat(document.getElementById("n2").value);
    let op = (document.getElementById("operacao").value);
    let resultado;

    //isNan = Validação caso o usuário deixe o campo em branco
    if( isNaN(n1) || isNaN(n2))
    {
        alert('Favor inserir somente números.');
        return;
    }

    switch (op) {

        case "+":
        resultado = somar(n1,n2)
            break;
            
            case "-":
            resultado = subtrair(n1,n2)
                break;

            case "/":
            resultado = dividir(n1,n2)
                break;

            case "*":
            resultado = multiplicar(n1,n2)
                break;
    
        default:
            alert('Favor inserir o operador!')
            break;
    }
    //Inserindo o resultado no HTML (DOM)
    //Utilizamos innerText para inserir o texto que foi gerado no resultado lá no HTML
    document.getElementById('result').innerText = resultado;
        
    
        //alert(`O Resultado é: ${resultado}`) //Para visualizar o resultado via alert

        //console.log(`A Soma é: ${resultado}`) //Para visualizar os resultados via console
}

function subtrair(x,y){
    return x - y;
}
function somar(x,y){
    return x + y;
}
function multiplicar(x,y){
    return x * y;
}
function dividir(x,y){
    //Validação caso o usuário tente dividir algo por 0, sem essa validação retornaria o valor Infinity
    if( 0 == y)
    {
        return "Não é possível dividir por 0"
    }
    return x / y;
}