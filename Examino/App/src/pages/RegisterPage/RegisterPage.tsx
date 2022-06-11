import { useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";
import { RootState, useAppDispatch } from "../../app/store";
import { registerPatient } from "../../features/userSlice";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import styles from "./RegisterPage.module.scss";
import InputField from "../../components/common/Forms/InputField/InputField";
import { UserRegisterDataViewModel } from "../../models/Users/UserRegisterDataViewModel";

const RegisterPage = () => {
  const { user, error } = useSelector((state: RootState) => state.user);

  const dispatch = useAppDispatch();
  const navigate = useNavigate();

  useEffect(() => {
    if (user) {
      navigate(`/${user?.role}`);
    }
  }, [user]);

  const registerSchema = yup.object().shape({
    name: yup
      .string()
      .matches(/^[A-ZĄĆĘŁŃÓŚŹŻ]/, "Imię musi zaczynać się z dużej litery")
      .matches(/^\S+$/, "Imię nie może zawierać przerw")
      .matches(
        /^.[a-ząćęłńóśźż\s]*$/,
        "Imię nie może zawierać dużych liter w środku"
      )
      .min(3, "Imię musi mieć minimum 3 znaki")
      .max(50, "Imię może mieć maksimum 50 znaków")
      .required("To pole jest wymagane"),
    surname: yup
      .string()
      .matches(/^[A-ZĄĆĘŁŃÓŚŹŻ]/, "Nazwisko musi zaczynać się z dużej litery")
      .matches(/^\S+$/, "Nazwisko nie może zawierać przerw")
      .matches(
        /^.[a-ząćęłńóśźż\s]*$/,
        "Nazwisko nie może zawierać dużych liter w środku"
      )
      .min(3, "Nazwisko musi mieć minimum 3 znaki")
      .max(50, "Nazwisko może mieć maksimum 50 znaków")
      .required("To pole jest wymagane"),
    pesel: yup
      .string()
      .matches(/^[0-9]+$/, "Pesel może zawierać tylko cyfry")
      .length(11, "Pesel musi zawierać 11 cyfr")
      .required("To pole jest wymagane"),
    email: yup
      .string()
      .email("Podany email jest niepoprawny")
      .required("To pole jest wymagane"),
    password: yup
      .string()
      .matches(/[A-Z]/, "Hasło musi mieć jedną dużą literę")
      .matches(/[a-z]/, "Hasło musi mieć jedną małą literę")
      .matches(/[0-9]/, "Hasło musi mieć jedną liczbę")
      .matches(/(?=.*?[#?!@$%^&*-])/, "Hasło musi mieć jeden znak specjalny")
      .min(6, "Hasło musi mieć minimum 6 znaków")
      .max(50, "Hasło może mieć maksimum 50 znaków")
      .required("To pole jest wymagane"),
    confirmPassword: yup
      .string()
      .oneOf([yup.ref("password"), null], "Hasła się nie zgadzają")
      .required("To pole jest wymagane"),
  });

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<UserRegisterDataViewModel>({
    resolver: yupResolver(registerSchema),
  });

  const onSubmit = (data: UserRegisterDataViewModel) => {
    dispatch(registerPatient(data));
  };

  return (
    <div className={styles.wrapper}>
      <div className={styles.header}>
        <div>Examino</div>
        <div>Twoje zdrowie na wyciągnięcie ręki</div>
      </div>
      <div className={styles.formWrapper}>
        <div className={styles.formHeader}>Zarejestruj się</div>
        <div className={styles.formDescription}>
          Rejestrując się uzyskujesz dostęp do całej dokumentacji wystawionej
          przez twojego lekarza
        </div>
        <form onSubmit={handleSubmit(onSubmit)}>
          <InputField
            register={register}
            name="name"
            errors={errors}
            type="text"
            label="Imię"
            serverErrors={error.register?.Name}
          />
          <InputField
            register={register}
            name="surname"
            errors={errors}
            type="text"
            label="Nazwisko"
            serverErrors={error.register?.Surname}
          />
          <InputField
            register={register}
            name="pesel"
            errors={errors}
            type="text"
            label="Pesel"
            serverErrors={error.register?.PESEL}
          />
          <InputField
            register={register}
            name="email"
            errors={errors}
            type="email"
            label="Adres email"
            serverErrors={error.register?.Email}
          />
          <InputField
            register={register}
            name="password"
            errors={errors}
            type="password"
            label="Hasło"
            serverErrors={error.register?.Password}
          />
          <InputField
            register={register}
            name="confirmPassword"
            errors={errors}
            type="password"
            label="Potwierdź hasło"
          />
          <button type="submit" className={styles.formButton}>
            Zarejestruj
          </button>
        </form>
        <div className={styles.link}>
          Posiadasz już konto? <Link to="/">Zaloguj się</Link>
        </div>
      </div>
    </div>
  );
};

export default RegisterPage;
