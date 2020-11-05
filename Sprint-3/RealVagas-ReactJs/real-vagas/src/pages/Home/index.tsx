import React from 'react';
import './style.css';
import '../../assets/style/global.css';
import Header from '../../components/Header';
import Footer from '../../components/Footer';
import ImgLupa from '../../assets/image/ImgHome.png';

function Home() {

    return (
        <div>
            <Header/>
            <div className="Home">
                {/* <img className="ImageLupa" src={ImgLupa} alt="Real vagas, sua vaga em um clique"/> */}
            </div>
            <Footer/>
        </div>
    )
}

export default Home;