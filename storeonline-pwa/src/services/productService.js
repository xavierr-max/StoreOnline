import api from './api'; // Importa a configuração que criamos acima

export const createProduct = async (productData) => {
  try {
    // Faz um POST para http://localhost:5194/api/products
    // O seu C# receberá o JSON e fará o bind automático para o seu DTO Request
    const response = await api.post('/products', productData);
    return response.data;
  } catch (error) {
    // Se o C# retornar um erro (ex: validação do FluentValidation ou erro 500),
    // nós capturamos aqui e jogamos de volta para o componente exibir na tela
    throw error.response?.data || new Error("Erro ao conectar com o servidor da API.");
  }
};

// Quando você for criar a listagem no futuro, basta adicionar aqui:
// export const getProducts = async () => { ... }