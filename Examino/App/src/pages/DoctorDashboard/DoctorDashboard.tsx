import { useEffect } from "react";
import { Outlet, useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";
import { RootState, useAppDispatch } from "../../app/store";
import { getUser } from "../../features/userSlice";
import { logout } from "../../features/userSlice";
import {
  FaHeartbeat,
  FaThLarge,
  FaFileAlt,
  FaCalendarAlt,
  FaUserAlt,
  FaSignOutAlt,
} from "react-icons/fa";
import "./DoctorDashboard.scss";
import NavigationItem from "../../components/common/NavigationItem/NavigationItem";

const DoctorDashboard = () => {
  const { user } = useSelector((state: RootState) => state.user);
  const navigate = useNavigate();
  const dispatch = useAppDispatch();

  useEffect(() => {
    if (user) {
      dispatch(getUser());
    } else {
      navigate("/");
    }
  }, [user]);

  const handleLogout = () => {
    dispatch(logout());
  };

  return (
    <div className="dashboard">
      <div className="dashboard-navigation">
        <div className="dashboard-navigation-logo">
          <FaHeartbeat />
          &nbsp;Examino
        </div>
        <div className="dashboard-navigation-links">
          <NavigationItem to="panel" label="Panel" icon={<FaThLarge />} />
          <NavigationItem to="form" label="Formularz" icon={<FaFileAlt />} />
          <NavigationItem
            to="schedule"
            label="Terminarz"
            icon={<FaCalendarAlt />}
          />
          <NavigationItem to="profile" label="Profil" icon={<FaUserAlt />} />
          <NavigationItem
            to="/"
            label="Wyloguj"
            icon={<FaSignOutAlt />}
            onClick={handleLogout}
          />
        </div>
      </div>
      <div className="dashboard-content">
        <Outlet />
      </div>
    </div>
  );
};

export default DoctorDashboard;
