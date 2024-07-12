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
const StyledButton = styled.button`
  background-color: #123; 
  color: white; 
  padding: 10px 20px; 
  border: none; 

  font-size: 16px;
  cursor: pointer; 
  transition: background-color 0.3s;

  &:hover {
    background-color: #123; 
  }
`;

const StyledTableCell = styled.td`
  padding: 12px;
  text-align: left;
  font-family: Arial, sans-serif;
`;

function ListarAlunos() {
  const [alunos, setAlunos] = useState<Aluno[]>([]);

  useEffect(() => {
    carregarAlunos();
  }, []);

  function carregarAlunos() {
    //FETCH ou AXIOS
    fetch("http://localhost:5250/aluno/listar")
      .then((resposta) => resposta.json())
      .then((alunos: Aluno[]) => {
        console.table(alunos);
        setAlunos(alunos);
      });
  }

  

  return (
    <div>
      <h1>Listar Alunos</h1>
      <StyledTable>
        
        <thead>
          <tr>
            <th>#</th>
            <th>Nome</th>
            <th>Sobrenome</th>
            <th>Altura</th>
            <th>Peso</th>
            <th>Criado Em</th>
          </tr>
        </thead>
        <tbody>
          {alunos.map((aluno, categoria) => (
            <tr key={aluno.alunoId}>
              <StyledTableCell>{aluno.alunoId}</StyledTableCell>
              <StyledTableCell>{aluno.nome}</StyledTableCell>
              <StyledTableCell>{aluno.sobrenome}</StyledTableCell>
              <StyledTableCell>{aluno.altura}</StyledTableCell>
              <StyledTableCell>{aluno.peso}</StyledTableCell>
              <StyledTableCell>{aluno.criadoEm}</StyledTableCell>
            </tr>
          ))}
        </tbody>
        </StyledTable>
    </div>
  );
}

export default ListarAlunos;