import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { RootState } from "../app/store";
import axios from "axios";
import { RaportViewModel } from "../models/Raports/RaportViewModel";
import { RaportCreateViewModel } from "../models/Raports/RaportCreateViewModel";

interface IRaportState {
  raports: RaportViewModel[];
  loading: "idle" | "pending" | "fulfilled" | "failed";
  error: string | undefined;
}

const initialState: IRaportState = {
  raports: [],
  loading: "idle",
  error: undefined,
};

// Get raports
// GET /api/raport
export const getRaports = createAsyncThunk<
  RaportViewModel[],
  void,
  { state: RootState; rejectValue: string }
>("raport/get", async (_, thunkAPI) => {
  try {
    const res = await axios.get("/api/raport");
    return res.data;
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});

// Create raport
// POST /api/raport/create
export const createRaport = createAsyncThunk<
  RaportViewModel,
  RaportCreateViewModel,
  { state: RootState; rejectValue: string }
>("raport/create", async (raportData, thunkAPI) => {
  try {
    const res = await axios.post("/api/raport/create", raportData);
    return res.data;
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});

// Update raport
// PUT /api/raport/:id/update
export const updateRaport = createAsyncThunk<
  RaportViewModel,
  RaportViewModel,
  { state: RootState; rejectValue: string }
>("raport/update", async (raportData, thunkAPI) => {
  try {
    const res = await axios.put(
      `/api/raport/${raportData.raport.id}/update`,
      raportData
    );
    return res.data;
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});

// Delete raport
// DELETE /api/raport/:id/delete
export const deleteRaport = createAsyncThunk<
  RaportViewModel,
  string,
  { state: RootState; rejectValue: string }
>("raport/delete", async (raportId, thunkAPI) => {
  try {
    const res = await axios.delete(`/api/raport/${raportId}/delete`);
    return res.data;
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});

export const raportSlice = createSlice({
  name: "raport",
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
          raport.raport.id === action.payload.raport.id
            ? action.payload
            : raport
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
          (raport) => raport.raport.id !== action.payload.raport.id
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
