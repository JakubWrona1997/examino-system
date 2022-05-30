import React from "react";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { useForm } from "react-hook-form";
import { RootState, useAppDispatch } from "../../../app/store";
import { useSelector } from "react-redux";
import { format } from "date-fns";
import "./PatientProfile.scss";
import InputField from "../../common/Forms/InputField/InputField";
import SelectField from "../../common/Forms/SelectField/SelectField";

interface FormInputs {
  gender: string;
  name: string;
  surname: string;
  phoneNumber: string;
  postalCode: string;
  city: string;
  address: string;
  dateOfBirth: string;
  pesel: string;
  height: string;
  weight: string;
  bloodType: string;
}

const PatientProfile = () => {
  const { userData } = useSelector((state: RootState) => state.user);
  const dispatch = useAppDispatch();

  const editProfileSchema = yup.object().shape({
    gender: yup
      .string()
      .oneOf(["Mężczyzna", "Kobieta"])
      .required("To pole jest wymagane"),
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
    phoneNumber: yup
      .string()
      .matches(/^[0-9]+$/, "Numer telefonu może zawierać tylko cyfry")
      .length(9, "Numer telefonu musi zawierać 9 cyfr")
      .required("To pole jest wymagane"),
    postalCode: yup
      .string()
      .matches(/^[0-9]{2}-[0-9]{3}$/, "Kod pocztowy musi mieć format [XX-XXX]")
      .required("To pole jest wymagane"),
    city: yup
      .string()
      .matches(/^[A-Z]/, "Nazwa miasta musi zaczynać się z dużej litery")
      .required("To pole jest wymagane"),
    address: yup.string().required("To pole jest wymagane"),
    dateOfBirth: yup
      .date()
      .typeError("Data urodzenia nie może być pusta")
      .max(new Date(), "Nie możesz urodzić się w przyszłości")
      .required("To pole jest wymagane"),
    pesel: yup
      .string()
      .matches(/^[0-9]+$/, "Pesel może zawierać tylko cyfry")
      .length(11, "Pesel musi zawierać 11 cyfr")
      .required("To pole jest wymagane"),
    height: yup
      .string()
      .matches(/^[0-9]+$/, "Wzrost może zawierać tylko cyfry")
      .required("To pole jest wymagane"),
    weight: yup
      .string()
      .matches(/^[0-9]+$/, "Waga może zawierać tylko cyfry")
      .required("To pole jest wymagane"),
    bloodType: yup
      .string()
      .oneOf([
        "0 Rh-",
        "0 Rh+",
        "A Rh-",
        "A Rh+",
        "B Rh-",
        "B Rh+",
        "AB Rh-",
        "AB Rh+",
      ])
      .required("To pole jest wymagane"),
  });

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<FormInputs>({
    resolver: yupResolver(editProfileSchema),
    defaultValues: {
      ...userData,
      dateOfBirth: format(new Date(userData.dateOfBirth), "yyyy-MM-dd"),
    },
  });

  const onSubmit = (data: FormInputs) => {
    // TODO - dispatch update
  };

  return (
    <React.Fragment>
      <header className="dashboard-content-header">Edycja profilu</header>
      <div className="dashboard-profile-wrapper">
        <form onSubmit={handleSubmit(onSubmit)}>
          <div className="card-wrapper">
            <header className="card-header">Dane osobowe</header>
            <div className="card-content">
              <SelectField
                register={register}
                name="gender"
                errors={errors}
                label="Płeć"
                options={["Mężczyzna", "Kobieta"]}
                placeholder="Wybierz płeć"
              />
              <InputField
                register={register}
                name="name"
                errors={errors}
                type="text"
                label="Imię"
              />
              <InputField
                register={register}
                name="surname"
                errors={errors}
                type="text"
                label="Nazwisko"
              />
              <InputField
                register={register}
                name="pesel"
                errors={errors}
                type="text"
                label="Pesel"
              />
              <InputField
                register={register}
                name="dateOfBirth"
                errors={errors}
                type="date"
                label="Data urodzenia"
              />
              <InputField
                register={register}
                name="phoneNumber"
                errors={errors}
                type="text"
                label="Numer telefonu"
              />
              <InputField
                register={register}
                name="postalCode"
                errors={errors}
                type="text"
                label="Kod pocztowy"
              />
              <InputField
                register={register}
                name="city"
                errors={errors}
                type="text"
                label="Miasto"
              />
              <InputField
                register={register}
                name="address"
                errors={errors}
                type="text"
                label="Adres"
              />
            </div>
          </div>
          <div className="card-wrapper">
            <header className="card-header">Dane szczegółowe</header>
            <div className="card-content">
              <InputField
                register={register}
                name="height"
                errors={errors}
                type="number"
                label="Wzrost [cm]"
              />
              <InputField
                register={register}
                name="weight"
                errors={errors}
                type="number"
                label="Waga [kg]"
              />
              <SelectField
                register={register}
                name="bloodType"
                errors={errors}
                label="Grupa krwi"
                options={[
                  "0 Rh-",
                  "0 Rh+",
                  "A Rh-",
                  "A Rh+",
                  "B Rh-",
                  "B Rh+",
                  "AB Rh-",
                  "AB Rh+",
                ]}
                placeholder="Wybierz grupę krwi"
              />
            </div>
          </div>
          <div className="form-button">
            <button type="submit">Zaktualizuj</button>
          </div>
        </form>
      </div>
    </React.Fragment>
  );
};

export default PatientProfile;
