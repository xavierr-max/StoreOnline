import { BrowserRouter, Routes, Route, Link } from 'react-router-dom';
import CreateProduct from '../pages/CreateProduct';

const Home = () => (
  <div style={{ padding: '20px' }}>
    <h1>Bem-vindo ao StoreOnline</h1>
    <p>Selecione uma opção no menu acima.</p>
  </div>
);

const AppRoutes = () => {
  return (
    <BrowserRouter>
      {/* Um menu simples para você navegar */}
      <nav style={{ padding: '20px', backgroundColor: '#f4f4f4', marginBottom: '20px', display: 'flex', gap: '15px' }}>
        <Link to="/" style={{ textDecoration: 'none', color: '#333', fontWeight: 'bold' }}>Home</Link>
        <Link to="/produtos/novo" style={{ textDecoration: 'none', color: '#333', fontWeight: 'bold' }}>Novo Produto</Link>
      </nav>

      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/produtos/novo" element={<CreateProduct />} />
      </Routes>
    </BrowserRouter>
  );
};

export default AppRoutes;