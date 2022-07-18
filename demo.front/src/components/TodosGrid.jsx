import { useEffect } from 'react';
import { Card, Container, Table, Row, Col, Button } from 'react-bootstrap';
import { useSelector, useDispatch } from 'react-redux';
import { getTodos } from '../store/thunks/thunks';
import { Todo } from './Todo';
import { TodoForm } from './TodoForm';
import { setShow } from '../store/slices/todoFormsSlice';
import { MessageForm } from './MessageForm';

export const TodoGrid = () => {
  const { data } = useSelector(state => state.todo);
  const dispatch = useDispatch();

  const handleForm = () => {
    dispatch(setShow());
  }

  useEffect(() => {
    dispatch(getTodos());
  }, [dispatch]);

  console.log(data);

  return (
  <>
    <br/>
    <Container>
      <TodoForm/>
      <MessageForm/>
      <Row>
        <Col>
          <Card>
            <Card.Body>
              <Button size='sm' variant="success" className='mt-2 mb-2' onClick={ handleForm }>Add Todo</Button>
              <Table striped bordered hover responsive="sm" size="sm">
                <thead>
                  <tr>
                    <th>Id</th>
                    <th>Todo</th>
                    <th>Completed</th>
                    <th>Completed At</th>
                    <th></th>
                    <th></th>
                  </tr>
                </thead>
                <tbody>
                  {
                    data.map(todo => 
                      <Todo key={todo.id} todo={todo}/>
                    )
                  }
                </tbody>
              </Table>
            </Card.Body>
        </Card>        
        </Col>
      </Row>
    </Container>
  </>    
  )
}