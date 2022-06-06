import axios from "axios";
import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { DoctorDataViewModel } from "../models/Users/Doctor/DoctorDataViewModel";
import { DoctorUpdateDataViewModel } from "../models/Users/Doctor/DoctorUpdateDataViewModel";

interface IDoctorState {
  doctor: DoctorDataViewModel | undefined;
  alert: string | undefined;
}

const initialState: IDoctorState = {
  doctor: undefined,
  alert: undefined,
};

// Get Doctor Data
// GET /api/doctor
export const getDoctorData = createAsyncThunk<
  DoctorDataViewModel,
  void,
  { rejectValue: string }
>("doctor/get", async (_, thunkAPI) => {
  try {
    const res = await axios.get("/api/doctor");
    return res.data;
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});

// Update Doctor
// PUT /api/doctor
export const updateDoctor = createAsyncThunk<
  void,
  DoctorUpdateDataViewModel,
  { rejectValue: string }
>("doctor/update", async (userData, thunkAPI) => {
  try {
    const res = await axios.put("/api/doctor", userData);
    return res.data;
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});

export const doctorSlice = createSlice({
  name: "doctor",
  initialState,
  reducers: {
    doctorReset: () => initialState,
    removeAlert: (state) => {
      state.alert = initialState.alert;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(getDoctorData.fulfilled, (state, action) => {
        state.doctor = action.payload;
      })
      .addCase(updateDoctor.fulfilled, (state) => {
        state.alert = "Profil zaktualizowano pomyślnie";
      })
      .addCase(updateDoctor.rejected, (state) => {
        state.alert = "Oops! Coś poszło nie tak";
      });
  },
});

export const { doctorReset, removeAlert } = doctorSlice.actions;
export default doctorSlice.reducer;
