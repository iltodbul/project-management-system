import React, { useState, useEffect } from 'react';
import { useHistory } from 'react-router-dom';

export function Project() {
  const [project, setProject] = useState({});
  const [taskId, setTaskId] = useState();
  const [loading, setLoading] = useState(true);

  const history = useHistory();

  useEffect(() => {
    if (taskId) {
      let path = `/task/${taskId}`;
      history.push(path);
    }
  }, [taskId]);

  useEffect(() => {
    fetch(`project${location.pathname}`)
      .then((response) => response.json())
      .then((data) => {
        setProject(data);
      });
    setLoading(false);
  }, []);

  function renderTasksTable(a) {
    return (
      <table className="table table-striped" aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Title</th>
            <th>Status</th>
          </tr>
        </thead>
        <tbody>
          {project['tasks'] ? (
            a.map((task) => (
              <tr onClick={() => setTaskId(task.id)} key={task.id}>
                <td>{task.title}</td>
                <td>{task.status}</td>
              </tr>
            ))
          ) : (
            <tr>
              <td>This project has not task</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  let contents = loading ? (
    <p>
      <em>Loading...</em>
    </p>
  ) : (
    renderTasksTable(project['tasks'])
  );

  return (
    <div>
      <h1 id="tabelLabel">List of all task in {project.name} project</h1>

      {contents}
    </div>
  );
}
