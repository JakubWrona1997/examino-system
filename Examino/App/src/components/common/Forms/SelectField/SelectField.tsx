import { UseFormRegister } from "react-hook-form";
import "./SelectField.scss";

interface Props {
  register: UseFormRegister<any>;
  name: string;
  errors: any;
  label: string;
  options: string[];
  placeholder?: string;
}

const SelectField = ({
  register,
  name,
  errors,
  label,
  options,
  placeholder,
}: Props) => {
  return (
    <div className="form-field">
      <label htmlFor={name}>{label}</label>
      <select
        {...register(name)}
        className={errors[name] ? "is-invalid" : ""}
        defaultValue=""
      >
        {placeholder && (
          <option value="" disabled hidden>
            {placeholder}
          </option>
        )}
        {options.map((value) => (
          <option key={value} value={value}>
            {value}
          </option>
        ))}
      </select>
      {errors[name] && (
        <p className="form-field-error">{errors[name].message}</p>
      )}
    </div>
  );
};

export default SelectField;
