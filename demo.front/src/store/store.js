import { configureStore } from '@reduxjs/toolkit';
import { todoSlice } from './slices/todoSlice';
import { todoFormSlice } from './slices/todoFormsSlice';
import { messageFormSlice } from './slices/messageFormSlice';

export const store = configureStore({
  reducer: {
    todo: todoSlice.reducer,
    todoForm: todoFormSlice.reducer,
    messageForm: messageFormSlice.reducer
  },
})