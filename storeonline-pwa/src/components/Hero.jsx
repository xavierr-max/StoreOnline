import React from 'react';
import { useNavigate } from 'react-router-dom';
import '../styles/hero.css';

const Hero = ({ title, subtitle, userName }) => {
    const navigate = useNavigate();

    const getGreeting = () => {
        const hour = new Date().getHours();
        if (hour < 12) return 'Bom dia';
        if (hour < 18) return 'Boa tarde';
        return 'Boa noite';
    };

    return (
        <div className="hero-container">
            <div className="hero-content">
                <div className="hero-text">
                    <span className="hero-greeting">
                        {getGreeting()}, {userName || 'Administrador'}! 👋
                    </span>
                    <h1>{title || 'StoreOnline Dashboard'}</h1>
                    <p>{subtitle || 'Gerencie seu inventário, vendas e relatórios em um só lugar.'}</p>

                    <div className="hero-actions">
                        <button
                            className="btn-primary"
                            onClick={() => navigate('/produtos/novo')}
                        >
                            ➕ Adicionar Novo Produto
                        </button>
                        <button className="btn-secondary">
                            📊 Ver Relatório Rápido
                        </button>
                    </div>
                </div>

                <div className="hero-visual">
                    <div className="abstract-chart">
                        <div className="bar bar-1"></div>
                        <div className="bar bar-2"></div>
                        <div className="bar bar-3"></div>
                        <div className="bar bar-4"></div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Hero;