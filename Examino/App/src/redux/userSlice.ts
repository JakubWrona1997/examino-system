import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import { LoginUser, RegisterUser } from "../models/User";

interface IUserState {
  token: string | null;
  loading: "idle" | "pending" | "fulfilled" | "failed";
  error: string | null | undefined;
}

const initialState: IUserState = {
  token: null,
  loading: "idle",
  error: null,
};

// Register User
// POST /api/patient/register
export const registerUser = createAsyncThunk<
  string,
  RegisterUser,
  { rejectValue: string }
>("register", async (userData: RegisterUser, thunkAPI) => {
  try {
    const res = await axios.post("/api/patient/register", userData);
    return res.data;
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.message);
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
    return thunkAPI.rejectWithValue(error.message);
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
        state.error = action.payload;
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
        state.error = action.payload;
      });
  },
});

export const { logout } = userSlice.actions;
export default userSlice.reducer;
