import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Aluno as Imc } from "../models/aluno";
import { Imcs } from "../models/imcs";
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

function CadastrarImc() {
  const navigate = useNavigate();
  const [peso, setPeso] = useState("");
  const [altura, setAltura] = useState("");
  const [alunoId, setAlunoId] = useState("");
  const [imcs, setImcs] = useState<Imc[]>([]);

  

  function cadastrarImc(e: any) {
    const imc: Imc = {
        peso: peso,
        altura: altura,
        alunoId: alunoId,
        nome: "",
        sobrenome: ""
    };

    //FETCH ou AXIOS
    fetch("http://localhost:5250/imc/cadastrar", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(imc),
    })
      .then((resposta) => resposta.json())
      .then((imc: Imc) => {
        navigate("/pages/imc/listar");
      });
    e.preventDefault();
  }

  return (
    <div>
      <h1>Cadastrar Aluno</h1>
      <form onSubmit={cadastrarImc}>
        <label>Nome:</label>
        <input
          type="text"
          placeholder="Digite o peso"
          onChange={(e: any) => setPeso(e.target.value)}
          required
        />
        <br />
        <label>Sobrenome:</label>
        <input
          type="text"
          placeholder="Digite a altura"
          onChange={(e: any) => setAltura(e.target.value)}
        />
        <br />
      

       
        <br />
        <button type="submit">Cadastrar</button>
      </form>
    </div>
  );
}

export default CadastrarImc;