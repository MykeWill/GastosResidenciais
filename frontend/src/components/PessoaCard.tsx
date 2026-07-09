import type { Pessoa } from "../types/pessoa.type";

/** Exibe o resumo financeiro de uma pessoa, com avatar e barra de progresso do saldo. */
interface PessoaCardProps {
  pessoa: Pessoa;
}

export default function PessoaCard({ pessoa }: PessoaCardProps) {
  // % do saldo em relação às receitas, usada para preencher a barra de progresso.
  const percentual = pessoa.totalReceitas > 0
    ? Math.max(0, Math.min(100, (pessoa.saldo / pessoa.totalReceitas) * 100))
    : 0;

  return (
    <section className="pessoa-card">
      <div className="pessoa-header">
        <h3>{pessoa.nome}</h3>
        {/* Avatar com a inicial do nome */}
        <div className="avatar">{pessoa.nome.charAt(0).toUpperCase()}</div>
      </div>

      <p>Receitas: R$ {pessoa.totalReceitas.toFixed(2)}</p>
      <p>Despesas: R$ {pessoa.totalDespesas.toFixed(2)}</p>
      <p className={pessoa.saldo < 0 ? "saldo-negativo" : ""}>
         Saldo: R$ {pessoa.saldo.toFixed(2)}
      </p>

      {/* Barra de progresso representando o saldo sobre as receitas */}
      <div className="barra-progresso">
        <div
          className="barra-progresso-preenchida"
          style={{ width: `${percentual}%` }}
        />
      </div>
    </section>
  );
}