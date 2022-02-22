import React, { useState, useEffect } from 'react';
import axios from 'axios'
import { useHistory } from 'react-router-dom';
import { Button, Modal, Form } from 'react-bootstrap';

export function EditTaskModal() {
  const [show, setShow] = useState(true);
  const [task, setTask] = useState({});

  const[id, setId] = useState('');
  const[taskType, setTaskType] = useState('');
  const[title, setTitle] = useState('');
  const[description, setDescription] = useState('');
  const[assignee, setAssignee] = useState('');
  const[priority, setPriority] = useState('');
  const[status, setStatus] = useState('');
  const[estimate, setEstimate] = useState('');
  const[createdAt, setCreatedAt] = useState('');

  const history = useHistory();
  const handleClose = () => setShow(false);

  useEffect(() => {
    let path = location.pathname.split('/').reverse();
    let id = path[0];
    fetch(`task/details/${id}`)
      .then((response) => response.json())
      .then((data) => {
        setTask(data);
        setId(data.id);
        setTaskType(data.taskType);
        setTitle(data.title);
        setDescription(data.description);
        setAssignee(data.assignee);
        setPriority(data.priority);
        setStatus(data.status);
        setEstimate(data.estimate);
        setCreatedAt(data.createdAt);
      });
  }, []);

  function editTask(e) {
    e.preventDefault();
    let newTask = {id, taskType, title, description, assignee, priority, status, estimate, createdAt}
    console.log(newTask);

    let result = axios.put('task', newTask)

    // TODO change data in the server
    setShow(false);
    history.goBack();
  }

  const titleOnChange = (e) => {
    setTitle(e.target.value);
  };
  
  const taskTypeOnChange = (e) => {
    setTaskType(e.target.value);
  };

  const descriptionOnChange = (e) => {
    setDescription(e.target.value);
  };

  const assigneeOnChange = (e) => {
    setAssignee(e.target.value);
  };

  const priorityOnChange = (e) => {
    setPriority(e.target.value);
  };

  const statusOnChange = (e) => {
    setStatus(e.target.value);
  };

  const estimateOnChange = (e) => {
    setEstimate(e.target.value);
  };

  return (
    <>
      <Modal show={show} onHide={handleClose}>
        <Modal.Header>
          <Modal.Title>Modal for task editing</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form>
            <Form.Group className="mb-3" controlId="taskType">
              <Form.Label>Type</Form.Label>
              <br />
              <Form.Select onChange={taskTypeOnChange}>
                <option>{taskType}</option>
                <option value="1">Story</option>
                <option value="2">Bug</option>
              </Form.Select>
            </Form.Group>

            <Form.Group className="mb-3" controlId="title">
              <Form.Label>Title</Form.Label>
              <Form.Control onChange={titleOnChange} type="text" value={title} />
            </Form.Group>

            <Form.Group className="mb-3" controlId="description">
              <Form.Label>Description</Form.Label>
              <Form.Control onChange={descriptionOnChange} as="textarea" value={description} />
            </Form.Group>

            <Form.Group className="mb-3" controlId="assignee">
              <Form.Label>Assignee</Form.Label>
              <Form.Control onChange={assigneeOnChange} type="text" value={assignee} />
            </Form.Group>

            <Form.Group className="mb-3" controlId="priority">
              <Form.Label>Priority</Form.Label>
              <br />
              <Form.Select onChange={priorityOnChange}>
                <option>{priority}</option>
                <option value="1">Low</option>
                <option value="2">Normal</option>
                <option value="3">High</option>
                <option value="4">Critical</option>
              </Form.Select>
            </Form.Group>

            <Form.Group className="mb-3" controlId="status">
              <Form.Label>Status</Form.Label>
              <br />
              <Form.Select onChange={statusOnChange}>
                <option>{status}</option>
                <option value="1">To Do</option>
                <option value="2">In Progress</option>
                <option value="3">Ready for Test</option>
                <option value="4">Done</option>
              </Form.Select>
            </Form.Group>

            <Form.Group className="mb-3" controlId="estimate">
              <Form.Label>Estimate</Form.Label>
              <Form.Control onChange={estimateOnChange} type="number" value={estimate} />
            </Form.Group>

            <Button onClick={editTask} variant="primary" type="button">
              Submit
            </Button>
          </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Close
          </Button>
        </Modal.Footer>
      </Modal>
    </>
  );
}
