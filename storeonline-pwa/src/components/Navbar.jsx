import React from 'react';
import { useNavigate, Link } from 'react-router-dom';
import '../styles/navbar.css';

const Navbar = () => {
    const navigate = useNavigate();

    return (
        <nav className="navbar">
            <div className="navbar-content">
                <div className="navbar-brand" onClick={() => navigate('/')}>
                    <div className="logo-icon">S</div>
                    <span>StoreOnline</span>
                </div>

                <ul className="navbar-links">
                    <li><Link to="/">Dashboard</Link></li>
                    <li><Link to="/produtos/novo">Novo Produto</Link></li>
                    <li><Link to="/estoque" className="disabled-link">Estoque</Link></li>
                </ul>

                <div className="navbar-user">
                    <div className="user-avatar">
                        <img src="https://ui-avatars.com/api/?name=Admin&background=6366f1&color=fff" alt="User" />
                    </div>
                    <span className="user-name">Administrador</span>
                </div>
            </div>
        </nav>
    );
};

export default Navbar;