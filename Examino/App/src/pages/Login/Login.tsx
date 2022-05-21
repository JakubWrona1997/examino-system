import { useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../../app/store";
import { loginUser } from "../../features/userSlice";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./Login.scss";

interface FormInputs {
  email: string;
  password: string;
}

const Login = () => {
  const { token, loading, error } = useSelector(
    (state: RootState) => state.user
  );

  const dispatch = useDispatch<AppDispatch>();
  const navigate = useNavigate();

  useEffect(() => {
    if (loading === "fulfilled" || token) {
      navigate("/dashboard");
    }
  }, [loading, token]);

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
    dispatch(loginUser(data));
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
          {error.login && <p className="login-error">{error.login}</p>}
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
