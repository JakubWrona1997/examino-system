import axios from "axios";
import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { PatientDataViewModel } from "../models/Users/Patient/PatientDataViewModel";
import { PatientUpdateDataViewModel } from "../models/Users/Patient/PatientUpdateDataViewModel";
import { AlertViewModel } from "../models/Alert/AlertViewModel";

interface IPatientState {
  patient: PatientDataViewModel | undefined;
  alert: AlertViewModel | undefined;
}

const initialState: IPatientState = {
  patient: undefined,
  alert: undefined,
};

// Get Patient Data
// GET /api/patient
export const getPatientData = createAsyncThunk<
  PatientDataViewModel,
  void,
  { rejectValue: string }
>("patient/get", async (_, thunkAPI) => {
  try {
    const res = await axios.get("/api/patient");
    return res.data;
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});

// Update Patient
// PUT /api/patient
export const updatePatient = createAsyncThunk<
  void,
  PatientUpdateDataViewModel,
  { rejectValue: string }
>("patient/update", async (userData, thunkAPI) => {
  try {
    const res = await axios.put("/api/patient", userData);
    return res.data;
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});

export const patientSlice = createSlice({
  name: "patient",
  initialState,
  reducers: {
    patientReset: () => initialState,
    removeAlert: (state) => {
      state.alert = initialState.alert;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(getPatientData.fulfilled, (state, action) => {
        state.patient = action.payload;
      })
      .addCase(updatePatient.fulfilled, (state) => {
        state.alert = {
          type: "info",
          message: "Profil zaktualizowano pomyślnie",
        };
      })
      .addCase(updatePatient.rejected, (state) => {
        state.alert = { type: "error", message: "Oops! Coś poszło nie tak" };
      });
  },
});

export const { patientReset, removeAlert } = patientSlice.actions;
export default patientSlice.reducer;
