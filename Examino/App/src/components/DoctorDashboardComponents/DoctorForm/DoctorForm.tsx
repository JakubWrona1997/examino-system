import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import { RootState, useAppDispatch } from "../../../app/store";
import { useSelector } from "react-redux";
import {
  createRaport,
  getRaports,
  removeAlert,
} from "../../../features/raportSlice";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { useForm } from "react-hook-form";
import { RaportCreateViewModel } from "../../../models/Raports/RaportCreateViewModel";
import { PatientShortDetailsViewModel } from "../../../models/Users/Patient/PatientShortDetailsViewModel";
import { SelectFieldOptionViewModel } from "../../../models/Forms/SelectFieldOptionViewModel";
import styles from "./DoctorForm.module.scss";
import TextareaField from "../../common/Forms/TextareaField/TextareaField";
import SelectField from "../../common/Forms/SelectField/SelectField";
import displayAlert from "../../../utils/displayAlert";

const DoctorForm = () => {
  const [patientOptions, setPatientOptions] = useState<
    SelectFieldOptionViewModel[]
  >([]);
  const { alert } = useSelector((state: RootState) => state.raports);
  const dispatch = useAppDispatch();
  const navigate = useNavigate();

  useEffect(() => {
    const getPatientsAsync = async () => {
      const { data } = await axios.get("/api/doctor/users-list");
      const list = data.map((patient: PatientShortDetailsViewModel) => {
        return {
          value: patient.id,
          label: `${patient.name} ${patient.surname}, PESEL: ${patient.pesel}`,
        };
      });
      setPatientOptions(list);
    };
    getPatientsAsync();
  }, []);

  useEffect(() => {
    if (alert) {
      displayAlert(alert);
    }
    return () => {
      if (alert) dispatch(removeAlert());
    };
  }, [alert]);

  const formSchema = yup.object().shape({
    patientId: yup.string().required("To pole jest wymagane"),
    symptoms: yup.string().required("To pole jest wymagane"),
    examination: yup.string().required("To pole jest wymagane"),
    diagnosis: yup.string().required("To pole jest wymagane"),
    recommendation: yup.string().required("To pole jest wymagane"),
    comment: yup.string(),
    prescription: yup.object({
      medicines: yup.string(),
    }),
  });

  const {
    register,
    control,
    handleSubmit,
    formState: { errors },
  } = useForm<RaportCreateViewModel>({
    resolver: yupResolver(formSchema),
  });

  const onSubmit = async (data: RaportCreateViewModel) => {
    const { payload } = await dispatch(createRaport(data));
    await dispatch(getRaports());
    navigate(`/doctor/history/raport/${payload}`);
  };

  return (
    <React.Fragment>
      <header className={styles.header}>Formularz wizyty</header>
      <div className={styles.wrapper}>
        <form onSubmit={handleSubmit(onSubmit)}>
          <div className={styles.cardWrapper}>
            <div className={styles.cardContent}>
              <SelectField
                control={control}
                name="patientId"
                errors={errors}
                label="Pacjent"
                options={patientOptions}
              />
              <TextareaField
                register={register}
                name="symptoms"
                errors={errors}
                label="Symptomy"
              />
              <TextareaField
                register={register}
                name="examination"
                errors={errors}
                label="Badanie"
              />
              <TextareaField
                register={register}
                name="diagnosis"
                errors={errors}
                label="Diagnoza"
              />
              <TextareaField
                register={register}
                name="recommendation"
                errors={errors}
                label="Zalecenia"
              />
              <TextareaField
                register={register}
                name="comment"
                errors={errors}
                label="Komentarz"
              />
              <TextareaField
                register={register}
                name="prescription.medicines"
                errors={errors}
                label="Recepta"
              />
            </div>
          </div>
          <div className={styles.formButton}>
            <button type="submit">Zapisz</button>
          </div>
        </form>
      </div>
    </React.Fragment>
  );
};

export default DoctorForm;
