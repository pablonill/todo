import { Button } from 'react-bootstrap';
import { useDispatch } from 'react-redux';
import Moment from 'moment';
import { setCompleted, setDeleted } from '../store/thunks/thunks';

export const Todo = ({todo}) => {
  const { id, task, completedDate } = todo;
  const dispatch = useDispatch();

  const handleSetCompleted = () => {
    dispatch(setCompleted(id));
  }

  const handleDelete = () => {
    dispatch(setDeleted(id));
  }


  return <>
    <tr>
      <td>{id}</td>
      <td>{task}</td>
      <td>{completedDate ? 'Completed' : 'Pending'}</td>
      <td>{completedDate ? Moment(completedDate).format('dd/MM/yyyy hh:mm') : ''}</td>
      <td className='d-grid gap-2'>
          <Button size='sm' variant="primary" disabled={completedDate} onClick={handleSetCompleted}>Set Completed</Button>
      </td>
      <td className='gap-2'>
        <Button size='sm' variant="danger" onClick={handleDelete}>Delete</Button>
      </td>
    </tr>    
  </>
}