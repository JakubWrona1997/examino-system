import React from "react";
import { useAppDispatch } from "../../../app/store";
import { createRaport } from "../../../features/raportSlice";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { useForm } from "react-hook-form";
import { RaportCreateViewModel } from "../../../models/Raports/RaportCreateViewModel";
import "./DoctorForm.scss";
import TextareaField from "../../common/Forms/TextareaField/TextareaField";
import SelectField from "../../common/Forms/SelectField/SelectField";

const DoctorForm = () => {
  const dispatch = useAppDispatch();

  const formSchema = yup.object().shape({
    patientId: yup.string().required("To pole jest wymagane"),
    sympthoms: yup.string().required("To pole jest wymagane"),
    examination: yup.string().required("To pole jest wymagane"),
    diagnosis: yup.string().required("To pole jest wymagane"),
    recommendation: yup.string().required("To pole jest wymagane"),
    comment: yup.string(),
    prescription: yup.string(),
  });

  const {
    register,
    control,
    handleSubmit,
    formState: { errors },
  } = useForm<RaportCreateViewModel>({
    resolver: yupResolver(formSchema),
  });

  const onSubmit = (data: RaportCreateViewModel) => {
    dispatch(createRaport(data));
  };

  return (
    <React.Fragment>
      <header className="dashboard-content-header">Formularz wizyty</header>
      <div className="dashboard-doctor-form-wrapper">
        <form onSubmit={handleSubmit(onSubmit)}>
          <div className="card-wrapper">
            <div className="card-content">
              <SelectField
                control={control}
                name="patientId"
                errors={errors}
                label="Pacjent"
                options={[]} // TODO - patient options
              />
              <TextareaField
                register={register}
                name="sympthoms"
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
                name="prescription"
                errors={errors}
                label="Recepta"
              />
            </div>
          </div>
          <div className="form-button">
            <button type="submit">Zapisz</button>
          </div>
        </form>
      </div>
    </React.Fragment>
  );
};

export default DoctorForm;
