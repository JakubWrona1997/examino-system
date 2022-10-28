import { useForm } from "react-hook-form";
import { useAppDispatch } from "../../../app/store";
import InputField from "../../common/Forms/InputField/InputField";
import ModalWrapper from "../../ModalWrapper/ModalWrapper";
import styles from "./PasswordChangeModal.module.scss";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { changePassword } from "../../../features/adminSlice";

interface Props {
  isModalOpen: boolean;
  onModalOpen: () => void;
}

type PasswordChangeModalFormFields = {
  currentPassword: string;
  newPassword: string;
  newPasswordConfirm: string;
};

const PasswordChangeModal = ({ isModalOpen, onModalOpen }: Props) => {
  const dispatch = useAppDispatch();

  const passwordChangeSchema = yup.object().shape({
    currentPassword: yup.string().required("To pole jest wymagane"),
    newPassword: yup
      .string()
      .matches(/[A-Z]/, "Hasło musi mieć jedną dużą literę")
      .matches(/[a-z]/, "Hasło musi mieć jedną małą literę")
      .matches(/[0-9]/, "Hasło musi mieć jedną liczbę")
      .matches(/(?=.*?[#?!@$%^&*-])/, "Hasło musi mieć jeden znak specjalny")
      .min(6, "Hasło musi mieć minimum 6 znaków")
      .max(50, "Hasło może mieć maksimum 50 znaków")
      .required("To pole jest wymagane"),
    newPasswordConfirm: yup
      .string()
      .oneOf([yup.ref("newPassword"), null], "Hasła się nie zgadzają")
      .required("To pole jest wymagane"),
  });

  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm<PasswordChangeModalFormFields>({
    resolver: yupResolver(passwordChangeSchema),
  });

  const onSubmit = (data: PasswordChangeModalFormFields) => {
    const { newPasswordConfirm, ...passwords } = data;
    dispatch(changePassword(passwords));
  };

  return (
    <ModalWrapper
      isOpen={isModalOpen}
      onRequestClose={onModalOpen}
      onAfterClose={() => reset()}
    >
      <form onSubmit={handleSubmit(onSubmit)}>
        <div className={styles.cardWrapper}>
          <header className={styles.cardHeader}>Zmień hasło</header>
          <div className={styles.cardContent}>
            <InputField
              register={register}
              name="currentPassword"
              errors={errors}
              type="password"
              label="Aktualne hasło"
            />
            <InputField
              register={register}
              name="newPassword"
              errors={errors}
              type="password"
              label="Nowe hasło"
            />
            <InputField
              register={register}
              name="newPasswordConfirm"
              errors={errors}
              type="password"
              label="Potwierdź nowe hasło"
            />
          </div>
          <div className={styles.formButton}>
            <button onClick={onModalOpen}>Anuluj</button>
            <button type="submit">Zapisz</button>
          </div>
        </div>
      </form>
    </ModalWrapper>
  );
};

export default PasswordChangeModal;
