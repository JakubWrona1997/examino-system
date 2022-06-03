import { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import { RootState, useAppDispatch } from "../../../app/store";
import { authenticateUser } from "../../../features/userSlice";
import axios from "axios";

const AuthenticationRoute = ({
  children,
}: {
  children: JSX.Element;
}): JSX.Element => {
  const { user } = useSelector((state: RootState) => state.user);
  const [isAuthenticated, setIsAuthenticated] = useState<boolean>(false);
  const dispatch = useAppDispatch();

  const setAxiosDefaults = () => {
    axios.defaults.withCredentials = true;
  };

  useEffect(() => {
    if (!isAuthenticated && !user) {
      setAxiosDefaults();
      dispatch(authenticateUser());
      setIsAuthenticated(true);
    }
  }, [isAuthenticated, user]);

  return isAuthenticated ? children : <div />;
};

export default AuthenticationRoute;
