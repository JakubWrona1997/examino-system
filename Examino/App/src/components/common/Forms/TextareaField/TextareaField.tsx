import { UseFormRegister } from "react-hook-form";
import "./TextareaField.scss";

interface Props {
  register: UseFormRegister<any>;
  registerName: string;
  registerErrors: any;
  label: string;
  placeholder?: string;
  serverErrors?: string[];
}

const TextareaField = ({
  register,
  registerName,
  registerErrors,
  label,
  placeholder,
  serverErrors,
}: Props) => {
  return (
    <div className="form-field">
      <label htmlFor={registerName}>{label}</label>
      <textarea
        {...register(registerName)}
        className={registerErrors[registerName] ? "is-invalid" : ""}
        placeholder={placeholder}
      />
      {registerErrors[registerName] && (
        <div className="form-field-error">
          {registerErrors[registerName].message}
        </div>
      )}
      {serverErrors &&
        serverErrors.map((err, index) => (
          <div key={index} className="form-field-error">
            {err}
          </div>
        ))}
    </div>
  );
};

export default TextareaField;
