import { useEffect, useState } from "react";
import { api } from "../services/api";
import type { Transacao } from "../types/transacao.type";
import type { PessoaCadastro } from "../types/pessoa.type";

/**
 * Página responsável pelo gerenciamento das transações.
 * Consome GET /api/transacoes para listar, POST para cadastrar,
 * PUT para editar e DELETE para excluir.
 * A regra "menor de idade só cadastra despesa" é validada pelo
 * próprio backend; aqui só exibimos o erro retornado.
 */
export default function Transacoes() {
  const [transacoes, setTransacoes] = useState<Transacao[]>([]);
  const [pessoas, setPessoas] = useState<PessoaCadastro[]>([]);
  const [carregando, setCarregando] = useState(true);
  const [erro, setErro] = useState("");
  const [editandoId, setEditandoId] = useState<number | null>(null);

  const [descricao, setDescricao] = useState("");
  const [valor, setValor] = useState("");
  const [tipo, setTipo] = useState("0");
  const [pessoaId, setPessoaId] = useState("");

  useEffect(() => {
    carregarDados();
  }, []);

  /** Busca transações e pessoas (para preencher o select). */
  async function carregarDados() {
    try {
      const [resTransacoes, resPessoas] = await Promise.all([
        api.get<Transacao[]>("/transacoes"),
        api.get<PessoaCadastro[]>("/pessoas"),
      ]);
      setTransacoes(resTransacoes.data);
      setPessoas(resPessoas.data);
    } catch (error) {
      console.error("Erro ao carregar dados:", error);
    } finally {
      setCarregando(false);
    }
  }

  /** Envia o formulário: cria uma transação nova ou salva a edição, e recarrega a lista. */
  async function handleSalvar(e: React.SyntheticEvent) {
    e.preventDefault();
    setErro("");
    const dto = {
      descricao,
      valor: Number(valor),
      tipo: Number(tipo),
      pessoaId: Number(pessoaId),
    };
    try {
      if (editandoId) {
        await api.put(`/transacoes/${editandoId}`, dto);
      } else {
        await api.post("/transacoes", dto);
      }
      setDescricao("");
      setValor("");
      setEditandoId(null);
      carregarDados();
    } catch (error: any) {
      const mensagens = error.response?.data?.erros;
      setErro(mensagens ? mensagens.join(", ") : "Erro ao salvar transação.");
    }
  }

  /** Preenche o formulário com os dados da transação selecionada para edição. */
  function handleEditar(t: Transacao) {
    setEditandoId(t.id);
    setDescricao(t.descricao);
    setValor(String(t.valor));
    setTipo(String(t.tipo));
    setPessoaId(String(t.pessoaId));
  }

  /** Cancela a edição em andamento e limpa o formulário. */
  function handleCancelar() {
    setEditandoId(null);
    setDescricao("");
    setValor("");
    setTipo("0");
    setPessoaId("");
    setErro("");
  }

  /** Exclui uma transação e recarrega a lista. */
  async function handleExcluir(id: number) {
    if (!window.confirm("Excluir esta transação?")) return;
    try {
      await api.delete(`/transacoes/${id}`);
      carregarDados();
    } catch (error) {
      console.error("Erro ao excluir transação:", error);
    }
  }

  /** Busca o nome da pessoa pelo id, para exibir na listagem. */
  function nomePessoa(id: number) {
    return pessoas.find((p) => p.id === id)?.nome ?? "—";
  }

  if (carregando) return <h2>Carregando...</h2>;

  /** Renderiza o formulário de cadastro/edição e a tabela de transações. */
  return (
    <div>
      <h1>Transações</h1>

      <form onSubmit={handleSalvar}>
        <input
          type="text"
          placeholder="Descrição"
          value={descricao}
          onChange={(e) => setDescricao(e.target.value)}
          required
        />
        <input
          type="number"
          placeholder="Valor"
          value={valor}
          onChange={(e) => setValor(e.target.value)}
          required
        />
        <select value={tipo} onChange={(e) => setTipo(e.target.value)}>
          <option value="0">Despesa</option>
          <option value="1">Receita</option>
        </select>
        <select value={pessoaId} onChange={(e) => setPessoaId(e.target.value)} required>
          <option value="">Selecione a pessoa</option>
          {pessoas.map((p) => (
            <option key={p.id} value={p.id}>{p.nome}</option>
          ))}
        </select>
        <button type="submit">{editandoId ? "Salvar" : "Cadastrar"}</button>
        {editandoId && (
          <button type="button" onClick={handleCancelar}>Cancelar</button>
        )}
      </form>

      {/* className="erro" aplica o estilo de caixa vermelha definido no App.css */}
      {erro && <p className="erro">{erro}</p>}

      {/* Tabela com cabeçalho nomeando cada coluna (Descrição, Valor, Tipo, Pessoa, Ações) */}
      <table className="tabela-transacoes">
        <thead>
          <tr>
            <th>Descrição</th>
            <th>Valor</th>
            <th>Tipo</th>
            <th>Pessoa</th>
            <th>Ações</th>
          </tr>
        </thead>
        <tbody>
          {transacoes.map((t) => (
            <tr key={t.id}>
              <td>{t.descricao}</td>
              <td>R$ {t.valor.toFixed(2)}</td>
              <td>{t.tipo === 0 ? "Despesa" : "Receita"}</td>
              <td>{nomePessoa(t.pessoaId)}</td>
              <td>
                <button onClick={() => handleEditar(t)}>Editar</button>{" "}
                <button onClick={() => handleExcluir(t.id)}>Excluir</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}