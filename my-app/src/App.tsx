import React from "react";
import { BrowserRouter, Link, Route, Routes } from "react-router-dom";
import styled, { createGlobalStyle } from "styled-components";
import ListarAlunos from "./components/listar-aluno";
import ListarImcs from "./components/listar-imcs";
import CadastrarAluno from "./components/cadastrar-aluno";
import CadastrarImc from "./components/cadastrar-imc";


const GlobalStyle = createGlobalStyle`
  body, html, #root {
    margin: 0;
    padding: 0;
    width: 100%;
    height: 100%;
  }
`;

const StyledNavLink = styled(Link)`
  text-decoration: none;
  color: white;
  margin-right: 15px;
  font-weight: bold;
 font-family: Arial, sans-serif;
  &:hover {
    color: #123;
  }
`;
const PageContainer = styled.div`
  background-color: #343541; 
  color: white;
  min-height: 100vh; 
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
`;


// Componente estilizado para o conteúdo principal
const MainContent = styled.div`
  padding: 20px;
  font-family: Arial, sans-serif;
  color: white;
`;
function App() {
  return (
    <div>
      <GlobalStyle />
      <PageContainer>
      <div>
        <BrowserRouter>
          <nav>
            <ul>
              <li>
                <StyledNavLink to={"/"}>Home</StyledNavLink>
              </li>
              <li>
                <StyledNavLink to={"/pages/aluno/listar"}>
                  Listar Alunos{" "}
                </StyledNavLink>
              </li>
              <li>
                <StyledNavLink to={"/pages/imc/listar"}>
                  Listar Imcs{" "}
                </StyledNavLink>
              </li>
              <li>
                <StyledNavLink to={"/pages/imc/cadastrar"}>
                  Cadastrar Imcs{" "}
                </StyledNavLink>
              </li>
              <li>
                <StyledNavLink to={"/pages/aluno/cadastrar"}>
                  Cadastrar Alunos{" "}
                </StyledNavLink>
              </li>
            </ul>
          </nav>
          <MainContent>
          <Routes>
            <Route path="/" element={<ListarAlunos />} />
            <Route
              path="/pages/aluno/listar"
              element={<ListarAlunos />}
            />
            <Route
              path="/pages/imc/listar"
              element={<ListarImcs />}
            />
              <Route
              path="/pages/aluno/cadastrar"
              element={<CadastrarAluno />}
            />
            <Route
              path="/pages/imc/cadastrar"
              element={<CadastrarImc />}
            />

          
          </Routes>
          <footer>
            <p>Desenvolvido por Tagore Nataniel de Lara</p>
          </footer>
          </MainContent>
        </BrowserRouter>
      </div>
      </PageContainer>
    </div>
  );
}

export default App;