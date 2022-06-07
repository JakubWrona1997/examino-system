import { useEffect } from "react";
import { Outlet, useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";
import { RootState, useAppDispatch } from "../../../app/store";
import { logoutUser } from "../../../features/userSlice";
import { getDoctors } from "../../../features/adminSlice";
import { FaHeartbeat, FaUsers, FaFileAlt, FaSignOutAlt } from "react-icons/fa";
import "./AdminDashboardPage.scss";
import NavItem from "../../../components/layout/NavItem/NavItem";

const AdminDashboardPage = () => {
  const { user } = useSelector((state: RootState) => state.user);
  const navigate = useNavigate();
  const dispatch = useAppDispatch();

  useEffect(() => {
    if (user && user.role === "admin") {
      dispatch(getDoctors());
    } else {
      navigate("/");
    }
  }, [user]);

  const handleLogout = () => {
    dispatch(logoutUser());
    navigate("/");
  };

  return (
    <div className="dashboard">
      <div className="dashboard-navigation">
        <div className="dashboard-navigation-logo">
          <FaHeartbeat />
          &nbsp;Examino
        </div>
        <div className="dashboard-navigation-links">
          <NavItem to="doctors" label="Doktorzy" icon={<FaUsers />} />
          <NavItem to="form" label="Formularz" icon={<FaFileAlt />} />
          <NavItem
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

export default AdminDashboardPage;
