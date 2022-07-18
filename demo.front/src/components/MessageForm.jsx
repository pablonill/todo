import { useDispatch, useSelector } from 'react-redux';
import { Modal, Button, Row, Col, Alert } from 'react-bootstrap';
import { setHide } from '../store/slices/messageFormSlice';

export const MessageForm = () => {
  const { show, error, message } = useSelector(state => state.messageForm);
  const dispatch = useDispatch();

  const handleClose = () => {
    dispatch(setHide());
  }

  setTimeout(() => {
    handleClose();
  }, 2000);
  
  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Todo info { error ? 'Ops something went wrong' : '' }</Modal.Title>        
      </Modal.Header>
      <Modal.Body>
          <Row>
            <Col>
              <Alert variant={error ? 'danger' : 'success'}>{message}</Alert>
            </Col>
          </Row>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Close
          </Button>
        </Modal.Footer>
    </Modal>    
  )
}