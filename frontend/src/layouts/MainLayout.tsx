import { Outlet } from "react-router-dom";
import Header from "../components/Header";

/**
 * Layout principal da aplicação.
 * Exibe os componentes compartilhados entre todas as páginas.
 */
export default function MainLayout() {
    return (
        <>
            <Header />
            <main>
                <Outlet />
            </main>
        </>
    );
}