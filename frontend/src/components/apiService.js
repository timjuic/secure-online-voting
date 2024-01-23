import axios from 'axios';

const apiClient = axios.create({
  baseURL: 'https://localhost:7086/api/',
});

const getAuthToken = () => localStorage.getItem('token');

// Set the AUTH token for any request
apiClient.interceptors.request.use((config) => {
  const token = getAuthToken();
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
}, (error) => {
  return Promise.reject(error);
});

const registerUser = (userData) => apiClient.post('Auth/register', userData);

const loginUser = async (credentials) => {
  const response = await apiClient.post('Auth/login', credentials);
  if (response.data.token) {
    localStorage.setItem('token', response.data.token); 
  }
  return response.data;
};

const submitVote = async (voteData) => {
  const response = await apiClient.post('Vote/submit', voteData);
  return response.data;
};

const getAllElections = () => apiClient.get('Election/getall');

export { registerUser, loginUser, getAllElections, submitVote };