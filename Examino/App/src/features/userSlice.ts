import axios from "axios";
import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { UserViewModel } from "../models/Users/UserViewModel";
import { UserLoginDataViewModel } from "../models/Users/UserLoginDataViewModel";
import { UserRegisterDataViewModel } from "../models/Users/UserRegisterDataViewModel";
import { UserRegisterErrorsViewModel } from "../models/Users/UserRegisterErrorsViewModel";
import { AlertViewModel } from "../models/Alert/AlertViewModel";
import jwtDecode from "../utils/jwtDecode";

interface IUserState {
  user: UserViewModel | null;
  error: {
    register: UserRegisterErrorsViewModel | undefined;
    login: string | undefined;
  };
  alert: AlertViewModel | undefined;
}

const initialState: IUserState = {
  user: null,
  error: {
    register: undefined,
    login: undefined,
  },
  alert: undefined,
};

// Register patient
// POST /api/user/register
export const registerPatient = createAsyncThunk<
  UserViewModel,
  UserRegisterDataViewModel,
  { rejectValue: UserRegisterErrorsViewModel }
>("user/register", async (userData, thunkAPI) => {
  try {
    const res = await axios.post("/api/user/register", userData);
    return jwtDecode(res.data);
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data.errors);
  }
});

// Register doctor
// POST /api/admin/register-doctor
export const registerDoctor = createAsyncThunk<
  void,
  UserRegisterDataViewModel,
  { rejectValue: UserRegisterErrorsViewModel }
>("admin/register-doctor", async (userData, thunkAPI) => {
  try {
    await axios.post("/api/admin/register-doctor", userData);
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data.errors);
  }
});

// Login user
// POST /api/user/login
export const loginUser = createAsyncThunk<
  UserViewModel,
  UserLoginDataViewModel,
  { rejectValue: string }
>("user/login", async (userData, thunkAPI) => {
  try {
    const res = await axios.post("/api/user/login", userData);
    return jwtDecode(res.data);
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});

// Authenticate user
// GET /api/user/auth
export const authenticateUser = createAsyncThunk<
  UserViewModel,
  void,
  { rejectValue: string }
>("user/auth", async (_, thunkAPI) => {
  try {
    const res = await axios.get("/api/user/auth");
    return jwtDecode(res.data);
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});

export const userSlice = createSlice({
  name: "user",
  initialState,
  reducers: {
    logoutUser: () => {
      axios.post("/api/user/logout");
      return initialState;
    },
    removeAlert: (state) => {
      state.alert = initialState.alert;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(registerPatient.fulfilled, (state, action) => {
        state.user = action.payload;
      })
      .addCase(registerPatient.rejected, (state, action) => {
        state.error.register = action.payload;
      })
      .addCase(registerDoctor.fulfilled, (state) => {
        state.alert = {
          type: "info",
          message: "Rejestracja przebiegła pomyślnie",
        };
      })
      .addCase(registerDoctor.rejected, (state, action) => {
        state.error.register = action.payload;
      })
      .addCase(loginUser.fulfilled, (state, action) => {
        state.user = action.payload;
      })
      .addCase(loginUser.rejected, (state, action) => {
        state.error.login = action.payload;
      })
      .addCase(authenticateUser.fulfilled, (state, action) => {
        state.user = action.payload;
      });
  },
});

export const { logoutUser, removeAlert } = userSlice.actions;
export default userSlice.reducer;
