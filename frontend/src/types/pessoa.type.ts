/**
 * Representa o resumo financeiro de uma pessoa.
 */
export interface Pessoa {
  id: number;
  nome: string;
  totalReceitas: number;
  totalDespesas: number;
  saldo: number;
}

/** Dados cadastrais de uma pessoa. Espelha PessoaResponseDto.cs do backend. */
export interface PessoaCadastro {
  id: number;
  nome: string;
  idade: number;
}