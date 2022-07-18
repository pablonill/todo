import { createSlice } from '@reduxjs/toolkit'

const initialState = {
  show: false,
  error: false,
  message: ""
}

export const messageFormSlice = createSlice({
  name: 'messageForm',
  initialState,
  reducers: {
    setShow: (state, action) => {
      state.show = true;
      state.error = action.payload.error;
      state.message = action.payload.message;
    },
    setHide: (state, action) => {
      state.show = false;
    }    
  }
})

export const { setShow, setHide } = messageFormSlice.actions