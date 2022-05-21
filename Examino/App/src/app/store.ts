import { configureStore } from "@reduxjs/toolkit";
import { useDispatch } from "react-redux";
import userReducer from "../features/userSlice";
import raportReducer from "../features/raportSlice";

export const store = configureStore({
  reducer: {
    user: userReducer,
    raports: raportReducer,
  },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
export const useAppDispatch = () => useDispatch<AppDispatch>();
