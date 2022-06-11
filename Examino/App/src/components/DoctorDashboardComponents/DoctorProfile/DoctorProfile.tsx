import React, { useEffect } from "react";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { useForm } from "react-hook-form";
import { RootState, useAppDispatch } from "../../../app/store";
import { useSelector } from "react-redux";
import {
  removeAlert,
  getDoctorData,
  updateDoctor,
} from "../../../features/doctorSlice";
import { format } from "date-fns";
import styles from "./DoctorProfile.module.scss";
import InputField from "../../common/Forms/InputField/InputField";
import SelectField from "../../common/Forms/SelectField/SelectField";
import { DoctorDataViewModel } from "../../../models/Users/Doctor/DoctorDataViewModel";
import { DoctorUpdateDataViewModel } from "../../../models/Users/Doctor/DoctorUpdateDataViewModel";
import { GenderOptions } from "../../../constants/GenderOptions";
import displayAlert from "../../../utils/displayAlert";

const DoctorProfile = () => {
  const { doctor, alert } = useSelector((state: RootState) => state.doctor);
  const dispatch = useAppDispatch();

  const doctorProfileSchema = yup.object().shape({
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
    qualification: yup.string().nullable(),
    specialization: yup.string().nullable(),
  });

  const {
    register,
    control,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm<DoctorDataViewModel>({
    resolver: yupResolver(doctorProfileSchema),
  });

  useEffect(() => {
    if (doctor && doctor.dateOfBirth) {
      reset({
        ...doctor,
        dateOfBirth: format(new Date(doctor.dateOfBirth), "yyyy-MM-dd"),
      });
    }
  }, [doctor, reset]);

  useEffect(() => {
    if (alert) {
      displayAlert(alert);
    }
    return () => {
      if (alert) dispatch(removeAlert());
    };
  }, [alert]);

  const onSubmit = async (data: DoctorUpdateDataViewModel) => {
    await dispatch(updateDoctor(data));
    dispatch(getDoctorData());
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
                name="qualification"
                errors={errors}
                type="text"
                label="Kwalifikacje"
              />
              <InputField
                register={register}
                name="specialization"
                errors={errors}
                type="text"
                label="Specjalizacje"
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

export default DoctorProfile;
