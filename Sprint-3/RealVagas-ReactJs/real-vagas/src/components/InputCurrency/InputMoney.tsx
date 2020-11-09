import React, { InputHTMLAttributes, useCallback } from "react";

import { currency, cpf } from "./Mask";

interface InputProps extends InputHTMLAttributes<HTMLInputElement> {
  mask: "cep" | "currency" | "cpf";
  label: string;
  name: string;
}

const InputPerson: React.FC<InputProps> = ({ label, name,mask, ...props }) => {
  const handleKeyUp = useCallback(
    (e: React.FormEvent<HTMLInputElement>) => {
      if (mask === "currency") {
        currency(e);
      }
      if (mask === "cpf") {
        cpf(e);
      }
    },
    [mask]
  );

  return (
    <div className="form">
    <label id="Label" htmlFor={name}>{label}</label><br />
      <input {...props} onKeyUp={handleKeyUp} />
    </div>
  );
};

export default InputPerson;