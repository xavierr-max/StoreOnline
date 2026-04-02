import React from 'react';
import '../styles/footer.css';

const Footer = () => {
    const currentYear = new Date().getFullYear();

    return (
        <footer className="main-footer">
            <div className="footer-content">
                <div className="footer-brand">
                    <div className="footer-logo">S</div>
                    <span>StoreOnline</span>
                </div>

                <div className="footer-info">
                    <p>&copy; {currentYear} Sistema de Gerenciamento de Vendas.</p>
                    <div className="footer-status-pill">
                        <span className="dot"></span>
                        Status da API: Conectado (Porta 5194)
                    </div>
                </div>

                <div className="footer-links">
                    <a href="#ajuda">Ajuda</a>
                    <a href="#suporte">Suporte</a>
                    <a href="#termos">Termos</a>
                </div>
            </div>
        </footer>
    );
};

export default Footer;