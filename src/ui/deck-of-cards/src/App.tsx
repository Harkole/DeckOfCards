import React from 'react';
import logo from './images/cards/1B.svg';
import './App.css';
import Button from '@material-ui/core/Button';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Get a deck to start
        </p>
      <Button variant="contained" color="primary">Get Deck</Button>
      </header>
    </div>
  );
}

export default App;
