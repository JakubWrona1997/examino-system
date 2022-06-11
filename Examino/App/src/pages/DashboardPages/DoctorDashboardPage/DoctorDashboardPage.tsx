import { useEffect } from "react";
import { Outlet, useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";
import { RootState, useAppDispatch } from "../../../app/store";
import { getRaports } from "../../../features/raportSlice";
import { logoutUser } from "../../../features/userSlice";
import { getDoctorData, doctorReset } from "../../../features/doctorSlice";
import {
  FaHeartbeat,
  FaThLarge,
  FaFileAlt,
  FaClipboard,
  FaCalendarAlt,
  FaUserAlt,
  FaSignOutAlt,
} from "react-icons/fa";
import styles from "./DoctorDashboardPage.module.scss";
import NavItem from "../../../components/layout/NavItem/NavItem";

const DoctorDashboardPage = () => {
  const { user } = useSelector((state: RootState) => state.user);
  const navigate = useNavigate();
  const dispatch = useAppDispatch();

  useEffect(() => {
    if (user && user.role === "doctor") {
      dispatch(getRaports());
      dispatch(getDoctorData());
    } else {
      navigate("/");
    }
    return () => {
      dispatch(doctorReset());
    };
  }, [user]);

  const handleLogout = () => {
    dispatch(logoutUser());
    navigate("/");
  };

  return (
    <div className={styles.wrapper}>
      <div className={styles.sidebar}>
        <div className={styles.logo}>
          <FaHeartbeat />
          &nbsp;Examino
        </div>
        <div className={styles.navigation}>
          <NavItem to="panel" label="Panel" icon={<FaThLarge />} />
          <NavItem to="history" label="Historia" icon={<FaCalendarAlt />} />
          <NavItem to="form" label="Formularz" icon={<FaFileAlt />} />
          <NavItem to="schedule" label="Terminarz" icon={<FaClipboard />} />
          <NavItem to="profile" label="Profil" icon={<FaUserAlt />} />
          <NavItem
            to="/"
            label="Wyloguj"
            icon={<FaSignOutAlt />}
            onClick={handleLogout}
          />
        </div>
      </div>
      <div className={styles.content}>
        <Outlet />
      </div>
    </div>
  );
};

export default DoctorDashboardPage;
