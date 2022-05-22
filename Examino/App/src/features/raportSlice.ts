import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { RootState } from "../app/store";
import axios from "axios";
import { CreateRaport, Raport } from "../models/Raport";

interface IRaportState {
  raports: Raport[];
  loading: "idle" | "pending" | "fulfilled" | "failed";
  error: string | undefined;
}

const initialState: IRaportState = {
  raports: [],
  loading: "idle",
  error: undefined,
};

// Get raports
// GET /api/raports
export const getRaports = createAsyncThunk<
  Raport[],
  void,
  { state: RootState; rejectValue: string }
>("raports/get", async (_, thunkAPI) => {
  try {
    // TODO
    const token = thunkAPI.getState().user.token;
    const config = {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    };
    const res = await axios.get("/api/raports", config);
    return res.data;
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});

// Create raport
// POST /api/raports/create
export const createRaport = createAsyncThunk<
  Raport,
  CreateRaport,
  { state: RootState; rejectValue: string }
>("raports/create", async (raportData, thunkAPI) => {
  try {
    // TODO
    const token = thunkAPI.getState().user.token;
    const config = {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    };
    const res = await axios.post("/api/raports/create", raportData, config);
    return res.data;
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});

// Update raport
// PUT /api/raports/:id/update
export const updateRaport = createAsyncThunk<
  Raport,
  Raport,
  { state: RootState; rejectValue: string }
>("raports/update", async (raportData, thunkAPI) => {
  try {
    // TODO
    const token = thunkAPI.getState().user.token;
    const config = {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    };
    const res = await axios.put(
      `/api/raports/${raportData.id}/update`,
      raportData,
      config
    );
    return res.data;
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});

// Delete raport
// DELETE /api/raports/:id/delete
export const deleteRaport = createAsyncThunk<
  Raport,
  string,
  { state: RootState; rejectValue: string }
>("raports/delete", async (raportId, thunkAPI) => {
  try {
    // TODO
    const token = thunkAPI.getState().user.token;
    const config = {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    };
    const res = await axios.delete(`/api/raports/${raportId}/delete`, config);
    return res.data;
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});

export const raportSlice = createSlice({
  name: "raports",
  initialState,
  reducers: {
    reset: () => initialState,
  },
  extraReducers: (builder) => {
    builder
      .addCase(getRaports.pending, (state) => {
        state.loading = "pending";
      })
      .addCase(getRaports.fulfilled, (state, action) => {
        state.loading = "fulfilled";
        state.raports = action.payload;
      })
      .addCase(getRaports.rejected, (state, action) => {
        state.loading = "failed";
        state.error = action.payload;
      })
      .addCase(createRaport.pending, (state) => {
        state.loading = "pending";
      })
      .addCase(createRaport.fulfilled, (state, action) => {
        state.loading = "fulfilled";
        state.raports.push(action.payload);
      })
      .addCase(createRaport.rejected, (state, action) => {
        state.loading = "failed";
        state.error = action.payload;
      })
      .addCase(updateRaport.pending, (state) => {
        state.loading = "pending";
      })
      .addCase(updateRaport.fulfilled, (state, action) => {
        state.loading = "fulfilled";
        state.raports = state.raports.filter((raport) =>
          raport.id === action.payload.id ? action.payload : raport
        );
      })
      .addCase(updateRaport.rejected, (state, action) => {
        state.loading = "failed";
        state.error = action.payload;
      })
      .addCase(deleteRaport.pending, (state) => {
        state.loading = "pending";
      })
      .addCase(deleteRaport.fulfilled, (state, action) => {
        state.loading = "fulfilled";
        state.raports = state.raports.filter(
          (raport) => raport.id !== action.payload.id
        );
      })
      .addCase(deleteRaport.rejected, (state, action) => {
        state.loading = "failed";
        state.error = action.payload;
      });
  },
});

export const { reset } = raportSlice.actions;
export default raportSlice.reducer;
