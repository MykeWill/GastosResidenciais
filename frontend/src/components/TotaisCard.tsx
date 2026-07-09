/**
 * Exibe os totais gerais do relatório financeiro.
 */
interface TotaisCardProps {
  totalReceitas: number;
  totalDespesas: number;
  saldoLiquido: number;
}

export default function TotaisCard({
  totalReceitas,
  totalDespesas,
  saldoLiquido,
}: TotaisCardProps) {
  return (
    <section className="totais-gerais">
      <h2>Totais Gerais</h2>

      <p>💰 Receitas: R$ {totalReceitas.toFixed(2)}</p>

      <p>💸 Despesas: R$ {totalDespesas.toFixed(2)}</p>

      <p>📊 Saldo: R$ {saldoLiquido.toFixed(2)}</p>
    </section>
  );
}