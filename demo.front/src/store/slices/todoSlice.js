import { createSlice } from '@reduxjs/toolkit'

const initialState = {
  data: [],
  message: "",
  loading: false,
  error: false,
}

export const todoSlice = createSlice({
  name: 'todo',
  initialState,
  reducers: {
    setTodos: (state, action) => {
      state.data = action.payload.data;
      state.message = action.payload.message;
      state.error = action.payload.error;
    },
    setLoading: (state, action) => {
      state.loading = action.payload;
    }
  }
})

export const { setTodos, setLoading } = todoSlice.actions