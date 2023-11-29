import './App.css';
// import Titulo from './Components/Titulo/Titulo';
import Rotas from './routes';
import { UserContext } from './context/AuthContext';
import { useState } from 'react';

const App = () => {
    const [userData, setUserData] = useState({})
    return (
        <UserContext.Provider value={{ userData, setUserData }}>
            <Rotas />
        </UserContext.Provider>


    );
};

export default App;
