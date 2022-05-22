import { useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../../app/store";
import { registerUser } from "../../features/userSlice";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./Register.scss";
import InputField from "../../components/common/InputField/InputField";

interface FormInputs {
  name: string;
  surname: string;
  pesel: string;
  email: string;
  password: string;
  confirmPassword: string;
}

const Register = () => {
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

  const registerSchema = yup.object().shape({
    name: yup
      .string()
      .matches(/^[A-Z]/, "Imię musi zaczynać się z dużej litery")
      .matches(/^\S+$/, "Imię nie może zawierać przerw")
      .matches(
        /^[A-Z][a-z\s]*$/,
        "Imię nie może zawierać dużych liter w środku"
      )
      .min(3, "Imię musi mieć minimum 3 znaki")
      .max(50, "Imię może mieć maksimum 50 znaków")
      .required("To pole jest wymagane"),
    surname: yup
      .string()
      .matches(/^[A-Z]/, "Nazwisko musi zaczynać się z dużej litery")
      .matches(/^\S+$/, "Nazwisko nie może zawierać przerw")
      .matches(
        /^[A-Z][a-z\s]*$/,
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
  } = useForm<FormInputs>({
    resolver: yupResolver(registerSchema),
  });

  const onSubmit = (data: FormInputs) => {
    const { confirmPassword, ...dataCopy } = data;
    dispatch(registerUser(dataCopy));
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
          <InputField
            register={register}
            registerName="name"
            registerErrors={errors}
            type="text"
            label="Imię"
            serverErrors={error.register?.Name}
          />
          <InputField
            register={register}
            registerName="surname"
            registerErrors={errors}
            type="text"
            label="Nazwisko"
            serverErrors={error.register?.Surname}
          />
          <InputField
            register={register}
            registerName="pesel"
            registerErrors={errors}
            type="text"
            label="Pesel"
            serverErrors={error.register?.PESEL}
          />
          <InputField
            register={register}
            registerName="email"
            registerErrors={errors}
            type="email"
            label="Adres email"
            serverErrors={error.register?.Email}
          />
          <InputField
            register={register}
            registerName="password"
            registerErrors={errors}
            type="password"
            label="Hasło"
            serverErrors={error.register?.Password}
          />
          <InputField
            register={register}
            registerName="confirmPassword"
            registerErrors={errors}
            type="password"
            label="Potwierdź hasło"
          />
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
