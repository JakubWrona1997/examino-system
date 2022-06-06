import axios from "axios";
import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { UserViewModel } from "../models/Users/UserViewModel";
import { UserLoginDataViewModel } from "../models/Users/UserLoginDataViewModel";
import { UserRegisterDataViewModel } from "../models/Users/UserRegisterDataViewModel";
import { UserRegisterErrorsViewModel } from "../models/Users/UserRegisterErrorsViewModel";
import jwtDecode from "../utils/jwtDecode";

interface IUserState {
  user: UserViewModel | null;
  loading: "idle" | "pending" | "fulfilled" | "failed";
  error: {
    register: UserRegisterErrorsViewModel | undefined;
    login: string | undefined;
  };
}

const initialState: IUserState = {
  user: null,
  loading: "idle",
  error: {
    register: undefined,
    login: undefined,
  },
};

// Register user
// POST /api/patient/register
export const registerUser = createAsyncThunk<
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

// Login user
// POST /api/patient/login
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
// GET /api/patient/auth
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
      });
  },
});

export const { logoutUser } = userSlice.actions;
export default userSlice.reducer;
