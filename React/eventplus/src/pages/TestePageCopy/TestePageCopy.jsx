import React, { useEffect, useState } from 'react';

const TestePageCopy = () => {
    
    const [count, setCount] = useState(0); //Valor que inicia a contagem
    const [calculation, setCalculation] = useState(0);

    //Executa quando o componente for montado
    //e quando o state count for alterado
    useEffect(() => {
        setCalculation(count * 2); // por quantas X sera multiplicado
    }, [count]);

    return (
        <>
            <p> Count: {count}</p>
            <button onClick={() => setCount((c) => c + 1)}> + </button> {/* */}
            <p>Calculation: {calculation}</p>
        </>
    );
};

export default TestePageCopy;