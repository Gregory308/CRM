import './App.css';
import Layout from './components/Layout';
import Login from './components/Login';
import Register from './components/Register';
import LinkPage from './components/LinkPage';
import Editor from './components/Editor';
import Admin from './components/Admin';
import Home from './components/Home';
import Unauthorized from './components/Unauthorized';
import { Routes, Route } from 'react-router-dom';
import RequireAuth from './components/RequireAuth';
import ShowUsers from './components/ShowUsers';
import ShowNotifications from './components/ShowNotifications';
import AddNotification from './components/AddNotification';
import MyNotification from './components/MyNotifications';

function App() {
  return (
    <Routes>
      <Route path = "/" element = {<Layout />}>

        {/* Publiczny dostep  */}
        <Route path="login" element={<Login />} />
        <Route path="showUsers" element={<ShowUsers />} />
        <Route path="linkpage" element={<LinkPage />} />
        <Route path="register" element={<Register />} />
        <Route path="showNotifications" element={<ShowNotifications />} />
        <Route path="addNotification" element={<AddNotification />} />
        <Route path="myNotification" element={<MyNotification />} />
        <Route path="unauthorized" element={<Unauthorized />} />
        <Route path="/" element={<Home />} />

        {/* Prywatny dostep  
        <Route element = {<RequireAuth allowedRoles={'employee'}/>} >
          
        </Route>*/}
        <Route element = {<RequireAuth allowedRoles={"admin"}/>} >
          <Route path="admin" element={<Admin />} />
        </Route>
        <Route element = {<RequireAuth allowedRoles={"admin"}/>} >
          <Route path="register" element={<Register />} />
        </Route>
        <Route element={<RequireAuth allowedRoles={"admin"} />}>
          <Route path="editor" element={<Editor />} />
        </Route>

      </Route>
    </Routes>
  );
}

export default App;
