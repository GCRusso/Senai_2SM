// Importa o arquivo de estilos "App.css" para estilizar o componente App
import './App.css';
import Title from './components/Title/Title';
import CardEvento from './components/CardEventos/CardEvento';
import Container from './components/Container/Container';

// Define a função do componente App
function App() {
  return (
    <div className="App">

      <h1>Hello World React</h1>
      <Title nome="Gabriel" sobrenome="Russo" />

      <Container>
        <CardEvento titulo="Título Evento" descricao="Breve descrição do evento, pode ser um paragrafo pequeno" link="Conectar" />

        <CardEvento titulo="SQL Server" descricao="Iniciando em SQL Server, será um evento criado pelo professor Eduardo Costa" link="Conectar" />
      </Container>
      
    </div>
  );

}

// Exporta o componente App para que ele possa ser usado como ponto de entrada na aplicação
export default App;
