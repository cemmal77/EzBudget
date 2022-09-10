import { configureStore } from '@reduxjs/toolkit';
import communicationSlice from './CommunicationSlice';

export default configureStore({
  reducer: {
    communication: communicationSlice,
  },
});
