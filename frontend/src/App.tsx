import { Routes, Route } from "react-router-dom";
import Dashboard from "./pages/Dashboard.page";
import Pessoas from "./pages/Pessoas.page";
import Transacoes from "./pages/Transacoes.page";
import MainLayout from "./layouts/MainLayout";



function App() {
    return (
        <Routes>
          <Route element={<MainLayout />}>
            <Route path="/" element={<Dashboard />} />
            <Route path="/pessoas" element={<Pessoas />} />
            <Route path="/transacoes" element={<Transacoes />} />
          </Route>
        </Routes>
    );
}

export default App;