import React, {useState, useEffect, Fragment} from "react";
import Table from 'react-bootstrap/Table';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Container from "react-bootstrap/Container";
import axios from 'axios';

const CRUD = () => {

    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    const[editName, setEditName] = useState('');
    const[editLastName, setEditLastName] = useState('');
    const[editEmail, setEditEmail] = useState('');
    const[editRole, setEditRole] = useState('');
    const[editLogin, setEditLogin] = useState('');
    const[editPassword, setEditPassword] = useState('');

    const [data, setData] = useState([]);

    useEffect(()=>{
        getData();
    },[])

    const getData = () => {
        axios.get('https://localhost:7002/api/Customers')
        .then((result) => {
            setData(result.data)
        })
        .catch((error) => {
            console.log(error)
        })
    }

    const handleEdit = (id) => {
        handleShow();
    }

    const handleDelete = (id) => {
        if(window.confirm("Potwierdz usunięcie") == true)
        {
            alert(id);
        }
    }
    const handleUpdate = (id) => {

    }
    const handleSave = (id) => {
        handleShow();
    }

    return(
        <Fragment>
            <Table striped bordered hover variant="dark">
                <thead>
                    <tr>
                    <th>id</th>
                    <th>name</th>
                    <th>lastName</th>
                    <th>email</th>
                    <th>role</th>
                    <th>login</th>
                    <th>password</th>
                    <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                {
                    data && data.length > 0 ?
                    data.map((item, index) => {
                        return(
                            <tr key={index}>
                                <td>{item.id}</td>
                                <td>{item.name}</td>
                                <td>{item.lastName}</td>
                                <td>{item.email}</td>
                                <td>{item.role}</td>
                                <td>{item.login}</td>
                                <td>{item.password}</td>
                                <td colSpan = {2}>
                                    <button className = "btn btn-primary" onClick = {() => handleEdit(item.id)}>Edit</button>
                                    <button className = "btn btn-primary" onClick = {() => handleDelete(item.id)}>Delete</button>
                                </td>
                            </tr>
                        )
                    })
                    :
                    'Loading'
                }
                </tbody>
            </Table>
            <Modal show={show} onHide={handleClose}>
                <Modal.Header>
                    <Modal.Title>Edycja</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Container>
                        <Row>
                            <Col>
                                <input type="text" className="form-control" placeholder="Imie" 
                                value={editName} onChange = {(e) => setEditName(e.target.value)} />
                            </Col>
                            <Col>
                                <input type="text" className="form-control" placeholder="Nazwisko" 
                                value={editLastName} onChange = {(e) => setEditLastName(e.target.value)} />
                            </Col>
                            <Col>
                                <input type="email" className="form-control" placeholder="E-mail" 
                                value={editEmail} onChange = {(e) => setEditEmail(e.target.value)} />
                            </Col>
                            <Col>
                                <input type="role" className="form-control" placeholder="Role" 
                                value={editRole} onChange = {(e) => setEditRole(e.target.value)} />
                            </Col>
                            <Col>
                                <input type="text" className="form-control" placeholder="Login" 
                                value={editLogin} onChange = {(e) => setEditLogin(e.target.value)}/>
                            </Col>
                            <Col>
                                <input type="password" className="form-control" placeholder="Hasło"
                                onChange = {(e) => setEditPassword(e.target.value)} />
                            </Col>
                        </Row>
                    </Container>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant = "secondary" onClick = {handleClose}>
                        Close
                    </Button>
                    <Button variant = "primary" onClick = {handleUpdate}>
                        Save changes
                    </Button>
                </Modal.Footer>
            </Modal>
        </Fragment>
    )
}


export default CRUD;