import './App.css';
import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import LoginPage from './components/loginPage';
import RegisterPage from './components/registerPage';
import ElectionPage from './components/electionPage';
import VotePage from './components/votePage';

function App() {
  return (
    <Router>
      <div className="App">
        <Routes>
          <Route path="/login" element={<LoginPage />} />
          <Route path="/register" element={<RegisterPage />} />
          <Route path="/election" element={<ElectionPage />} />
          <Route path="/vote" element={<VotePage />} />
          <Route path="/" element={<LoginPage />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
