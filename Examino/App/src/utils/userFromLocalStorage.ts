import jwtDecode from "./jwtDecode";

const userFromLocalStorage = () => {
  try {
    const token = localStorage.getItem("token");
    if (token) {
      return jwtDecode(token);
    } else {
      return null;
    }
  } catch (error) {
    return null;
  }
};

export default userFromLocalStorage;
