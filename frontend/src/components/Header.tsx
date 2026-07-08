import { Link } from "react-router-dom";

/**
 * Cabeçalho da aplicação.
 * Contém a navegação entre as páginas.
 */
export default function Header() {
    return (
        <header>
            <nav>
                <Link to="/">Dashboard</Link>{" | "}
                <Link to="/pessoas">Pessoas</Link>{" | "}
                <Link to="/transacoes">Transações</Link>
            </nav>

            <hr />
        </header>
    );
}