import React, { useEffect } from "react";
import { useSelector } from "react-redux";
import { RootState, useAppDispatch } from "../../../app/store";
import { registerDoctor, removeAlert } from "../../../features/userSlice";
import { getDoctors } from "../../../features/adminSlice";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./RegisterDoctorForm.scss";
import { UserRegisterDataViewModel } from "../../../models/Users/UserRegisterDataViewModel";
import InputField from "../../common/Forms/InputField/InputField";
import displayAlert from "../../../utils/displayAlert";

const RegisterDoctorForm = () => {
  const { alert, error } = useSelector((state: RootState) => state.user);

  const dispatch = useAppDispatch();

  useEffect(() => {
    if (alert) {
      displayAlert(alert);
    }
    return () => {
      if (alert) dispatch(removeAlert());
    };
  }, [alert]);

  const registerSchema = yup.object().shape({
    name: yup
      .string()
      .matches(/^[A-Z]/, "Imię musi zaczynać się z dużej litery")
      .matches(/^\S+$/, "Imię nie może zawierać przerw")
      .matches(/^.[a-z\s]*$/, "Imię nie może zawierać dużych liter w środku")
      .min(3, "Imię musi mieć minimum 3 znaki")
      .max(50, "Imię może mieć maksimum 50 znaków")
      .required("To pole jest wymagane"),
    surname: yup
      .string()
      .matches(/^[A-Z]/, "Nazwisko musi zaczynać się z dużej litery")
      .matches(/^\S+$/, "Nazwisko nie może zawierać przerw")
      .matches(
        /^.[a-z\s]*$/,
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

  const onSubmit = async (data: UserRegisterDataViewModel) => {
    await dispatch(registerDoctor(data));
    dispatch(getDoctors());
  };

  return (
    <React.Fragment>
      <header className="dashboard-content-header">
        Formularz rejestracji doktora
      </header>
      <div className="dashboard-admin-form-wrapper">
        <form onSubmit={handleSubmit(onSubmit)}>
          <div className="card-wrapper">
            <div className="card-content">
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
            </div>
          </div>
          <div className="form-button">
            <button type="submit">Zarejestruj</button>
          </div>
        </form>
      </div>
    </React.Fragment>
  );
};

export default RegisterDoctorForm;
