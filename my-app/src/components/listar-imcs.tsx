import { useEffect, useState } from "react";
import { Imcs } from "../models/imcs";
import axios from "axios";
import { styled } from "styled-components";
import { Link } from "react-router-dom";
import { Aluno } from "../models/aluno";



const StyledTable = styled.table`
  width: 100%;
  border-collapse: collapse;
  margin-top: 20px;
  th, td {
    border: 1px solid black;
    padding: 8px;
    text-align: left;
  }
  th {
    background-color: #123;
  }
`;


const StyledTableCell = styled.td`
  padding: 12px;
  text-align: left;
  font-family: Arial, sans-serif;
`;

function ListarImcs() {
  const [Imcs, setImcs] = useState<Imcs[]>([]);

  useEffect(() => {
    carregarImcs();
  }, []);

  function carregarImcs() {
    //FETCH ou AXIOS
    fetch("http://localhost:5250/imc/listar")
      .then((resposta) => resposta.json())
      .then((imcs: Imcs[]) => {
        console.table(imcs);
        setImcs(imcs);
      });
  }

  

  return (
    <div>
      <h1>Listar Imcs</h1>
      <StyledTable>
        
        <thead>
          <tr>
            <th>Id</th>
            <th>AlunoId</th>
            <th>Peso</th>
            <th>Altura</th>
            <th>Classificação</th>
            <th>Criado Em</th>
          </tr>
        </thead>
        <tbody>
          {Imcs.map((imcs) => (
            <tr key={imcs.alunoId}>
              <StyledTableCell>{imcs.id}</StyledTableCell>
              <StyledTableCell>{imcs.alunoId}</StyledTableCell>
              <StyledTableCell>{imcs.peso}</StyledTableCell>
              <StyledTableCell>{imcs.altura}</StyledTableCell>
              <StyledTableCell>{imcs.classificacao}</StyledTableCell>
              <StyledTableCell>{imcs.dataCriacao}</StyledTableCell>
            </tr>
          ))}
        </tbody>
        </StyledTable>
    </div>
  );
}

export default ListarImcs;