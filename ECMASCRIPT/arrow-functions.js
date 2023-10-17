const mesa = ["Coral", "Anna", "Demétrio", "Vinicius", "Lacerda", "Evelyn", "Luiz"]
4
//TODO ******************** CALL BACK FUNCTIONS *************************
// function Carlos(pessoa)
// {
//     console.log('Bom dia ' + pessoa);
// }

// mesa.forEach(cadaPessoa => Carlos(cadaPessoa));

/*
mesa.forEach(
    function Carlos(cadaPessoa){
        console.log('Bom dia ' + cadaPessoa)
    }
)
*/

//TODO **********Função Anonima************
/*
mesa.forEach(
    function (cadaPessoa) {
        console.log('Bom dia ' + cadaPessoa);
    }
)
*/

//TODO **********Arrow Functions************
/*
mesa.forEach( (cadaPessoa) => {
    console.log("Bom dia " + cadaPessoa);
});


const dobro = (x) => {
    return x * 2;
}
console.log ( dobro(15) );
*/

//TODO Forma simplificada com return implicito
/* const dobro = (x) => x * 2; //retorna o dobro
console.log( dobro(10) ) */

/*
const bomDia = () => "Bom dia"; //Sem parametro
console.log( bomDia() );
*/