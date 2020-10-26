import React, { ButtonHTMLAttributes } from 'react';
import '../../assets/style/global.css';
import './style.css';

interface ButtonInscricaoProps extends ButtonHTMLAttributes<HTMLButtonElement> {
    value: string;
}

const ButtonInscricao: React.FC<ButtonInscricaoProps> = ({ value }) => {
    return (
        <div>
            <button className="ButtonArea2">{value}</button>
        </div>
    );
}

export default ButtonInscricao;