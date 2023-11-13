//Modulo para trabalhar com APIS, Disponibiliza
import axios from 'axios';

/**
 * Rota para o recurso Evento
 */
export const eventsResource = '/Evento';

/**
 * Rota para o recurso Próximos Eventos 
 */
export const nextEventResource = '/Evento/ListarProximos'

/**
 * Rota para o recurso para Eventos
 */
export const eventTypeResource = '/TiposEvento'

const apiPort = '7118';
const localApiUrl = `https://localhost:${apiPort}/api`;
const externalApiUrl = null;

const api = axios.create({
    baseURL: localApiUrl
});

export default api;