//Modulo para trabalhar com APIS, Disponibiliza
import axios from 'axios';

/**
 * Rota para o recurso Evento
 */
export const eventsResource = '/Evento';

/**
 * Rota para o recurso Login
 */
export const loginResource = '/Login';

/**
 * Rota para o recurso Próximos Eventos 
 */
export const nextEventResource = '/Evento/ListarProximos'

/**
 * Rota para o recurso Próximos Eventos 
 */
export const myEventsResource = '/PresencaEvento/ListarMinhas'

/**
 * Rota para o recurso Presença evento
 */
export const myComentaryResource = '/ComentariosEvento/BuscarPorIdUsuario'

/**
 * Rota para o recurso Presença evento
 */
export const presencesEventResource = '/PresencasEvento'

/**
 * Rota para o recurso para Eventos
 */
export const eventTypeResource = '/TiposEvento'

//Rota para o recurso Presenças Evento
export const commentaryEventResource = '/ComentariosEvento';


const apiPort = '7118';
// const localApiUrl = `https://localhost:${apiPort}/api`;
const externalApiUrl = 'https://eventwebapi-russo.azurewebsites.net/api';

const api = axios.create({
    baseURL: externalApiUrl
});

export default api;