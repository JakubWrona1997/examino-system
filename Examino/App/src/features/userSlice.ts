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
}

const initialState: IUserState = {
  user: null,
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
    const res = await axios.post("/api/patient/register", userData, {
      withCredentials: true,
    });
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
    const res = await axios.post("/api/patient/login", userData, {
      withCredentials: true,
    });
    return jwtDecode(res.data);
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});

// Logout User
// POST /api/patient/logout
export const logoutUser = createAsyncThunk<void, void, { rejectValue: string }>(
  "user/logout",
  async (_, thunkAPI) => {
    try {
      await axios.post("/api/patient/logout");
    } catch (error: any) {
      return thunkAPI.rejectWithValue(error.response.data);
    }
  }
);

// Get user data
// GET /api/patient
export const getUser = createAsyncThunk<
  UserDataViewModel,
  void,
  { rejectValue: string }
>("user/get", async (_, thunkAPI) => {
  try {
    const res = await axios.get("/api/patient", {withCredentials: true});
    return res.data;
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});

// Update User
// PUT /api/patient/update
export const updateUser = createAsyncThunk<
  UserDataViewModel,
  UserUpdateDataViewModel,
  { rejectValue: string }
>("user/update", async (userData, thunkAPI) => {
  try {
    const res = await axios.put("/api/patient/update", userData);
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
      })
      .addCase(authenticateUser.pending, (state) => {
        state.loading = "pending";
      })
      .addCase(authenticateUser.fulfilled, (state, action) => {
        state.loading = "fulfilled";
        state.user = action.payload;
      })
      .addCase(authenticateUser.rejected, (state) => {
        state.loading = "failed";
      })
      .addCase(logoutUser.fulfilled, (state) => {
        state.loading = initialState.loading;
        state.user = initialState.user;
        state.userData = initialState.userData;
      });
  },
});

export default userSlice.reducer;
