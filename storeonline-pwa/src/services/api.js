import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:5194/v1', // A porta exata do seu backend C#
  headers: {
    'Content-Type': 'application/json'
  }
});

// Interceptor: ajuda a capturar e exibir erros de forma mais clara no console (F12)
api.interceptors.response.use(
  response => response,
  error => {
    console.error("Detalhes do erro da API:", error.response?.data || error.message);
    return Promise.reject(error);
  }
);

export default api;