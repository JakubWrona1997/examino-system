import { UseFormRegister } from "react-hook-form";
import "./InputField.scss";

interface Props {
  register: UseFormRegister<any>;
  name: string;
  errors: any;
  type: string;
  label: string;
  placeholder?: string;
  serverErrors?: string[];
  disabled?: boolean;
}

const InputField = ({
  register,
  name,
  errors,
  type,
  label,
  placeholder,
  serverErrors,
  disabled,
}: Props) => {
  return (
    <div className="form-field">
      <label htmlFor={name}>{label}</label>
      <input
        {...register(name)}
        className={errors[name] ? "is-invalid" : ""}
        type={type}
        placeholder={placeholder}
        disabled={disabled}
      />
      {errors[name] && (
        <div className="form-field-error">{errors[name].message}</div>
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

export default InputField;
