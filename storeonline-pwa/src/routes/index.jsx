import {BrowserRouter, Routes, Route} from 'react-router-dom';
import CreateProduct from '../pages/CreateProduct';
import Home from "../pages/Home.jsx";
import Navbar from '../components/Navbar';
import Footer from "../components/Footer.jsx"; // Importe sua nova Navbar aqui

const AppRoutes = () => {
    return (
        <BrowserRouter>
            <div style={{display: 'flex', flexDirection: 'column', minHeight: '100vh'}}>
                <Navbar/>

                <main style={{flex: 1}}> {/* Isso empurra o footer para baixo */}
                    <Routes>
                        <Route path="/" element={<Home/>}/>
                        <Route path="/produtos/novo" element={<CreateProduct/>}/>
                    </Routes>
                </main>

                <Footer/>
            </div>
        </BrowserRouter>
    );
};

export default AppRoutes;