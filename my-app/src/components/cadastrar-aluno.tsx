import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Aluno } from "../models/aluno";
import { styled } from "styled-components";

const Button = styled.button`
  background: black;
  color: white;
  font-size: 1em;
  margin: 1em;
  padding: 0.25em 1em;
  border: 2px solid grey;
  border-radius: 3px;
`;

function CadastrarAluno() {
  const navigate = useNavigate();
  const [nome, setNome] = useState("");
  const [sobrenome, setSobrenome] = useState("");
  const [peso, setPeso] = useState("");
  const [altura, setAltura] = useState("");
  const [alunoId, setAlunoId] = useState("");
  const [alunos, setAlunos] = useState<Aluno[]>([]);

  

  function cadastrarAluno(e: any) {
    const aluno: Aluno = {
        nome: nome,
        sobrenome: sobrenome,
        peso: peso,
        altura: altura,
        alunoId: alunoId,
    };

    //FETCH ou AXIOS
    fetch("http://localhost:5250/aluno/cadastrar", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(aluno),
    })
      .then((resposta) => resposta.json())
      .then((aluno: Aluno) => {
        navigate("/pages/aluno/listar");
      });
    e.preventDefault();
  }

  return (
    <div>
      <h1>Cadastrar Aluno</h1>
      <form onSubmit={cadastrarAluno}>
        <label>Nome:</label>
        <input
          type="text"
          placeholder="Digite o nome"
          onChange={(e: any) => setNome(e.target.value)}
          required
        />
        <br />
        <label>Sobrenome:</label>
        <input
          type="text"
          placeholder="Digite o sobrenome"
          onChange={(e: any) => setSobrenome(e.target.value)}
        />
        <br />
        <label>Peso:</label>
        <input
          type="text"
          placeholder="Digite o peso"
          onChange={(e: any) => setPeso(e.target.value)}
        />
        <input
          type="text"
          placeholder="Digite a altura"
          onChange={(e: any) => setAltura(e.target.value)}
        />
       
        <br />
        <button type="submit">Cadastrar</button>
      </form>
    </div>
  );
}

export default CadastrarAluno;