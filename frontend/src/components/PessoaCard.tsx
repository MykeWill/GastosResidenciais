import type { Pessoa } from "../types/pessoa.type";


/**
 * Exibe o resumo financeiro de uma pessoa.
 */
interface PessoaCardProps {
  pessoa: Pessoa;
}

export default function PessoaCard({ pessoa }: PessoaCardProps) {
  return (
    <section>
      <h3>{pessoa.nome}</h3>

      <p>Receitas: R$ {pessoa.totalReceitas.toFixed(2)}</p>

      <p>Despesas: R$ {pessoa.totalDespesas.toFixed(2)}</p>

      <p>Saldo: R$ {pessoa.saldo.toFixed(2)}</p>

      <hr />
    </section>
  );
}