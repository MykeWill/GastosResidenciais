/** Espelha o enum TipoTransacao do backend: Despesa=0, Receita=1. */
export interface Transacao {
  id: number;
  descricao: string;
  valor: number;
  tipo: number;
  pessoaId: number;
}