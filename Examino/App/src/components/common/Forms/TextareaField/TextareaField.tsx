import { UseFormRegister } from "react-hook-form";
import styles from "./TextareaField.module.scss";

interface Props {
  register: UseFormRegister<any>;
  name: string;
  errors: any;
  label: string;
  placeholder?: string;
  serverErrors?: string[];
  disabled?: boolean;
}

const TextareaField = ({
  register,
  name,
  errors,
  label,
  placeholder,
  serverErrors,
  disabled,
}: Props) => {
  return (
    <div className={styles.wrapper}>
      <label htmlFor={name}>{label}</label>
      <textarea
        {...register(name)}
        className={errors[name] ? styles.invalid : ""}
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

export default TextareaField;
