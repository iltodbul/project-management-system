import React, { useState, useEffect } from 'react';
import { Image } from 'react-bootstrap';
import { useHistory } from 'react-router-dom';
import { Button } from 'reactstrap';

import { AddProject } from './modals/AddProject';
import static_logo from '../assets/static_logo.png';

export function Projects() {
  const [projects, setProjects] = useState([]);
  const [projectId, setProjectId] = useState();
  const [loading, setLoading] = useState(true);
  const [modal, setModal] = useState(false);

  const history = useHistory();

  useEffect(() => {
    if (projectId) {
      let path = `/details/${projectId}`;
      history.push(path);
    }
  }, [projectId]);

  useEffect(() => {
    fetch('project')
      .then((response) => response.json())
      .then((data) => {
        setProjects(data);
      });
    setLoading(false);
  }, []);

  function renderProjectsTable(projects) {
    return (
      <table className="table table-striped" aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Logo</th>
            <th>Project name</th>
            <th>Details</th>
          </tr>
        </thead>
        <tbody>
          {projects.map((project) => (
            <tr onClick={() => setProjectId(project.id)} key={project.id}>
              <td>
                <Image
                  style={{
                    width: '6rem',
                    height: '6rem',
                    display: 'inline-flex',
                  }}
                  fluid={true}
                  src={static_logo}
                ></Image>
              </td>
              <td>{project.name}</td>
              <td>
                <Button color="primary" size="lg">
                  View more
                </Button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }

  let contents = loading ? (
    <p>
      <em>Loading...</em>
    </p>
  ) : (
    renderProjectsTable(projects)
  );

  return (
    <div>
      <h1 id="tabelLabel">List of all projects</h1>
      <p>This component fetching data from the server.</p>
      {contents}
      <Button onClick={() => setModal(true)} color="success" size="lg">
        Add new project
      </Button>
      
      {modal ? <AddProject /> : ''}
    </div>
  );
}
