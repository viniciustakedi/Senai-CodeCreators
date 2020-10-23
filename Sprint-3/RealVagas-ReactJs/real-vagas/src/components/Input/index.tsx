import React, { InputHTMLAttributes } from 'react';
import '../../assets/style/global.css';
import './style.css';

interface InputProps extends InputHTMLAttributes<HTMLInputElement> {
    label: string;
    name: string;
}

const Input: React.FunctionComponent<InputProps> = ({ label, name, ...rest }) => {
    return (
        <div >
            <div className="form">
                <label id="Label" htmlFor={name}>{label}</label><br />
                <input type="text" id={name}{...rest}></input>
            </div>
        </div>
    );
}

export default Input