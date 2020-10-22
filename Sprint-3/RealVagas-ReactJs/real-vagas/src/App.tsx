import React from 'react';
import Header from '../src/components/Header/index';
import Footer from '../src/components/Footer/index';
import { Router } from 'react-router-dom';
import Routers from './routers';

function App() {
  return (
    <div className="App">
      <Routers/>
    </div>
  );
}

export default App;
