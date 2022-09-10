import { createSlice, configureStore } from '@reduxjs/toolkit';

const communicationSlice = createSlice({
  name: 'communication',
  initialState: {
    isFetching: false,
  },
  reducers: {
    isFetching: (state) => {
      state.isFetching = true;
    },
    isIdle: (state) => {
      state.isFetching = false;
    },
  },
});

export const { isFetching, isIdle } = communicationSlice.actions;
export default communicationSlice.reducer;
