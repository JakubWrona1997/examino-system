import { Outlet } from "react-router-dom";
import { useSelector } from "react-redux";
import { RootState } from "../../app/store";

interface Props {
  allowedRole: string;
}

const ProtectedRoute = ({ allowedRole }: Props) => {
  const { user } = useSelector((state: RootState) => state.user);

  return allowedRole === user?.role ? <Outlet /> : <div />;
};

export default ProtectedRoute;
