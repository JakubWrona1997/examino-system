import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import { LoginUser, RegisterUser, RegisterError } from "../models/User";

interface IUserState {
  token: string | null;
  loading: "idle" | "pending" | "fulfilled" | "failed";
  error: {
    register: RegisterError | undefined;
    login: string | undefined;
  };
}

const initialState: IUserState = {
  token: null,
  loading: "idle",
  error: {
    register: undefined,
    login: undefined,
  },
};

// Register User
// POST /api/patient/register
export const registerUser = createAsyncThunk<
  string,
  RegisterUser,
  { rejectValue: RegisterError }
>("register", async (userData: RegisterUser, thunkAPI) => {
  try {
    const res = await axios.post("/api/patient/register", userData);
    return res.data;
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data.errors);
  }
});

// Login User
// POST /api/patient/login
export const loginUser = createAsyncThunk<
  string,
  LoginUser,
  { rejectValue: string }
>("login", async (userData: LoginUser, thunkAPI) => {
  try {
    const res = await axios.post("/api/patient/login", userData);
    return res.data;
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});

export const userSlice = createSlice({
  name: "user",
  initialState,
  reducers: {
    logout: () => initialState,
  },
  extraReducers: (builder) => {
    builder
      .addCase(registerUser.pending, (state) => {
        state.loading = "pending";
      })
      .addCase(registerUser.fulfilled, (state, action) => {
        state.loading = "fulfilled";
        state.token = action.payload;
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
        state.token = action.payload;
      })
      .addCase(loginUser.rejected, (state, action) => {
        state.loading = "failed";
        state.error.login = action.payload;
      });
  },
});

export const { logout } = userSlice.actions;
export default userSlice.reducer;
