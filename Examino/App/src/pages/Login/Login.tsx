import { Link } from "react-router-dom";
import { useForm } from "react-hook-form";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import "./Login.scss";

interface FormInputs {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  confirmPassword: string;
}

const Login = () => {
  const loginSchema = yup.object().shape({
    email: yup
      .string()
      .email("Podany email jest niepoprawny")
      .required("To pole jest wymagane"),
    password: yup.string().required("To pole jest wymagane"),
  });

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<FormInputs>({
    resolver: yupResolver(loginSchema),
  });

  const onSubmit = (data: FormInputs) => {
    // TODO
    console.log(data);
  };

  return (
    <div className="login">
      <div className="login-header">
        <p>Examino</p>
        <p>Twoje zdrowie na wyciągnięcie ręki</p>
      </div>
      <div className="login-form">
        <div className="login-form-header">Zaloguj się</div>
        <form className="form" onSubmit={handleSubmit(onSubmit)}>
          <div className="form-field">
            <label htmlFor="email">Adres email</label>
            <input
              className={errors.email ? "is-invalid" : ""}
              type="email"
              {...register("email")}
            />
            {errors.email && (
              <p className="form-field-error">{errors.email.message}</p>
            )}
          </div>
          <div className="form-field">
            <label htmlFor="password">Hasło</label>
            <input
              className={errors.password ? "is-invalid" : ""}
              type="password"
              {...register("password")}
            />
            {errors.password && (
              <p className="form-field-error">{errors.password.message}</p>
            )}
          </div>
          <button type="submit" className="form-button">
            Zaloguj
          </button>
        </form>
        <div className="login-register-link">
          Nie masz konta? <Link to="/register">Zarejestruj się</Link>
        </div>
      </div>
    </div>
  );
};

export default Login;
