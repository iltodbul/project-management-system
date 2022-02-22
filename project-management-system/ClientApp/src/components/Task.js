import React, { useState, useEffect } from 'react';
import { useHistory } from 'react-router-dom';
import { Button } from 'react-bootstrap';

import { EditTaskModal } from './modals/EditTaskModal';

export function Task() {
  const [task, setTask] = useState({});
  const [loading, setLoading] = useState(true);
  const [modal, setModal] = useState(false);

  const history = useHistory();

  const routeChange = () => {
    setModal(true);
  };

  useEffect(() => {
    let path = location.pathname.split('/').reverse();
    let id = path[0];
    fetch(`task/details/${id}`)
      .then((response) => response.json())
      .then((data) => {
        setTask(data);
      });
    setLoading(false);
  }, []);

  function renderTaskTable(t) {
    return (
      <table className="table table-striped" aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>
              <h2>Selected task's details</h2>
            </th>
            <td>
              <Button onClick={routeChange}>Edit task</Button>
            </td>
          </tr>
        </thead>
        <tbody>
          <tr>
            <th>ID</th>
            <td>{t.id}</td>
          </tr>
          <tr>
            <th>Type</th>
            <td>{t.taskType}</td>
          </tr>
          <tr>
            <th>Title</th>
            <td>{t.title}</td>
          </tr>
          <tr>
            <th>Description</th>
            <td>{t.description}</td>
          </tr>
          <tr>
            <th>Assignee</th>
            <td>{t.assignee}</td>
          </tr>
          <tr>
            <th>Priority</th>
            <td>{t.priority}</td>
          </tr>
          <tr>
            <th>Status</th>
            <td>{t.status}</td>
          </tr>
          <tr>
            <th>Estimate</th>
            <td>{t.estimate}</td>
          </tr>
          <tr>
            <th>Created at</th>
            <td>{t.createdAt}</td>
          </tr>
        </tbody>
      </table>
    );
  }

  let contents = loading ? (
    <p>
      <em>Loading...</em>
    </p>
  ) : (
    renderTaskTable(task)
  );

  return (
    <div>
      {/* <h1 id="tabelLabel">Selected task's details</h1> */}

      {contents}

      {modal ? <EditTaskModal /> : ''}
    </div>
  );
}
