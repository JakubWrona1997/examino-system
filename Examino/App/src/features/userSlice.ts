import axios from "axios";
import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { UserViewModel } from "../models/Users/UserViewModel";
import { UserLoginDataViewModel } from "../models/Users/UserLoginDataViewModel";
import { UserRegisterDataViewModel } from "../models/Users/UserRegisterDataViewModel";
import { UserRegisterErrorsViewModel } from "../models/Users/UserRegisterErrorsViewModel";
import { PatientDataViewModel } from "../models/Users/Patient/PatientDataViewModel";
import { PatientUpdateDataViewModel } from "../models/Users/Patient/PatientUpdateDataViewModel";
import { DoctorDataViewModel } from "../models/Users/Doctor/DoctorDataViewModel";
import { DoctorUpdateDataViewModel } from "../models/Users/Doctor/DoctorUpdateDataViewModel";
import jwtDecode from "../utils/jwtDecode";

interface IUserState {
  user: UserViewModel | null;
  userData: PatientDataViewModel | DoctorDataViewModel | undefined;
  loading: "idle" | "pending" | "fulfilled" | "failed";
  error: {
    register: UserRegisterErrorsViewModel | undefined;
    login: string | undefined;
  };
  alert: string | undefined;
}

const initialState: IUserState = {
  user: null,
  userData: undefined,
  loading: "idle",
  error: {
    register: undefined,
    login: undefined,
  },
  alert: undefined,
};

// Register user
// POST /api/patient/register
export const registerUser = createAsyncThunk<
  UserViewModel,
  UserRegisterDataViewModel,
  { rejectValue: UserRegisterErrorsViewModel }
>("user/register", async (userData, thunkAPI) => {
  try {
    const res = await axios.post("/api/patient/register", userData);
    return jwtDecode(res.data);
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data.errors);
  }
});

// Login user
// POST /api/patient/login
export const loginUser = createAsyncThunk<
  UserViewModel,
  UserLoginDataViewModel,
  { rejectValue: string }
>("user/login", async (userData, thunkAPI) => {
  try {
    const res = await axios.post("/api/patient/login", userData);
    return jwtDecode(res.data);
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});

// Authenticate user
// GET /api/patient/auth
export const authenticateUser = createAsyncThunk<
  UserViewModel,
  void,
  { rejectValue: string }
>("user/auth", async (_, thunkAPI) => {
  try {
    const res = await axios.get("/api/patient/auth");
    return jwtDecode(res.data);
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});

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

export const userSlice = createSlice({
  name: "user",
  initialState,
  reducers: {
    logoutUser: () => {
      axios.post("/api/patient/logout");
      return initialState;
    },
    removeAlert: (state) => {
      state.alert = initialState.alert;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(registerUser.pending, (state) => {
        state.loading = "pending";
      })
      .addCase(registerUser.fulfilled, (state, action) => {
        state.loading = "fulfilled";
        state.user = action.payload;
      })
      .addCase(registerUser.rejected, (state, action) => {
        state.loading = "failed";
        state.error.register = action.payload;
      })
      .addCase(loginUser.pending, (state) => {
        state.loading = "pending";
      })
      .addCase(loginUser.fulfilled, (state, action) => {
        state.loading = "fulfilled";
        state.user = action.payload;
      })
      .addCase(loginUser.rejected, (state, action) => {
        state.loading = "failed";
        state.error.login = action.payload;
      })
      .addCase(authenticateUser.fulfilled, (state, action) => {
        state.user = action.payload;
      })
      .addCase(getPatientData.fulfilled, (state, action) => {
        state.userData = action.payload;
      })
      .addCase(getDoctorData.fulfilled, (state, action) => {
        state.userData = action.payload;
      })
      .addCase(updatePatient.fulfilled, (state) => {
        state.alert = "Profil zaktualizowano pomyślnie";
      })
      .addCase(updateDoctor.fulfilled, (state) => {
        state.alert = "Profil zaktualizowano pomyślnie";
      });
  },
});

export const { logoutUser, removeAlert } = userSlice.actions;
export default userSlice.reducer;
