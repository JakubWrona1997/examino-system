import { UseFormRegister } from "react-hook-form";
import styles from "./InputField.module.scss";

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
    <div className={styles.wrapper}>
      <label htmlFor={name}>{label}</label>
      <input
        {...register(name)}
        className={errors[name] ? styles.invalid : ""}
        type={type}
        placeholder={placeholder}
        disabled={disabled}
      />
      {errors[name] && (
        <div className={styles.error}>{errors[name].message}</div>
      )}
      {serverErrors &&
        serverErrors.map((err, index) => (
          <div key={index} className={styles.error}>
            {err}
          </div>
        ))}
    </div>
  );
};

export default InputField;
