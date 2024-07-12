import { Imcs } from "./imcs";
export interface Aluno{
    alunoId: string;
    nome: string;
    sobrenome: string;
    altura: string;
    peso: string;
    Imcs? : Imcs;
    criadoEm?: string;
}