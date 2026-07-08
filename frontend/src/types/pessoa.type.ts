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