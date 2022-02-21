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
    fetch(`project/details?id=1`)
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
            <th>{project.name}</th>
            <th>Empty for now</th>
          </tr>
        </thead>
        <tbody>
          {project.name ? (
            a.map((task) => (
              <tr key={task.id}>
                <td>{task.id}</td>
                <td>{task.title}</td>
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
      <h1 id="tabelLabel">List of all projects</h1>
      <p>This component fetching data from the server.</p>

      {contents}
    </div>
  );
}
