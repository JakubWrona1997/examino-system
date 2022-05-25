import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { RootState } from "../app/store";
import axios from "axios";
import jwt_decode from "jwt-decode";
import {
  LoginUser,
  RegisterUser,
  RegisterError,
  UserData,
  User,
} from "../models/User";
import { Token } from "../models/Token";

interface IUserState {
  user: User | null;
  userData: UserData;
  loading: "idle" | "pending" | "fulfilled" | "failed";
  error: {
    register: RegisterError | undefined;
    login: string | undefined;
  };
}

const initialState: IUserState = {
  user: null,
  userData: {} as UserData,
  loading: "idle",
  error: {
    register: undefined,
    login: undefined,
  },
};

// Register User
// POST /api/patient/register
export const registerUser = createAsyncThunk<
  User,
  RegisterUser,
  { rejectValue: RegisterError }
>("users/register", async (userData, thunkAPI) => {
  try {
    const res = await axios.post("/api/patient/register", userData);
    const decoded: Token = jwt_decode(res.data);
    return {
      name: decoded[
        "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"
      ],
      role: decoded[
        "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
      ],
      token: res.data,
    };
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data.errors);
  }
});

// Login User
// POST /api/patient/login
export const loginUser = createAsyncThunk<
  User,
  LoginUser,
  { rejectValue: string }
>("users/login", async (userData, thunkAPI) => {
  try {
    const res = await axios.post("/api/patient/login", userData);
    const decoded: Token = jwt_decode(res.data);
    return {
      name: decoded[
        "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"
      ],
      role: decoded[
        "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
      ],
      token: res.data,
    };
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});

// Get user data
// GET /api/patient
export const getUser = createAsyncThunk<
  UserData,
  void,
  { state: RootState; rejectValue: string }
>("users/get", async (_, thunkAPI) => {
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
  UserData,
  UserData,
  { state: RootState; rejectValue: string }
>("users/update", async (userData, thunkAPI) => {
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
    logout: () => initialState,
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

export const { logout } = userSlice.actions;
export default userSlice.reducer;
