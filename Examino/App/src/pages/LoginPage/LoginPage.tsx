import { useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../../app/store";
import { loginUser } from "../../features/userSlice";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./LoginPage.scss";
import InputField from "../../components/common/Forms/InputField/InputField";
import { UserLoginDataViewModel } from "../../models/Users/UserLoginDataViewModel";

const LoginPage = () => {
  const { user, loading, error } = useSelector(
    (state: RootState) => state.user
  );

  const dispatch = useDispatch<AppDispatch>();
  const navigate = useNavigate();

  useEffect(() => {
    if (loading === "fulfilled" || user) {
      navigate(`/${user?.role}`);
    }
  }, [loading, user]);

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
  } = useForm<UserLoginDataViewModel>({
    resolver: yupResolver(loginSchema),
  });

  const onSubmit = (data: UserLoginDataViewModel) => {
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
          <InputField
            register={register}
            name="email"
            errors={errors}
            type="email"
            label="Adres email"
          />
          <InputField
            register={register}
            name="password"
            errors={errors}
            type="password"
            label="Hasło"
          />
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

export default LoginPage;
