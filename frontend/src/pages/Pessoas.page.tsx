import { useEffect, useState } from "react";
import { api } from "../services/api";
import type { PessoaCadastro } from "../types/pessoa.type";

/**
 * Página responsável pelo gerenciamento das pessoas.
 * Consome GET /api/pessoas para listar, POST para cadastrar,
 * PUT para editar e DELETE para excluir.
 */
export default function Pessoas() {
  const [pessoas, setPessoas] = useState<PessoaCadastro[]>([]);
  const [carregando, setCarregando] = useState(true);
  const [nome, setNome] = useState("");
  const [idade, setIdade] = useState("");
  const [erro, setErro] = useState("");
  const [editandoId, setEditandoId] = useState<number | null>(null);

  useEffect(() => {
    carregarPessoas();
  }, []);

  /** Busca a lista atualizada de pessoas na API. */
  async function carregarPessoas() {
    try {
      const response = await api.get<PessoaCadastro[]>("/pessoas");
      setPessoas(response.data);
    } catch (error) {
      console.error("Erro ao carregar pessoas:", error);
    } finally {
      setCarregando(false);
    }
  }

  /** Envia o formulário: cria uma pessoa nova ou salva a edição, e recarrega a lista. */
  async function handleSalvar(e: React.SyntheticEvent) {
    e.preventDefault();
    setErro("");
    try {
      if (editandoId) {
        await api.put(`/pessoas/${editandoId}`, { nome, idade: Number(idade) });
      } else {
        await api.post("/pessoas", { nome, idade: Number(idade) });
      }
      setNome("");
      setIdade("");
      setEditandoId(null);
      carregarPessoas();
    } catch (error: any) {
      const mensagens = error.response?.data?.erros;
      setErro(mensagens ? mensagens.join(", ") : "Erro ao salvar pessoa.");
    }
  }

  /** Preenche o formulário com os dados da pessoa selecionada para edição. */
  function handleEditar(pessoa: PessoaCadastro) {
    setEditandoId(pessoa.id);
    setNome(pessoa.nome);
    setIdade(String(pessoa.idade));
  }

  /** Cancela a edição em andamento e limpa o formulário. */
  function handleCancelar() {
    setEditandoId(null);
    setNome("");
    setIdade("");
    setErro("");
  }

  /** Exclui uma pessoa (e suas transações) e recarrega a lista. */
  async function handleExcluir(id: number) {
    if (!window.confirm("Excluir esta pessoa também excluirá todas as suas transações. Continuar?")) return;
    try {
      await api.delete(`/pessoas/${id}`);
      carregarPessoas();
    } catch (error) {
      console.error("Erro ao excluir pessoa:", error);
    }
  }

  if (carregando) return <h2>Carregando...</h2>;

  /** Renderiza o formulário de cadastro/edição e a lista de pessoas. */
  return (
    <div>
      <h1>Pessoas</h1>

      <form onSubmit={handleSalvar}>
        <input
          type="text"
          placeholder="Nome"
          value={nome}
          onChange={(e) => setNome(e.target.value)}
          required
        />
        <input
          type="number"
          placeholder="Idade"
          value={idade}
          onChange={(e) => setIdade(e.target.value)}
          required
        />
        <button type="submit">{editandoId ? "Salvar" : "Cadastrar"}</button>
        {editandoId && (
          <button type="button" onClick={handleCancelar}>Cancelar</button>
        )}
      </form>

      {/* className="erro" aplica o estilo de caixa vermelha definido no App.css */}
      {erro && <p className="erro">{erro}</p>}

      {/* className="item-lista" aplica o estilo de "card" definido no App.css */}
      {pessoas.map((pessoa) => (
        <p key={pessoa.id} className="item-lista">
          {pessoa.nome} — {pessoa.idade} anos{" "}
          <span>
            <button onClick={() => handleEditar(pessoa)}>Editar</button>{" "}
            <button onClick={() => handleExcluir(pessoa.id)}>Excluir</button>
          </span>
        </p>
      ))}
    </div>
  );
}