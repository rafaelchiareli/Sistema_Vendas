
import React, { useState, useEffect } from 'react'

import './App.css';


const App = () => {
 
  const [registro, setRegistro] = useState({})


  const HandleChange = (evt, val) =>{

     registro[evt.target.id] = val;
     setRegistro({...registro})
    
  }
 

  return (
    <div className="App">
      <label>Clique no botão para somar</label>
      <input onChange={(e) => HandleChange(e, e.target.value)} type="text" id="nome" placeholder="Nome" value={registro.nome || ""}></input>
      <input onChange={(e) => HandleChange(e, e.target.value)}type="date" id="nascimento" placeholder="Nascimento"value={registro.nascimento }></input>
      <input onChange={(e) => HandleChange(e, e.target.value)}type="text" id="telefone" placeholder="Telefone"value={registro.telefone || ""}></input>
      <input onChange={(e) => HandleChange(e, e.target.value)}type="text" id="nomeMae" placeholder="Nome da Mae"value={registro.nomeMae || ""}></input>
    <button type='button' onClick={() => console.log(registro)}>Ver</button>
    </div>
  );
}

export default App;
