import { UseFormRegister } from "react-hook-form";
import "./SelectField.scss";

interface Props {
  register: UseFormRegister<any>;
  registerName: string;
  registerErrors: any;
  label: string;
  options: string[];
  placeholder?: string;
}

const SelectField = ({
  register,
  registerName,
  registerErrors,
  label,
  options,
  placeholder,
}: Props) => {
  return (
    <div className="form-field">
      <label htmlFor={registerName}>{label}</label>
      <select
        {...register(registerName)}
        className={registerErrors[registerName] ? "is-invalid" : ""}
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
      {registerErrors[registerName] && (
        <p className="form-field-error">
          {registerErrors[registerName].message}
        </p>
      )}
    </div>
  );
};

export default SelectField;
