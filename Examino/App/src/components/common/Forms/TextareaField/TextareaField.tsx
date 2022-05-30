import { UseFormRegister } from "react-hook-form";
import "./TextareaField.scss";

interface Props {
  register: UseFormRegister<any>;
  name: string;
  errors: any;
  label: string;
  placeholder?: string;
  serverErrors?: string[];
}

const TextareaField = ({
  register,
  name,
  errors,
  label,
  placeholder,
  serverErrors,
}: Props) => {
  return (
    <div className="form-field">
      <label htmlFor={name}>{label}</label>
      <textarea
        {...register(name)}
        className={errors[name] ? "is-invalid" : ""}
        placeholder={placeholder}
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

export default TextareaField;
