import React, { ButtonHTMLAttributes } from 'react';
import './style.css';

interface ButtonInscricaoProps extends ButtonHTMLAttributes<HTMLButtonElement> {
    value: string;
}

const ButtonTeste: React.FC<ButtonInscricaoProps> = ({ value }) => {
    return (
        <div>
            <button className="ButtonArea3">{value}</button>
        </div>
    );
}

export default ButtonTeste;
