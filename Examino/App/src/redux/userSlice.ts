import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import { LoginUser, RegisterUser, User } from "../models/User";

let user: User | null = null;
const userFromLocalStorage = localStorage.getItem("user");
if (userFromLocalStorage !== null) {
  user = JSON.parse(userFromLocalStorage);
}

interface IUserState {
  user: User | null;
  loading: "idle" | "pending" | "fulfilled" | "failed";
}

const initialState: IUserState = {
  user: user,
  loading: "idle",
};

// Register User
// POST /api/...
export const registerUser = createAsyncThunk<User, RegisterUser>(
  "register",
  async (user: RegisterUser, thunkAPI) => {
    try {
      // TODO add endpoint url
      const res = await axios.post("api/...", user);
      if (res.data) {
        localStorage.setItem("user", JSON.stringify(res.data));
      }
      return res.data;
    } catch (error: any) {
      return thunkAPI.rejectWithValue(error);
    }
  }
);

// Login User
// POST /api/...
export const loginUser = createAsyncThunk<User, LoginUser>(
  "login",
  async (user: LoginUser, thunkAPI) => {
    try {
      // TODO add endpoint url
      const res = await axios.post("api/...", user);
      if (res.data) {
        localStorage.setItem("user", JSON.stringify(res.data));
      }
      return res.data;
    } catch (error: any) {
      return thunkAPI.rejectWithValue(error);
    }
  }
);

// Logout User
export const logoutUser = createAsyncThunk("logout", async () => {
  await localStorage.removeItem("user");
});

export const userSlice = createSlice({
  name: "user",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(registerUser.pending, (state) => {
        state.loading = "pending";
      })
      .addCase(registerUser.fulfilled, (state, action) => {
        state.loading = "fulfilled";
        state.user = action.payload;
      })
      .addCase(registerUser.rejected, (state) => {
        state.loading = "failed";
      })
      .addCase(loginUser.pending, (state) => {
        state.loading = "pending";
      })
      .addCase(loginUser.fulfilled, (state, action) => {
        state.loading = "fulfilled";
        state.user = action.payload;
      })
      .addCase(loginUser.rejected, (state) => {
        state.loading = "failed";
      })
      .addCase(logoutUser.fulfilled, (state) => {
        state.user = null;
      });
  },
});

export default userSlice.reducer;
