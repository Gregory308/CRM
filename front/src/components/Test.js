import React, {useState,submit,} from "react";
import { CreateApiEndpoint } from "../api";
import Table from 'react-bootstrap/Table';



export default function Test(){
    function fetchData() {
        fetch('https://localhost:7002/api/Customers')
          .then(response => response.json())
          .then(data => {
            console.log(data); // Wyświetl odpowiedź w logach
          })
          .catch(error => {
            console.error('Błąd:', error);
          });
          return;
      }
      //fetchData();
      
      
      async function postJSON(data) {
        try {
          const response = await fetch("https://localhost:7002/api/Customers", {
            method: "POST", // or 'PUT'
            headers: {
              "Content-Type": "application/json",
            },
            body: JSON.stringify(data),
          });
      
          const result = await response.json();
          console.log("Success:", result);
        } catch (error) {
          console.error("Error:", error);
        }
    }
    const CustomerForm = props => {
        const [customer, setCustomer] = useState(props.customer)
    
        return (
          <>
          <p>dupa</p>
          <form onSubmit={submit}>
            <input
              type="text"
              name="customer[name]"
              value={customer.name}
              onChange={e => setCustomer({ ...customer, name: e.target.value })}
            />

            <input
              type="text"
              name="customer[lastName]"
              value={customer.lastName}
              onChange={e => setCustomer({ ...customer, lastName: e.target.value })}
            />
      
            <input
              type="text"
              name="customer[email]"
              value={customer.email}
              onChange={e => setCustomer({ ...customer, email: e.target.value })}
            />

            <input
              type="text"
              name="customer[login]"
              value={customer.login}
              onChange={e => setCustomer({ ...customer, login: e.target.value })}
            />

            <input
              type="text"
              name="customer[password]"
              value={customer.password}
              onChange={e => setCustomer({ ...customer, password: e.target.value })}
            />
      
            <input type="submit" name="Sign Up" />
          </form>
          </>

        )
    }
      
      /*const data = { name: "chuy",
      lastName: "chuy",
      email: "chuy",
      login: "chuy",
      password: "chuy" };
      //postJSON(data);*/

      /*return (
        <div>{CustomerForm}</div>
        //<button onClick={() => postJSON(data)}>Dupa</button>

        //onClick={() => this.props.addCharacterById(character.id)}
      )*/
      //return <div>{CustomerForm}</div>;

    
}