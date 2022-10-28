import React, { useState } from "react";
import styles from "./AdminProfile.module.scss";
import PasswordChangeModal from "../../Modals/PasswordChangeModal/PasswordChangeModal";

const AdminProfile = () => {
  const [isPasswordModalOpen, setIsPasswordModalOpen] = useState(false);

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
