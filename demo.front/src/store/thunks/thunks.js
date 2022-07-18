import axios from 'axios';
import { setTodos, setLoading } from '../slices/todoSlice';
import { setShow } from '../slices/messageFormSlice';

const BASE_URL = process.env.REACT_APP_BASE_API_URL; //'http://localhost:5163/api';

export const getTodos = () => {
    return async (dispatch, getState) => {
      dispatch(setLoading(true));

      const { data } = await axios.get(`${BASE_URL}/todo/all?showDeleted=false`);
      const { error, message } = data;

      dispatch(setLoading(false));
      dispatch(setTodos(data));
      dispatch(setShow({
        error,
        message
      }));  
    }
}

export const saveTodo = (todo) => {
  return async (dispatch, getState) => {
    dispatch(setLoading(true));

    try {
      await axios.post(`${BASE_URL}/todo`, todo);

      dispatch(setLoading(false));
      dispatch(getTodos()); 
    } catch (err) {
      const { data } = err.response;
      const { error, message } = data;

      dispatch(setShow({
        error,
        message
      }));      
    }
  }
}

export const setCompleted = (id) => {
  return async (dispatch, getState) => {
    dispatch(setLoading(true));

    const { data } = await axios.patch(`${BASE_URL}/todo/setcompleted/${id}`);

    dispatch(setLoading(false));
    dispatch(getTodos());
  }
}

export const setDeleted = (id) => {
  return async (dispatch, getState) => {
    dispatch(setLoading(true));

    const { data } = await axios.patch(`${BASE_URL}/todo/setdeleted/${id}`);

    dispatch(setLoading(false));
    dispatch(getTodos());
  }
}