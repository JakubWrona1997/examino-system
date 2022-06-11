import { useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";
import { RootState, useAppDispatch } from "../../app/store";
import { loginUser } from "../../features/userSlice";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import styles from "./LoginPage.module.scss";
import InputField from "../../components/common/Forms/InputField/InputField";
import { UserLoginDataViewModel } from "../../models/Users/UserLoginDataViewModel";

const LoginPage = () => {
  const { user, error } = useSelector((state: RootState) => state.user);

  const dispatch = useAppDispatch();
  const navigate = useNavigate();

  useEffect(() => {
    if (user) {
      navigate(`/${user?.role}`);
    }
  }, [user]);

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
    <div className={styles.wrapper}>
      <div className={styles.header}>
        <div>Examino</div>
        <div>Twoje zdrowie na wyciągnięcie ręki</div>
      </div>
      <div className={styles.formWrapper}>
        <div className={styles.formHeader}>Zaloguj się</div>
        <form onSubmit={handleSubmit(onSubmit)}>
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
          {error.login && (
            <span className={styles.formError}>{error.login}</span>
          )}
          <button type="submit" className={styles.formButton}>
            Zaloguj
          </button>
        </form>
        <div className={styles.link}>
          Nie masz konta? <Link to="/register">Zarejestruj się</Link>
        </div>
      </div>
    </div>
  );
};

export default LoginPage;
