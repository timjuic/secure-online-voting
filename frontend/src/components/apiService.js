import axios from 'axios';

const apiClient = axios.create({
  baseURL: 'https://localhost:7086/api/',
});

const registerUser = (userData) => apiClient.post('Auth/register', userData);
const loginUser = (credentials) => apiClient.post('Auth/login', credentials);

export { registerUser, loginUser };
