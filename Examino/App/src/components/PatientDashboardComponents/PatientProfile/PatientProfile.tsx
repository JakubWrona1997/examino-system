import React, { useEffect } from "react";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { useForm } from "react-hook-form";
import { RootState, useAppDispatch } from "../../../app/store";
import { useSelector } from "react-redux";
import {
  removeAlert,
  getPatientData,
  updatePatient,
} from "../../../features/patientSlice";
import { format } from "date-fns";
import styles from "./PatientProfile.module.scss";
import InputField from "../../common/Forms/InputField/InputField";
import SelectField from "../../common/Forms/SelectField/SelectField";
import { PatientDataViewModel } from "../../../models/Users/Patient/PatientDataViewModel";
import { PatientUpdateDataViewModel } from "../../../models/Users/Patient/PatientUpdateDataViewModel";
import { BloodTypeOptions } from "../../../constants/BloodTypeOptions";
import { GenderOptions } from "../../../constants/GenderOptions";
import displayAlert from "../../../utils/displayAlert";

const PatientProfile = () => {
  const { patient, alert } = useSelector((state: RootState) => state.patient);
  const dispatch = useAppDispatch();

  const patientProfileSchema = yup.object().shape({
    phoneNumber: yup
      .string()
      .matches(/^[0-9]+$/, "Numer telefonu może zawierać tylko cyfry")
      .length(9, "Numer telefonu musi zawierać 9 cyfr")
      .nullable(),
    postalCode: yup
      .string()
      .matches(/^[0-9]{2}-[0-9]{3}$/, "Kod pocztowy musi mieć format [XX-XXX]")
      .nullable(),
    city: yup
      .string()
      .matches(
        /^[A-ZĄĆĘŁŃÓŚŹŻ]/,
        "Nazwa miasta musi zaczynać się z dużej litery"
      )
      .nullable(),
    address: yup.string().nullable(),
    height: yup
      .string()
      .matches(/^[0-9]+$/, "Wzrost może zawierać tylko cyfry")
      .nullable(),
    weight: yup
      .string()
      .matches(/^[0-9]+$/, "Waga może zawierać tylko cyfry")
      .nullable(),
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
        null,
      ])
      .nullable(),
  });

  const {
    register,
    control,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm<PatientDataViewModel>({
    resolver: yupResolver(patientProfileSchema),
  });

  useEffect(() => {
    if (patient && patient.dateOfBirth) {
      reset({
        ...patient,
        dateOfBirth: format(new Date(patient.dateOfBirth), "yyyy-MM-dd"),
      });
    }
  }, [patient, reset]);

  useEffect(() => {
    if (alert) {
      displayAlert(alert);
    }
    return () => {
      if (alert) dispatch(removeAlert());
    };
  }, [alert]);

  const onSubmit = async (data: PatientUpdateDataViewModel) => {
    await dispatch(updatePatient(data));
    dispatch(getPatientData());
  };

  return (
    <React.Fragment>
      <header className={styles.header}>Edycja profilu</header>
      <div className={styles.wrapper}>
        <form onSubmit={handleSubmit(onSubmit)}>
          <div className={styles.cardWrapper}>
            <header className={styles.cardHeader}>Dane osobowe</header>
            <div className={styles.cardContent}>
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
          <div className={styles.cardWrapper}>
            <header className={styles.cardHeader}>Dane szczegółowe</header>
            <div className={styles.cardContent}>
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
          <div className={styles.formButton}>
            <button type="submit">Zaktualizuj</button>
          </div>
        </form>
      </div>
    </React.Fragment>
  );
};

export default PatientProfile;
