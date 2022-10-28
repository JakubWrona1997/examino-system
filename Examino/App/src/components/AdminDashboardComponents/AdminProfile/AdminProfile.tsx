import React, { useEffect, useState } from "react";
import styles from "./AdminProfile.module.scss";
import PasswordChangeModal from "../../Modals/PasswordChangeModal/PasswordChangeModal";
import displayAlert from "../../../utils/displayAlert";
import { useSelector } from "react-redux";
import { RootState, useAppDispatch } from "../../../app/store";
import { removeAlert } from "../../../features/adminSlice";

const AdminProfile = () => {
  const [isPasswordModalOpen, setIsPasswordModalOpen] = useState(false);

  const { alert } = useSelector((state: RootState) => state.admin);
  const dispatch = useAppDispatch();

  useEffect(() => {
    if (alert) {
      displayAlert(alert);
    }
    return () => {
      if (alert) dispatch(removeAlert());
    };
  }, [alert]);

  const onPasswordModalOpen = () => setIsPasswordModalOpen((prev) => !prev);

  return (
    <React.Fragment>
      <header className={styles.header}>Profil administratora</header>
      <div className={styles.wrapper}>
        <button onClick={() => setIsPasswordModalOpen(true)}>
          Zmień hasło
        </button>
      </div>
      <PasswordChangeModal
        isModalOpen={isPasswordModalOpen}
        onModalOpen={onPasswordModalOpen}
      />
    </React.Fragment>
  );
};

export default AdminProfile;
