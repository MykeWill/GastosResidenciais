import type { Pessoa } from "./pessoa.type";


/**
 * Representa o relatório financeiro geral.
 */
export interface Relatorio {
  pessoas: Pessoa[];
  totalReceitas: number;
  totalDespesas: number;
  saldoLiquido: number;
}