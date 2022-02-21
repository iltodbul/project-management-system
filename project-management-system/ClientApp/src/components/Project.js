import React, { useState, useEffect } from 'react';
import { Image } from 'react-bootstrap';
import { useHistory } from 'react-router-dom';

import static_logo from '../assets/static_logo.png';

export function Project() {
  const [project, setProject] = useState({});
  const [loading, setLoading] = useState(true);

  const history = useHistory();

  const routeChange = (e) => {
    let path = `/fetch-data`; // /project/details?id={e.id}
    history.push(path);
  };
  useEffect(() => {
    fetch(`project${location.pathname}`)
      .then((response) => response.json())
      .then((data) => {
        setProject(data);
      });
    setLoading(false);
  }, []);

  function renderProjectsTable(a) {
    return (
      <table className="table table-striped" aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Title</th>
            <th>Status</th>
          </tr>
        </thead>
        <tbody>
          {project.id ? (
            a.map((task) => (
              <tr key={task.id}>
                <td>{task.title}</td>
                <td>{task.status}</td>
              </tr>
            ))
          ) : (
            <tr>
              <td>Loading...</td>
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
    renderProjectsTable(project['tasks'])
  );

  return (
    <div>
      <h1 id="tabelLabel">List of all task in {project.name} project</h1>

      {contents}
    </div>
  );
}
