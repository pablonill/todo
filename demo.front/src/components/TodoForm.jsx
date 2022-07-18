import { useDispatch, useSelector } from 'react-redux';
import { Modal, Button, Form, Row, Col } from 'react-bootstrap';
import { useState } from 'react';
import { setHide } from '../store/slices/todoFormsSlice';
import { saveTodo } from '../store/thunks/thunks';

export const TodoForm = () => {
  const [task, setTask] = useState({
    Task: ""
  });
  const { show } = useSelector(state => state.todoForm);
  const dispatch = useDispatch();

  const handleClose = () => {
    dispatch(setHide());
  }

  const handleOnChange = (e) => {
    if (e.target.name && e.target.value) {
      setTask({
        [e.target.name]: e.target.value
      });  
    }
  }

  const handleSaveChanges = (e) => {
    e.preventDefault();

    dispatch(saveTodo(task));

    handleClose();
  }

  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Add new todo</Modal.Title>
      </Modal.Header>
      <Form onSubmit={handleSaveChanges}>
        <Modal.Body>
          <Row>
            <Col>
              <Form.Group className="mb-3">
              <Form.Label>Task</Form.Label>
              <Form.Control size="sm" type="text" name='Task' onChange={handleOnChange} />
              </Form.Group>
            </Col>
          </Row>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Close
          </Button>
          <Button variant="primary" type='submit'>
            Save
          </Button>
        </Modal.Footer>
      </Form>
    </Modal>    
  )
}