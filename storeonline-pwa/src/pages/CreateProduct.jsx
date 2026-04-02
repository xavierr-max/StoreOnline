import React, {useState} from 'react';
import {createProduct} from '../services/productService';
import '../styles/create-product.css'; // Importando o arquivo CSS separado

const CreateProduct = () => {
    const [loading, setLoading] = useState(false);
    const [message, setMessage] = useState('');

    const [formData, setFormData] = useState({
        name: '',
        price: 0,
        stock: 0,
        description: ''
    });

    const handleChange = (e) => {
        const {name, value} = e.target;
        setFormData({
            ...formData,
            [name]: name === 'price' || name === 'stock' ? Number(value) : value
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setLoading(true);
        setMessage('');

        try {
            await createProduct(formData);
            setMessage('✅ Produto criado com sucesso!');
            setFormData({name: '', price: 0, stock: 0, description: ''});
        } catch (err) {
            setMessage(`❌ Erro: ${err.message || 'Falha na comunicação com a API'}`);
        } finally {
            setLoading(false);
        }
    };

    return (
        <div className="create-product-container">
            <h2>Cadastrar Novo Produto</h2>

            <form onSubmit={handleSubmit} className="create-product-form">
                <div className="form-group">
                    <label>Nome do Produto:</label>
                    <input
                        name="name"
                        value={formData.name}
                        onChange={handleChange}
                        required
                        className="form-input"
                    />
                </div>

                <div className="form-group">
                    <label>Preço:</label>
                    <input
                        type="number"
                        name="price"
                        step="0.01"
                        value={formData.price}
                        onChange={handleChange}
                        required
                        className="form-input"
                    />
                </div>

                <div className="form-group">
                    <label>Estoque Inicial:</label>
                    <input
                        type="number"
                        name="stock"
                        value={formData.stock}
                        onChange={handleChange}
                        required
                        className="form-input"
                    />
                </div>

                <div className="form-group">
                    <label>Descrição:</label>
                    <textarea
                        name="description"
                        value={formData.description}
                        onChange={handleChange}
                        className="form-textarea"
                    />
                </div>

                <button
                    type="submit"
                    disabled={loading}
                    className="submit-button"
                >
                    {loading ? 'Salvando...' : 'Salvar Produto'}
                </button>
            </form>

            {message && (
                <div className={`message-box ${message.includes('✅') ? 'message-success' : 'message-error'}`}>
                    {message}
                </div>
            )}
        </div>
    );
};

export default CreateProduct;