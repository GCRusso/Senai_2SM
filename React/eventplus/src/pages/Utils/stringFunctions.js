export const dateFormatDbToView = data => {
    //Transformando a data 2023-11-15T00:00:00 para 15/11/2023

    data = data.substr(0 ,10); // retorna apenas a data (2023-11-15)
    data = data.split("-"); // [2023, 09, 30] transformamos a data em um array





    return `${data[2]}/${data[1]}/${data[0]}`; //retornamos o array data na sequencia que queremos
}

//DEFAULT so pode ser usado 1 por modulo, EXPORT ilimitado
export default function xpto(x){




    return x + 1;
}