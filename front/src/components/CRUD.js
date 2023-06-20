import React, {useState, useEffect, Fragment} from "react";
import Table from 'react-bootstrap/Table';

const CRUD = () => {

    const cusdata = [
        {
            id : 1,
            name : "Dupa",
            lastname : "Dupa",
            email : "dupna",
            login : "dupno",
            password : "123"
        },
        {
            id : 2,
            name : "asd",
            lastname : "dsa",
            email : "dusdapna",
            login : "dupdsno",
            password : "1234"
        }
    ]

    const [data, setData] = useEffect([]);

    useEffect(()=>{
        setData(cusdata);
    },[])

    return(
        <Fragment>
             <Table striped bordered hover>
      <thead>
        <tr>
          <th>#</th>
          <th>id</th>
          <th>namee</th>
          <th>lastname</th>
          <th>email</th>
          <th>login</th>
          <th>password</th>
        </tr>
      </thead>
      <tbody>
        {
            data && data.length > 0 ?
            data.map((item, index) => {
                return(
                    <tr key={index}>
                        <td>{index+ 1}</td>
                        <td>{item.id}</td>
                        <td>{item.name}</td>
                        <td>{item.lastname}</td>
                        <td>{item.email}</td>
                        <td>{item.login}</td>
                        <td>{item.password}</td>
                    </tr>
                )
            })
            :
            'Loading'
        }
      </tbody>
    </Table>
        </Fragment>
    )
}


export default CRUD;