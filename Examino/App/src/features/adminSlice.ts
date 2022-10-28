import axios from "axios";
import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { DoctorShortDetailsViewModel } from "../models/Users/Doctor/DoctorShortDetailsViewModel";
import { AlertViewModel } from "../models/Alert/AlertViewModel";

interface IAdminState {
  doctors: DoctorShortDetailsViewModel[];
  alert: AlertViewModel | undefined;
}

const initialState: IAdminState = {
  doctors: [],
  alert: undefined,
};

// Get doctors
// GET /api/admin/doctors-list
export const getDoctors = createAsyncThunk<
  DoctorShortDetailsViewModel[],
  void,
  { rejectValue: string }
>("admin/get", async (_, thunkAPI) => {
  try {
    const res = await axios.get("/api/admin");
    return res.data;
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});

// Delete doctor
// DELETE /api/admin/:id
export const deleteDoctor = createAsyncThunk<
  { id: string },
  string,
  { rejectValue: string }
>("admin/delete", async (doctorId, thunkAPI) => {
  try {
    const res = await axios.delete(`/api/admin/${doctorId}`);
    return res.data;
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});

// Change password
// DELETE /api/admin/change-password
export const changePassword = createAsyncThunk<
  void,
  { currentPassword: string; newPassword: string },
  { rejectValue: string }
>("admin/changePassword", async (passwords, thunkAPI) => {
  try {
    const res = await axios.put("/api/admin/change-password", passwords);
    return res.data;
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});

export const adminSlice = createSlice({
  name: "admin",
  initialState,
  reducers: {
    removeAlert: (state) => {
      state.alert = initialState.alert;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(getDoctors.fulfilled, (state, action) => {
        state.doctors = action.payload;
      })
      .addCase(deleteDoctor.fulfilled, (state, action) => {
        state.doctors = state.doctors.filter(
          (doctor) => doctor.id !== action.payload.id
        );
      })
      .addCase(deleteDoctor.rejected, (state) => {
        state.alert = { type: "error", message: "Oops! Coś poszło nie tak" };
      })
      .addCase(changePassword.fulfilled, (state) => {
        state.alert = { type: "success", message: "Hasło zostało zmienione" };
      })
      .addCase(changePassword.rejected, (state) => {
        state.alert = { type: "error", message: "Oops! Coś poszło nie tak" };
      });
  },
});

export const { removeAlert } = adminSlice.actions;
export default adminSlice.reducer;
