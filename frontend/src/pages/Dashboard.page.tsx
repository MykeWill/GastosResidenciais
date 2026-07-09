import { useEffect, useState } from "react";
import { api } from "../services/api";
import type { Relatorio } from "../types/relatorio.type";
import TotaisCard from "../components/TotaisCard";
import PessoaCard from "../components/PessoaCard";


export default function Dashboard() {
  const [relatorio, setRelatorio] = useState<Relatorio | null>(null);

  useEffect(() => {
    async function carregarRelatorio() {
      try {
        const response = await api.get<Relatorio>("/relatorios/totais");
        setRelatorio(response.data);
      } catch (error) {
        console.error("Erro ao carregar relatório:", error);
      }
    }

    carregarRelatorio();
  }, []);

  if (!relatorio) {
    return <h2>Carregando...</h2>;
  }

return (
  <div>
    <h1>Dashboard</h1>

    <div className="dashboard-layout">
      <TotaisCard
        totalReceitas={relatorio.totalReceitas}
        totalDespesas={relatorio.totalDespesas}
        saldoLiquido={relatorio.saldoLiquido}
      />

      <div className="dashboard-pessoas">
        <h2>Pessoas</h2>
        <div className="grid-pessoas">
          {relatorio.pessoas.map((pessoa) => (
          <PessoaCard key={pessoa.id} pessoa={pessoa} />
          ))}
       </div>
      </div>
      
    </div>
  </div>
);
}