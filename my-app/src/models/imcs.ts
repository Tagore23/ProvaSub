import { Aluno } from "./aluno";
export interface Imcs{
    id: string;
    alunoId?: string;
    peso: string;
    altura: string;
    valorImc: string;
    Aluno?: Aluno;
    classificacao: string;
    dataCriacao?: string;
}