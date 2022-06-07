import { configureStore } from "@reduxjs/toolkit";
import { useDispatch } from "react-redux";
import userReducer from "../features/userSlice";
import raportReducer from "../features/raportSlice";
import patientReducer from "../features/patientSlice";
import doctorReducer from "../features/doctorSlice";
import adminReducer from "../features/adminSlice";

export const store = configureStore({
  reducer: {
    user: userReducer,
    patient: patientReducer,
    doctor: doctorReducer,
    admin: adminReducer,
    raports: raportReducer,
  },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
export const useAppDispatch = () => useDispatch<AppDispatch>();
