import React, { useEffect } from "react";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { useForm } from "react-hook-form";
import { RootState, useAppDispatch } from "../../../app/store";
import { useSelector } from "react-redux";
import { removeAlert, getUser, updateUser } from "../../../features/userSlice";
import { format } from "date-fns";
import { toast } from "react-toastify";
import "./PatientProfile.scss";
import InputField from "../../common/Forms/InputField/InputField";
import SelectField from "../../common/Forms/SelectField/SelectField";
import { UserDataViewModel } from "../../../models/Users/UserDataViewModel";
import { UserUpdateDataViewModel } from "../../../models/Users/UserUpdatedDataViewModel";
import { BloodTypeOptions } from "../../../constants/BloodTypeOptions";
import { GenderOptions } from "../../../constants/GenderOptions";

const PatientProfile = () => {
  const { userData, alert } = useSelector((state: RootState) => state.user);
  const dispatch = useAppDispatch();

  const editProfileSchema = yup.object().shape({
    phoneNumber: yup
      .string()
      .matches(/^[0-9]+$/, "Numer telefonu może zawierać tylko cyfry")
      .length(9, "Numer telefonu musi zawierać 9 cyfr"),
    postalCode: yup
      .string()
      .matches(/^[0-9]{2}-[0-9]{3}$/, "Kod pocztowy musi mieć format [XX-XXX]"),
    city: yup
      .string()
      .matches(/^[A-Z]/, "Nazwa miasta musi zaczynać się z dużej litery"),
    address: yup.string().required("To pole jest wymagane"),
    height: yup
      .string()
      .matches(/^[0-9]+$/, "Wzrost może zawierać tylko cyfry"),
    weight: yup.string().matches(/^[0-9]+$/, "Waga może zawierać tylko cyfry"),
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
      ]),
  });

  const {
    register,
    control,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm<UserDataViewModel>({
    resolver: yupResolver(editProfileSchema),
  });

  useEffect(() => {
    if (userData && userData.dateOfBirth) {
      reset({
        ...userData,
        dateOfBirth: format(new Date(userData.dateOfBirth), "yyyy-MM-dd"),
      });
    }
  }, [userData, reset]);

  useEffect(() => {
    if (alert) toast.info(alert);
    return () => {
      if (alert) dispatch(removeAlert());
    };
  }, [alert]);

  const onSubmit = async (data: UserUpdateDataViewModel) => {
    await dispatch(updateUser(data));
    dispatch(getUser());
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
                control={control}
                name="gender"
                errors={errors}
                label="Płeć"
                options={GenderOptions}
                placeholder="Wybierz płeć"
                disabled
              />
              <InputField
                register={register}
                name="name"
                errors={errors}
                type="text"
                label="Imię"
                disabled
              />
              <InputField
                register={register}
                name="surname"
                errors={errors}
                type="text"
                label="Nazwisko"
                disabled
              />
              <InputField
                register={register}
                name="pesel"
                errors={errors}
                type="text"
                label="Pesel"
                disabled
              />
              <InputField
                register={register}
                name="dateOfBirth"
                errors={errors}
                type="date"
                label="Data urodzenia"
                disabled
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
                control={control}
                name="bloodType"
                errors={errors}
                label="Grupa krwi"
                options={BloodTypeOptions}
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
