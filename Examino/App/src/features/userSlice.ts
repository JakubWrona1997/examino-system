import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { RootState } from "../app/store";
import axios from "axios";
import { UserViewModel } from "../models/Users/UserViewModel";
import { UserDataViewModel } from "../models/Users/UserDataViewModel";
import { UserLoginDataViewModel } from "../models/Users/UserLoginDataViewModel";
import { UserRegisterDataViewModel } from "../models/Users/UserRegisterDataViewModel";
import { UserRegisterErrorsViewModel } from "../models/Users/UserRegisterErrorsViewModel";
import jwtDecode from "../utils/jwtDecode";
import userFromLocalStorage from "../utils/userFromLocalStorage";

interface IUserState {
  user: UserViewModel | null;
  userData: UserDataViewModel;
  loading: "idle" | "pending" | "fulfilled" | "failed";
  error: {
    register: UserRegisterErrorsViewModel | undefined;
    login: string | undefined;
  };
}

const initialState: IUserState = {
  user: userFromLocalStorage(),
  userData: {} as UserDataViewModel,
  loading: "idle",
  error: {
    register: undefined,
    login: undefined,
  },
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
    localStorage.setItem("token", res.data);
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
    localStorage.setItem("token", res.data);
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
  { state: RootState; rejectValue: string }
>("user/get", async (_, thunkAPI) => {
  try {
    const token = thunkAPI.getState().user.user?.token;
    const config = {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    };
    const res = await axios.get("/api/patient", config);
    return res.data;
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});

// Update User
// PUT /api/patient/update
export const updateUser = createAsyncThunk<
  UserDataViewModel,
  UserDataViewModel,
  { state: RootState; rejectValue: string }
>("user/update", async (userData, thunkAPI) => {
  try {
    const token = thunkAPI.getState().user.user?.token;
    const config = {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    };
    const res = await axios.put("/api/patient/update", userData, config);
    return res.data;
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});

export const userSlice = createSlice({
  name: "user",
  initialState,
  reducers: {
    logoutUser: (state) => {
      localStorage.removeItem("token");
      state.user = null;
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
      .addCase(updateUser.pending, (state) => {
        state.loading = "pending";
      })
      .addCase(updateUser.fulfilled, (state, action) => {
        state.loading = "fulfilled";
        state.userData = action.payload;
      })
      .addCase(updateUser.rejected, (state) => {
        state.loading = "failed";
      });
  },
});

export const { logoutUser } = userSlice.actions;
export default userSlice.reducer;
