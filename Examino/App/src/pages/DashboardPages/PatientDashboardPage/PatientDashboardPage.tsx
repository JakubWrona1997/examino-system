import React, { useEffect } from "react";
import { Outlet, useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";
import { RootState, useAppDispatch } from "../../../app/store";
import { getRaports } from "../../../features/raportSlice";
import { logoutUser } from "../../../features/userSlice";
import { getPatientData, patientReset } from "../../../features/patientSlice";
import {
  FaHeartbeat,
  FaThLarge,
  FaCalendarAlt,
  FaUserAlt,
  FaSignOutAlt,
} from "react-icons/fa";
import styles from "./PatientDashboardPage.module.scss";
import NavItem from "../../../components/layout/NavItem/NavItem";
import RaportAddedNotify from "../../../components/RaportAddedNotify/RaportAddedNotify";

const PatientDashboardPage = () => {
  const { user } = useSelector((state: RootState) => state.user);
  const navigate = useNavigate();
  const dispatch = useAppDispatch();

  useEffect(() => {
    if (user && user.role === "patient") {
      dispatch(getRaports());
      dispatch(getPatientData());
    } else {
      navigate("/");
    }
    return () => {
      dispatch(patientReset());
    };
  }, [user]);

  const handleLogout = () => {
    dispatch(logoutUser());
    navigate("/");
  };

  return (
    <React.Fragment>
      <div className={styles.wrapper}>
        <div className={styles.sidebar}>
          <div className={styles.logo}>
            <FaHeartbeat />
            &nbsp;Examino
          </div>
          <div className={styles.navigation}>
            <NavItem to="panel" label="Panel" icon={<FaThLarge />} />
            <NavItem to="history" label="Historia" icon={<FaCalendarAlt />} />
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
      <RaportAddedNotify />
    </React.Fragment>
  );
};

export default PatientDashboardPage;
