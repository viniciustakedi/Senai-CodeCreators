import React, { ButtonHTMLAttributes } from 'react';
import '../../assets/style/global.css';
import './style.css';

interface ButtonProps extends ButtonHTMLAttributes<HTMLButtonElement> {
    name: string;
}

const Button: React.FC<ButtonProps> = ({ name, ...rest}) => {
    return (
        <div>
            <button {...rest}>{name}</button>
        </div>  
    );
}

export default Button;
