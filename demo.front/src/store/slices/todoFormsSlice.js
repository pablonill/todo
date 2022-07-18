import { createSlice } from '@reduxjs/toolkit'

const initialState = {
  show: false
}

export const todoFormSlice = createSlice({
  name: 'todoForm',
  initialState,
  reducers: {
    setShow: (state, action) => {
      state.show = true;
    },
    setHide: (state, action) => {
      state.show = false;
    }
  }
})

export const { setShow, setHide } = todoFormSlice.actions