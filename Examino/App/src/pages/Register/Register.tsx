import { Link } from "react-router-dom";
import { useForm } from "react-hook-form";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import "./Register.scss";

interface FormInputs {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  confirmPassword: string;
}

const Register = () => {
  const registerSchema = yup.object().shape({
    firstName: yup.string().required("To pole jest wymagane"),
    lastName: yup.string().required("To pole jest wymagane"),
    email: yup
      .string()
      .email("Podany email jest niepoprawny")
      .required("To pole jest wymagane"),
    password: yup.string().required("To pole jest wymagane"),
    confirmPassword: yup
      .string()
      .oneOf([yup.ref("password"), null], "Hasła się nie zgadzają")
      .required("To pole jest wymagane"),
  });

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<FormInputs>({
    resolver: yupResolver(registerSchema),
  });

  const onSubmit = (data: FormInputs) => {
    // TODO
    console.log(data);
  };

  return (
    <div className="register">
      <div className="register-header">
        <p>Examino</p>
        <p>Twoje zdrowie na wyciągnięcie ręki</p>
      </div>
      <div className="register-form">
        <div className="register-form-header">Zarejestruj się</div>
        <div className="register-form-description">
          Rejestrując się uzyskujesz dostęp do całej dokumentacji wystawionej
          przez twojego lekarza
        </div>
        <form className="form" onSubmit={handleSubmit(onSubmit)}>
          <div className="form-field">
            <label htmlFor="firstName">Imię</label>
            <input type="text" {...register("firstName")} />
            {errors.firstName && (
              <p className="form-field-error">{errors.firstName.message}</p>
            )}
          </div>
          <div className="form-field">
            <label htmlFor="lastName">Nazwisko</label>
            <input type="text" {...register("lastName")} />
            {errors.lastName && (
              <p className="form-field-error">{errors.lastName.message}</p>
            )}
          </div>
          <div className="form-field">
            <label htmlFor="email">Adres email</label>
            <input type="email" {...register("email")} />
            {errors.email && (
              <p className="form-field-error">{errors.email.message}</p>
            )}
          </div>
          <div className="form-field">
            <label htmlFor="password">Hasło</label>
            <input type="password" {...register("password")} />
            {errors.password && (
              <p className="form-field-error">{errors.password.message}</p>
            )}
          </div>
          <div className="form-field">
            <label htmlFor="confirmPassword">Potwierdź hasło</label>
            <input type="password" {...register("confirmPassword")} />
            {errors.confirmPassword && (
              <p className="form-field-error">
                {errors.confirmPassword.message}
              </p>
            )}
          </div>
          <button type="submit" className="form-button">
            Zarejestruj
          </button>
        </form>
        <div className="register-login-link">
          Posiadasz już konto? <Link to="/">Zaloguj się</Link>
        </div>
      </div>
    </div>
  );
};

export default Register;
