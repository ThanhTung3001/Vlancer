import { useState } from 'react'
import { BrowserRouter, Route, Routes } from "react-router-dom";
import './App.css'
import { routes } from './routes';
import PrivateRoute from './routes/PrivateRoute';
import Home from './pages/home/Index';
import About from './pages/about';
import Contact from './pages/contact/Index';
import Login from './pages/auth/Login';
import Dashboard from './pages/dashboard/Index';

function App() {

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/about" element={<About />} />
        <Route path="/contact" element={<Contact />} />
        <Route path="/login" element={<Login />} />
        <Route
          path="/dashboard"
          element={<Dashboard />}

        />
      </Routes>
    </BrowserRouter>
  )
}

export default App
