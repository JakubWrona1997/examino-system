import axios from "axios";
import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { UserViewModel } from "../models/Users/UserViewModel";
import { UserDataViewModel } from "../models/Users/UserDataViewModel";
import { UserUpdateDataViewModel } from "../models/Users/UserUpdatedDataViewModel";
import { UserLoginDataViewModel } from "../models/Users/UserLoginDataViewModel";
import { UserRegisterDataViewModel } from "../models/Users/UserRegisterDataViewModel";
import { UserRegisterErrorsViewModel } from "../models/Users/UserRegisterErrorsViewModel";
import jwtDecode from "../utils/jwtDecode";

interface IUserState {
  user: UserViewModel | null;
  userData: UserDataViewModel;
  loading: "idle" | "pending" | "fulfilled" | "failed";
  error: {
    register: UserRegisterErrorsViewModel | undefined;
    login: string | undefined;
  };
  alert: string | undefined;
}

const initialState: IUserState = {
  user: null,
  userData: {} as UserDataViewModel,
  loading: "idle",
  error: {
    register: undefined,
    login: undefined,
  },
  alert: undefined,
};

// Register User
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

// Login User
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

// Get user data
// GET /api/patient
export const getUser = createAsyncThunk<
  UserDataViewModel,
  void,
  { rejectValue: string }
>("user/get", async (_, thunkAPI) => {
  try {
    const res = await axios.get("/api/patient");
    return res.data;
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});

// Update User
// PUT /api/patient/update
export const updateUser = createAsyncThunk<
  void,
  UserUpdateDataViewModel,
  { rejectValue: string }
>("user/update", async (userData, thunkAPI) => {
  try {
    const res = await axios.put("/api/patient", userData);
    return res.data;
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
      .addCase(getUser.pending, (state) => {
        state.loading = "pending";
      })
      .addCase(getUser.fulfilled, (state, action) => {
        state.loading = "fulfilled";
        state.userData = action.payload;
      })
      .addCase(getUser.rejected, (state) => {
        state.loading = "failed";
      })
      .addCase(updateUser.fulfilled, (state) => {
        state.alert = "Profil zaktualizowano pomyślnie";
      })
      .addCase(authenticateUser.fulfilled, (state, action) => {
        state.user = action.payload;
      });
  },
});

export const { logoutUser, removeAlert } = userSlice.actions;
export default userSlice.reducer;
