import { UseFormRegister } from "react-hook-form";
import "./InputField.scss";

interface Props {
  register: UseFormRegister<any>;
  registerName: string;
  registerErrors: any;
  type: string;
  label: string;
  placeholder?: string;
  serverErrors?: string[];
}

const InputField = ({
  register,
  registerName,
  registerErrors,
  type,
  label,
  placeholder,
  serverErrors,
}: Props) => {
  return (
    <div className="form-field">
      <label htmlFor={registerName}>{label}</label>
      <input
        {...register(registerName)}
        className={registerErrors[registerName] ? "is-invalid" : ""}
        type={type}
        placeholder={placeholder}
      />
      {registerErrors[registerName] && (
        <p className="form-field-error">
          {registerErrors[registerName].message}
        </p>
      )}
      {serverErrors &&
        serverErrors.map((err, index) => (
          <p key={index} className="form-field-error">
            {err}
          </p>
        ))}
    </div>
  );
};

export default InputField;
