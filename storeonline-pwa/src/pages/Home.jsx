import React from 'react';
import { useNavigate } from 'react-router-dom';
import '../styles/home.css';
import Hero from "../components/Hero.jsx";

const Home = () => {
    const navigate = useNavigate();

    return (
        <div className="home-container">
            <Hero
                title="StoreOnline Dashboard"
                subtitle="Seu painel centralizado para gerenciamento rápido de vendas e estoque."
            />

            <div className="dashboard-grid">
                {/* Card para Navegar para Cadastro */}
                <div className="stats-card" onClick={() => navigate('/produtos/novo')}>
                    <div className="card-icon">➕</div>
                    <div className="card-info">
                        <h3>Novo Produto</h3>
                        <p>Cadastre itens no estoque</p>
                    </div>
                </div>

                {/* Placeholder para futuras implementações */}
                <div className="stats-card disabled">
                    <div className="card-icon">📦</div>
                    <div className="card-info">
                        <h3>Ver Estoque</h3>
                        <p>Em breve: Lista de produtos</p>
                    </div>
                </div>

                <div className="stats-card disabled">
                    <div className="card-icon">📊</div>
                    <div className="card-info">
                        <h3>Relatórios</h3>
                        <p>Em breve: Gráficos de vendas</p>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Home;