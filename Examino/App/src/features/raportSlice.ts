import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { RootState } from "../app/store";
import axios from "axios";
import { RaportViewModel } from "../models/Raports/RaportViewModel";
import { RaportCreateViewModel } from "../models/Raports/RaportCreateViewModel";
import { AlertViewModel } from "../models/Alert/AlertViewModel";

interface IRaportState {
  raports: RaportViewModel[];
  error: string | undefined;
  alert: AlertViewModel | undefined;
}

const initialState: IRaportState = {
  raports: [],
  error: undefined,
  alert: undefined,
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
  string,
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
// PUT /api/raport/:id
export const updateRaport = createAsyncThunk<
  RaportViewModel,
  RaportViewModel,
  { state: RootState; rejectValue: string }
>("raport/update", async (raportData, thunkAPI) => {
  try {
    const res = await axios.put(`/api/raport/${raportData.id}`, raportData);
    return res.data;
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});

// Delete raport
// DELETE /api/raport/:id
export const deleteRaport = createAsyncThunk<
  { id: string },
  string,
  { state: RootState; rejectValue: string }
>("raport/delete", async (raportId, thunkAPI) => {
  try {
    const res = await axios.delete(`/api/raport/${raportId}`);
    return res.data;
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});

export const raportSlice = createSlice({
  name: "raport",
  initialState,
  reducers: {
    removeAlert: (state) => {
      state.alert = initialState.alert;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(getRaports.fulfilled, (state, action) => {
        state.raports = action.payload;
      })
      .addCase(createRaport.fulfilled, (state) => {
        state.alert = {
          type: "info",
          message: "Raport dodany pomyślnie",
        };
      })
      .addCase(createRaport.rejected, (state) => {
        state.alert = {
          type: "error",
          message: "Oops! Coś poszło nie tak",
        };
      })
      .addCase(updateRaport.fulfilled, (state, action) => {
        state.raports = state.raports.filter((raport) =>
          raport.id === action.payload.id ? action.payload : raport
        );
      })
      .addCase(deleteRaport.fulfilled, (state, action) => {
        state.raports = state.raports.filter(
          (raport) => raport.id !== action.payload.id
        );
      });
  },
});

export const { removeAlert } = raportSlice.actions;
export default raportSlice.reducer;
